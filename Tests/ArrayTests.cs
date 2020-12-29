using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using ProcessTimeBenchmarking.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ProcessTimeBenchmarking
{
    public class ArrayTests<T> where T : IComparable
    {
        private T[] array;
        public ArrayTests(int length)
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
        public void BenchmarkLinqForEach()
        {
            List<T> list = new List<T>();
            array.ToList().ForEach((_) => list.Add(_));
        }
        public void BenchmarkForeach()
        {
            List<T> list = new List<T>();
            foreach (var element in array)
                list.Add(element);
        }
        public void BenchmarkFor()
        {
            List<T> list = new List<T>();
            for (int j = 0; j < array.Length; j++)
                list.Add(array[j]);
        }
        public void BenchmarkArrayCopy()
        {
            T[] copyArray = new T[array.Length];
            Array.Copy(array, copyArray, array.Length);
        }
        public void BenchmarkCopyTo()
        {
            T[] copyArray = new T[array.Length];
            array.CopyTo(copyArray, 0);
        }
        public void BenchmarkBlockCopy()
        {
            T[] copyArray = new T[array.Length];
            Buffer.BlockCopy(array, 0, copyArray, 0, array.Length);
        }
        public unsafe void BenchmarkMemoryCopy()
        {
        }

        public void BubbleSort()
        {
            T[] arr = (T[])array.Clone();
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[i].CompareTo(arr[j]) <= 0)
                    {
                        T temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }
    }
}
