using System;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;

namespace serial2http.Test
{
    [TestClass]
    public class HelpTest
    {
        private StringBuilder StandardOutput { get; } = new StringBuilder();
        private static readonly TextWriter RegularConsoleOut = Console.Out;

        [TestInitialize]
        public void Initialize()
        {
            Console.SetOut(new StringWriter(StandardOutput));
        }

        [TestCleanup]
        public void Cleanup()
        {
            Console.SetOut(RegularConsoleOut);
            StandardOutput.Clear();
        }

        [DataTestMethod]
        [DataRow("xx", "yy", "--help")]
        [DataRow("-h", "yy")]
        [DataRow("-h", "--help")]
        public void Help_Switch_At_Any_Position_In_Args_Shows_Help_In_Console(params string[] args)
        {
            Program.Main(args);
            Check.That(StandardOutput.ToString()).IsEqualTo(ProgramHelp.AsOneLine);
        }
    }
}
