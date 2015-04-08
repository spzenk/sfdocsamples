using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace BaseComponents1
{
    public partial class BaseComboCheckActive : BaseComboCheck
    {
        public BaseComboCheckActive()
        {
            InitializeComponent();
        }

        private Boolean ShowActiveFlag = false;
        public Boolean _ShowActiveFlag
        {
            get { return ShowActiveFlag; }
            set { ShowActiveFlag = value;
            baseCheck2._Visible = value;
            baseCheck2.TabStop = value;
            }
        }

        public Boolean _ActiveFlagChecked
        {
            set { baseCheck2._Checked = value;}
            get { return baseCheck2._Checked; }
        }


        #region CheckedChanged
        public event EventHandler _ActiveFlagCheckedChanged;
        protected virtual void On_ActiveFlagCheckedChanged(object sender, EventArgs e)
        {
            if (_ActiveFlagCheckedChanged != null)
            {
                _ActiveFlagCheckedChanged(sender, e);
            }

        }
        private void baseCheck2__CheckedChanged(object sender, EventArgs e)
        {
            On_ActiveFlagCheckedChanged(sender, e);
         
        }




        #endregion   
      

       
    }
}
