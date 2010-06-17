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
            txtCifrado.Text = Cryptographer.EncryptSymmetric("RijndaelManaged", txtValorOriginal.Text);

        }

        private void btnDEncrypt_Click(object sender, EventArgs e)
        {
            txtNoCifrado.Text = Cryptographer.DecryptSymmetric("RijndaelManaged", txtCifrado.Text);

        }

        private  void CreateKeys()
        {
            symmKeyFileName = Fwk.HelperFunctions.FileFunctions.OpenFileDialog_New(symmKeyFileName, "Key Files(*.key)|*.key", false);

            //if (!Path.GetExtension(symmKeyFileName).Equals("key", StringComparison.OrdinalIgnoreCase))
            //{ 
                
            //}
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
    }
}
