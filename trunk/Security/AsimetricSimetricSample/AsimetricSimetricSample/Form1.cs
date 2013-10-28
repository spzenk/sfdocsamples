using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

//http://msdn.microsoft.com/es-es/library/bb972217.aspx#mainSection
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

        /// <summary>
        /// Genera _bytEncriptado: Es unByte[] con el contenido de llavePublica RSA encriptada (bytes) y contenido Encriptado Simetrico 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAsimEncriptar_Click(object sender, EventArgs e)
        {
            byte[] _bytEncriptado = null;
            System.Security.Cryptography.CspParameters csp = new CspParameters();
            csp.KeyContainerName = "pepe";
            //Creamos una instancia del encritador publico 
            RSACryptoServiceProvider _objEncriptadorPublicoRSA = new RSACryptoServiceProvider(csp);
            //Le asignamos la llave genarada 
            _objEncriptadorPublicoRSA.FromXmlString(this.txtAsimLlavePublica.Text);

            if (this.chkSimetrica.Checked)
            {
                //Se declara la memoria para almacenar la llave utilizada por nuestro Rijndael personalizado 
                byte[] _bytKey = (Rijndael.Create()).Key;

                //Se encripta el texto y se obtiene la llave que se utilizó para la encriptación 
                byte[] _contenidoEncriptadoSimetrico = MiRijndael.Encriptar(this.txtAsimAEncriptar.Text, _bytKey);

                //Se encripta la llave con el algoritmo RSA 
                byte[] llaveEncriptadaRSA = _objEncriptadorPublicoRSA.Encrypt(_bytKey, false);

                #region Se copia en un vector la llave encriptada y el contenido encriptado Simetrico (Rijndael)
                _bytEncriptado = new byte[llaveEncriptadaRSA.Length + _contenidoEncriptadoSimetrico.Length];
                llaveEncriptadaRSA.CopyTo(_bytEncriptado, 0);
                _contenidoEncriptadoSimetrico.CopyTo(_bytEncriptado, llaveEncriptadaRSA.Length);
                #endregion

            }
            else
            {
                _bytEncriptado = _objEncriptadorPublicoRSA.Encrypt(System.Text.Encoding.UTF8.GetBytes(this.txtAsimAEncriptar.Text), false);
            }
            this.txtAsimEncriptado.Text = Convert.ToBase64String(_bytEncriptado);

        }

        private void btnAsimGenerar_Click(object sender, EventArgs e)
        {
            this.txtAsimLlavePublica.Text = this._objKey.ObtenerLlavePublica();
        }

        private void btnAsimDesEncriptar_Click(object sender, EventArgs e)
        {
            this.txtAsimDesEncriptado.Text = this._objKey.DesEncriptar(Convert.FromBase64String(this.txtAsimEncriptado.Text), this.chkSimetrica.Checked);
        }
    }
}
