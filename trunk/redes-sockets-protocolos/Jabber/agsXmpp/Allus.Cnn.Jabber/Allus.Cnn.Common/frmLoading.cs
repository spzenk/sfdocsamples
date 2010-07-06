using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Allus.Cnn.Common
{
    public partial class frmLoading : Form
    {
        public frmLoading()
        {
            InitializeComponent();
        }

        private String mTextoEstado;


        public String TextoEstado
        {
            get
            {
                return mTextoEstado;
            }
            set
            {
                lblText.Text = value;
                mTextoEstado = value;
            }
        }
    }
}
