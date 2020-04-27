using System;
using System.Linq;
using serial2http.Exceptions;

namespace serial2http
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            if (!args.Any()) throw new PortNameException(string.Empty);
            if (args.Length < 2) throw new MalformedUriException(string.Empty);
            
            if (args.Contains("-h") || args.Contains("--help"))
            {
                Console.Write(ProgramHelp.AsOneLine);
                return;
            }

            Uri listenedUri;
            try
            {
                listenedUri = new Uri(args[1]);
            }
            catch (UriFormatException e)       
            {
                throw new MalformedUriException(args[1], e);
            }

            var portName = args.First();
            var builder = new SerialPortBuilder(portName);
            builder.Build();

            var listener = new HttpListenerBuilder(listenedUri);
            listener.Build();
        }
    }
}
