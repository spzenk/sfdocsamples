using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Asymetric_1.Client
{
    public partial class Form1 : Form
   {
        RSACryptoServiceProvider alg;
        public Form1()
        {
            InitializeComponent();
        }

        private string Desencriptar(string cryptedText)
        {
            CargarLlave("key.xml");
            byte[] cryptedBin = Convert.FromBase64String(cryptedText);
            byte[] output = alg.Decrypt(cryptedBin, false);
            return Encoding.UTF8.GetString(output);

        }

        private void btnDEncrypt_Click(object sender, EventArgs e)
        {
            txtNoCifrado.Text = Desencriptar(txtCifrado.Text);
            
        }
        private void CargarLlave(string archivo)
        {
            alg = new RSACryptoServiceProvider();
            string xmlKeys = Fwk.HelperFunctions.FileFunctions.OpenTextFile(archivo);
            alg.FromXmlString(xmlKeys);

        }
    }
}
