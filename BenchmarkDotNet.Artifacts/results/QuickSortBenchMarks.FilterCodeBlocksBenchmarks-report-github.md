``` ini

BenchmarkDotNet=v0.11.3, OS=macOS Mojave 10.14.3 (18D109) [Darwin 18.2.0]
Intel Core i7-4870HQ CPU 2.50GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.100-preview3-009430
  [Host]     : .NET Core 2.2.0-preview3-27014-02 (CoreCLR 4.6.27014.03, CoreFX 4.6.27014.02), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.0-preview3-27014-02 (CoreCLR 4.6.27014.03, CoreFX 4.6.27014.02), 64bit RyuJIT


```
|                    Method |        Mean |       Error |      StdDev | Rank | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|-------------------------- |------------:|------------:|------------:|-----:|------------:|------------:|------------:|--------------------:|
|   FilterBySpanAndToString |    367.5 ns |   1.4204 ns |   1.3287 ns |    1 |      0.1016 |           - |           - |               640 B |
|  FilterBySpanAndToString2 |    397.5 ns |   0.8286 ns |   0.7345 ns |    2 |      0.0987 |           - |           - |               624 B |
| FilterBySpanAndMemoryChar |    404.8 ns |   1.1492 ns |   0.9596 ns |    3 |      0.0482 |           - |           - |               304 B |
| FilterBySpanAndStringSpan |    405.9 ns |   1.3555 ns |   1.2679 ns |    3 |      0.0482 |           - |           - |               304 B |
|            FilterByString | 41,343.1 ns | 280.6476 ns | 262.5180 ns |    4 |      0.1831 |           - |           - |              1392 B |
