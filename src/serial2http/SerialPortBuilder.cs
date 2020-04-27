using System;
using System.IO;
using System.IO.Ports;
using serial2http.Exceptions;

namespace serial2http
{
    internal class SerialPortBuilder
    {
        private readonly string _portName;

        //public int? BaudRate { get; set; }
        //public int? DataBits { get; set; }
        //public StopBits? StopBits { get; set; }
        //public Parity? Parity { get; set; }

        public SerialPortBuilder(string portName)
        {
            _portName = portName;
        }

        public SerialPort Build()
        {
            try
            {
                var port = new SerialPort(_portName);
                port.Open();
                port.Close();
                return port;
            }
            catch (Exception e)
            {
                throw new PortNameException(_portName, e);
            }

            //if(StopBits.HasValue) return new SerialPort(_portName, BaudRate.Value, Parity.Value, DataBits.Value, StopBits.Value);
        }
    }
}
