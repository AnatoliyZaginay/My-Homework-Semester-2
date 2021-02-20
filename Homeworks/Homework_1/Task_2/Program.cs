using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select an operation: \n1 - BWT\n2 - Reverse BWT");
            string line = Console.ReadLine();
            int index = 0;
            string transformedLine = BWT.Transform(line, ref index);
            Console.WriteLine(transformedLine);
            string reverse = BWT.ReverseTransform(transformedLine, index);
            Console.WriteLine(reverse);
        }
    }
}
