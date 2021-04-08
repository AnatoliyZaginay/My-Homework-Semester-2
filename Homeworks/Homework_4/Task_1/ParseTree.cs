using System;

namespace Task_1
{
    /// <summary>
    /// Arithmetic expression parsing tree.
    /// </summary>
    public class ParseTree
    {
        /// <summary>
        /// Pointer to the root of the parse tree.
        /// </summary>
        private ITreeElement root;

        /// <summary>
        /// Creates a parse tree by the specified arithmetic expression.
        /// </summary>
        /// <param name="arithmeticExpression">Specified arithmetic expression.</param>
        public ParseTree(string arithmeticExpression)
        {
            char[] separationSymbols = { ' ', '(', ')' };
            string[] expression = arithmeticExpression.Split(separationSymbols, StringSplitOptions.RemoveEmptyEntries);
            int index = 0;
            root = AddElement(expression, ref index);
        }

        private bool isOperator(string symbol)
            => (symbol == "+" || symbol == "-" || symbol == "*" || symbol == "/");

        private ITreeElement AddElement(string[] expression, ref int index)
        {
            if (index >= expression.Length)
            {
                throw new ArgumentException();
            }

            if (isOperator(expression[index]))
            {
                var newOperator = new Operator(expression[index]);
                ++index;
                newOperator.LeftChild = AddElement(expression, ref index);
                newOperator.RightChild = AddElement(expression, ref index);
                return newOperator;
            }

            if (double.TryParse(expression[index], out double value))
            {
                ++index;
                return new Operand(value);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// Returns the result of an arithmetic expression.
        /// </summary>
        public double Calculate()
            => root.Calculate();

        /// <summary>
        /// Returns a string of an arithmetic expression.
        /// </summary>
        public string Print()
            => root.Print();
    }
}