using System;

namespace Task_1
{
    class Operand : ITreeElement
    {
        /// <summary>
        /// Value of element.
        /// </summary>
        private double value;

        /// <summary>
        /// Creates new tree element with specified value.
        /// </summary>
        /// <param name="value">Specified value.</param>
        public Operand(double value)
        {
            this.value = value;
        }

        /// <summary>
        /// Returns the value of the element.
        /// </summary>
        public double Calculate()
            => value;

        /// <summary>
        /// Returns a string containing the value.
        /// </summary>
        public string Print()
            => value.ToString();
    }
}