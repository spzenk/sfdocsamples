using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.Diagnostics;
namespace TcpClientApp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textBoxSendText;
		private System.Windows.Forms.Button buttonConnect;
		private TcpClient tcp = null;
		private string ipAddress ="";
		private Thread receiveThread = null;
		private byte [] received = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxDataToSend;
		private byte[] dataToSend = null;
		private bool formClosing = false;
		private System.Windows.Forms.TextBox textBoxIPAddress;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button buttonSend;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			buttonSend.Enabled = false;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			this.textBoxSendText = new System.Windows.Forms.TextBox();
			this.buttonConnect = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxDataToSend = new System.Windows.Forms.TextBox();
			this.textBoxIPAddress = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.buttonSend = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBoxSendText
			// 
			this.textBoxSendText.Location = new System.Drawing.Point(120, 64);
			this.textBoxSendText.Multiline = true;
			this.textBoxSendText.Name = "textBoxSendText";
			this.textBoxSendText.ReadOnly = true;
			this.textBoxSendText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxSendText.Size = new System.Drawing.Size(248, 64);
			this.textBoxSendText.TabIndex = 3;
			this.textBoxSendText.Text = "";
			// 
			// buttonConnect
			// 
			this.buttonConnect.Location = new System.Drawing.Point(248, 8);
			this.buttonConnect.Name = "buttonConnect";
			this.buttonConnect.TabIndex = 1;
			this.buttonConnect.Text = "Connect";
			this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 24);
			this.label1.TabIndex = 4;
			this.label1.Text = "Incoming Message";
			// 
			// textBoxDataToSend
			// 
			this.textBoxDataToSend.Location = new System.Drawing.Point(120, 160);
			this.textBoxDataToSend.Multiline = true;
			this.textBoxDataToSend.Name = "textBoxDataToSend";
			this.textBoxDataToSend.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxDataToSend.Size = new System.Drawing.Size(248, 72);
			this.textBoxDataToSend.TabIndex = 2;
			this.textBoxDataToSend.Text = "";
			// 
			// textBoxIPAddress
			// 
			this.textBoxIPAddress.Location = new System.Drawing.Point(112, 8);
			this.textBoxIPAddress.Name = "textBoxIPAddress";
			this.textBoxIPAddress.TabIndex = 0;
			this.textBoxIPAddress.Text = "";
			this.textBoxIPAddress.TextChanged += new System.EventHandler(this.textBoxIPAddress_TextChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 32);
			this.label3.TabIndex = 8;
			this.label3.Text = "IP address of the listener";
			// 
			// buttonSend
			// 
			this.buttonSend.Location = new System.Drawing.Point(192, 248);
			this.buttonSend.Name = "buttonSend";
			this.buttonSend.TabIndex = 4;
			this.buttonSend.Text = "Send";
			this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(384, 309);
			this.Controls.Add(this.buttonSend);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBoxIPAddress);
			this.Controls.Add(this.textBoxDataToSend);
			this.Controls.Add(this.textBoxSendText);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonConnect);
			this.Name = "Form1";
			this.Text = "Client";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		public void ThreadProcReceive()
		{
			for (;;)
			{
				received = new byte[1024];
				int readBytes = 0;

				try
				{
					readBytes = tcp.GetStream().Read(received,0,received.Length);
				}
				catch (ObjectDisposedException)
				{
					return;
				}
				if (readBytes == 8)
				{
					StringBuilder shutMessage = new StringBuilder(8);
					for (int count = 0; count < 8; count++)
					{
						char ch = (char)received[count];
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
				StringBuilder str = new StringBuilder(1024);
				for (int count = 0; count < readBytes ; count++)
				{
					char ch = (char)received[count];
					str = str.Append(ch);
					str = str.Append(" ");
				}
				textBoxSendText.Text = str.ToString();
				if (formClosing == true)
				{
					break;
				}
			}
		}
		
		private void buttonConnect_Click(object sender, System.EventArgs e)
		{
			textBoxIPAddress.Enabled = false;
			IPAddress address = IPAddress.Parse(ipAddress);
					
			tcp = new TcpClient((new IPEndPoint(Dns.Resolve(Dns.GetHostName()).AddressList[0],4002)));
			LingerOption lingerOption = new LingerOption(false, 1);
			tcp.LingerState = lingerOption;
			tcp.Connect(new IPEndPoint(Dns.Resolve(ipAddress).AddressList[0],4001));
			buttonSend.Enabled = true;
			((Button)sender).Enabled = false;
			receiveThread = new Thread(new ThreadStart(ThreadProcReceive));
			receiveThread.Name = "Client's Receive Thread";
			receiveThread.ApartmentState = ApartmentState.MTA;
			receiveThread.Start();
		}

		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			dataToSend = new byte[]{(byte)'s',(byte)'h',(byte)'u',(byte)'t',(byte)'d',(byte)'o',(byte)'w',(byte)'n'};
			tcp.GetStream().Write(dataToSend,0,dataToSend.Length);
			tcp.Close();
		}

		private void textBoxIPAddress_TextChanged(object sender, System.EventArgs e)
		{
			ipAddress = textBoxIPAddress.Text;
		}

		private void textBoxPortNumber_TextChanged(object sender, System.EventArgs e)
		{
			
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}

		private void buttonSend_Click(object sender, System.EventArgs e)
		{
			if (textBoxDataToSend.Text.Length != 0)
			{
				char[] charArray = textBoxDataToSend.Text.ToCharArray(0,textBoxDataToSend.Text.Length);
				dataToSend = new byte[textBoxDataToSend.Text.Length];
				for (int charCount = 0; 
					charCount < textBoxDataToSend.Text.Length;
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
			textBoxDataToSend.Text = "";
		}
	}
}
