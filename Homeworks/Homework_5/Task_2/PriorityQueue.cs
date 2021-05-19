﻿using System;

namespace Task_2
{
    /// <summary>
    /// Class of priority class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PriorityQueue<T>
    {
        /// <summary>
        /// Priority queue element that has a value, a priority and a reference to the next element.
        /// </summary>
        private class QueueElement
        {
            public QueueElement Next { get; set; }

            public T Value { get; }

            public int Priority { get; }

            public QueueElement(T value, int priority)
            {
                Value = value;
                Priority = priority;
            }
        }

        /// <summary>
        /// Pointer to the head of the queue.
        /// </summary>
        private QueueElement head;

        /// <summary>
        /// Adds a value to the queue by priority.
        /// </summary>
        /// <param name="value">Value to add.</param>
        /// <param name="priority">Priority value.</param>
        public void Enqueue(T value, int priority)
        {
            var currentElement = head;
            var newElement = new QueueElement(value, priority);

            if (head == null || head.Priority < newElement.Priority)
            {
                newElement.Next = head;
                head = newElement;
                return;
            }

            while (currentElement.Next != null && currentElement.Next.Priority >= newElement.Priority)
            {
                currentElement = currentElement.Next;
            }

            newElement.Next = currentElement.Next;
            currentElement.Next = newElement;
        }

        /// <summary>
        /// Returns the value of the queue head and shifts the head to the next element.
        /// </summary>
        public T Dequeue()
        {
            if (head == null)
            {
                throw new QueueIsEmptyException();
            }

            var value = head.Value;
            head = head.Next;
            return value;
        }
    }
}