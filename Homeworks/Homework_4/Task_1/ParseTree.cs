using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public class ParseTree
    {
        private ITreeElement root;

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
                return null;
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

        public double Calculate()
            => root.Calculate();

        public string Print()
            => root.Print();
    }
}
