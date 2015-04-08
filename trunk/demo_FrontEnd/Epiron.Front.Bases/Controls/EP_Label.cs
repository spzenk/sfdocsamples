using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Epiron.Front.Bases.Controls
{
    public partial class EP_Label : DevExpress.XtraEditors.LabelControl, IEpironControl
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
