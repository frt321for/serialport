using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace serialport
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.open_or_close = new System.Windows.Forms.Button();
            this.stop_bit = new System.Windows.Forms.ComboBox();
            this.data_bit = new System.Windows.Forms.ComboBox();
            this.baud_rate = new System.Windows.Forms.ComboBox();
            this.parity_type = new System.Windows.Forms.ComboBox();
            this.port_num = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.r_stop = new System.Windows.Forms.Button();
            this.manual_clear = new System.Windows.Forms.Button();
            this.r_hex = new System.Windows.Forms.CheckBox();
            this.auto_clear = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.s_clear = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.auto_time = new System.Windows.Forms.TextBox();
            this.auto_send = new System.Windows.Forms.CheckBox();
            this.manual_send = new System.Windows.Forms.Button();
            this.s_hex = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.recv_box = new System.Windows.Forms.RichTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.send_box = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.current_state = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.send_count = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.recv_count = new System.Windows.Forms.ToolStripStatusLabel();
            this.Myserialport = new System.IO.Ports.SerialPort(this.components);
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.clear_count = new System.Windows.Forms.Button();
            this.clearTimer = new System.Windows.Forms.Timer(this.components);
            this.sendtimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.open_or_close);
            this.groupBox1.Controls.Add(this.stop_bit);
            this.groupBox1.Controls.Add(this.data_bit);
            this.groupBox1.Controls.Add(this.baud_rate);
            this.groupBox1.Controls.Add(this.parity_type);
            this.groupBox1.Controls.Add(this.port_num);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(213, 219);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "串口配置";
            // 
            // open_or_close
            // 
            this.open_or_close.BackColor = System.Drawing.SystemColors.Window;
            this.open_or_close.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.open_or_close.Location = new System.Drawing.Point(18, 174);
            this.open_or_close.Margin = new System.Windows.Forms.Padding(2);
            this.open_or_close.Name = "open_or_close";
            this.open_or_close.Size = new System.Drawing.Size(178, 33);
            this.open_or_close.TabIndex = 2;
            this.open_or_close.Text = "打开串口";
            this.open_or_close.UseVisualStyleBackColor = false;
            this.open_or_close.Click += new System.EventHandler(this.open_or_close_Click);
            // 
            // stop_bit
            // 
            this.stop_bit.FormattingEnabled = true;
            this.stop_bit.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.stop_bit.Location = new System.Drawing.Point(69, 147);
            this.stop_bit.Margin = new System.Windows.Forms.Padding(2);
            this.stop_bit.Name = "stop_bit";
            this.stop_bit.Size = new System.Drawing.Size(127, 24);
            this.stop_bit.TabIndex = 1;
            // 
            // data_bit
            // 
            this.data_bit.FormattingEnabled = true;
            this.data_bit.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.data_bit.Location = new System.Drawing.Point(69, 117);
            this.data_bit.Margin = new System.Windows.Forms.Padding(2);
            this.data_bit.Name = "data_bit";
            this.data_bit.Size = new System.Drawing.Size(127, 24);
            this.data_bit.TabIndex = 1;
            // 
            // baud_rate
            // 
            this.baud_rate.FormattingEnabled = true;
            this.baud_rate.Items.AddRange(new object[] {
            "4800",
            "9600",
            "115200"});
            this.baud_rate.Location = new System.Drawing.Point(69, 55);
            this.baud_rate.Margin = new System.Windows.Forms.Padding(2);
            this.baud_rate.Name = "baud_rate";
            this.baud_rate.Size = new System.Drawing.Size(127, 24);
            this.baud_rate.TabIndex = 1;
            // 
            // parity_type
            // 
            this.parity_type.FormattingEnabled = true;
            this.parity_type.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd"});
            this.parity_type.Location = new System.Drawing.Point(69, 85);
            this.parity_type.Margin = new System.Windows.Forms.Padding(2);
            this.parity_type.Name = "parity_type";
            this.parity_type.Size = new System.Drawing.Size(127, 24);
            this.parity_type.TabIndex = 1;
            // 
            // port_num
            // 
            this.port_num.FormattingEnabled = true;
            this.port_num.Location = new System.Drawing.Point(69, 23);
            this.port_num.Margin = new System.Windows.Forms.Padding(2);
            this.port_num.Name = "port_num";
            this.port_num.Size = new System.Drawing.Size(127, 24);
            this.port_num.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 149);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "停止位";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 119);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "数据位";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "波特率";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 87);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "校验位";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "端口号";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.r_stop);
            this.groupBox2.Controls.Add(this.manual_clear);
            this.groupBox2.Controls.Add(this.r_hex);
            this.groupBox2.Controls.Add(this.auto_clear);
            this.groupBox2.Location = new System.Drawing.Point(4, 229);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(213, 148);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "接收配置";
            // 
            // r_stop
            // 
            this.r_stop.Location = new System.Drawing.Point(97, 80);
            this.r_stop.Margin = new System.Windows.Forms.Padding(2);
            this.r_stop.Name = "r_stop";
            this.r_stop.Size = new System.Drawing.Size(98, 31);
            this.r_stop.TabIndex = 3;
            this.r_stop.Text = "暂停";
            this.r_stop.UseVisualStyleBackColor = true;
            this.r_stop.Click += new System.EventHandler(this.r_stop_Click);
            // 
            // manual_clear
            // 
            this.manual_clear.Location = new System.Drawing.Point(97, 32);
            this.manual_clear.Margin = new System.Windows.Forms.Padding(2);
            this.manual_clear.Name = "manual_clear";
            this.manual_clear.Size = new System.Drawing.Size(98, 31);
            this.manual_clear.TabIndex = 3;
            this.manual_clear.Text = "手动清空";
            this.manual_clear.UseVisualStyleBackColor = true;
            this.manual_clear.Click += new System.EventHandler(this.manual_clear_Click);
            // 
            // r_hex
            // 
            this.r_hex.AutoSize = true;
            this.r_hex.Location = new System.Drawing.Point(15, 85);
            this.r_hex.Margin = new System.Windows.Forms.Padding(2);
            this.r_hex.Name = "r_hex";
            this.r_hex.Size = new System.Drawing.Size(53, 20);
            this.r_hex.TabIndex = 0;
            this.r_hex.Text = "HEX";
            this.r_hex.UseVisualStyleBackColor = true;
            this.r_hex.CheckedChanged += new System.EventHandler(this.r_hex_CheckedChanged);
            // 
            // auto_clear
            // 
            this.auto_clear.AutoSize = true;
            this.auto_clear.Location = new System.Drawing.Point(10, 39);
            this.auto_clear.Margin = new System.Windows.Forms.Padding(2);
            this.auto_clear.Name = "auto_clear";
            this.auto_clear.Size = new System.Drawing.Size(93, 20);
            this.auto_clear.TabIndex = 0;
            this.auto_clear.Text = "自动清空";
            this.auto_clear.UseVisualStyleBackColor = true;
            this.auto_clear.CheckedChanged += new System.EventHandler(this.auto_clear_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.s_clear);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.auto_time);
            this.groupBox3.Controls.Add(this.auto_send);
            this.groupBox3.Controls.Add(this.manual_send);
            this.groupBox3.Controls.Add(this.s_hex);
            this.groupBox3.Location = new System.Drawing.Point(4, 381);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(213, 176);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "发送配置";
            // 
            // s_clear
            // 
            this.s_clear.Location = new System.Drawing.Point(97, 92);
            this.s_clear.Margin = new System.Windows.Forms.Padding(2);
            this.s_clear.Name = "s_clear";
            this.s_clear.Size = new System.Drawing.Size(98, 29);
            this.s_clear.TabIndex = 3;
            this.s_clear.Text = "清空发送";
            this.s_clear.UseVisualStyleBackColor = true;
            this.s_clear.Click += new System.EventHandler(this.s_clear_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 142);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "自动发送周期(ms)";
            // 
            // auto_time
            // 
            this.auto_time.Location = new System.Drawing.Point(140, 139);
            this.auto_time.Margin = new System.Windows.Forms.Padding(2);
            this.auto_time.Name = "auto_time";
            this.auto_time.Size = new System.Drawing.Size(62, 26);
            this.auto_time.TabIndex = 4;
            this.auto_time.Text = "1000";
            // 
            // auto_send
            // 
            this.auto_send.AutoSize = true;
            this.auto_send.Location = new System.Drawing.Point(8, 54);
            this.auto_send.Margin = new System.Windows.Forms.Padding(2);
            this.auto_send.Name = "auto_send";
            this.auto_send.Size = new System.Drawing.Size(93, 20);
            this.auto_send.TabIndex = 0;
            this.auto_send.Text = "自动发送";
            this.auto_send.UseVisualStyleBackColor = true;
            this.auto_send.CheckedChanged += new System.EventHandler(this.auto_send_CheckedChanged);
            // 
            // manual_send
            // 
            this.manual_send.Location = new System.Drawing.Point(97, 47);
            this.manual_send.Margin = new System.Windows.Forms.Padding(2);
            this.manual_send.Name = "manual_send";
            this.manual_send.Size = new System.Drawing.Size(98, 31);
            this.manual_send.TabIndex = 3;
            this.manual_send.Text = "手动发送";
            this.manual_send.UseVisualStyleBackColor = true;
            this.manual_send.Click += new System.EventHandler(this.manual_send_Click);
            // 
            // s_hex
            // 
            this.s_hex.AutoSize = true;
            this.s_hex.Location = new System.Drawing.Point(15, 101);
            this.s_hex.Margin = new System.Windows.Forms.Padding(2);
            this.s_hex.Name = "s_hex";
            this.s_hex.Size = new System.Drawing.Size(53, 20);
            this.s_hex.TabIndex = 0;
            this.s_hex.Text = "HEX";
            this.s_hex.UseVisualStyleBackColor = true;
            this.s_hex.CheckedChanged += new System.EventHandler(this.s_hex_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.recv_box);
            this.groupBox4.Location = new System.Drawing.Point(222, 9);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(528, 341);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "接收区";
            // 
            // recv_box
            // 
            this.recv_box.BackColor = System.Drawing.SystemColors.Info;
            this.recv_box.Location = new System.Drawing.Point(5, 18);
            this.recv_box.Margin = new System.Windows.Forms.Padding(2);
            this.recv_box.Name = "recv_box";
            this.recv_box.ReadOnly = true;
            this.recv_box.Size = new System.Drawing.Size(519, 314);
            this.recv_box.TabIndex = 0;
            this.recv_box.Text = "";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.send_box);
            this.groupBox5.Location = new System.Drawing.Point(222, 355);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(528, 202);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "发送区";
            // 
            // send_box
            // 
            this.send_box.BackColor = System.Drawing.SystemColors.Info;
            this.send_box.Location = new System.Drawing.Point(5, 17);
            this.send_box.Margin = new System.Windows.Forms.Padding(2);
            this.send_box.Name = "send_box";
            this.send_box.Size = new System.Drawing.Size(519, 171);
            this.send_box.TabIndex = 0;
            this.send_box.Text = "";
            this.send_box.TextChanged += new System.EventHandler(this.send_box_TextChanged);
            this.send_box.Leave += new System.EventHandler(this.send_box_Leave);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.current_state,
            this.toolStripStatusLabel3,
            this.send_count,
            this.toolStripStatusLabel5,
            this.recv_count});
            this.statusStrip1.Location = new System.Drawing.Point(0, 624);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 11, 0);
            this.statusStrip1.Size = new System.Drawing.Size(782, 28);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(60, 21);
            this.toolStripStatusLabel1.Text = "状态:";
            // 
            // current_state
            // 
            this.current_state.AutoSize = false;
            this.current_state.Name = "current_state";
            this.current_state.Size = new System.Drawing.Size(150, 21);
            this.current_state.Text = "X";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.AutoSize = false;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(70, 21);
            this.toolStripStatusLabel3.Text = "发送计数";
            // 
            // send_count
            // 
            this.send_count.AutoSize = false;
            this.send_count.Name = "send_count";
            this.send_count.Size = new System.Drawing.Size(80, 21);
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.AutoSize = false;
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(70, 21);
            this.toolStripStatusLabel5.Text = "接收计数";
            // 
            // recv_count
            // 
            this.recv_count.AccessibleDescription = "";
            this.recv_count.AutoSize = false;
            this.recv_count.Name = "recv_count";
            this.recv_count.Size = new System.Drawing.Size(80, 21);
            // 
            // Myserialport
            // 
            this.Myserialport.PortName = "COM5";
            this.Myserialport.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.Myserialport_DataReceived);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.clear_count);
            this.groupBox6.Location = new System.Drawing.Point(4, 562);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(766, 45);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            // 
            // clear_count
            // 
            this.clear_count.Location = new System.Drawing.Point(8, 13);
            this.clear_count.Name = "clear_count";
            this.clear_count.Size = new System.Drawing.Size(105, 32);
            this.clear_count.TabIndex = 0;
            this.clear_count.Text = "清空计数";
            this.clear_count.UseVisualStyleBackColor = true;
            this.clear_count.Click += new System.EventHandler(this.clear_count_Click);
            // 
            // clearTimer
            // 
            this.clearTimer.Tick += new System.EventHandler(this.clearTimer_Tick);
            // 
            // sendtimer
            // 
            this.sendtimer.Tick += new System.EventHandler(this.sendtimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 652);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(800, 700);
            this.MinimumSize = new System.Drawing.Size(800, 700);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "串口助手";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox port_num;
        private Label label1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private Button open_or_close;
        private ComboBox stop_bit;
        private ComboBox data_bit;
        private ComboBox baud_rate;
        private ComboBox parity_type;
        private Label label5;
        private Label label4;
        private Label label2;
        private Label label3;
        private Button r_stop;
        private Button manual_clear;
        private CheckBox r_hex;
        private CheckBox auto_clear;
        private Button s_clear;
        private CheckBox auto_send;
        private Button manual_send;
        private CheckBox s_hex;
        private Label label6;
        private TextBox auto_time;
        private RichTextBox recv_box;
        private RichTextBox send_box;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel current_state;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private ToolStripStatusLabel send_count;
        private ToolStripStatusLabel toolStripStatusLabel5;
        private ToolStripStatusLabel recv_count;
        private System.IO.Ports.SerialPort Myserialport;
        private GroupBox groupBox6;
        private Timer clearTimer;
        private Button clear_count;
        private Timer sendtimer;
    }
}
