using System;
using System.Collections.Generic;

namespace Task_1
{
    /// <summary>
    /// Static class for compressing and decompressing byte arrays.
    /// </summary>
    public static class RLE
    {
        /// <summary>
        /// Compresses byte array.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <returns>Returns compressed byte array.</returns>
        public static byte[] Compress(byte[] source)
        {
            if (source == null)
            {
                throw new ArgumentException();
            }

            var count = 1;
            var result = new List<byte>();

            for (int i = 0; i < source.Length; ++i)
            {
                if (i < source.Length - 1 && source[i] == source[i + 1] && count < 255)
                {
                    ++count;
                }
                else
                {
                    result.Add((byte)count);
                    result.Add(source[i]);
                    count = 1;
                }
            }

            return result.ToArray();
        }

        /// <summary>
        /// Decompresses byte array.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <returns>Returns decompressed byte array.</returns>
        public static byte[] Decompress(byte[] source)
        {
            if (source == null || source.Length % 2 > 0)
            {
                throw new ArgumentException();
            }

            var result = new List<byte>();

            for (int i = 0; i < source.Length; i += 2)
            {
                for (int j = 0; j < source[i]; ++j)
                {
                    result.Add(source[i + 1]);
                }
            }

            return result.ToArray();
        }
    }
}