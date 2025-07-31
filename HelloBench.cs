using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Threading;

BenchmarkRunner.Run<HelloBench>();

[MemoryDiagnoser]
public class HelloBench
{
    private const string _row = "1991-09-23,Catherine Semiletova,Aeroport,70000";

    [Benchmark]
    public string SplitName() => GetFieldSplit(_row, 1);

    [Benchmark]
    public char SpanName() => GetFieldSpan(_row, 1)[0];

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
}