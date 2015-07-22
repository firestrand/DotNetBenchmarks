using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBenchmarks
{
    /// <summary>
    /// The purpose of this benchmark is to determine if when creating a key to store a multidimensional int point
    /// it is better to call GetHashCode on the array, or use array bounds to create a unique value similar to
    /// flattening the value similar to when storing a multidimensional array in a single dimension array
    /// </summary>
    public static class IndexKeyHashKeyBenchmark
    {
        public static void Execute(int count = 10000000)
        {
            double controlTotalSeconds;
            int key;

            Console.WriteLine();
            Console.WriteLine("***************************");
            Console.WriteLine("Index Key Hash Key Benchmark");
            Console.WriteLine("***************************");
            Console.WriteLine();

            //Setup Values
            var indexList = new List<int[]>();
            int[] xMin = { 0, 0, 0 };
            int[] xMax = { 3, 3, 3 };
            int[] x = xMin.CloneFast(); //Initialize to Min
            bool complete = false;
            while (!complete)
            {
                indexList.Add(x.CloneFast());
                for (int j = 0; j < x.Length; j++)
                {
                    x[j] += 1;
                    if (x[j] < xMax[j])
                    {
                        break;
                    }
                    if (j == x.Length - 1)
                    {
                        complete = true;
                    }
                    x[j] = xMin[j];
                }
            }

            var offsets = new int[xMin.Length];
            for (int i = 0; i < xMin.Length; i++)
            {
                offsets[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    offsets[i] *= xMax[i] - xMin[i];
                }
            }

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (var i = 0; i < count; i++)
            {
                // do nothing
            }
            stopwatch.Stop();
            controlTotalSeconds = stopwatch.Elapsed.TotalSeconds;
            Console.WriteLine("Control - Empty Loop - " + controlTotalSeconds + " seconds");

            Console.WriteLine();

            stopwatch.Restart();
            for (int i = 0; i < count; i++)
            {
                foreach (var index in indexList)
                {
                    key = index.GetHashCode();
                }
            }
            stopwatch.Stop();
            Console.WriteLine("Hash Key - " + stopwatch.Elapsed.TotalSeconds + " seconds");
            Console.WriteLine("Relative: " + (stopwatch.Elapsed.TotalSeconds - controlTotalSeconds) + " seconds");

            Console.WriteLine();
            stopwatch.Restart();
            for (int i = 0; i < count; i++)
            {
                foreach (var index in indexList)
                {
                    key = To1DFromND(index,offsets);
                }
            }
            stopwatch.Stop();
            Console.WriteLine("Int Index Key - " + stopwatch.Elapsed.TotalSeconds + " seconds");
            Console.WriteLine("Relative: " + (stopwatch.Elapsed.TotalSeconds - controlTotalSeconds) + " seconds");


        }
        public static int To1DFromND(int[] indices, int[] offsets)
        {
            int index = 0;
            for (var i = 0; i < indices.Length; i++)
            {
                index += indices[i] * offsets[i];
            }
            return index;
        }
    }
}
