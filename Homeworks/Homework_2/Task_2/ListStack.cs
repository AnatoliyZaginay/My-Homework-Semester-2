using System;

namespace Task_2
{
    class ListStack : IStack
    {
        private class StackElement
        {
            public StackElement(double value, StackElement next)
            {
                this.value = value;
                this.next = next;
            }

            private double value;
            public double Value
            {
                get
                {
                    return value;
                }
            }

            private StackElement next;

            public StackElement Next
            {
                get
                {
                    return next;
                }
            }
        }

        private StackElement head;

        public void Push(double value)
            => head = new StackElement(value, head);

        public bool IsEmpty()
            => head == null;

        public double Pop()
        {
            if (IsEmpty())
            {
                throw new NullReferenceException();
            }
            var returnedValue = head.Value;
            head = head.Next;
            return returnedValue;
        }
    }
}