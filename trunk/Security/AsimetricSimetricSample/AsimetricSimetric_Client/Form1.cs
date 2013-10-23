using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace AsimetricSimetric_Client
{
    /// <summary>
    /// Para un sistema de almacenamiento de contraseñas de usuario seguro, 
    /// hay que hacer algunas modificaciones a esta función, pero son mínimas. 
    /// Las modificaciones no pasan por cambios en el algoritmo, sino más bien por crear una función para que genere 
    /// Salt randómicos y crear la función para la comparación de las contraseñas.
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAsimEncriptar_Click(object sender, EventArgs e)
        {
            //PasswordDeriveBytes que sirve para realizar de forma automática todo lo anteriormente visto. 
            //En el evento click, además de la llamada a la función detallada de más arriba (HashContraseñas.Encriptar),
            //se crea una instancia de esta clase (PasswordDeriveBytes) y se le especifican los mismos parámetros que estamos utilizando en nuestro algoritmo de Hash (la contraseña, el Salt, el algoritmo SHA256 y la cantidad de iteraciones). Esto hace que en sólo pocas líneas se pueda realizar el mismo proceso.

            PasswordDeriveBytes _objPdb = new PasswordDeriveBytes(this.txtAsimAEncriptar.Text, System.Text.Encoding.UTF8.GetBytes(this.txtSalt.Text), "SHA256", Convert.ToInt32(this.txtIteraciones.Text));
            this.txtHashEncriptado2.Text = Convert.ToBase64String(_objPdb.GetBytes(32));

            byte[] bytes_CriptedData = HashContraseñas.Encriptar(txtAsimAEncriptar.Text, txtSalt.Text, Convert.ToInt32(txtIteraciones.Text));
            this.txtHashEncriptado.Text = Convert.ToBase64String(bytes_CriptedData);

        }
        byte[] _objHashKey = null;

        private void btnAsimGenerar_Click(object sender, EventArgs e)
        {
            this._objHashKey = (new System.Security.Cryptography.DESCryptoServiceProvider()).Key;
            this.lblSalt.Text = "Key : " + Convert.ToBase64String(this._objHashKey);
        }


    }
}
