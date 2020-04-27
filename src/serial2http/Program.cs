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
            
            if (args.Contains("-h") || args.Contains("--help"))
            {
                Console.Write(ProgramHelp.AsOneLine);
                return;
            }

            var portName = args.First();
            var builder = new SerialPortBuilder(portName);
            builder.Build();
        }
    }
}
