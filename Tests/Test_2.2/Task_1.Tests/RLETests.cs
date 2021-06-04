using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Task_1.Tests
{
    public class RLETests
    {
        [TestCaseSource(nameof(IncorrectCasesForCompressing))]
        public void CompressingShouldThrowExceptionIfArrayForCompressingIsIncorrect(byte[] byteArray)
            => Assert.Throws<ArgumentException>(() => RLE.Compress(byteArray));

        [TestCaseSource(nameof(IncorrectCasesForDecompressing))]
        public void DecompressingShouldThrowExceptionIfArrayForDecompressingIsIncorrect(byte[] byteArray)
            => Assert.Throws<ArgumentException>(() => RLE.Decompress(byteArray));

        [TestCaseSource(nameof(CorrectCases))]
        public void CompressingShouldWorkCorrect(byte[] byteArray, byte[] expectedArray)
        {
            var result = RLE.Compress(byteArray);
            Assert.AreEqual(expectedArray, result);
        }

        [TestCaseSource(nameof(CorrectCases))]
        public void DecompressingShouldWorkCorrect(byte[] expectedArray, byte[] byteArray)
        {
            var result = RLE.Decompress(byteArray);
            Assert.AreEqual(expectedArray, result);
        }

        private static IEnumerable<object[]> CorrectCases()
        {
            yield return new object[] { new byte[] { 1, 1, 1 }, new byte[] { 3, 1 } };
            yield return new object[] { new byte[] { 1, 1, 255, 1, 1 }, new byte[] { 2, 1, 1, 255, 2, 1 } };
            yield return new object[] { new byte[] { 0 }, new byte[] { 1, 0 } };
            yield return new object[] { new byte[] { 2, 1, 2 }, new byte[] { 1, 2, 1, 1, 1, 2 } };
            yield return new object[] { new byte[] { 1, 1, 2, 2, 1 }, new byte[] { 2, 1, 2, 2, 1, 1 } };
            yield return new object[] { new byte[400], new byte[] { 255, 0, 145, 0 } };
            yield return new object[] { new byte[1024], new byte[] { 255, 0, 255, 0, 255, 0, 255, 0, 4, 0 } };
            yield return new object[] { new byte[128], new byte[] { 128, 0 } };
            yield return new object[] { new byte[] { 0, 1, 1, 1, 4, 4 }, new byte[] { 1, 0, 3, 1, 2, 4 } };
            yield return new object[] { new byte[] { 1, 1, 1, 1, 4, 4 }, new byte[] { 4, 1, 2, 4 } };
            yield return new object[] { new byte[] { 1, 1, 1, 1, 4, 4 }, new byte[] { 4, 1, 2, 4 } };
            yield return new object[] { new byte[] { 1, 2, 3, 4, 5, 6 }, new byte[] { 1, 1, 1, 2, 1, 3, 1, 4, 1, 5, 1, 6 } };
        }

        private static IEnumerable<object[]> IncorrectCasesForCompressing()
        {
            yield return new object[] { null };
        }

        private static IEnumerable<object[]> IncorrectCasesForDecompressing()
        {
            yield return new object[] { null };
            yield return new object[] { new byte[] { 2, 1, 2 } };
            yield return new object[] { new byte[] { 2, 1, 2, 0, 1 } };
        }
    }
}