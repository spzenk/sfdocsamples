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
    public partial class BaseComboCheck : XtraUserControl
    {
        public BaseComboCheck()
        {
            InitializeComponent();
        }

        #region ComboEditValueChanged
        public event EventHandler _ComboEditValueChanged;
        protected virtual void On_ComboEditValueChanged(object sender, EventArgs e)
        {
            if (_ComboEditValueChanged != null)
            {
                _ComboEditValueChanged(sender, e);
            }

        }
        private void baseCombo1__ComboEditValueChanged(object sender, EventArgs e)
        {
            On_ComboEditValueChanged(sender, e);
        }
        
        #endregion    

        private Boolean ShowCheck;

        public virtual Boolean _ShowCheck
        {
            get { return ShowCheck; }
            set { 
                    ShowCheck = value;
                    baseLabel1._Visible = !value;
                    baseCheck1._Visible = value;
                    baseCheck1.TabStop = value;
                    //baseCheck1._Checked = true;
            }
        }

        public Boolean _Checked
        {
            get { return baseCheck1._Checked; }
            set { 
                    baseCheck1._Checked = value;
                    baseCombo1.lookUpEdit1.Enabled = value;
                }
        }

        public Boolean _VisibleLabels
        {
            get { return baseLabel1._Visible; }
            set { 
                    baseCheck1._Visible = !value;
                    baseLabel1._Visible = value;
                }
        }

        public String _text
        {
            get { return baseLabel1._Text; }
            set { baseLabel1._Text = value; baseCheck1._Text = value; }
        }

        private void baseLabel1_Load(object sender, EventArgs e)
        {
           
        }

        private void baseCheck1__CheckedChanged(object sender, EventArgs e)
        {
            _Checked = baseCheck1._Checked;
        }

        public int _TabIndex
        {
            get { return baseCombo1._TabIndex; }
            set {
                    baseCombo1._TabIndex = value;     
                    this.TabIndex = value + 100;
                    this.baseLabel1._TabIndex = value + 101;
                    this.baseCheck1._TabIndex = value + 102;
                }
        }

        public Boolean _Enabled
        {
            get { return baseCombo1._Enabled; }
            set { baseCombo1._Enabled = value; 
                this.Enabled = value;
                baseLabel1._Enabled = value; 
                baseCheck1._Enabled = value;
                baseCombo1.TabStop = value;
                }
        }

        public float _FontSize
        {
            get { return baseLabel1._FontSize; 
                }
            set { 
                    baseLabel1._FontSize = value;
                    baseCheck1._FontSize = value;
                    baseCombo1._FontSize = value;
                }
        }

        // public Size _SizeCombo
        //{
        //    get { return baseCombo1.Size; }
        //    set { baseCombo1.Size = value; }
        //}

        private Boolean CheckEditingABM;
        public Boolean _CheckEditingABM
        {
            get { return CheckEditingABM; }
            set { CheckEditingABM = value; }
        }

        private Boolean CheckEditingABMValue;
        public Boolean _CheckEditingABMValue
        {
            get { return CheckEditingABMValue; }
            set { CheckEditingABMValue = value; }
        }

        //private Boolean WithTextSelection;
        //[Category("Components"), Description("Agrega texto 'Seleccione' al los item del combo ")]
        //public Boolean _WithTextSelection
        //{
        //    get { return baseCombo1._WithTextSelection; }
        //    set { baseCombo1._WithTextSelection = value; }
        //}

        private void baseCheck1_Load(object sender, EventArgs e)
        {
           
        }     

    }
}
