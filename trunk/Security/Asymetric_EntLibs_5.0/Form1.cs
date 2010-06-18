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

namespace Asymetric_EntLibs_5_0
{
    public partial class Form1 : Form
    {
        static string symmKeyFileName = "seckey.key";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            //txtCifrado.Text = Cryptographer.EncryptSymmetric("RijndaelManaged", txtValorOriginal.Text);

            if (GetSymmetricCryptoProvider())
            {
                byte[] decryptedBin = Encoding.UTF8.GetBytes(txtValorOriginal.Text);
                txtCifrado.Text = Convert.ToBase64String(_SymmetricAlgorithmProvider.Encrypt(decryptedBin));
            }
        }

        private void btnDEncrypt_Click(object sender, EventArgs e)
        {
            //txtNoCifrado.Text = Cryptographer.DecryptSymmetric("RijndaelManaged", txtCifrado.Text);

            
            if (GetSymmetricCryptoProvider())
            {
                byte[] cryptedBin = Convert.FromBase64String(txtCifrado.Text);
                txtNoCifrado.Text = Encoding.UTF8.GetString(_SymmetricAlgorithmProvider.Decrypt(cryptedBin));
            }
            
        }

        private  void CreateKeys()
        {
            symmKeyFileName = Fwk.HelperFunctions.FileFunctions.OpenFileDialog_New(symmKeyFileName, "Key Files(*.key)|*.key", false);

            
            if (!string.IsNullOrEmpty(symmKeyFileName))
            {
                txtReference.Text = symmKeyFileName;
                ProtectedKey symmetricKey = KeyManager.GenerateSymmetricKey(typeof(RijndaelManaged), DataProtectionScope.LocalMachine);
                using (FileStream keyStream = new FileStream(symmKeyFileName, FileMode.Create))
                {
                    KeyManager.Write(keyStream, symmetricKey);
                }
            }
   
        }

        private void btnKey_Click(object sender, EventArgs e)
        {


            CreateKeys();
           
        }

        SymmetricAlgorithmProvider _SymmetricAlgorithmProvider;
        bool GetSymmetricCryptoProvider()
        {
            if (File.Exists(txtReference.Text))
            {
                
                
                if (_SymmetricAlgorithmProvider == null)

                    _SymmetricAlgorithmProvider = new SymmetricAlgorithmProvider(typeof(RijndaelManaged), txtReference.Text, DataProtectionScope.LocalMachine);
                
                return true;
            }
            else
            {
                MessageBox.Show("No existe un archivo de clave de encriptacion");
                return false;
            }

            
            
            
        }

        
    }
}
