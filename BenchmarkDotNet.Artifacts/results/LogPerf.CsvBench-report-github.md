```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.26100.4652/24H2/2024Update/HudsonValley)
Unknown processor
.NET SDK 9.0.301
  [Host]     : .NET 9.0.6 (9.0.625.26613), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.6 (9.0.625.26613), X64 RyuJIT AVX2


```
| Method        | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0      | Allocated   | Alloc Ratio |
|-------------- |----------:|----------:|----------:|------:|--------:|----------:|------------:|------------:|
| SplitTotal    | 29.491 ms | 0.5854 ms | 1.3912 ms |  1.00 |    0.07 | 5312.5000 | 100806328 B |        1.00 |
| SpanTotal     | 19.633 ms | 0.3901 ms | 0.5208 ms |  0.67 |    0.04 | 1468.7500 |  28007120 B |        0.28 |
| Utf8SpanTotal |  3.364 ms | 0.0464 ms | 0.0434 ms |  0.11 |    0.01 |         - |           - |        0.00 |
