using NUnit.Framework;
using System.IO;

namespace Task_1.Tests
{
    [TestFixture]
    public class LZWTests
    {
        private static bool FilesAreEqual(FileStream firstFile, FileStream secondFile)
        {
            if (firstFile.Length != secondFile.Length)
            {
                return false;
            }

            for (int i = 0; i < firstFile.Length; ++i)
            {
                if (firstFile.ReadByte() != secondFile.ReadByte())
                {
                    return false;
                }
            }

            return true;
        }

        [Test]
        public static void DecompressionShouldRecoverSourceFile()
        {
            var sourceFileName = "..\\..\\..\\test.txt";
            var checkFileName = "..\\..\\..\\check.txt";
            LZW.Compress(sourceFileName);
            LZW.Decompress(sourceFileName + ".zipped");
            File.Delete(sourceFileName + ".zipped");
            using FileStream decompressedFile = File.OpenRead(sourceFileName);
            using FileStream checkFile = File.OpenRead(checkFileName);
            Assert.IsTrue(FilesAreEqual(decompressedFile, checkFile));
        }
    }
}