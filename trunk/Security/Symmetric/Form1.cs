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

namespace Symmetric
{
    public partial class Form1 : Form
    {
       
      
        //SymmetricAlgorithm
        public Form1()
        {
            InitializeComponent();

            
        }

      

        
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            txtCifrado.Text = FwkSymetricAlg.Encrypt(txtValorOriginal.Text);
        }

        private void btnDEncrypt_Click(object sender, EventArgs e)
        {

            txtNoCifrado.Text = FwkSymetricAlg.Dencrypt(txtCifrado.Text);
        }
    }
}
