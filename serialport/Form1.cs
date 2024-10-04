using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace serialport
{
    
    public partial class Form1 : Form
    {
        private bool isOpen = false;// 串口开关状态位
        private bool isRecv = true; // 是否接收数据 默认允许
        private List<byte> RecvBuff = new List<byte>();// 接收数据缓冲区
        private int recvCount = 0; // 接收数据计数
        private List<byte> SendBuff = new List<byte>();// 发送数据缓冲区
        private int sendCount = 0; // 发送数据计数

        public TransmitData transmit_data; 
        public event TransmitEventHandler transmit_data2;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;// 禁用跨线程检查

            Form2 form = new Form2();
            transmit_data += form.recvData;//接收数据委托Form2 recvData 执行显示
            transmit_data2 += new TransmitEventHandler(form.recvData2);
            form.useForm1Send = sendBytes;//Form2发送委托Form1 sendBytes 执行发送
            form.useForm1Send2 += new TransmitEventHandler(sendBytes2);
            form.Show();
        }

        private void sendBytes2(object sender, transmitEventArgs e)
        {
            Myserialport.Write(e.data, 0, e.data.Length);
            sendCount += e.data.Length;
            send_count.Text = sendCount.ToString();
        }

        private void sendBytes(byte[] data)
        {
            Myserialport.Write(data, 0, data.Length);
            sendCount += data.Length;
            send_count.Text = sendCount.ToString();
        }

        /// <summary>
        /// 窗体加载事件 展示默认参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // 从注册列表获取端口信息
            RegistryKey keyCom = Registry.LocalMachine.OpenSubKey(@"HardWare\DeviceMap\SerialComm");
            string[] ports =  keyCom.GetValueNames();
            if (ports != null)
            {
                foreach (var item in ports)
                {
                    string portName = keyCom.GetValue(item).ToString();
                    port_num.Items.Add(portName);
                }
            }
            port_num.SelectedIndex = 0;// 第一个读取到的串口
            baud_rate.SelectedIndex = 1; // 9600波特率
            parity_type.SelectedIndex = 0; // 无校验
            data_bit.SelectedIndex = 3; // 8位数据位
            stop_bit.SelectedIndex = 0; // 1位停止位
        }


        /// <summary>
        /// 串口开关按钮 进行参数配置与按钮状态变更 可以捕获异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void open_or_close_Click(object sender, EventArgs e)
        {
            try
            {
                if(Myserialport.IsOpen == false)
                {
                    Myserialport.PortName = port_num.Text;
                    Myserialport.BaudRate = Convert.ToInt32(baud_rate.Text);
                    Myserialport.DataBits = Convert.ToInt32(data_bit.Text);
                    switch (parity_type.SelectedIndex)
                    {
                        case 0:Myserialport.Parity = Parity.None;break;
                        case 1: Myserialport.Parity = Parity.Even; break;
                        case 2: Myserialport.Parity = Parity.Odd; break;
                        default:break;
                    }
                    switch (stop_bit.SelectedIndex)
                    {
                        case 0: Myserialport.StopBits = StopBits.One; break;
                        case 1: Myserialport.StopBits = StopBits.OnePointFive; break;
                        case 2: Myserialport.StopBits = StopBits.Two; break;
                        default: break;
                    }
                    Myserialport.Open();
                    MessageBox.Show(Myserialport.PortName + "  is open !","提示");
                    current_state.Text = Myserialport.PortName + "已打开";
                    isOpen = true;
                    open_or_close.Text = "关闭串口";
                    open_or_close.BackColor = Color.Pink;
                }
                else
                {
                    Myserialport.Close();
                    MessageBox.Show(Myserialport.PortName + "  is close !","提示");
                    current_state.Text = "X";
                    isOpen = false;
                    open_or_close.Text = "打开串口";
                    open_or_close.BackColor = System.Drawing.SystemColors.Window;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.ToString()}\n打开{Myserialport.PortName}时发生异常,请检查参数","警告");
            }
           
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        private void sendData()
        {
            Myserialport.Write(SendBuff.ToArray(), 0, SendBuff.Count);
            sendCount += SendBuff.Count; //utf-8中ascii字符为1byte 而1个汉字是3 bytes
            send_count.Text = sendCount.ToString();
        }
        /// <summary>
        /// 手动发送数据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void manual_send_Click(object sender, EventArgs e)
        {
            if (!Myserialport.IsOpen)
            {
                MessageBox.Show("请先打开串口!", "警告");
            }
            else
            {
                if (send_box.Text == "")
                {
                    MessageBox.Show("请先输入发送数据!", "警告");
                }
                else
                {
                    // Myserialport.Write(send_box.Text); // 不加缓冲和处理的简单发送
                    sendData();
                }
            }

        }
        /// <summary>
        /// 串口接收数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Myserialport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // 一次性读取
            //string dataRecv = Myserialport.ReadExisting();
            //recv_box.AppendText(dataRecv);

            if (!isRecv)
            {
                Myserialport.DiscardInBuffer(); // 选择暂停接收 直接丢弃接收缓冲区数据
                return;
            }
            byte[] dataTmp = new byte[Myserialport.BytesToRead];
            Myserialport.Read(dataTmp,0, dataTmp.Length);
            RecvBuff.AddRange(dataTmp);
            recvCount += dataTmp.Length;
            transmit_data?.Invoke(dataTmp); // 不等于空就执行
            transmit_data2?.Invoke(this,new transmitEventArgs{ data = dataTmp});
            //异步线程更新UI
            Invoke(new EventHandler(delegate
            {
                recv_count.Text = recvCount.ToString();//更新计数
                if (!r_hex.Checked)
                {
                    string s = Encoding.GetEncoding("UTF-8").GetString(dataTmp);
                    s = s.Replace("\0","\\0");
                    recv_box.AppendText(s);
                }
                else
                {
                    recv_box.AppendText(Transform.ToHexString(dataTmp," "));
                }
               
            }));

        }

        /// <summary>
        /// 暂停接收按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void r_stop_Click(object sender, EventArgs e)
        {
            if (isRecv)
            {
                isRecv = false;
                r_stop.Text = "取消暂停";
            }
            else 
            {
                isRecv=true;
                r_stop.Text = "暂停";
            }
        }

        /// <summary>
        /// 接收切换Hex UI更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void r_hex_CheckedChanged(object sender, EventArgs e)
        {
            if(recv_box == null)
            {
                return;
            }
            if(r_hex.Checked)
            {
                recv_box.Text = Transform.ToHexString(RecvBuff.ToArray()," ");
            }
            else
            {
                recv_box.Text = Encoding.GetEncoding("UTF-8").GetString(RecvBuff.ToArray()).Replace("\0","\\0");
            }
        }

        /// <summary>
        /// 手动清空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void manual_clear_Click(object sender, EventArgs e)
        {
            RecvBuff.Clear();
            recv_box.Text = "";
            recvCount = 0;
        }
        /// <summary>
        /// 自动清空 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void auto_clear_CheckedChanged(object sender, EventArgs e)
        {
            if(auto_clear.Checked)
            {
                clearTimer.Start();// 开启定时
            }
            else
            {
                clearTimer.Stop(); // 关闭定时
            }
        }

        /// <summary>
        /// 定时器触发清空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearTimer_Tick(object sender, EventArgs e)
        {
            if(recv_box.Text.Length > 500)
            {
                RecvBuff.Clear();
                recv_box.Text = "";
                recvCount = 0;
            }
        }


        /// <summary>
        /// 发送框焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void send_box_Leave(object sender, EventArgs e)
        {
            if(s_hex.Checked) // 选择以Hex发送
            {
                if(DataEncoding.IsHexString(send_box.Text.Replace(" ", "")))
                {
                    SendBuff.Clear();
                    SendBuff.AddRange(Transform.ToBytes(send_box.Text.Replace(" ","")));

                }
                else
                {
                    MessageBox.Show("请输入正确的十六进制数据 !","警告");
                    send_box.Select();
                }
            }
            else
            {
                SendBuff.Clear();
                SendBuff.AddRange(Encoding.GetEncoding("UTF-8").GetBytes(send_box.Text));
            }
        }
        /// <summary>
        /// 发送框数据改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void send_box_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 发送Hex切换 更新UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void s_hex_CheckedChanged(object sender, EventArgs e)
        {
            if(send_box.Text == "")
            {
                return;
            }
            if (s_hex.Checked)
            {
                send_box.Text = Transform.ToHexString(SendBuff.ToArray()," ");
            }
            else
            {
                send_box.Text = Encoding.GetEncoding("UTF-8").GetString(SendBuff.ToArray()).Replace("\0","\\0");
            }
        }

        /// <summary>
        /// 清空发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void s_clear_Click(object sender, EventArgs e)
        {
            SendBuff.Clear();
            send_box.Text = "";
            sendCount = 0;
        }

        /// <summary>
        /// 清空计数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clear_count_Click(object sender, EventArgs e)
        {
            send_count.Text = "0";
            recv_count.Text = "0";
            sendCount = 0;
            recvCount = 0;
        }

        /// <summary>
        /// 自动发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void auto_send_CheckedChanged(object sender, EventArgs e)
        {
            if (!Myserialport.IsOpen)
            {
                MessageBox.Show("不允许的操作 无串口打开!", "警告");
            }
            else
            {
                if (auto_send.Checked)
                {
                    auto_time.Enabled = false;
                    manual_send.Enabled = false;
                    int i = Convert.ToInt32(auto_time.Text);
                    if(i < 10 || i > 60 * 1000)
                    {
                        i = 1000;
                        auto_time.Text = "1000";
                        MessageBox.Show("允许值为(10~60000)","警告");
                    }
                    sendtimer.Interval = i;
                    sendtimer.Start();
                }
                else
                {
                    auto_time.Enabled = true;
                    manual_send.Enabled = true;
                    sendtimer.Stop();
                }
                
            }
        }

        private void sendtimer_Tick(object sender, EventArgs e)
        {
            if (send_box.Text == "")
            {
                Console.WriteLine("请先输入发送数据!");
            }
            else
            {
                // Myserialport.Write(send_box.Text); // 不加缓冲和处理的简单发送
                sendData();
            }
        }
    }
}
