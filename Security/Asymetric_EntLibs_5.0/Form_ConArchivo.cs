using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography;
using System.Security.Cryptography;
namespace Symetric_EntLibs_5._0
{
    public partial class Form_ConArchivo : Form
    {
        public Form_ConArchivo()
        {
            InitializeComponent();
        }

        private void btnKey_Click(object sender, EventArgs e)
        {

            Fwk.Security.Cryptography.SymetriCypher<RijndaelManaged> cyfer = Fwk.Security.Cryptography.SymetricCypherFactory.Get<RijndaelManaged>();
            txtKey.Text = cyfer.GeneratetNewK();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            Fwk.Security.Cryptography.SymetriCypher<RijndaelManaged> cyfer = Fwk.Security.Cryptography.SymetricCypherFactory.Get<RijndaelManaged>(txtKey.Text);
            txtCifrado.Text = cyfer.Encrypt(txtNoCifrado.Text);
        }

        private void btnDEncrypt_Click(object sender, EventArgs e)
        {
            Fwk.Security.Cryptography.SymetriCypher<RijndaelManaged> cyfer = Fwk.Security.Cryptography.SymetricCypherFactory.Get<RijndaelManaged>(txtKey.Text);
            txtValorOriginal.Text = cyfer.Dencrypt(txtCifrado.Text);
        }
    }
}
