using System;

namespace Task_1
{
    abstract class Operator : ITreeElement
    {
        /// <summary>
        /// Pointer to the left child.
        /// </summary>
        public ITreeElement LeftChild { get; set; }

        /// <summary>
        /// Pointer to the right child.
        /// </summary>
        public ITreeElement RightChild { get; set; }

        /// <summary>
        /// Returns the result of the operation.
        /// </summary>
        public abstract double Calculate();

        /// <summary>
        /// Returns a string containing the operation, the result of printing left child, and the result of printing right child.
        /// </summary>
        public abstract string Print();
    }
}