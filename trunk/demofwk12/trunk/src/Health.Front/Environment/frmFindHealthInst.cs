using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Health.BE;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Health.Front.Environment
{
    public partial class frmFindHealthInst : frmBase_Dialog
    {
        public HealthInstitutionBE HealthInst;
        GridHitInfo _HitInfo = null;
        public frmFindHealthInst()
        {
            InitializeComponent();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
            {
                FindInst();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FindInst();
        }

        void FindInst()
        {
            try
            {
                healthInstitutionBEBindingSource.DataSource = ServiceCalls.RetriveHealthInstitutionList(txtSearchText.Text.Trim());
                gridView1.RefreshData();
            }
            catch (Exception ex)
            {
                this.ExceptionViewer.Show(ex);
            }

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (HealthInst == null) return;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
            //using (frmEvent frm = new frmEvent())
            //{
            //    frm.MedicalEventId = _Event.MedicalEventId;
            //    frm.Refresh();
            //    frm.ShowDialog();
            //}
        }

        
        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {

            _HitInfo = gridView1.CalcHitInfo(new Point(e.X, e.Y));
            HealthInst = ((HealthInstitutionBE)gridView1.GetRow(_HitInfo.RowHandle));

        }

        private void aceptCancelButtonBar1_ClickOkCancelEvent(object sender, DialogResult result)
        {
          this.DialogResult = result;
                this.Close();
        }
    }
}
