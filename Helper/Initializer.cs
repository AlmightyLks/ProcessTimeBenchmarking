using System;

namespace ProcessTimeBenchmarking.Helper
{
    public static class Initializer
    {
        public static long RandomLong(long min, long max, Random rand)
        {
            byte[] buf = new byte[8];
            rand.NextBytes(buf);
            long longRand = BitConverter.ToInt64(buf, 0);

            return Math.Clamp(longRand, min, max);
        }
    }
}
