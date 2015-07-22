using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBenchmarks
{
    public static class MinMaxBenchmark
    {
        public static void Execute(int count = 1000000000)
        {
            var num1 = 10.0;
            var num2 = 100.0;
            var value = 0.0;

            var intNum1 = 10;
            var intNum2 = 100;
            var intValue = 0;

            double controlTotalSeconds;

            Console.WriteLine();
            Console.WriteLine("***************************");
            Console.WriteLine("Min Max Benchmark");
            Console.WriteLine("***************************");
            Console.WriteLine();

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
            Console.WriteLine("***************************");
            Console.WriteLine("Double Min Max Benchmark");
            Console.WriteLine("***************************");
            Console.WriteLine();

            stopwatch.Restart();
            for (int i = 0; i < count; i++)
            {
                value = Math.Max(num1, num2);
            }
            stopwatch.Stop();
            Console.WriteLine("Math.Max() - " + stopwatch.Elapsed.TotalSeconds + " seconds");
            Console.WriteLine("Relative: " + (stopwatch.Elapsed.TotalSeconds - controlTotalSeconds) + " seconds");

            Console.WriteLine();

            stopwatch.Restart();
            for (int i = 0; i < count; i++)
            {
                value = num1 > num2 ? num1 : num2;
            }
            stopwatch.Stop();
            Console.WriteLine("Inline Max: " + stopwatch.Elapsed.TotalSeconds + " seconds");
            Console.WriteLine("Relative: " + (stopwatch.Elapsed.TotalSeconds - controlTotalSeconds) + " seconds");

            Console.WriteLine();

            stopwatch.Restart();
            for (int i = 0; i < count; i++)
            {
                value = Math.Min(num1, num2);
            }
            stopwatch.Stop();
            Console.WriteLine("Math.Min() - " + stopwatch.Elapsed.TotalSeconds + " seconds");
            Console.WriteLine("Relative: " + (stopwatch.Elapsed.TotalSeconds - controlTotalSeconds) + " seconds");

            Console.WriteLine();

            stopwatch.Restart();
            for (int i = 0; i < count; i++)
            {
                value = num1 < num2 ? num1 : num2;
            }
            stopwatch.Stop();
            Console.WriteLine("Inline Min: " + stopwatch.Elapsed.TotalSeconds + " seconds");
            Console.WriteLine("Relative: " + (stopwatch.Elapsed.TotalSeconds - controlTotalSeconds) + " seconds");


            Console.WriteLine();
            Console.WriteLine("***************************");
            Console.WriteLine("Int Min Max Benchmark");
            Console.WriteLine("***************************");
            Console.WriteLine();

            stopwatch.Restart();
            for (int i = 0; i < count; i++)
            {
                intValue = Math.Max(intNum1, intNum2);
            }
            stopwatch.Stop();
            Console.WriteLine("int Math.Max() - " + stopwatch.Elapsed.TotalSeconds + " seconds");
            Console.WriteLine("Relative: " + (stopwatch.Elapsed.TotalSeconds - controlTotalSeconds) + " seconds");

            Console.WriteLine();

            stopwatch.Restart();
            for (int i = 0; i < count; i++)
            {
                intValue = intNum1 > intNum2 ? intNum1 : intNum2;
            }
            stopwatch.Stop();
            Console.WriteLine("int Inline Max: " + stopwatch.Elapsed.TotalSeconds + " seconds");
            Console.WriteLine("Relative: " + (stopwatch.Elapsed.TotalSeconds - controlTotalSeconds) + " seconds");

            Console.WriteLine();

            stopwatch.Restart();
            for (int i = 0; i < count; i++)
            {
                intValue = Math.Min(intNum1, intNum2);
            }
            stopwatch.Stop();
            Console.WriteLine("int Math.Min() - " + stopwatch.Elapsed.TotalSeconds + " seconds");
            Console.WriteLine("Relative: " + (stopwatch.Elapsed.TotalSeconds - controlTotalSeconds) + " seconds");

            Console.WriteLine();
            stopwatch.Restart();
            for (int i = 0; i < count; i++)
            {
                intValue = intNum1 < intNum2 ? intNum1 : intNum2;
            }
            stopwatch.Stop();
            Console.WriteLine("int Inline Min: " + stopwatch.Elapsed.TotalSeconds + " seconds");
            Console.WriteLine("Relative: " + (stopwatch.Elapsed.TotalSeconds - controlTotalSeconds) + " seconds");

        }
    }
}
