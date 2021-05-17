﻿using System;

namespace Task_2
{
    /// <summary>
    /// Standard list.
    /// </summary>
    public class List
    {
        /// <summary>
        /// List element class that has a value and a reference to the next element.
        /// </summary>
        private class ListElement
        {
            public int Value { get; set; }

            public ListElement Next { get; set; }

            public ListElement(int value)
            {
                Value = value;
            }
        }

        /// <summary>
        /// Pointer to the head of the list.
        /// </summary>
        private ListElement head;

        /// <summary>
        /// Number of elements in the list.
        /// </summary>
        private int length;

        private void MovePointersToListElements(ref ListElement firstPointer, ref ListElement secondPointer)
        {
            firstPointer = secondPointer;
            secondPointer = secondPointer.Next;
        }

        /// <summary>
        /// Adds a value to the list by index.
        /// </summary>
        /// <param name="value">Value to add.</param>
        /// <param name="index">Specified index.</param>
        public virtual void Add(int value, int index)
        {
            if (index > length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            var newElement = new ListElement(value);
            var currentElement = head;
            ListElement previousElement = null;

            for (int i = 0; i < index; ++i)
            {
                MovePointersToListElements(ref previousElement, ref currentElement);
            }
            ++length;

            if (previousElement == null)
            {
                newElement.Next = head;
                head = newElement;
                return;
            }

            previousElement.Next = newElement;
            newElement.Next = currentElement;
        }

        /// <summary>
        /// Changes a value in the list by index.
        /// </summary>
        /// <param name="newValue">New value.</param>
        /// <param name="index">Specified index.</param>
        public virtual void ChangeValue(int newValue, int index)
        {
            if (index >= length || index < 0)
            {
                throw new ElementDoesNotExistException();
            }

            var currentElement = head;

            for (int i = 0; i < index; ++i)
            {
                currentElement = currentElement.Next;
            }

            currentElement.Value = newValue;
        }

        /// <summary>
        /// Deletes a list element by index.
        /// </summary>
        /// <param name="index">Specified index.</param>
        public void Delete(int index)
        {
            if (index >= length || index < 0)
            {
                throw new ElementDoesNotExistException();
            }

            var currentElement = head;
            ListElement previousElement = null;

            for (int i = 0; i < index; ++i)
            {
                MovePointersToListElements(ref previousElement, ref currentElement);
            }
            --length;

            if (previousElement == null)
            {
                head = head.Next;
                return;
            }

            previousElement.Next = currentElement.Next;
        }

        /// <summary>
        /// Returns the value of the list element by index.
        /// </summary>
        /// <param name="index">Specified index.</param>
        public int GetValue(int index)
        {
            if (index >= length || index < 0)
            {
                throw new ElementDoesNotExistException();
            }

            var currentElement = head;

            for (int i = 0; i < index; ++i)
            {
                currentElement = currentElement.Next;
            }

            return currentElement.Value;
        }

        /// <summary>
        /// Returns true if the list contains the value otherwise returns false.
        /// </summary>
        /// <param name="value">Specified value.</param>
        public bool Contains(int value)
        {
            var currentElement = head;
            for (int i = 0; i < length; ++i)
            {
                if (currentElement.Value == value)
                {
                    return true;
                }

                currentElement = currentElement.Next;
            }

            return false;
        }
    }
}