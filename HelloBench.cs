using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogPerf;

[MemoryDiagnoser]
public class HelloBench
{
    private const string _row = "1991-09-23,Catherine Semiletova,Aeroport,70000";

    [Benchmark]
    public string SplitName() => GetFieldSplit(_row, 1);

    [Benchmark]
    public char SpanName() => GetFieldSpan(_row, 1)[0];

    [Benchmark]
    public int SpanSalary() => GetSalary(_row);

    [Benchmark]
    public void Pause() => Thread.Sleep(10);

    private static string GetFieldSplit(string line, int column)
        => line.Split(',')[column];

    private static ReadOnlySpan<char> GetFieldSpan(ReadOnlySpan<char> line, int column)
    {
        for (int i = 0; i < column; i++)
            line = line[(line.IndexOf(',') + 1)..];
        int next = line.IndexOf(',');
        return next == -1 ? line : line[..next];
    }

    private static int GetSalary(ReadOnlySpan<char> line)
    {
        for (int i = 0; i < 3; i++)
            line = line[(line.IndexOf(',') + 1)..];

        int value = 0;
        foreach (char c in line)
            value = value * 10 + (c - '0');
        return value;
    }
}
