using System;

namespace Task_2
{
    /// <summary>
    /// Exception that is thrown when the graph is not connected.
    /// </summary>
    [Serializable]
    public class GraphIsNotConnectedException : Exception
    {
        public GraphIsNotConnectedException() { }

        public GraphIsNotConnectedException(string message)
            : base(message) { }

        public GraphIsNotConnectedException(string message, Exception inner)
            : base(message, inner) { }

        protected GraphIsNotConnectedException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}