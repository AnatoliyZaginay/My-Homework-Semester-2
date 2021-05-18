using System;

namespace Task_1
{
    /// <summary>
    /// Plus operator class
    /// </summary>
    class Divison : Operator
    {
        /// <summary>
        /// Returns the result of the division.
        /// </summary>
        public override double Calculate()
        {
            double rightNumber = RightChild.Calculate();
            if (Math.Abs(rightNumber) < double.Epsilon)
            {
                throw new DivideByZeroException();
            }
            return LeftChild.Calculate() / rightNumber;
        }

        /// <summary>
        /// Returns a string containing the division, the result of printing left child, and the result of printing right child.
        /// </summary>
        /// <returns></returns>
        public override string Print()
            => $"( / {LeftChild.Print()} {RightChild.Print()} )";
    }
}