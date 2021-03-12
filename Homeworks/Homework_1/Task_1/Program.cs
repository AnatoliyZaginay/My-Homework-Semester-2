using System;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!SortingTests.Tests())
            {
                Console.WriteLine("Tests failed");
                return;
            }
            Console.Write("Enter an array of integers: ");
            var numbers = Console.ReadLine().Split(' ');
            var array = new int[numbers.Length];
            for (int i = 0; i < array.Length; ++i)
            {
                array[i] = int.Parse(numbers[i]);
            }
            Sorting.Sort(array);
            Console.Write("Sorted array: ");
            for (int i = 0; i < array.Length; ++i)
            {
                Console.Write($"{array[i]} ");
            }
        }
    }
}
