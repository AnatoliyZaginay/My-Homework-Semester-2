using System;

namespace Task_2
{
    /// <summary>
    /// List containing only unique values.
    /// </summary>
    public class UniqueList : List
    {
        /// <summary>
        /// Adds a value to the list by index, if it is not contained in the list.
        /// </summary>
        /// <param name="value">Value to add.</param>
        /// <param name="index">Specified index.</param>
        public override void Add(int value, int index)
        {
            if (Contains(value))
            {
                throw new ElementAlreadyExistsException();
            }
            base.Add(value, index);
        }

        /// <summary>
        /// Changes a value in the list by index, if it is not contained in the list.
        /// </summary>
        /// <param name="newValue">New value.</param>
        /// <param name="index">Specified index.</param>
        public override void ChangeValue(int newValue, int index)
        {
            if (Contains(newValue) && GetValue(index) != newValue)
            {
                throw new ElementAlreadyExistsException();
            }
            base.ChangeValue(newValue, index);
        }
    }
}