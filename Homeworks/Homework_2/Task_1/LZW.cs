using System;
using System.IO;
using static System.Math;

namespace Task_1
{
    static class LZW
    {
        private static int GetCountOfBytes(int number)
            => (int)Ceiling(Log2(number + 1) / 8);

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
                    var byteCode = BitConverter.GetBytes(trie.PointerCode);
                    Array.Resize(ref byteCode, GetCountOfBytes(trie.CurrentCode));
                    compressedFile.Write(byteCode);
                    trie.Add(currentByte);
                }
            }
            var lastByte = BitConverter.GetBytes(trie.PointerCode);
            Array.Resize(ref lastByte, GetCountOfBytes(trie.CurrentCode));
            compressedFile.Write(lastByte);
        }
    }
}
