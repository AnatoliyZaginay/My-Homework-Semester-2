using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select the stack type: 1 - on array, 2 - on list");
            var type = int.Parse(Console.ReadLine());
            IStack stack;
            if (type == 1)
            {
                stack = new ArrayStack();
            }
            else
            {
                stack = new ListStack();
            }
            Console.Write("Eneter an arithmetical expression in postfix form: ");
            var arithmeticalExpression = Console.ReadLine();
            var calculator = new Calculator(stack);
            try
            {
                Console.WriteLine(calculator.Calculate(arithmeticalExpression));
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Error: not enough numbers");
                return;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: division by zero");
                return;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Error: invalid symbol");
                return;
            }
            catch (ArithmeticException)
            {
                Console.WriteLine("Error: not enough operations");
                return;
            }
        }
    }
}