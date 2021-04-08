using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select the stack type used in the calculator: 1 - on array, 2 - on list");
            var type = int.Parse(Console.ReadLine());
            var stack = type == 1 ? (IStack) new ArrayStack() : new ListStack();
            Console.Write("Eneter an arithmetical expression in postfix form: ");
            var arithmeticalExpression = Console.ReadLine();
            var calculator = new Calculator(stack);
            try
            {
                Console.WriteLine(calculator.Calculate(arithmeticalExpression));
            }
            catch (InvalidOperationException)
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