using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography;
using AsimetricSimetric_Client;

namespace AsimetricSimetric_hash_Ent_Libs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAsimEncriptar_Click(object sender, EventArgs e)
        {
            txtHashValue.Text = HashPasswords.CreateHash(txtUserName.Text,txtPassword.Text);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Form2 f = new Form2())
            {
                
              
                f.username = txtUserName.Text;
                f.stored_hash = txtHashValue.Text;
                f.pwd = txtPassword.Text;
                f.ShowDialog();
            }
        }
    }
}
