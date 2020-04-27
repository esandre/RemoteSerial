using System.IO.Ports;
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using serial2http.Exceptions;

namespace serial2http.Test
{
    [TestClass]
    public class HttpListenerBuilderTest
    {
        private static readonly string ValidSerialPortName = SerialPort.GetPortNames().First();

        [TestMethod]
        public void No_Uri_Throws_MalformedUriException()
        {
            var expectedMessage = new MalformedUriException(string.Empty).Message;

            Check.ThatCode(() => Program.Main(new []{ ValidSerialPortName }))
                .Throws<MalformedUriException>()
                .WithMessage(expectedMessage);
        }

        [TestMethod]
        public void Not_An_Uri_Throws_MalformedUriException()
        {
            const string badUri = "htpt:\\/:ObviouslyNotAnUri";
            var expectedMessage = new MalformedUriException(badUri).Message;

            Check.ThatCode(() => Program.Main(new[] { ValidSerialPortName, badUri }))
                .Throws<MalformedUriException>()
                .WithMessage(expectedMessage);
        }

        [TestMethod]
        public void Not_Listenable_Uri_Throws_CannotListenOnUriException()
        {
            const string testedUri = "http://localhost:60530/";
            using var listenerOccupingThePort = new HttpListener { Prefixes = { testedUri }};
            listenerOccupingThePort.Start();

            Check.ThatCode(() => Program.Main(new[] {ValidSerialPortName, testedUri}))
                .Throws<CannotListenOnUriException>();

            listenerOccupingThePort.Stop();
        }
    }
}
