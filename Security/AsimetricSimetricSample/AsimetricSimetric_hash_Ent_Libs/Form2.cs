using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AsimetricSimetric_hash_Ent_Libs;

namespace AsimetricSimetric_Client
{
    public partial class Form2 : Form
    {
        public string strSalt { get; set; }
        public int intIteraciones { get; set; }
        public string username { get; set; }
        public string pwd { get; set; }
        public string stored_hash { get; set; }
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            txtHashEncriptado.Text = stored_hash;
            txtPassword.Text = pwd;
            txtUserName.Text = username;
        }

        private void btnAsimEncriptar_Click(object sender, EventArgs e)
        {
            string txt=HashPasswords.Get_Credentials_Pathern(txtUserName.Text,txtPassword.Text);
            bool isValid = HashPasswords.CompararHash(txt, txtHashEncriptado.Text);





            if (isValid)
              {
                  MessageBox.Show("El usuario se autentico correctamente");

              }
              else
                  MessageBox.Show("Autenticacion FALLIDA, nombre de usuario o contraseña es invalida");

        }
    }
}
