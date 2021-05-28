using System;
using System.Collections.Generic;

namespace Task_1
{
    /// <summary>
    /// Class for comparing integer remainders of the division by 5.
    /// </summary>
    public class Mod5Comparer : IComparer<int>
    {
        /// <summary>
        /// Returns the difference between first number remainder and second number remainder.
        /// </summary>
        /// <param name="x">First number.</param>
        /// <param name="y">Second number.</param>
        /// <returns></returns>
        public int Compare(int x, int y)
            => x % 5 - y % 5;
    }
}