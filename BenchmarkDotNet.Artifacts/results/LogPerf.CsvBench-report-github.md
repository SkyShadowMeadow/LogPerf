```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.26100.4652/24H2/2024Update/HudsonValley)
Unknown processor
.NET SDK 9.0.301
  [Host]     : .NET 9.0.6 (9.0.625.26613), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.6 (9.0.625.26613), X64 RyuJIT AVX2


```
| Method     | Mean     | Error    | StdDev   | Ratio | Gen0      | Gen1    | Allocated | Alloc Ratio |
|----------- |---------:|---------:|---------:|------:|----------:|--------:|----------:|------------:|
| SplitTotal | 27.66 ms | 0.308 ms | 0.273 ms |  1.00 | 5343.7500 | 31.2500 |  96.14 MB |        1.00 |
| SpanTotal  | 18.10 ms | 0.329 ms | 0.338 ms |  0.65 | 1468.7500 |       - |  26.71 MB |        0.28 |
