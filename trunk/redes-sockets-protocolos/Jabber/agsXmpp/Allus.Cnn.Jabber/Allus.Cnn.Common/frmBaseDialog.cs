using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.HelperFunctions.Caching;


namespace Allus.Cnn.Common
{
    public partial class frmBaseDialog : frmBase
    {
        //public Fwk.HelperFunctions.Caching.FwkCache _FwkCache=null;
        //public AlertCache _AlertCache = null;

        public frmBaseDialog()
        {
            InitializeComponent();
        }

        void Init()
        {
            
            //_FwkCache = new FwkCache();

            //_AlertCache = (AlertCache)_FwkCache.GetItemFromCache("AlertInfo_");

            //if (_AlertCache == null)
            //{
            //    _AlertCache = new AlertCache();
            //}

        }
        public void ForceClose()
        {
            //if (_FwkCache != null)
            //{
            //    _FwkCache.RemoveItem("AlertCache");
            //    _FwkCache.SaveItemInCache("AlertCache", _AlertCache);
            //}

            this.Close();

        }

        private void frmBaseDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
