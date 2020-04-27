using System;
using System.Collections.Generic;
using System.Linq;

namespace serial2http
{
    public static class ProgramHelp
    {
        private static IEnumerable<string> EnumerateHelpLines()
        {
            yield return "Binds a serial port and exposes it with a REST API";
            yield return "Usage: serial2http <pathToPort> <serverUri>";
        }

        public static string AsOneLine { get; } = 
            EnumerateHelpLines().Aggregate((accumulated, chunk) => accumulated + Environment.NewLine + chunk);
    }
}
