```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.26100.4652/24H2/2024Update/HudsonValley)
Unknown processor
.NET SDK 9.0.301
  [Host]     : .NET 9.0.6 (9.0.625.26613), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.6 (9.0.625.26613), X64 RyuJIT AVX2


```
| Method    | Mean              | Error          | StdDev         | Gen0   | Allocated |
|---------- |------------------:|---------------:|---------------:|-------:|----------:|
| SplitName |         40.443 ns |      0.8541 ns |      0.7989 ns | 0.0127 |     240 B |
| SpanName  |          4.508 ns |      0.0680 ns |      0.0636 ns |      - |         - |
| Pause     | 15,586,541.875 ns | 39,069.5757 ns | 36,545.7054 ns |      - |         - |
