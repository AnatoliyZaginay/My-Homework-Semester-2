using System;
using System.IO;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the path to the file: ");
            var filePath = Console.ReadLine();
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File doesn't exist.");
                return;
            }

            var arithmeticExpression = File.ReadAllText(filePath);

            ParseTree tree = null;
            try
            {
                tree = new ParseTree(arithmeticExpression);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Error: invalid symbol.");
                return;
            }

            Console.WriteLine($"Arithmetic expression: {tree.Print()}");

            try
            {
                Console.WriteLine($"Result: {tree.Calculate()}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: division by zero.");
                return;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Error: invalid symbol.");
                return;
            }
        }
    }
}
