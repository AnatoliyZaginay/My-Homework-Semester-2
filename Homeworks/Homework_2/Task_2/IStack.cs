using System;

namespace Task_2
{
    /// <summary>
    /// Interface of last-in-first out container for integers.
    /// </summary>
    public interface IStack
    {
        /// <summary>
        /// Adds value to a top of the stack.
        /// </summary>
        /// <param name="value">Value to add.</param>
        void Push(double value);

        /// <summary>
        /// True if the stack is empty otherwise false.
        /// </summary>
        bool Empty { get; }

        /// <summary>
        /// Gets value from a top of the stack and deletes it.
        /// </summary>
        /// <returns>Value from the top.</returns>
        double Pop();
    }
}