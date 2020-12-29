using ProcessTimeBenchmarking.Helper;
using System;
using System.Collections.Generic;

namespace ProcessTimeBenchmarking
{
    public class SpanTests<T>
    {
        private T[] array;
        public SpanTests(int length)
        {
            array = new T[length];
        }
        public void Init()
        {
            var rnd = new Random();
            Type genericType = array.GetType().GetElementType();

            if (genericType == typeof(Int32))
            {
                for (int i = 0; i < array.Length; i++)
                    array[i] = (T)(object)rnd.Next(Int32.MinValue, Int32.MaxValue);
            }
            else if (genericType == typeof(Int64))
            {
                for (int i = 0; i < array.Length; i++)
                    array[i] = (T)(object)Initializer.RandomLong(Int64.MinValue, Int64.MaxValue, new Random());
            }


            //if (genericType == typeof(Int16))
            //{
            //    for (int i = 0; i < array.Length; i++)
            //        array[i] = (T)(object)rnd.Next(Int16.MinValue, Int16.MaxValue);
            //}
            //else if (genericType == typeof(Int32))
            //{
            //    for (int i = 0; i < array.Length; i++)
            //        array[i] = (T)(object)rnd.Next(Int32.MinValue, Int32.MaxValue);
            //}
            //else if (genericType == typeof(Int64))
            //{
            //    for (int i = 0; i < array.Length; i++)
            //        array[i] = (T)(object)(rnd.Next(Int32.MinValue, Int32.MaxValue) * 2);
            //}
            //else if (genericType == typeof(UInt16))
            //{
            //    for (int i = 0; i < array.Length; i++)
            //        array[i] = (T)(object)rnd.Next(UInt16.MinValue, UInt16.MaxValue);
            //}
            //else if (genericType == typeof(UInt32))
            //{
            //    for (int i = 0; i < array.Length; i++)
            //        array[i] = (T)(object)(rnd.Next(0, Int32.MaxValue) * 2);
            //}
            //else if (genericType == typeof(UInt64))
            //{
            //    for (int i = 0; i < array.Length; i++)
            //        array[i] = (T)(object)rnd.Next(0, Int32.MaxValue);
            //}
        }
        public void BenchmarkForeach()
        {
            List<T> list = new List<T>();
            foreach (var element in array.AsSpan())
                list.Add(element);
        }
        public void BenchmarkFor()
        {
            List<T> list = new List<T>();
            for (int j = 0; j < array.AsSpan().Length; j++)
                list.Add(array.AsSpan()[j]);
        }
        public void BenchmarkCopyTo()
        {
            T[] copyArray = new T[array.Length];
            array.AsSpan().CopyTo(copyArray);
        }
    }
}
