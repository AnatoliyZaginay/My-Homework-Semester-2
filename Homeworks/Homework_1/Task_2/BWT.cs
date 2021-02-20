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

        public static string Transform(string line, ref int index)
        {
            var circularShiftsArray = new int[line.Length];
            for (int i = 0; i < circularShiftsArray.Length; ++i)
            {
                circularShiftsArray[i] = i;
            }
            Sort(circularShiftsArray, line, 0, circularShiftsArray.Length - 1);
            index = Array.IndexOf(circularShiftsArray, 0);
            string result = "";
            for (int i = 0; i < circularShiftsArray.Length; ++i)
            {
                result += line[(circularShiftsArray[i] + line.Length - 1) % line.Length];
            }
            return result;
        }

        private static char[] GetAlphabet(string line)
        {
            string symbols = "";
            for (int i = 0; i < line.Length; ++i)
            {
                if (!symbols.Contains(line[i]))
                {
                    symbols += line[i];
                }
            }
            var alphabet = symbols.ToCharArray();
            Array.Sort(alphabet);
            return alphabet;
        }

        private static int[] GetCounts(string line, char[] alphabet)
        {
            var counts = new int[alphabet.Length];
            for (int i = 0; i < line.Length; ++i)
            {
                int indexOfSymbol = Array.IndexOf(alphabet, line[i]);
                ++counts[indexOfSymbol];
            }
            return counts;
        }

        private static int[] GetHelperArray(string line, char[] alphabet)
        {
            var counts = GetCounts(line, alphabet);
            var helper = new int[counts.Length];
            for (int i = 1; i < helper.Length; ++i)
            {
                helper[i] = counts[i - 1] + helper[i - 1];
            }
            return helper;
        }

        private static int[] GetPositions(string line)
        {
            var alphabet = GetAlphabet(line);
            var helper = GetHelperArray(line, alphabet);
            var positions = new int[line.Length];
            for (int i = 0; i < positions.Length; ++i)
            {
                var index = Array.IndexOf(alphabet, line[i]);
                positions[i] = helper[index];
                ++helper[index];
            }
            return positions;
        }

        public static string ReverseTransform(string line, int index)
        {
            var positions = GetPositions(line);
            var result = new char[line.Length];
            for (int i = 0; i < line.Length; ++i)
            {
                result[i] = line[index];
                index = positions[index];
            }
            Array.Reverse(result);
            string resultLine = new string(result);
            return resultLine;
        }
    }
}
