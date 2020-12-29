using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace ProcessTimeBenchmarking.Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class SpanBenchmark
    {
        private SpanTests<long> tests;

        [GlobalSetup]
        public void Setup()
        {
            tests = new SpanTests<long>(1_000_000);
            tests.Init();
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
        public void CopyTo()
        {
            tests.BenchmarkCopyTo();
        }
    }
}
