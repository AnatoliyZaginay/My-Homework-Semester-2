using System;

namespace Task_1
{
    /// <summary>
    /// Plus operator class
    /// </summary>
    class Minus : Operator
    {
        /// <summary>
        /// Returns the result of the subtraction.
        /// </summary>
        public override double Calculate()
            => LeftChild.Calculate() - RightChild.Calculate();

        /// <summary>
        /// Returns a string containing the minus, the result of printing left child, and the result of printing right child.
        /// </summary>
        /// <returns></returns>
        public override string Print()
            => $"( - {LeftChild.Print()} {RightChild.Print()} )";
    }
}