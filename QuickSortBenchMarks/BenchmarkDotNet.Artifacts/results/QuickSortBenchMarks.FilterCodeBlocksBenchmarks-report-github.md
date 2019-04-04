``` ini

BenchmarkDotNet=v0.11.3, OS=macOS Mojave 10.14.3 (18D109) [Darwin 18.2.0]
Intel Core i7-4870HQ CPU 2.50GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.100-preview3-009430
  [Host]     : .NET Core 2.2.0-preview3-27014-02 (CoreCLR 4.6.27014.03, CoreFX 4.6.27014.02), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.0-preview3-27014-02 (CoreCLR 4.6.27014.03, CoreFX 4.6.27014.02), 64bit RyuJIT


```
|                       Method |        Mean |       Error |      StdDev | Rank | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|----------------------------- |------------:|------------:|------------:|-----:|------------:|------------:|------------:|--------------------:|
| FilterBySpanAndStringBuilder |    867.1 us |    12.06 us |    11.28 us |    1 |    385.7422 |    385.7422 |    385.7422 |              1.7 MB |
|      FilterBySpanAndToString | 10,440.6 us |   160.98 us |   150.58 us |    2 |  14968.7500 |  14578.1250 |  14546.8750 |             57.9 MB |
|                FilterByRegex | 10,721.4 us |    78.90 us |    65.88 us |    3 |   1906.2500 |   1750.0000 |   1265.6250 |             7.96 MB |
|               FilterByString | 84,372.7 us | 1,669.69 us | 1,855.85 us |    4 |  63833.3333 |  61333.3333 |  61166.6667 |           253.66 MB |
