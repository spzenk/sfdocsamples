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
            string xmlKeys = xmlKeys = Fwk.HelperFunctions.FileFunctions.OpenTextFile(archivo);
            alg.FromXmlString(xmlKeys);

        }

        private string Encriptar(string input)
        {
           return Convert.ToBase64String(Encriptar(System.Text.Encoding.UTF8.GetBytes(input)));
        }
        private byte[] Encriptar(byte[] input)
        {
            CrearLlave("key.xml");
            byte[] output = alg.Encrypt(input, false);
            return output;
        }


        private byte[] Desencriptar(byte[] input)
        {
            CargarLlave("key.xml");
            byte[] output = alg.Decrypt(input, false);
            return output;
        }
        private string Desencriptar(string  input)
        {
            return Convert.ToBase64String(Desencriptar(System.Text.Encoding.UTF8.GetBytes(input)));
        }
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
          
            Encriptar(textValor.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDEncrypt_Click(object sender, EventArgs e)
        {
            Desencriptar(textResultado.Text);
        }
    }
}
