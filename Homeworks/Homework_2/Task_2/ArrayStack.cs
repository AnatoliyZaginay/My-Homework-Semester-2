using System;

namespace Task_2
{
    class ArrayStack : IStack
    {

        private double[] array = new double[1];
        private int headIndex = 0;
        
        public void Push(double value)
        {
            if (headIndex >= array.Length)
            {
                Array.Resize(ref array, array.Length * 2);
            }
            array[headIndex] = value;
            ++headIndex;
        }

        public bool IsEmpty()
            => headIndex == 0;

        public double Pop()
        {
            if (IsEmpty())
            {
                throw new NullReferenceException();
            }
            --headIndex;
            return array[headIndex];
        }
    }
}