using System;

namespace Task_2
{
    /// <summary>
    /// Class based on stack that can calculate the result of an arithmetic expression in postfix form.
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// Create a new calculator based on stack.
        /// </summary>
        /// <param name="stack">Stack used in the calculation.</param>
        public Calculator(IStack stack)
            => this.stack = stack;

        private IStack stack;

        /// <summary>
        /// Calculate the result of an arithmetic expression.
        /// </summary>
        /// <param name="arithmeticExpression">Arithmetic expression to be calculated.</param>
        /// <returns>Result of the calculations.</returns>
        public double Calculate(string arithmeticExpression)
        {
            string[] operationsAndOperands = arithmeticExpression.Split(' ', StringSplitOptions.RemoveEmptyEntries);

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
                                throw new DivideByZeroException("Attempt to divide by zero");
                            }
                            stack.Push(secondNumber / firstNumber);
                            break;
                    }
                }
                else
                {
                    throw new ArgumentException("Wrong symbol");
                }
            }

            var result = stack.Pop();
            if (!stack.Empty)
            {
                throw new ArithmeticException("Stack isn't empty after completing all arithmetical operations");
            }
            return result;
        }
    }
}