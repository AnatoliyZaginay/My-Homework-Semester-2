using System;
using System.IO;
using System.Collections.Generic;
using static System.Math;

namespace Task_1
{
    /// <summary>
    /// Static class used for compressing and decompressing files using LZW algorithm.
    /// </summary>
    public static class LZW
    {
        /// <summary>
        /// Returns the number of bytes required to store the specified number.
        /// </summary>
        /// <param name="number">Specified number.</param>
        private static int GetCountOfBytes(int number)
            => (int)Ceiling(Log2(number) / 8);

        /// <summary>
        /// Gets byte representation of the pointer code and write it to the file.
        /// </summary>
        /// <param name="trie">The trie where the pointer code is read from.</param>
        /// <param name="file">Specified file.</param>
        private static void WriteByteCode(Trie trie, FileStream file)
        {
            var byteCode = BitConverter.GetBytes(trie.PointerCode);
            Array.Resize(ref byteCode, GetCountOfBytes(trie.CurrentCode + 1));
            file.Write(byteCode);
        }

        /// <summary>
        /// Compresses the specified file and adds the extension ".zipped".
        /// </summary>
        /// <param name="path">Path to the file.</param>
        public static void Compress(string path)
        {
            var trie = new Trie();
            using FileStream sourceFile = File.OpenRead(path);
            var compressedFilePath = path + ".zipped";
            using FileStream compressedFile = File.OpenWrite(compressedFilePath);
            for (int i = 0; i < sourceFile.Length; ++i)
            {
                var currentByte = (byte)sourceFile.ReadByte();
                if (trie.PointerContains(currentByte))
                {
                    trie.MovePointer(currentByte);
                }
                else
                {
                    WriteByteCode(trie, compressedFile);
                    trie.Add(currentByte);
                }
            }
            WriteByteCode(trie, compressedFile);
        }

        /// <summary>
        /// Initializes the byte array dictionary with the first 256 bytes.
        /// </summary>
        /// <param name="dictionary">Specified byte array dictionary.</param>
        private static void DictionaryInitialization(Dictionary<int, byte[]> dictionary)
        {
            for (int i = 0; i < 256; ++i)
            {
                byte[] byteArray = { (byte)i };
                dictionary.Add(i, byteArray);
            }
        }

        /// <summary>
        /// Returns an integer representation of an array of bytes.
        /// </summary>
        /// <param name="byteArray">Specified byte array.</param>
        private static int GetIntCode(byte[] byteArray)
        {
            var arrayForCode = new byte[4];
            Array.Copy(byteArray, arrayForCode, byteArray.Length);
            return BitConverter.ToInt32(arrayForCode, 0);
        }

        /// <summary>
        /// Returns a new byte array by adding first element of the second array to the end of the first array.
        /// </summary>
        /// <param name="firstArray">First byte array.</param>
        /// <param name="secondArray">Second byte array.</param>
        private static byte[] GetNewByteArray(byte[] firstArray, byte[] secondArray)
        {
            var newByteArray = new byte[firstArray.Length + 1];
            Array.Copy(firstArray, newByteArray, firstArray.Length);
            newByteArray[firstArray.Length] = secondArray[0];
            return newByteArray;
        }

        /// <summary>
        /// Decompresses the specified file and removes the extension ".zipped".
        /// </summary>
        /// <param name="path">Path to the file.</param>
        static public void Decompress(string path)
        {
            using FileStream sourceFile = File.OpenRead(path);
            var decompressedFilePath = path.Remove(path.Length - 7, 7);
            using FileStream decompressedFile = File.OpenWrite(decompressedFilePath);
            var dictionary = new Dictionary<int, byte[]>();
            DictionaryInitialization(dictionary);

            var position = 0;
            while (position < sourceFile.Length)
            {
                var currentLength = GetCountOfBytes(dictionary.Count);
                position += currentLength;

                var currentBytes = new byte[currentLength];
                sourceFile.Read(currentBytes);

                var code = GetIntCode(currentBytes);
                
                if (position != 1)
                {
                    dictionary[dictionary.Count - 1] = GetNewByteArray(dictionary[dictionary.Count - 1], dictionary[code]);
                }

                dictionary.Add(dictionary.Count, dictionary[code]);

                decompressedFile.Write(dictionary[code]);
            }
        }
    }
}