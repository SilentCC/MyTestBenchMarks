``` ini

BenchmarkDotNet=v0.11.4, OS=macOS Mojave 10.14.3 (18D109) [Darwin 18.2.0]
Intel Core i7-4870HQ CPU 2.50GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.100-preview3-009430
  [Host]     : .NET Core 2.2.0-preview3-27014-02 (CoreCLR 4.6.27014.03, CoreFX 4.6.27014.02), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.0-preview3-27014-02 (CoreCLR 4.6.27014.03, CoreFX 4.6.27014.02), 64bit RyuJIT


```
| Method |    Mean |    Error |   StdDev | Ratio | Rank | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|------- |--------:|---------:|---------:|------:|-----:|------------:|------------:|------------:|--------------------:|
|   Sort | 3.088 s | 0.0097 s | 0.0086 s |  1.00 |    1 |           - |           - |           - |                   - |
