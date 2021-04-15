using System;
using System.Collections.Generic;

namespace Task_1
{
    class Program
    {
        public static void PrintList<T>(List<T> list)
        {
            foreach (var listElement in list)
            {
                Console.Write($"{listElement} ");
            }
            Console.WriteLine("\n");
        }

        static void Main(string[] args)
        {
            var list = new List<string> { "-1", "2", "-3", "4" };
            Console.Write("Source list: ");
            PrintList(list);

            var mappedList = ListFunctions.Map(list, x => int.Parse(x) * 3);
            Console.Write("Mapped list: ");
            PrintList(mappedList);

            var filteredList = ListFunctions.Filter(list, x => int.Parse(x) > 0);
            Console.Write("Filtered list: ");
            PrintList(filteredList);

            var value = ListFunctions.Fold(list, 0, (x, y) => x + int.Parse(y));
            Console.Write($"Folding result: {value}");
        }
    }
}