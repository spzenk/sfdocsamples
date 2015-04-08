using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epiron.Front.Bases.Controls
{
    public partial class EP_Button : DevExpress.XtraEditors.BaseButton, IEpironControl
    {
        [Browsable(true)]
        [Category("Epiron")]
        public string TextUICode { get; set; }

        [Browsable(true)]
        [Category("Epiron")]
        public Boolean CheckEditingABMValue { get; set; }

        [Browsable(true)]
        [Category("Epiron")]
        public Boolean CheckEditingABM { get; set; }

    }
}
