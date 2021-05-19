using System;
using System.IO;

namespace Task_2.Tests
{
    /// <summary>
    /// Static class that compares files.
    /// </summary>
    public static class FileComparator
    {
        /// <summary>
        /// Checks if the files are equal.
        /// </summary>
        /// <param name="firstPath">Path to the first file.</param>
        /// <param name="secondPath">Path to the second file.</param>
        public static bool FilesAreEqual(string firstPath, string secondPath)
        {
            var firstFileLines = File.ReadAllLines(firstPath);
            var secondFileLines = File.ReadAllLines(secondPath);

            if (firstFileLines.Length != secondFileLines.Length)
            {
                return false;
            }

            for (int i = 0; i < firstFileLines.Length; ++i)
            {
                if (firstFileLines[i] != secondFileLines[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}