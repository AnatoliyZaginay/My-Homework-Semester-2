using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2
{
    class Calculator
    {
        public Calculator(IStack stack)
            => this.stack = stack;

        private IStack stack;

        public double Calculate(string arithmeticalExpression)
        {
            string[] operationsAndOperands = arithmeticalExpression.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < operationsAndOperands.Length; ++i)
            {
                if (int.TryParse(operationsAndOperands[i], out int number))
                {
                    stack.Push(number);
                    continue;
                }
                if (operationsAndOperands[i] == "+" || operationsAndOperands[i] == "-" ||
                    operationsAndOperands[i] == "*" || operationsAndOperands[i] == "/")
                {
                    var firstNumber = stack.Pop();
                    var secondNumber = stack.Pop();
                    switch (operationsAndOperands[i])
                    {
                        case "+":
                            stack.Push(firstNumber + secondNumber);
                            break;
                        case "-":
                            stack.Push(secondNumber - firstNumber);
                            break;
                        case "*":
                            stack.Push(firstNumber * secondNumber);
                            break;
                        case "/":
                            if (Math.Abs(firstNumber) < 0.00000001)
                            {
                                throw new DivideByZeroException();
                            }
                            stack.Push(secondNumber / firstNumber);
                            break;
                    }
                }
                else
                {
                    throw new ArgumentException();
                }
            }

            var result = stack.Pop();
            if (!stack.IsEmpty())
            {
                throw new ArithmeticException();
            }
            return result;
        }
    }
}
