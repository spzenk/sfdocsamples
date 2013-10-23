using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace AsimetricSimetricSample
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private RSATest _objKey = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            _objKey = new RSATest();
        }

        private void btnAsimEncriptar_Click(object sender, EventArgs e)
        {
            byte[] _bytEncriptado = null;

            //Creamos una instancia del encritador publico 
            RSACryptoServiceProvider _objEncriptadorPublico = new RSACryptoServiceProvider();
            //Le asignamos la llave genarada 
            _objEncriptadorPublico.FromXmlString(this.txtAsimLlavePublica.Text);

            if (this.chkSimetrica.Checked)
            {
                //Se declara la memoria para almacenar la llave utilizada por nuestro Rijndael personalizado 
                byte[] _bytKey = (Rijndael.Create()).Key;

                //Se encripta el texto y se obtiene la llave que se utilizó para la encriptación 
                byte[] _bytEncriptadoSimetrico = MiRijndael.Encriptar(this.txtAsimAEncriptar.Text, _bytKey);

                //Se encripta la llave con el algoritmo RSA 
                byte[] _bytEncriptadoLlave = _objEncriptadorPublico.Encrypt(_bytKey, false);

                //Se copia en un arreglo la llave encriptada y el encriptado de Rijndael 
                _bytEncriptado = new byte[_bytEncriptadoLlave.Length + _bytEncriptadoSimetrico.Length];
                _bytEncriptadoLlave.CopyTo(_bytEncriptado, 0);
                _bytEncriptadoSimetrico.CopyTo(_bytEncriptado, _bytEncriptadoLlave.Length);
            }
            else
            {
                _bytEncriptado = _objEncriptadorPublico.Encrypt(System.Text.Encoding.UTF8.GetBytes(this.txtAsimAEncriptar.Text), false);
            }
            this.txtAsimEncriptado.Text = Convert.ToBase64String(_bytEncriptado);
        }

        private void btnAsimGenerar_Click(object sender, EventArgs e)
        {
            this.txtAsimLlavePublica.Text = this._objKey.ObtenerLlavePublica();
        }

        private void btnAsimDesEncriptar_Click(object sender, EventArgs e)
        {
            this.txtAsimDesEncriptado.Text = this._objKey.DesEncriptar(Convert.FromBase64String
(this.txtAsimEncriptado.Text), this.chkSimetrica.Checked);
        }
    }
}
