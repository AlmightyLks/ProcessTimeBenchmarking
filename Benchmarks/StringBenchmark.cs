using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using ProcessTimeBenchmarking.Tests;

namespace ProcessTimeBenchmarking.Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class StringBenchmark
    {
        private StringConcat stringConcat;

        [GlobalSetup]
        public void Setup()
        {
            stringConcat = new StringConcat(1_000_00);
        }
        [GlobalCleanup]
        public void Cleanup()
        {
            stringConcat = null;
        }

        public void something()
        {

        }
        [Benchmark]
        public void StringBuilder()
        {
            stringConcat.StringBuilderBenchmark();
        }
        [Benchmark]
        public void String()
        {
            stringConcat.StringBenchmark();
        }
    }
}
