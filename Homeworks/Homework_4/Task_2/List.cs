using System;

namespace Task_2
{
    public class List
    {
        protected class ListElement
        {
            public int Value { get; set; }

            public ListElement Next { get; set; }

            public ListElement(int value)
            {
                Value = value;
            }
        }

        protected ListElement head;

        protected int count;

        public virtual void Add(int value, int index)
        {
            if (index > count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            ListElement newElement = new ListElement(value);
            ListElement currentElement = head;
            ListElement previousElement = null;

            for (int i = 0; i < index; ++i)
            {
                previousElement = currentElement;
                currentElement = currentElement.Next;
            }
            ++count;

            if (previousElement == null)
            {
                newElement.Next = head;
                head = newElement;
                return;
            }

            previousElement.Next = newElement;
            newElement.Next = currentElement;
        }

        public void Delete(int index)
        {
            if (index >= count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            ListElement currentElement = head;
            ListElement previousElement = null;

            for (int i = 0; i < index; ++i)
            {
                previousElement = currentElement;
                currentElement = currentElement.Next;
            }
            --count;

            if (previousElement == null)
            {
                head = head.Next;
                return;
            }

            previousElement.Next = currentElement.Next;
        }

        public virtual void ChangeValue(int newValue, int index)
        {
            if (index >= count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            ListElement currentElement = head;

            for (int i = 0; i < index; ++i)
            {
                currentElement = currentElement.Next;
            }

            currentElement.Value = newValue;
        }
    }
}
