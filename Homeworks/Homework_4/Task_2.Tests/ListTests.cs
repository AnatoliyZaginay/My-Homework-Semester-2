using NUnit.Framework;

namespace Task_2.Tests
{
    [TestFixture]
    public class ListTests
    {
        private List list;

        [SetUp]
        public void Setup()
        {
            list = new List();
        }

        [Test]
        public void ListShouldContainOnlyAddedValues()
        {
            list.Add(0, 0);
            Assert.IsTrue(list.Contains(0));
            Assert.IsFalse(list.Contains(1));
        }

        [Test]
        public void GetValueShouldReturnValuesCorrectly()
        {
            list.Add(0, 0);
            list.Add(1, 1);

            Assert.AreEqual(0, list.GetValue(0));
            Assert.AreEqual(1, list.GetValue(1));
        }

        [Test]
        public void GetValueShouldThrowExceptionIfIndexIsNotCorrect()
        {
            list.Add(0, 0);
            Assert.Throws<ElementDoesNotExistException>(() => list.GetValue(1));
            Assert.Throws<ElementDoesNotExistException>(() => list.GetValue(-1));
        }

        [Test]
        public void ListShouldAddValuesCorrectly()
        {
            list.Add(1, 0);
            list.Add(4, 1);
            list.Add(0, 0);
            list.Add(3, 2);
            list.Add(2, 2);

            for (int i = 0; i < 5; ++i)
            {
                Assert.AreEqual(i, list.GetValue(i));
            }
        }

        [Test]
        public void AddShouldThrowExceptionIfIndexIsNotCorrect()
        {
            list.Add(0, 0);
            Assert.Throws<System.IndexOutOfRangeException>(() => list.Add(1, 2));
            Assert.Throws<System.IndexOutOfRangeException>(() => list.Add(1, -1));
        }

        [Test]
        public void ListShouldChangeValuesCorrectly()
        {
            list.Add(2, 0);
            list.Add(1, 0);
            list.Add(0, 0);

            for (int i = 0; i < 3; ++i)
            {
                list.ChangeValue(i + 10, i);
                Assert.AreEqual(i + 10, list.GetValue(i));
            }
        }

        [Test]
        public void ChangeValueShouldThrowExceptionIfIndexIsNotCorrect()
        {
            list.Add(0, 0);
            Assert.Throws<ElementDoesNotExistException>(() => list.ChangeValue(1, 2));
            Assert.Throws<ElementDoesNotExistException>(() => list.ChangeValue(1, -1));
        }

        [Test]
        public void ListShouldDeleteElementsCorrectly()
        {
            list.Add(10, 0);
            list.Add(0, 1);
            list.Add(11, 2);
            list.Add(1, 3);
            list.Add(2, 4);
            list.Add(12, 5);

            list.Delete(5);
            list.Delete(2);
            list.Delete(0);

            Assert.IsFalse(list.Contains(10));
            Assert.IsFalse(list.Contains(11));
            Assert.IsFalse(list.Contains(12));

            for (int i = 0; i < 3; ++i)
            {
                Assert.AreEqual(i, list.GetValue(i));
            }
        }

        [Test]
        public void DeleteShouldThrowExceptionIfIndexIsNotCorrect()
        {
            list.Add(0, 0);
            Assert.Throws<ElementDoesNotExistException>(() => list.Delete(1));
            Assert.Throws<ElementDoesNotExistException>(() => list.Delete(-1));
        }
    }
}