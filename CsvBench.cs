using BenchmarkDotNet.Attributes;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogPerf;

[MemoryDiagnoser]
public class CsvBench
{
    private static readonly string _file = Path.Combine(AppContext.BaseDirectory, "data.csv");
    private static readonly byte[] _fileBytes = File.ReadAllBytes(Path.Combine(AppContext.BaseDirectory, "data.csv"));

    [Benchmark(Baseline = true)]
    public int SplitTotal()
    {
        int sum = 0;
        foreach (var line in File.ReadLines(_file, Encoding.UTF8))
            sum += int.Parse(line.Split(',')[3]);
        return sum;
    }

    [Benchmark]
    public int SpanTotal()
    {
        int sum = 0;
        foreach (var str in File.ReadLines(_file, Encoding.UTF8))
        {
            ReadOnlySpan<char> line = str;
            for (int i = 0; i < 3; i++)
                line = line[(line.IndexOf(',') + 1)..];

            int val = 0;
            foreach (char c in line)
                val = val * 10 + (c - '0');

            sum += val;
        }
        return sum;
    }

    [Benchmark]
    public int Utf8SpanTotal()
    {
        ReadOnlySpan<byte> data = _fileBytes;
        int sum = 0;

        while (!data.IsEmpty)
        {
            int lineEnd = data.IndexOf((byte)'\n');
            ReadOnlySpan<byte> line = lineEnd >= 0 ? data[..lineEnd] : data;
            data = lineEnd >= 0 ? data[(lineEnd + 1)..] : ReadOnlySpan<byte>.Empty;

            for (int i = 0; i < 3; i++)
            {
                int comma = line.IndexOf((byte)',');
                line = line[(comma + 1)..];
            }

            Utf8Parser.TryParse(line, out int salary, out _);
            sum += salary;
        }

        return sum; 
    }
}
