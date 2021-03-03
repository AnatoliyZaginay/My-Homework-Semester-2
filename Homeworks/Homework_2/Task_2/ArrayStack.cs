using System;

namespace Task_2
{
    /// <summary>
    /// Last-in-first out container for integers based on array.
    /// </summary>
    public class ArrayStack : IStack
    {
        private double[] array = new double[1];
        private int headIndex = 0;

        /// <summary>
        /// Adds value to a top of the stack.
        /// </summary>
        /// <param name="value">Value to add.</param>
        public void Push(double value)
        {
            if (headIndex >= array.Length)
            {
                Array.Resize(ref array, array.Length * 2);
            }
            array[headIndex] = value;
            ++headIndex;
        }

        /// <summary>
        /// True if the stack is empty otherwise false.
        /// </summary>
        public bool Empty =>
            headIndex == 0;

        /// <summary>
        /// Gets value from a top of the stack and deletes it.
        /// </summary>
        /// <returns>Value from the top.</returns>
        public double Pop()
        {
            if (Empty)
            {
                throw new NullReferenceException("Stack is empty");
            }
            --headIndex;
            return array[headIndex];
        }
    }
}