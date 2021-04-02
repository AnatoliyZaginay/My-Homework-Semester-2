using NUnit.Framework;
using System.Collections.Generic;

namespace Task_1.Tests
{
    [TestFixture]
    public class Tests
    {
        private Vector firstVector;
        private Vector secondVector;
        private Vector nullVector;

        [SetUp]
        public void Setup()
        {
            Dictionary<int, int> firstCoordinates = new Dictionary<int, int>();
            firstCoordinates.Add(0, 3);
            firstCoordinates.Add(1, 2);
            firstCoordinates.Add(3, 5);

            firstVector = new Vector(4, firstCoordinates);

            Dictionary<int, int> secondCoordinates = new Dictionary<int, int>();
            secondCoordinates.Add(0, 3);
            secondCoordinates.Add(2, 3);
            secondCoordinates.Add(3, 3);

            secondVector = new Vector(4, secondCoordinates);

            Dictionary<int, int> thirdCoordinates = new Dictionary<int, int>();
            nullVector = new Vector(4, thirdCoordinates);
        }

        [Test]
        public void SumTest()
        {
            Vector result = Vector.Sum(firstVector, secondVector);

            Dictionary<int, int> expected = new Dictionary<int, int>();
            expected.Add(0, 6);
            expected.Add(1, 2);
            expected.Add(2, 3);
            expected.Add(3, 8);

            Assert.AreEqual(expected, result.Coordinates);
        }

        [Test]
        public void DifferenceTest()
        {
            Vector result = Vector.Difference(firstVector, secondVector);

            Dictionary<int, int> expected = new Dictionary<int, int>();
            expected.Add(1, 2);
            expected.Add(2, -3);
            expected.Add(3, 2);

            Assert.AreEqual(expected, result.Coordinates);
        }

        [Test]
        public void MultiplicationTest()
        {
            int multiplication = Vector.Multiplication(firstVector, secondVector);
            Assert.AreEqual(multiplication, 24);
        }

        [Test]
        public void NullVectorTest()
            => Assert.IsTrue(Vector.IsNull(nullVector));

    }
}