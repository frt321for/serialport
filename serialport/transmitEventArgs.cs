using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serialport
{
    public delegate void TransmitData(byte[] data);
    public delegate void TransmitEventHandler(object sender, transmitEventArgs e);
    public class transmitEventArgs:EventArgs
    {
        public SerialPort sp {  get; set; }
        public byte[] data {  get; set; }
    }
}
