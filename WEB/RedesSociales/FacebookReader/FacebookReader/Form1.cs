using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.SocialNetworks.Facebook.Configuration;

namespace Fwk.SocialNetworks.Facebook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        FacebookProcessor fp = null;
        private void button1_Click(object sender, EventArgs e)
        {
           txtRes.Text = fp.GetwMessagesList(DateTime.Now.AddDays(-275));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtRes.Text = fp.Get_stream_post(DateTime.Now.AddDays(-275));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FacebookProcessor fp = new FacebookProcessor();
            fp.InitSettings();
            User user = fp.GetUser_From_Facebook(textBox1.Text);
            StringBuilder s = new StringBuilder(user.UserName);


            s.AppendLine(string.Concat("User Name = ", user.UserName));
            s.AppendLine(string.Concat("Name = ", user.Name));
            s.AppendLine(string.Concat("ImageUrl = ", user.ImageUrl));
            txtRes.Text = s.ToString();
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            fp = new FacebookProcessor();
            fp.InitSettings();
            StringBuilder s = new StringBuilder(string.Concat("provider   = ", fp.FacebookConfig.DefaultProvider.Name,"\r\n"));

            
            s.AppendLine(string.Concat("Source Id       = ", fp.FacebookConfig.DefaultProvider.SourceId));
            s.AppendLine(string.Concat("UserAccessToken = ", fp.FacebookConfig.DefaultProvider.UserAccessToken));
            s.AppendLine(string.Concat("PageAccessToken = ", fp.FacebookConfig.DefaultProvider.PageAccessToken));

            textBox2.Text = s.ToString();
        }
    }
}
