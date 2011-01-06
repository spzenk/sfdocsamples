

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.IO;


namespace RichText
{
    public partial class frmChat : Form
    {


        public frmChat()
        {



            InitializeComponent();

           

        }

        

        private void OutgoingMessage(string msg)
        {
            rtfChat.SelectionColor = Color.Brown;
            rtfChat.SelectionFont = new Font(rtfChat.SelectionFont.FontFamily, rtfChat.SelectionFont.Size, FontStyle.Bold);
            rtfChat.AppendText(String.Concat("Marcelo oviedo", ":", "\r\n"));

            rtfChat.SelectionColor = Color.Black;
            rtfChat.SelectionFont = new Font(rtfChat.SelectionFont.FontFamily, rtfChat.SelectionFont.Size, FontStyle.Regular);
            rtfChat.AppendText(msg);
            rtfChat.AppendText("\r\n");
            rtfChat.ScrollToCaret();
        }

        public void IncomingMessage(string msg)
        {
            rtfChat.SelectionColor = Color.SlateGray;
            rtfChat.SelectionFont = new Font(rtfChat.SelectionFont.FontFamily, rtfChat.SelectionFont.Size, FontStyle.Bold);
            rtfChat.AppendText(String.Concat("Santana " + ": ", "\r\n"));

            rtfChat.SelectionColor = Color.Black;
            rtfChat.SelectionFont = new Font(rtfChat.SelectionFont.FontFamily, rtfChat.SelectionFont.Size, FontStyle.Regular);
            rtfChat.AppendText(msg);
            rtfChat.AppendText("\r\n");
            rtfChat.ScrollToCaret();
        }


        static char[] Delimiters = new char[] { '\r', '\n' };
        private void rtfSend_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {




                rtfSend.Lines = rtfSend.Text.Split(Delimiters, StringSplitOptions.RemoveEmptyEntries);

                //if (string.IsNullOrEmpty(rtfSend.Text.Replace("\n",string.Empty))) return;
                if (string.IsNullOrEmpty(rtfSend.Text)) return;



                OutgoingMessage(rtfSend.Text);
                rtfSend.Text = string.Empty;
            }
        }


        private void cmdSend_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(rtfSend.Text.Replace("\n", string.Empty))) return;
            


           
            OutgoingMessage(rtfSend.Text);
            rtfSend.Text = string.Empty;
            rtfSend.Focus();
        }

     



      


     
     
    }
}
