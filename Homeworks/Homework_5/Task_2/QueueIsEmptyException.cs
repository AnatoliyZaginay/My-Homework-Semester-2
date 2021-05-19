using System;

namespace Task_2
{
    /// <summary>
    /// Exception that is thrown when the queue is empty.
    /// </summary>
    [Serializable]
    public class QueueIsEmptyException : Exception
    {
        public QueueIsEmptyException() { }

        public QueueIsEmptyException(string message)
            : base(message) { }

        public QueueIsEmptyException(string message, Exception inner)
            : base(message, inner) { }

        protected QueueIsEmptyException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}