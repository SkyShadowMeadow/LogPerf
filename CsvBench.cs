using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogPerf;

[MemoryDiagnoser]
public class CsvBench
{
    private static readonly string _file = Path.Combine(AppContext.BaseDirectory, "data.csv");

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
}
