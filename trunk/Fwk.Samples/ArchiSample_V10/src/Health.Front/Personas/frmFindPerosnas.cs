using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Health.Back.BE;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Health.BE;

namespace Health.Front
{
    /// <summary>
    /// Grilla con personas registradas no realiza ninguna actualizacion
    /// </summary>
    public partial class frmFindPerosnas : frmBase_Dialog
    {
        public PersonaBE SelectedPersona{get;set;}
        public frmFindPerosnas()
        {
            InitializeComponent();
        }

        public override void Refresh()
        {
            grdPersonas.DataSource = Controller.RetrivePersonas();
            grdPersonas.RefreshDataSource();
            
            base.Refresh();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedPersona == null)            return;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnAcept_Click(object sender, EventArgs e)
        {
      
        }
        GridHitInfo _HitInfo = null;
        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
          //  if (e.Button != MouseButtons.Right) return;
            _HitInfo = gridView1.CalcHitInfo(new Point(e.X, e.Y));


            SelectedPersona = ((PersonaBE)gridView1.GetRow(_HitInfo.RowHandle));
         
        }
    }
}
