using System;

namespace Task_1
{
    /// <summary>
    /// Interface of parse tree element.
    /// </summary>
    interface ITreeElement
    {
        /// <summary>
        /// Returns the result of calculating the subtree starting with this element.
        /// </summary>
        public double Calculate();

        /// <summary>
        /// Returns the string of arithmetic expression of the subtree.
        /// </summary>
        public string Print();
    }
}