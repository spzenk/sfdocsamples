using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FwkFtpClient
{
    public partial class Form1 : Form

    {
        int logCount = 0;
        static StringBuilder logs;
        public Form1()
        {
            InitializeComponent();
            logs = new StringBuilder();
            ftpComponent1.OnErrorEvent += new ErrorHandler(ftpComponent1_OnErrorEvent);
            ftpComponent1.OnLoginEvent += new ObjectHandler(ftpComponent1_OnLoginEvent);
            ftpComponent1.OnFileListResivedEvent += new ObjectHandler(ftpComponent1_OnFileListResivedEvent);
            
            
        }

        void ftpComponent1_OnFileListResivedEvent(object sender)
        {
            if (InvokeRequired)
            {

                BeginInvoke(new ObjectHandler(ftpComponent1_OnLoginEvent), new object[] { sender });
                return;
            }
            string[] list = (string[])sender;

        }

        void ftpComponent1_OnLoginEvent(object sender)
        {
            if (InvokeRequired)
            {

                BeginInvoke(new ObjectHandler(ftpComponent1_OnLoginEvent), new object[] { sender });
                return;
            }

            AddLog("Conected to server " + ftpComponent1.FTPServer);
        }

        void ftpComponent1_OnErrorEvent(Exception ex)
        {
            if (InvokeRequired)
            {

                BeginInvoke(new ErrorHandler(ftpComponent1_OnErrorEvent), new object[] { ex });
                return;
            }

            AddLog(ex.Message);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ftp://194.44.214.3/pub/music/Dance/
            //172.22.12.22/
            //ftpComponent1.FTPHost = "194.44.214.3";
            ftpComponent1.FTPServer = "172.22.12.22";

            ftpComponent1.FTPPass = "";
            //ftpComponent1.FTPUser = "";

            ftpComponent1.FTPPort = 21;
            ftpComponent1.Debug = true;


            ftpComponent1.Conect();
        }

        void AddLog(string msg)
        {
            logs.AppendLine();
            logs.AppendLine(".................................");

            logs.AppendLine(string.Concat("(", logCount++, ")   t: ", System.DateTime.Now.ToLongTimeString()));
            logs.AppendLine(msg);
            logs.AppendLine(".................................");

            txtLogs.Text = logs.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ftpComponent1.GetFileList("*.*");
        }
    }
}
