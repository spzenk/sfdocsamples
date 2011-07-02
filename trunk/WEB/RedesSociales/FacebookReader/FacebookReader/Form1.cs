using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.SocialNetworks.Facebook.Configuration;

namespace  Fwk.SocialNetworks.Facebook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
      
            FacebookProcessor fp = new FacebookProcessor();

            fp.InitSettings();

           txtRes.Text =  fp.GetwMessagesList(DateTime.Now.AddDays(-275));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FacebookProcessor fp = new FacebookProcessor();
            fp.InitSettings();
            User user =  fp.GetUser_From_Facebook(textBox1.Text);
            StringBuilder s = new StringBuilder (user.UserName);

            
            s.AppendLine(string.Concat("User Name = ", user.UserName));
            s.AppendLine(string.Concat("Name = ", user.Name));
            s.AppendLine(string.Concat("ImageUrl = ",user.ImageUrl));
            txtRes.Text = s.ToString();
        }
    }
}
