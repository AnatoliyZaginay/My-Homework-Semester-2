using System;
using System.Collections.Generic;

namespace Task_1
{
    /// <summary>
    /// Class for comparing integers.
    /// </summary>
    public class IntComparer : IComparer<int>
    {
        /// <summary>
        /// Returns the difference between first number and second number.
        /// </summary>
        /// <param name="x">First number.</param>
        /// <param name="y">Second number.</param>
        public int Compare(int x, int y)
            => x - y;
    }
}