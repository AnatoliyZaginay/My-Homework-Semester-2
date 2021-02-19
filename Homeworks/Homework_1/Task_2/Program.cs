using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select an operation: \n1 - BWT\n2 - Reverse BWT");
            string line = Console.ReadLine();
            Console.WriteLine(BWT.Transform(line));
        }
    }
}
