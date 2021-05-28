using NUnit.Framework;
using System.Collections.Generic;

namespace Task_1.Tests
{
    public class Tests
    {
        [TestCaseSource(nameof(ListSortCases))]
        public void ListShouldBeSortedAfterSorting<T>(IComparer<T> comparer, List<T> list, List<T> expectedList)
        {
            Sorting.ListSort(list, comparer);
            Assert.AreEqual(expectedList, list);
        }

        private static IEnumerable<object[]> ListSortCases()
        {
            yield return new object[] { new IntComparer(), new List<int> { 4, 1, 2, 10, 2, 8, 2, 3 }, new List<int> { 1, 2, 2, 2, 3, 4, 8, 10 } };
            yield return new object[] { new Mod5Comparer(), new List<int> { 4, 1, 2, 10, 2, 8, 2, 3 }, new List<int> { 10, 1, 2, 2, 2, 8, 3, 4 } };
            yield return new object[] { new StringLengthComparer(), new List<string> { "abc", "a", "aa", "ab", "", "asdl", "b" }, new List<string> { "", "a", "b", "aa", "ab", "abc", "asdl" } };
        }
    }
}