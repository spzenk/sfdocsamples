using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.SocialNetworks.Config;

namespace Fwk.SocialNetworks.Data
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
            txtRes.Text = fp.GetwMessagesList(DateTime.Now.AddDays(-275), comboBox1.SelectedItem.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtRes.Text = fp.Get_stream_post(DateTime.Now.AddDays(-275),comboBox1.SelectedItem.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FacebookProcessor fp = new FacebookProcessor();
            fp.InitSettings();
            User user = fp.GetUser_From_Facebook(textBox1.Text, comboBox1.SelectedItem.ToString());
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
            //StringBuilder s = new StringBuilder(string.Concat("provider   = ", fp.FacebookConfig.DefaultProvider.Name,"\r\n"));

            
            //s.AppendLine(string.Concat("Source Id       = ", fp.FacebookConfig.DefaultProvider.SourceId));
            //s.AppendLine(string.Concat("UserAccessToken = ", fp.FacebookConfig.DefaultProvider.UserAccessToken));
            //s.AppendLine(string.Concat("PageAccessToken = ", fp.FacebookConfig.DefaultProvider.PageAccessToken));


            List<string> ps = new List<string>();
            foreach (FacebookProvider p in FacebookWrapper.Config.Providers)
            {
               ps.Add(p.Name);

            }
            comboBox1.DataSource = ps;
            comboBox1.SelectedIndex = 1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            StringBuilder s = new StringBuilder(string.Concat("selected provider   = ", comboBox1.SelectedItem.ToString(), "\r\n"));


            s.AppendLine(string.Concat("Source Id       = ", FacebookWrapper.Config.Providers[comboBox1.SelectedItem.ToString()].SourceId));
            s.AppendLine(string.Concat("UserAccessToken = ", FacebookWrapper.Config.Providers[comboBox1.SelectedItem.ToString()].UserAccessToken));
            s.AppendLine(string.Concat("PageAccessToken = ", FacebookWrapper.Config.Providers[comboBox1.SelectedItem.ToString()].PageAccessToken));

            textBox2.Text = s.ToString();
        }
    }
}
