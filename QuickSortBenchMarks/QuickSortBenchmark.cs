using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace QuickSortBenchMarks
{
    [RankColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]
    public class QuickSortBenchmark
    {
        private QuickSort quickSort = new QuickSort();
        public QuickSortBenchmark()
        {
        }

        [Benchmark(Baseline = true)]
        public void Sort()
        {
            quickSort.QuickSortOriginal(0, quickSort.array.Length-1);
        }
    }
}
