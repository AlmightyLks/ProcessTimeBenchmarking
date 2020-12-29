using BenchmarkDotNet.Running;
using ProcessTimeBenchmarking.Benchmarks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProcessTimeBenchmarking
{
    public class Program
    {
        static void Main(string[] args)
        {
            //BenchmarkRunner.Run<ArrayBenchmark>();
            //BenchmarkRunner.Run<SpanBenchmark>();
            //BenchmarkRunner.Run<StringBenchmark>();
            //BenchmarkRunner.Run<ArraySortBenchmark>();
            var smth = new ArraySortBenchmark();
            smth.Setup();
            smth.BubbleSort();
        }
    }
}
