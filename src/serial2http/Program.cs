using System;
using System.Linq;

namespace serial2http
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Contains("-h") || args.Contains("--help")) Console.Write(ProgramHelp.AsOneLine);
        }
    }
}
