using System;

namespace Task_2
{
    /// <summary>
    /// Last-in-first out container for integers based on list.
    /// </summary>
    public class ListStack : IStack
    {
        /// <summary>
        /// Element of the stack contains integer value and reference to the next element.
        /// </summary>
        private class StackElement
        {
            /// <summary>
            /// Create a new stack element.
            /// </summary>
            /// <param name="value">Value of the element.</param>
            /// <param name="next">Reference to the next element.</param>
            public StackElement(double value, StackElement next)
            {
                Value = value;
                Next = next;
            }

            public double Value { get; }

            public StackElement Next { get; }
        }

        private StackElement head;

        /// <summary>
        /// Adds value to a top of the stack.
        /// </summary>
        /// <param name="value">Value to add.</param>
        public void Push(double value)
            => head = new StackElement(value, head);

        /// <summary>
        /// True if the stack is empty otherwise false.
        /// </summary>
        public bool Empty =>
            head == null;

        /// <summary>
        /// Gets value from a top of the stack and deletes it.
        /// </summary>
        /// <returns>Value from the top.</returns>
        public double Pop()
        {
            if (Empty)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            var returnedValue = head.Value;
            head = head.Next;
            return returnedValue;
        }
    }
}