using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Health.Back.BE;
using Health.Isvc.GetPatient;
using System.Runtime.Remoting.Messaging;
using Health.BE;

namespace Health.Front.Patients
{
    [ToolboxItem(true)]
    [DefaultEvent("OnDoubleClickEvent")]
    public partial class uc_PatientsGrid : Xtra_UC_Base
    {

        public string Tittle { get { return this.lblTitle.Text; } set { this.lblTitle.Text = value; } }
        public event EventHandler OnDoubleClickEvent;
        internal BE.PatientBE SelectedPatientBE { get; set; }
        PatientList _PatientList;
        public uc_PatientsGrid()
        {
            InitializeComponent();
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedPatientBE == null) return;

            if (OnDoubleClickEvent != null)
            {
                OnDoubleClickEvent(this, new EventArgs());
            }

        }
        GridHitInfo _HitInfo = null;
        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            //  if (e.Button != MouseButtons.Right) return;
            _HitInfo = gridView1.CalcHitInfo(new Point(e.X, e.Y));
            SelectedPatientBE = ((PatientBE)gridView1.GetRow(_HitInfo.RowHandle));
        }

        public override void Populate(object filter)
        {
            PopulateAsync();
        }
        public override void Refresh()
        {
            this.PopulateAsync();
            base.Refresh();
        }
        #region PopulateSync

        /// <summary>
        /// Carga de manera asincrona 
        /// </summary>
        public void PopulateAsync()
        {
            Exception ex = null;
            DelegateWithOutAndRefParameters s = new DelegateWithOutAndRefParameters(Populate);

            s.BeginInvoke(out ex, new AsyncCallback(EndPopulate), null);
        }

        /// <summary>
        /// Fin de el metodo populate que fue llamado de forma asincrona
        /// </summary>
        /// <param name="res"></param>
        void EndPopulate(IAsyncResult res)
        {
            Exception ex;

            if (this.InvokeRequired)
            {
                AsyncCallback d = new AsyncCallback(EndPopulate);
                this.Invoke(d, new object[] { res });
            }
            else
            {
                AsyncResult result = (AsyncResult)res;
                DelegateWithOutAndRefParameters del = (DelegateWithOutAndRefParameters)result.AsyncDelegate;
                del.EndInvoke(out ex, res);
                PatientBEBindingSource.DataSource = _PatientList;
                gridView1.RefreshData();
                grdPersonas.RefreshDataSource();
            }
        }

        /// <summary>
        /// Carga _PatientList
        /// </summary>
        void Populate(out Exception ex)
        {
            ex = null;

            try
            {
                _PatientList = ServiceCalls.RetrivePatients(null);
            }
            catch (Exception err)
            {
                err.Source = "Origen de datos";
                ex = err;
            }
        }

        #endregion

        private void verDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (SelectedPatientBE == null) return;
            
            
                using (FrmABMPatient frm = new FrmABMPatient(Fwk.Bases.EntityUpdateEnum.UPDATED))
                {
                    frm.Patient = SelectedPatientBE;
                    frm.Refresh();
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {

                    }
                }
            
            

        }
    }
}
