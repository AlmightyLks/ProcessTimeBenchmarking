using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace ProcessTimeBenchmarking.Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class ArrayCopyingBenchmark
    {
        private ArrayTests<long> tests;

        [GlobalSetup]
        public void Setup()
        {
            tests = new ArrayTests<long>(1_000_000);
            tests.Init();
        }

        [Benchmark]
        public void LinqForEach()
        {
            tests.BenchmarkLinqForEach();
        }
        [Benchmark]
        public void Foreach()
        {
            tests.BenchmarkForeach();
        }
        [Benchmark]
        public void For()
        {
            tests.BenchmarkFor();
        }
        [Benchmark]
        public void ArrayCopy()
        {
            tests.BenchmarkArrayCopy();
        }
        [Benchmark]
        public void CopyTo()
        {
            tests.BenchmarkCopyTo();
        }
        [Benchmark]
        public void BlockCopy()
        {
            tests.BenchmarkBlockCopy();
        }
        [Benchmark]
        public void BubbleSort()
        {
            tests.BubbleSort();
        }
    }
}
