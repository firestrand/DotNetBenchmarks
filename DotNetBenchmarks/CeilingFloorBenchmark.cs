using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBenchmarks
{
    public static class CeilingFloorBenchmark
    {
        public static void Execute(int count = 1000000000)
        {
            double num1 = 11111.0;
            double num2 = 3.5;
            int value = 0;
            double dValue = 0.0;

            double controlTotalSeconds;

            Console.WriteLine();
            Console.WriteLine("***************************");
            Console.WriteLine("Ceiling and Floor Benchmark");
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
            Console.WriteLine("Int Results");
            Console.WriteLine("***************************");
            Console.WriteLine();

            stopwatch.Restart();
            for (int i = 0; i < count; i++)
            {
                value = (int)Math.Ceiling(num1 / num2);
            }
            stopwatch.Stop();
            Console.WriteLine("Math.Ceiling() - " + stopwatch.Elapsed.TotalSeconds + " seconds");
            Console.WriteLine("Relative: " + (stopwatch.Elapsed.TotalSeconds - controlTotalSeconds) + " seconds");

            Console.WriteLine();
            stopwatch.Restart();
            for (int i = 0; i < count; i++)
            {
                value = (int)(num1 / num2) + 1;
            }
            stopwatch.Stop();
            Console.WriteLine("Inline (int)result + 1: " + stopwatch.Elapsed.TotalSeconds + " seconds");
            Console.WriteLine("Relative: " + (stopwatch.Elapsed.TotalSeconds - controlTotalSeconds) + " seconds");

            Console.WriteLine();

            stopwatch.Restart();
            for (int i = 0; i < count; i++)
            {
                value = (int)Math.Floor(num1 / num2);
            }
            stopwatch.Stop();
            Console.WriteLine("Math.Floor() - " + stopwatch.Elapsed.TotalSeconds + " seconds");
            Console.WriteLine("Relative: " + (stopwatch.Elapsed.TotalSeconds - controlTotalSeconds) + " seconds");

            Console.WriteLine();
            stopwatch.Restart();
            for (int i = 0; i < count; i++)
            {
                value = (int)(num1 / num2);
            }
            stopwatch.Stop();
            Console.WriteLine("Inline (int)result: " + stopwatch.Elapsed.TotalSeconds + " seconds");
            Console.WriteLine("Relative: " + (stopwatch.Elapsed.TotalSeconds - controlTotalSeconds) + " seconds");

            Console.WriteLine();
            Console.WriteLine("***************************");
            Console.WriteLine("Double Results");
            Console.WriteLine("***************************");
            Console.WriteLine();

            stopwatch.Restart();
            for (int i = 0; i < count; i++)
            {
                dValue = Math.Ceiling(num1 / num2);
            }
            stopwatch.Stop();
            Console.WriteLine("Math.Ceiling() - " + stopwatch.Elapsed.TotalSeconds + " seconds");
            Console.WriteLine("Relative: " + (stopwatch.Elapsed.TotalSeconds - controlTotalSeconds) + " seconds");

            Console.WriteLine();
            stopwatch.Restart();
            for (int i = 0; i < count; i++)
            {
                dValue = (int)(num1 / num2) + 1;
            }
            stopwatch.Stop();
            Console.WriteLine("Inline (int)result + 1: " + stopwatch.Elapsed.TotalSeconds + " seconds");
            Console.WriteLine("Relative: " + (stopwatch.Elapsed.TotalSeconds - controlTotalSeconds) + " seconds");

            Console.WriteLine();

            stopwatch.Restart();
            for (int i = 0; i < count; i++)
            {
                dValue = Math.Floor(num1 / num2);
            }
            stopwatch.Stop();
            Console.WriteLine("Math.Floor() - " + stopwatch.Elapsed.TotalSeconds + " seconds");
            Console.WriteLine("Relative: " + (stopwatch.Elapsed.TotalSeconds - controlTotalSeconds) + " seconds");

            Console.WriteLine();
            stopwatch.Restart();
            for (int i = 0; i < count; i++)
            {
                dValue = (int)(num1 / num2);
            }
            stopwatch.Stop();
            Console.WriteLine("Inline (int)result: " + stopwatch.Elapsed.TotalSeconds + " seconds");
            Console.WriteLine("Relative: " + (stopwatch.Elapsed.TotalSeconds - controlTotalSeconds) + " seconds");


        }
    }
}
