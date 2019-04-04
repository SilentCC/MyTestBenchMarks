using System;
using System.IO;
using BenchmarkDotNet.Running;

namespace QuickSortBenchMarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<FilterCodeBlocksBenchmarks>();

        }
    }
}
