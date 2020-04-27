using System;
using System.Net;
using serial2http.Exceptions;

namespace serial2http
{
    internal class HttpListenerBuilder
    {
        private readonly Uri _listenedUri;

        public HttpListenerBuilder(Uri listenedUri)
        {
            _listenedUri = listenedUri;
        }

        public HttpListener Build()
        {
            try
            {
                var listener = new HttpListener {Prefixes = {_listenedUri.AbsoluteUri}};
                listener.Start();
                listener.Stop();
                return listener;
            }
            catch (Exception e)
            {
                throw new CannotListenOnUriException(_listenedUri, e);
            }
        }
    }
}
