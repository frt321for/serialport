using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace serialport
{
    public partial class Form2 : Form
    {
        public TransmitData useForm1Send;
        public TransmitEventHandler useForm1Send2;
        public Form2()
        {
            InitializeComponent();
        }


        public void recvData(byte[] tmpData)
        {
            string s = Encoding.GetEncoding("UTF-8").GetString(tmpData);
            s = s.Replace("\0","\\0");
            richTextBox1.AppendText(s);
        }

        internal void recvData2(object sender, transmitEventArgs e)
        {
            string s = Encoding.GetEncoding("UTF-8").GetString(e.data);
            //MessageBox.Show(s);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] tmpData = Encoding.GetEncoding("UTF-8").GetBytes(richTextBox2.Text);
            useForm1Send?.Invoke(tmpData);
            useForm1Send2?.Invoke(this, new transmitEventArgs { data = tmpData });
        }
    }
}
