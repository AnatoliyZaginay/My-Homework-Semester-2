using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    /// <summary>
    /// Class for comparing lengths of strings.
    /// </summary>
    public class StringLengthComparer : IComparer<string>
    {
        /// <summary>
        /// Returns the difference between first string length and second string length
        /// </summary>
        /// <param name="x">First string.</param>
        /// <param name="y">Second string.</param>
        /// <returns></returns>
        public int Compare(string x, string y)
            => x.Length - y.Length;
    }
}