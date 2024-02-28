using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.Math
{
    internal static class Helper
    {
        internal static void Swap<T>(ref T first, ref T second)
        {
            T bufer  = first;
            first = second;
            second = bufer;
        }
    }
}
