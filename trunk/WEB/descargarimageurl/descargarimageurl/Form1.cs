using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace descargarimageurl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = @"http://a0.twimg.com/profile_images/1127250143/Dibujo_normal.jpg";

            WebProxy wWebProxy = new WebProxy("proxyallus", 3128);
            wWebProxy.Credentials = new System.Net.NetworkCredential("moviedo", "Lincelin1", "ALLUS-AR");

            //SaveImageFromUrl(url);
            byte[] imageByte = GetImageFromUrl(url, wWebProxy);
        }
        private static byte[] GetImageFromUrl(string url, WebProxy webProxy)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

            req.Proxy = webProxy;
            WebResponse rsp = req.GetResponse();

            Stream st = rsp.GetResponseStream();
            int i = 0;
            List<byte> bList = new List<byte>();
            while (i != -1)
            {
                i = st.ReadByte();
                if (i != -1) bList.Add((byte)i);
            }

            return bList.ToArray();
        }

        private static void SaveImageFromUrl(Stream imageBytes, string fileName)
        {
            System.Drawing.Image Image = System.Drawing.Image.FromStream(imageBytes);
            Image.Save(fileName);
        }

        
    }
}
