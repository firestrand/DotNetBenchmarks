using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBenchmarks
{
    public static class Extensions
    {
        public static int[] CloneFast(this int[] array)
        {
            var result = new int[array.Length];
            Buffer.BlockCopy(array, 0, result, 0, array.Length * sizeof(int));
            return result;
        }
    }
}
