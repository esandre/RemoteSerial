using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using serial2http.Exceptions;

namespace serial2http.Test
{
    [TestClass]
    public class SerialPortBuilderTest
    {
        private const string ValidListenerUri = "http://localhost:60500/";

        [TestMethod]
        public void Invalid_Port_Name_Throws_PortNameException()
        {
            const string portName = "badPort";
            var expectedMessage = new PortNameException(portName).Message;

            Check.ThatCode(() => Program.Main(new []{ portName, ValidListenerUri }))
                .Throws<PortNameException>()
                .WithMessage(expectedMessage);
        }

        [TestMethod]
        public void No_Port_Name_Throws_PortNameException()
        {
            var expectedMessage = new PortNameException(string.Empty).Message;

            Check.ThatCode(() => Program.Main(new string[0]))
                .Throws<PortNameException>()
                .WithMessage(expectedMessage);
        }
    }
}
