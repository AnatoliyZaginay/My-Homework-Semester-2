using System;

namespace Task_1
{
    class Operator : ITreeElement
    {
        /// <summary>
        /// Symbol of arithmetic operation.
        /// </summary>
        private string operation;

        /// <summary>
        /// Pointer to the left child.
        /// </summary>
        public ITreeElement LeftChild { get; set; }

        /// <summary>
        /// Pointer to the right child.
        /// </summary>
        public ITreeElement RightChild { get; set; }

        /// <summary>
        /// Creates new tree element with specified operation.
        /// </summary>
        public Operator(string symbol)
        {
            operation = symbol;
        }

        /// <summary>
        /// Returns the result of the operation.
        /// </summary>
        public double Calculate()
        {
            switch (operation)
            {
                case "+":
                    return LeftChild.Calculate() + RightChild.Calculate();
                case "-":
                    return LeftChild.Calculate() - RightChild.Calculate();
                case "*":
                    return LeftChild.Calculate() * RightChild.Calculate();
                case "/":
                    double rightNumber = RightChild.Calculate();
                    if (Math.Abs(rightNumber) < 0.0000001)
                    {
                        throw new DivideByZeroException();
                    }
                    return LeftChild.Calculate() / rightNumber;
                default:
                    throw new ArgumentException();
            }
        }

        /// <summary>
        /// Returns a string containing the operation, the result of printing left child, and the result of printing right child.
        /// </summary>
        public string Print()
            => $"( {operation} {LeftChild.Print()} {RightChild.Print()} )";
    }
}