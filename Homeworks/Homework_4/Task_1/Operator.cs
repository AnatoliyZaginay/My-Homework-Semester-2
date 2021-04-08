using System;

namespace Task_1
{
    class Operator : ITreeElement
    {
        private string operation;

        public ITreeElement LeftChild { get; set; }

        public ITreeElement RightChild { get; set; }

        public Operator(string symbol)
        {
            operation = symbol;
        }

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

        public string Print()
            => $"( {operation} {LeftChild.Print()} {RightChild.Print()} )";
    }
}
