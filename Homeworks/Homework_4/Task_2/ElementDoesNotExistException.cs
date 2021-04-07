using System;

namespace Task_2
{
    /// <summary>
    /// Exception that is thrown when the specified element does not exist.
    /// </summary>
    [Serializable]
    public class ElementDoesNotExistException : Exception
    {
        public ElementDoesNotExistException() { }

        public ElementDoesNotExistException(string message) 
            : base(message) { }

        public ElementDoesNotExistException(string message, Exception inner)
            : base(message, inner) { }

        protected ElementDoesNotExistException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}