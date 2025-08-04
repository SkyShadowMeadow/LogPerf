```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.26100.4652/24H2/2024Update/HudsonValley)
Unknown processor
.NET SDK 9.0.301
  [Host]     : .NET 9.0.6 (9.0.625.26613), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.6 (9.0.625.26613), X64 RyuJIT AVX2


```
| Method     | Mean              | Error          | StdDev         | Gen0   | Allocated |
|----------- |------------------:|---------------:|---------------:|-------:|----------:|
| SplitName  |         42.646 ns |      0.4367 ns |      1.0629 ns | 0.0127 |     240 B |
| SpanName   |          4.406 ns |      0.0871 ns |      0.0815 ns |      - |         - |
| SpanSalary |          8.046 ns |      0.1306 ns |      0.1221 ns |      - |         - |
| Pause      | 15,539,135.714 ns | 62,579.9748 ns | 55,475.5177 ns |      - |         - |
