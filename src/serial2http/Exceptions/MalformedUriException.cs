using System;

namespace serial2http.Exceptions
{
    public class MalformedUriException : Exception
    {
        private static string BuildMessage(string listenedUri) => string.IsNullOrWhiteSpace(listenedUri)
            ? "Empty listened Uri."
            : $"Cannot listen to Uri '{listenedUri}'. See inner exception.";

        public MalformedUriException(string listenedUri) : base(BuildMessage(listenedUri))
        {
        }

        internal MalformedUriException(string listenedUri, Exception inner) : base(BuildMessage(listenedUri), inner)
        {
        }
    }
}
