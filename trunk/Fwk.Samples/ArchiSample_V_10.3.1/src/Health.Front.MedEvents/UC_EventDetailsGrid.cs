using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Health.BE;
using Health.BE.Enums;
using DevExpress.XtraGrid.Columns;

namespace Health.Front.Events
{
    [ToolboxItem(true)]
    public partial class UC_EventDetailsGrid : Xtra_UC_Base
    {
        MedicalEventDetail_ViewBE selectedDetails = null;
        MedicalEventBE medicalEvent;
        GridHitInfo _HitInfo = null;

        [Browsable(true)]
        internal MedicalEventDetailType DetailType { get; set; }
        
        public UC_EventDetailsGrid()
        {
            InitializeComponent();
            colColEnabled.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value;
            colColEnabled.FilterInfo = new ColumnFilterInfo("[ColEnabled] = true");
        }

        [Browsable(true)]
        public String Tittle
        {
            get
            {
                return this.lblTitle.Text;

            }
            set
            {
                this.lblTitle.Text = value;
            }
        }
        public override void Populate(object filter)
        {
            medicalEvent = (MedicalEventBE)filter;
            if (DetailType.Equals(MedicalEventDetailType.CEI10_Diagnosis))
                medicalEventDetailViewListBindingSource.DataSource = medicalEvent.DetailView_Diagnosis;

            if (DetailType.Equals(MedicalEventDetailType.Metodo_Complementarios))
                medicalEventDetailViewListBindingSource.DataSource = medicalEvent.DetailView_MetodosComplementarios;


            if (DetailType.Equals(MedicalEventDetailType.Quirurgico))
                medicalEventDetailViewListBindingSource.DataSource = medicalEvent.DetailView_Quirurgicos;
            gridView_Details.RefreshData();
        }
       


        private void gridView_Details_DoubleClick(object sender, EventArgs e)
        {
            if (selectedDetails == null) return;

            using (frm_EventDetails_Diagnosis frm = new frm_EventDetails_Diagnosis(medicalEvent))
            {
                frm.Refresh();

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    //Se debe obtener nuevamente dado q el PatientMedicaments que nos da la grilla pierde referencia con la coleccion _Evento.PatientMedicaments
                    gridControl_Details.RefreshDataSource();
                    gridView_Details.RefreshData();
                }
            }
        }

        private void gridView_Details_MouseDown(object sender, MouseEventArgs e)
        {
            _HitInfo = gridView_Details.CalcHitInfo(new Point(e.X, e.Y));
            selectedDetails = ((MedicalEventDetail_ViewBE)gridView_Details.GetRow(_HitInfo.RowHandle));
            if (selectedDetails == null) return;

        }


        internal void RefreshDataSourse()
        {
            //medicalEventDetailViewListBindingSource.DataSource = medicalEvent.MedicalEventDetail_ViewList;
            gridControl_Details.RefreshDataSource();
            gridView_Details.RefreshData();
        }
    }
}
