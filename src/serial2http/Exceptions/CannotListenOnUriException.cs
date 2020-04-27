using System;

namespace serial2http.Exceptions
{
    public class CannotListenOnUriException : Exception
    {
        private static string BuildMessage(Uri listenedUri) => $"Cannot listend uri {listenedUri}. See inner exception.";

        public CannotListenOnUriException(Uri listenedUri, Exception e) : base(BuildMessage(listenedUri), e)
        {
        }
    }
}
