using System;
using System.IO;
using System.Collections.Generic;
using static System.Math;

namespace Task_1
{
    static class LZW
    {
        private static int GetCountOfBytes(int number)
            => (int)Ceiling(Log2(number + 1) / 8);

        private static void WriteByteCode(Trie trie, FileStream file)
        {
            var byteCode = BitConverter.GetBytes(trie.PointerCode);
            Array.Resize(ref byteCode, GetCountOfBytes(trie.CurrentCode));
            file.Write(byteCode);
        }

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

        private static void DictionaryInitialization(Dictionary<int, byte[]> dictionary)
        {
            for (int i = 0; i < 256; ++i)
            {
                byte[] byteArray = { (byte)i };
                dictionary.Add(i, byteArray);
            }
        }

        private static int GetIntCode(byte[] byteArray)
        {
            var arrayForCode = new byte[4];
            Array.Copy(byteArray, arrayForCode, byteArray.Length);
            return BitConverter.ToInt32(arrayForCode, 0);
        }

        private static byte[] GetNewByteArray(byte[] firstArray, byte[] secondArray)
        {
            var newByteArray = new byte[firstArray.Length + 1];
            Array.Copy(firstArray, newByteArray, firstArray.Length);
            newByteArray[firstArray.Length] = secondArray[0];
            return newByteArray;
        }

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
                var currentLength = GetCountOfBytes(dictionary.Count - 1);
                position += currentLength;

                var currentBytes = new byte[currentLength];
                for (int i = 0; i < currentLength; ++i)
                {
                    currentBytes[i] = (byte)sourceFile.ReadByte();
                }

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
