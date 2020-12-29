using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessTimeBenchmarking.Benchmarks
{
    public class ArraySortBenchmark
    {
        private ArrayTests<long> tests;

        [GlobalSetup]
        public void Setup()
        {
            tests = new ArrayTests<long>(1_000_0);
            tests.Init();
        }
        [Benchmark]
        public void BubbleSort()
        {
            tests.BubbleSort();
        }
    }
}
