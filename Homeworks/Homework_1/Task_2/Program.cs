using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!BWTTests.Tests())
            {
                Console.WriteLine("Tests failed");
                return;
            }
            Console.Write("Enter a string: ");
            string line = Console.ReadLine();
            int index = 0;
            string transformedLine = BWT.Transform(line, ref index);
            Console.WriteLine($"Transformed string: {transformedLine}, position of the last symbol: {index}");
            string reverseLine = BWT.ReverseTransform(transformedLine, index);
            Console.WriteLine($"Reverse string: {reverseLine}");
            if (String.Compare(line, reverseLine) == 0)
            {
                Console.WriteLine("Strings are same");
                return;
            }
            Console.WriteLine("Strings aren't same");
        }
    }
}
