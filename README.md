| Method        | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0      | Allocated   | Alloc Ratio |
|-------------- |----------:|----------:|----------:|------:|--------:|----------:|------------:|------------:|
| SplitTotal    | 29.491 ms | 0.5854 ms | 1.3912 ms |  1.00 |    0.07 | 5312.5000 | 100806328 B |        1.00 |
| SpanTotal     | 19.633 ms | 0.3901 ms | 0.5208 ms |  0.67 |    0.04 | 1468.7500 |  28007120 B |        0.28 |
| Utf8SpanTotal |  3.364 ms | 0.0464 ms | 0.0434 ms |  0.11 |    0.01 |         - |           - |        0.00 |

ReadOnlySpan<T> is just a tiny stack-allocated struct that holds a pointer to the first element of some existing memory plus a length — nothing more. When you “slice” it (span = span[start..end]) you’re not copying bytes or chars; the compiler merely creates a new span whose pointer is moved forward and whose length is adjusted. Because the underlying buffer (a string, byte[], or memory-mapped file) stays put and spans themselves live only on the stack, every slice is a zero-cost, zero-allocation view into the same data. That’s why the UTF-8 parser produces no garbage collections even while carving millions of columns and lines—it’s all pointer arithmetic, not memory allocation.
