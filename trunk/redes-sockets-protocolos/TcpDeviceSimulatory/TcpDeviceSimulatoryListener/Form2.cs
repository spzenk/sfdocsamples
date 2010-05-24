using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using Common;


namespace TcpDeviceSimulatoryListener
{
	/// <summary>
	/// Summary description for Form2.
	/// </summary>
	public class Form2 : System.Windows.Forms.Form
	{
		private ThreadStart ethernetThreadStart = null;
		private Thread pollDevicesEthernetThread = null;
		private TcpListener tcpListener = null;
		private TcpClient tcp = null;
        private bool formClosing = false;
        public bool formClosed = false;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
		private Form1 refToForm1 = null;
		private AutoResetEvent dataReadyToSend = null;
		private byte[] dataToSend = null;
		private System.Windows.Forms.Button buttonSend;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form2(String hostPort, Form1 form1)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			dataReadyToSend = new AutoResetEvent(false);
			refToForm1 = form1;
			// Resolve the local host.
			IPHostEntry localHost = Dns.GetHostEntry(Dns.GetHostName());
			// Create a local end point for listening.
			IPEndPoint localEndPoint = new IPEndPoint(localHost.AddressList[0], 9000);
			// Instantiate the TCP Listener.
			tcpListener = new TcpListener(localEndPoint);
			tcpListener.Start();
			tcp = tcpListener.AcceptTcpClient();
			ethernetThreadStart = new ThreadStart(this.ThreadProcPollOnEthernet);
			pollDevicesEthernetThread = new Thread(ethernetThreadStart);
			pollDevicesEthernetThread.Name = "Listener's Receive Thread";
            pollDevicesEthernetThread.SetApartmentState(System.Threading.ApartmentState.MTA);
			pollDevicesEthernetThread.Start();
		}

		private void ThreadProcPollOnEthernet()
		{
			for (;;)
			{
				Thread.Sleep(100);			
				byte[] msg = new Byte[Constants.maxNoOfBytes];
                byte count1 = 0x01;
                for (int i = 0; i < msg.Length; i++)
                {
                    msg[i] = count1++;
                }
				try
				{
                    if (formClosing == true)
                    {
                        return;
                    }

				    int readBytes = tcp.GetStream().Read(msg,0,msg.Length);
					
					if (readBytes == 8)
					{
						StringBuilder shutMessage = new StringBuilder(8);
						for (int count = 0; count < 8; count++)
						{
							char ch = (char)msg[count];
							shutMessage = shutMessage.Append(ch);
						}
						string shut = "shutdown";
						string receivedMessage = shutMessage.ToString();
						if (receivedMessage.Equals(shut))
						{
							MessageBox.Show(this,"Shutdown Request has arrived from the \nconnected party.\nYou cannot send message anymore.\nPlease close the window.","Shut Down Request",MessageBoxButtons.OK,MessageBoxIcon.Information);
							buttonSend.Enabled = false;
							return;
						}
					}

                    StringBuilder str = new StringBuilder(Constants.maxNoOfBytes);
                    for (int count = 0; count < readBytes ; count++)
                    {
						char ch = (char)msg[count];
                        str = str.Append(ch);
                        str = str.Append(" ");
                    }
                    textBox1.Text = str.ToString();                    
				}
				catch (IOException)
				{
					return;
				}
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.buttonSend = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(32, 40);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox1.Size = new System.Drawing.Size(248, 56);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 19);
			this.label1.TabIndex = 1;
			this.label1.Text = "Incoming Message";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(32, 112);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 20);
			this.label2.TabIndex = 2;
			this.label2.Text = "Outgoing Message";
			// 
			// textBox2
			// 
			this.textBox2.AcceptsReturn = true;
			this.textBox2.Location = new System.Drawing.Point(32, 136);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox2.Size = new System.Drawing.Size(224, 72);
			this.textBox2.TabIndex = 3;
			this.textBox2.Text = "";
			this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
			// 
			// buttonSend
			// 
			this.buttonSend.Location = new System.Drawing.Point(40, 224);
			this.buttonSend.Name = "buttonSend";
			this.buttonSend.TabIndex = 4;
			this.buttonSend.Text = "Send";
			this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
			// 
			// Form2
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(336, 269);
			this.Controls.Add(this.buttonSend);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "Form2";
			this.Text = "Listener Data Form";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Form2_Closing);
			this.ResumeLayout(false);

		}
		#endregion

		private void Form2_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			dataToSend = new byte[]{(byte)'s',(byte)'h',(byte)'u',(byte)'t',(byte)'d',(byte)'o',(byte)'w',(byte)'n'};
			tcp.GetStream().Write(dataToSend,0,dataToSend.Length);
			tcpListener.Stop();
            formClosed = true;
			refToForm1.Close();
		}

		private void textBox2_TextChanged(object sender, System.EventArgs e)
		{
			dataReadyToSend.Set();
		}

		private void buttonSend_Click(object sender, System.EventArgs e)
		{
			if (textBox2.Text.Length != 0)
			{
				char[] charArray = textBox2.Text.ToCharArray(0,textBox2.Text.Length);
				dataToSend = new byte[textBox2.Text.Length];
				for (int charCount = 0; 
					charCount < textBox2.Text.Length;
					charCount++)
				{
					dataToSend[charCount] = (byte)charArray[charCount];
				}
			}
			else
			{
				dataToSend = new byte[]{(byte)'e',(byte)'m',(byte)'p',(byte)'t',(byte)'y'};
			}
			tcp.GetStream().Write(dataToSend,0,dataToSend.Length);
			textBox2.Text = "";
		}
	}
}
