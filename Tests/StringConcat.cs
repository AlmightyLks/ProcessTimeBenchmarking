using System.Text;

namespace ProcessTimeBenchmarking.Tests
{
    public class StringConcat
    {
        private int stringLength;

        private StringBuilder benchmarkBuilder;
        private string benchmarkString;

        public StringConcat(int length)
        {
            stringLength = length;
            benchmarkBuilder = new StringBuilder();
            benchmarkString = string.Empty;
        }

        public void StringBuilderBenchmark()
        {
            for (int i = 0; i < stringLength; i++)
                benchmarkBuilder.Append("a");

            benchmarkBuilder = new StringBuilder();
        }
        public void StringBenchmark()
        {
            for (int i = 0; i < stringLength; i++)
                benchmarkString += "a";
            benchmarkString = string.Empty;
        }
    }
}
