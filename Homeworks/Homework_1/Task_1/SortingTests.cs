using System;

namespace Task_1
{
    class SortingTests
    {
        private static bool IsSortedTest()
        {
            int[] firstArray = { -1, 2, 2, 3, 4 };
            int[] secondArray = { -1, 2, 4, 3, 3 };
            return Sorting.IsSorted(firstArray) && !Sorting.IsSorted(secondArray);
        }

        private static bool SortTest()
        {
            int[] firstArray = { -1, 2, 2, 3, 4 };
            Sorting.Sort(firstArray);
            int[] secondArray = { 3, 1, 2, 0, 4 };
            Sorting.Sort(secondArray);
            int[] thirdArray = { -3, -8, 0, 1, -1 };
            Sorting.Sort(thirdArray);
            return Sorting.IsSorted(firstArray) && Sorting.IsSorted(secondArray) && Sorting.IsSorted(thirdArray);
        }

        public static bool Tests()
        {
            return IsSortedTest() && SortTest();
        }
    }
}
