using System;   
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography;
using System.IO;
using System.Security.Cryptography;
using Fwk.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography.Configuration;
using Symetric_EntLibs_5._0;

namespace Asymetric_EntLibs_5_0
{
    public partial class Form1 : Form
    {
        //static string symmKeyFileName = "seckey.key";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            ISymetriCypher wISymetriCypher = SymetricCypherFactory.Get<RijndaelManaged>(txtReference.Text);
            txtCifrado.Text = wISymetriCypher.Encrypt(txtValorOriginal.Text);
          
        }

        private void btnDEncrypt_Click(object sender, EventArgs e)
        {
           
            ISymetriCypher wISymetriCypher = SymetricCypherFactory.Get<RijndaelManaged>(txtReference.Text);
            txtNoCifrado.Text = wISymetriCypher.Dencrypt(txtCifrado.Text);
         
        }

        private  void CreateKeys()
        {


        }

        private void btnKey_Click(object sender, EventArgs e)
        {


            ISymetriCypher wISymetriCypher = SymetricCypherFactory.Get<RijndaelManaged>(txtReference.Text);

            txtReference.Text = wISymetriCypher.CreateKeyFile();

        }

        //SymmetricAlgorithmProvider _SymmetricAlgorithmProvider;
        //bool GetSymmetricCryptoProvider()
        //{
        //    if (File.Exists(txtReference.Text))
        //    {

        //        FileStream fs = new FileStream(txtReference.Text, FileMode.Open, FileAccess.Read);
        //        if (_SymmetricAlgorithmProvider == null)

        //            //_SymmetricAlgorithmProvider = new SymmetricAlgorithmProvider(typeof(RijndaelManaged), txtReference.Text, DataProtectionScope.LocalMachine);
        //            _SymmetricAlgorithmProvider = new SymmetricAlgorithmProvider(typeof(RijndaelManaged), fs, DataProtectionScope.LocalMachine);
              
        //        return true;
        //    }
        //    else
        //    {
        //        MessageBox.Show("No existe un archivo de clave de encriptacion");
        //        return false;
        //    }

            
            
            
        //}

        
    }
}
