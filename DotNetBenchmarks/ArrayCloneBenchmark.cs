using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBenchmarks
{
    /// <summary>
    /// Adapted from https://social.msdn.microsoft.com/Forums/en-US/42189513-2106-4467-af9a-3b1810509cc8/fastest-way-to-clone-an-array-of-ints?forum=csharplanguage
    /// </summary>
    public static class ArrayCloneBenchmark
    {
        public static void Execute(int count = 100)
        {
            double controlTotalSeconds;
            int[] one = new int[1000];
            SetArrayValues(one);
            int[] two = null;

            Console.WriteLine();
            Console.WriteLine("***************************");
            Console.WriteLine("Small Int Array Clone Benchmark");
            Console.WriteLine("***************************");
            Console.WriteLine();

            var stopwatch = new Stopwatch();

            stopwatch.Restart();
            for (var i = 0; i < count * 40000; i++)
            {
                two = CloneObject(one);
            }
            stopwatch.Stop();
            controlTotalSeconds = stopwatch.Elapsed.TotalSeconds;
            Console.WriteLine("Clone Object - " + controlTotalSeconds + " seconds");

            Console.WriteLine();

            stopwatch.Restart();
            for (var i = 0; i < count * 40000; i++)
            {
                two = CloneArrayCopy(one);
            }
            stopwatch.Stop();
            controlTotalSeconds = stopwatch.Elapsed.TotalSeconds;
            Console.WriteLine("Clone Array Copy - " + controlTotalSeconds + " seconds");

            Console.WriteLine();

            stopwatch.Restart();
            for (var i = 0; i < count * 40000; i++)
            {
                two = CloneElementCopy(one);
            }
            stopwatch.Stop();
            controlTotalSeconds = stopwatch.Elapsed.TotalSeconds;
            Console.WriteLine("Clone Element Copy - " + controlTotalSeconds + " seconds");

            Console.WriteLine();

            stopwatch.Restart();
            for (var i = 0; i < count * 40000; i++)
            {
                two = CloneBlockCopy(one);
            }
            stopwatch.Stop();
            controlTotalSeconds = stopwatch.Elapsed.TotalSeconds;
            Console.WriteLine("Clone Block Copy - " + controlTotalSeconds + " seconds");

            Console.WriteLine();
            Console.WriteLine("***************************");
            Console.WriteLine("Large  Array Clone Benchmark");
            Console.WriteLine("***************************");
            Console.WriteLine();

            one = new int[10000000];
            SetArrayValues(one);

            stopwatch.Restart();
            for (var i = 0; i < count; i++)
            {
                two = CloneObject(one);
            }
            stopwatch.Stop();
            controlTotalSeconds = stopwatch.Elapsed.TotalSeconds;
            Console.WriteLine("Clone Object - " + controlTotalSeconds + " seconds");

            Console.WriteLine();

            stopwatch.Restart();
            for (var i = 0; i < count; i++)
            {
                two = CloneArrayCopy(one);
            }
            stopwatch.Stop();
            controlTotalSeconds = stopwatch.Elapsed.TotalSeconds;
            Console.WriteLine("Clone Array Copy - " + controlTotalSeconds + " seconds");

            Console.WriteLine();

            stopwatch.Restart();
            for (var i = 0; i < count; i++)
            {
                two = CloneElementCopy(one);
            }
            stopwatch.Stop();
            controlTotalSeconds = stopwatch.Elapsed.TotalSeconds;
            Console.WriteLine("Clone Element Copy - " + controlTotalSeconds + " seconds");

            Console.WriteLine();

            stopwatch.Restart();
            for (var i = 0; i < count; i++)
            {
                two = CloneBlockCopy(one);
            }
            stopwatch.Stop();
            controlTotalSeconds = stopwatch.Elapsed.TotalSeconds;
            Console.WriteLine("Clone Block Copy - " + controlTotalSeconds + " seconds");
        }

        static void SetArrayValues(int[] one)
        {
            for (int i = 0; i < one.Length; i++)
            {
                one[i] = i;
            }
        }
        static int[] CloneObject(int[] array)
        {
            return (int[])array.Clone();
        }

        static int[] CloneElementCopy(int[] array)
        {
            var result = new int[array.Length];
            for (int i = 0; i < result.Length; ++i)
            {
                result[i] = array[i];
            }
            return result;
        }

        static int[] CloneArrayCopy(int[] array)
        {
            var result = new int[array.Length];
            Array.Copy(array, result, array.Length);
            return result;
        }

        static int[] CloneBlockCopy(int[] array)
        {
            var result = new int[array.Length];
            Buffer.BlockCopy(array, 0, result, 0, array.Length * sizeof(int));
            return result;
        }
    }
}
