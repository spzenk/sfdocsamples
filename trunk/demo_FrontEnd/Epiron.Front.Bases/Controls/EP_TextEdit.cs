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
    public partial class EP_TextEdit : DevExpress.XtraEditors.TextEdit, IEpironControl
    {
        [Browsable(true)]
        [Category("Epiron")]
        public string TextUICode { get; set; }

      [Browsable(true)]
      [Category("Epiron")]
      public Boolean CheckEditingABM { get; set; }

      [Browsable(true)]
      [Category("Epiron")]
      public Boolean CheckEditingABMValue { get; set; }

      [Browsable(true)]
      [Category("Epiron")]
      public Boolean CleanOnABM { get; set; }


      //[Browsable(true)]
      //[Category("Epiron")]
      //public Boolean FocusedOnEditABM { get; set; }


      public bool FocusedOnEditABM { get; set; }
      public Boolean SelectOnEntry { get; set; }
      protected override void OnClick(EventArgs e)
      {
          if (SelectOnEntry)
            this.SelectAll();
          base.OnClick(e);
      }


      public TypeText TypeText { get; set; }
    }
}
