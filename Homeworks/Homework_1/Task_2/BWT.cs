using System;

namespace Task_2
{
    class BWT
    {
        private static string GetCircularShift(string line, int index)
            => line.Substring(index, line.Length - index) + line.Substring(0, index);

        private static void Sort(int[] array, string line, int firstIndex, int secondIndex)
        {
            var left = firstIndex;
            var right = secondIndex;
            var pivot = GetCircularShift(line, array[(firstIndex + secondIndex) / 2]);
            while (left <= right)
            {
                while (String.Compare(GetCircularShift(line, array[left]), pivot) < 0)
                {
                    ++left;
                }
                while (String.Compare(GetCircularShift(line, array[right]), pivot) > 0)
                {
                    --right;
                }
                if (left <= right)
                {
                    var swap = array[left];
                    array[left] = array[right];
                    array[right] = swap;
                    ++left;
                    --right;
                }
                if (right > firstIndex)
                {
                    Sort(array, line, firstIndex, right);
                }
                if (left < secondIndex)
                {
                    Sort(array, line, left, secondIndex);
                }
            }
        }

        public static string Transform(string line)
        {
            var circularShiftsArray = new int[line.Length];
            for (int i = 0; i < line.Length; ++i)
            {
                circularShiftsArray[i] = i;
            }
            Sort(circularShiftsArray, line, 0, circularShiftsArray.Length - 1);
            string result = "";
            for (int i = 0; i < circularShiftsArray.Length; ++i)
            {
                result += line[(circularShiftsArray[i] + line.Length - 1) % line.Length];
            }
            return result;
        }
    }
}
