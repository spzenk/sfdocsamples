using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace Asymetric_1
{
    public partial class Form1 : Form
    {
        private RSACryptoServiceProvider alg;

        public Form1()
        {
            InitializeComponent();
            alg = new RSACryptoServiceProvider();
        }

        /// <summary>
        /// Generar la información de las llaves y la haremos persistir en un archivo xml.
        /// </summary>
        /// <param name="archivo"></param>
        private void CrearLlave(string archivo)
        {
            //true = incluye también la llave privada
            //false = exclusivamente contendrá la llave pública
            string llave = alg.ToXmlString(true);
            FileStream fs = new FileStream(archivo, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(llave);
            sw.Close();
        }

        private void CargarLlave(string archivo)
        {
            alg = new RSACryptoServiceProvider();
            string xmlKeys =  Fwk.HelperFunctions.FileFunctions.OpenTextFile(archivo);
            alg.FromXmlString(xmlKeys);

        }
    
        private string Encriptar(string decryptedText)
        {
            CrearLlave("key.xml");
            byte[] decryptedBin = Encoding.UTF8.GetBytes(decryptedText);
            byte[]  output = alg.Encrypt(decryptedBin, false);
            return Convert.ToBase64String(output); 
        }
    

        private string Desencriptar(string cryptedText)
        {
            CargarLlave("key.xml");
            byte[] cryptedBin = Convert.FromBase64String(cryptedText);
            byte[] output = alg.Decrypt(cryptedBin, false);
            return Encoding.UTF8.GetString(output);
          
        }



        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            txtCifrado.Text = Encriptar(textValor.Text);
        }

        private void btnDEncrypt_Click(object sender, EventArgs e)
        {
           txtNoCifrado.Text = Desencriptar(txtCifrado.Text);
        }

        private void txtCifrado_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtNoCifrado_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
