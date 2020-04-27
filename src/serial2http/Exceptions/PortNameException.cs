using System;

namespace serial2http.Exceptions
{
    public class PortNameException : Exception
    {
        private static string BuildMessage(string portName) => string.IsNullOrWhiteSpace(portName) 
            ? "Empty port name."
            : $"Cannot open port with portName '{portName}'. See inner exception.";

        public PortNameException(string portName) : base(BuildMessage(portName))
        {
        }

        internal PortNameException(string portName, Exception inner) : base(BuildMessage(portName), inner)
        {
        }
    }
}
