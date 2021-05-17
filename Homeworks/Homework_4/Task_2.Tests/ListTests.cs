using NUnit.Framework;
using System.Collections.Generic;

namespace Task_2.Tests
{
    [TestFixture]
    public class ListTests
    {
        [TestCaseSource(nameof(ListTypes))]
        public void ListShouldContainOnlyAddedValues(List list)
        {
            list.Add(0, 0);
            Assert.IsTrue(list.Contains(0));
            Assert.IsFalse(list.Contains(1));
        }

        [TestCaseSource(nameof(ListTypes))]
        public void GetValueShouldReturnValuesCorrectly(List list)
        {
            list.Add(0, 0);
            list.Add(1, 1);

            Assert.AreEqual(0, list.GetValue(0));
            Assert.AreEqual(1, list.GetValue(1));
        }

        [TestCaseSource(nameof(ListTypes))]
        public void GetValueShouldThrowExceptionIfIndexIsNotCorrect(List list)
        {
            list.Add(0, 0);
            Assert.Throws<ElementDoesNotExistException>(() => list.GetValue(1));
            Assert.Throws<ElementDoesNotExistException>(() => list.GetValue(-1));
        }

        [TestCaseSource(nameof(ListTypes))]
        public void ListShouldAddValuesCorrectly(List list)
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

        [TestCaseSource(nameof(ListTypes))]
        public void AddShouldThrowExceptionIfIndexIsNotCorrect(List list)
        {
            list.Add(0, 0);
            Assert.Throws<System.IndexOutOfRangeException>(() => list.Add(1, 2));
            Assert.Throws<System.IndexOutOfRangeException>(() => list.Add(1, -1));
        }

        [TestCaseSource(nameof(ListTypes))]
        public void ListShouldChangeValuesCorrectly(List list)
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

        [TestCaseSource(nameof(ListTypes))]
        public void ChangeValueShouldThrowExceptionIfIndexIsNotCorrect(List list)
        {
            list.Add(0, 0);
            Assert.Throws<ElementDoesNotExistException>(() => list.ChangeValue(1, 2));
            Assert.Throws<ElementDoesNotExistException>(() => list.ChangeValue(1, -1));
        }

        [TestCaseSource(nameof(ListTypes))]
        public void ListShouldDeleteElementsCorrectly(List list)
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

        [TestCaseSource(nameof(ListTypes))]
        public void DeleteShouldThrowExceptionIfIndexIsNotCorrect(List list)
        {
            list.Add(0, 0);
            Assert.Throws<ElementDoesNotExistException>(() => list.Delete(1));
            Assert.Throws<ElementDoesNotExistException>(() => list.Delete(-1));
        }

        private static IEnumerable<List> ListTypes()
        {
            yield return new List();
            yield return new UniqueList();
        }
    }
}