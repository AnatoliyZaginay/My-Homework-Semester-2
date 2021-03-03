using System;

namespace Task_1
{
    class Sorting
    {
        public static bool IsSorted(int[] array)
        {
            for (int i = 0; i < array.Length - 1; ++i)
            {
                if (array[i] > array[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        public static void Sort(int[] array)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                var minIndex = i;
                for (int j = i + 1; j < array.Length; ++j)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }
                var swap = array[i];
                array[i] = array[minIndex];
                array[minIndex] = swap;
            }
        }
    }
}
