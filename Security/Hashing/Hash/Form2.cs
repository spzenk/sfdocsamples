using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
              string txtAsimAEncriptar=   HashContraseñas.Get_Credentials_Pathern(txtUserName.Text,txtPassword.Text);
              byte[] bytes_Llegada_To_Hash = HashContraseñas.CreateHash(txtAsimAEncriptar, strSalt, intIteraciones);
              String string_Llegada_To_Hash = Convert.ToBase64String(bytes_Llegada_To_Hash);

              //if (String.Compare(string_Llegada_To_Hash,stored_hash)==0)
              //{
              //    MessageBox.Show("El usuario se autentico correctamente");

              //}
              //else
              //    MessageBox.Show("Autenticacion FALLIDA, nombre de usuario o contraseña es invalida");

          
              byte[] bytes_Stored_Hash = System.Text.Encoding.UTF8.GetBytes(stored_hash);

              if (HashContraseñas.CompareByteArray(bytes_Stored_Hash, bytes_Llegada_To_Hash))
              {
                  MessageBox.Show("El usuario se autentico correctamente");

              }
              else
                  MessageBox.Show("Autenticacion FALLIDA, nombre de usuario o contraseña es invalida");

        }
    }
}
