using System;
using System.IO;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace QuickSortBenchMarks
{
    [RankColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]
    public class FilterCodeBlocksBenchmarks
    {
        FilterCodeBlocks FilterCodeBlocks = new FilterCodeBlocks();
        public static string s = "<p>我们通过IndexWriterConfig 可以设置IndexWriter的属性，" +
                            "已达到我们希望构建索引的需求，这里举一些属性，这些属性可以影响到IndexWriter写入索引的速度：" +
                            "</p>\n<div class=\"cnblogs_code\">\n<pre>IndexWriterConfig.setRAMBufferSizeMB" +
                            "(<span style=\"color: #0000ff;\">double</span><span style=\"color: #000000;\">);" +
                            "\nIndexWriterConfig.setMaxBufferedDocs(</span><span style=\"color: #0000ff;\">int</span><span " +
                            "style=\"color: #000000;\">);\nIndexWriterConfig.setMergePolicy(MergePolicy)</span></pre>\n</div>\n<p>" +
                            "setRAMBufferSizeMB()&nbsp;是设置";

        public FilterCodeBlocksBenchmarks()
        {
            s = "";
            using (var reader = new StreamReader("/Users/xiaokang/Projects/QuickSortBenchMarks/QuickSortBenchMarks/text.txt"))
            {
                var s3 = "";
                while ((s3 = reader.ReadLine()) != null)
                {
                    s += s3;
                }
            }
        }

        [Benchmark]
        public void FilterByString()
        {

            FilterCodeBlocks.FilterCodeBlockByString(s);
        }
        [Benchmark]
        public void FilterByRegex()
        {
            FilterCodeBlocks.FilterCodeBlocByRegex(s);
        }

        [Benchmark]
        public void FilterBySpanAndToString()
        {
            FilterCodeBlocks.FilterCodeBlockBySpanAndToString(s);
        }

        [Benchmark]
        public void FilterBySpanAndStringBuilder()
        {
            FilterCodeBlocks.FilterCodeBlockBySpanAndStringBuilder(s);
        }

        [Benchmark]
        public void FilterBySpanAndValueStringBuilder()
        {
            FilterCodeBlocks.FilterCodeBlockBySpanAndValueStringBuilder(s);
        }

        [Benchmark]
        public void FilterBySpanAndMemoryChar()
        {
            FilterCodeBlocks.FilterCodeBlockBySpanAndMemoryChar(s);
        }

        [Benchmark]
        public void FilterBySpanAndStringSpan()
        {
            FilterCodeBlocks.FilterCodeBlockBySpanAndStringSpan(s);
        }

    }
}
