using System;

namespace Task_2
{
    /// <summary>
    /// Exception that is thrown when the specified element already exists.
    /// </summary>
    [Serializable]
    public class ElementAlreadyExistsException : Exception
    {
        public ElementAlreadyExistsException() { }

        public ElementAlreadyExistsException(string message)
            : base(message) { }

        public ElementAlreadyExistsException(string message, Exception inner)
            : base(message, inner) { }

        protected ElementAlreadyExistsException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}