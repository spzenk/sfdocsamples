using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Health.Back.BE;
using Health.Entities;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Health.BE;
using DevExpress.XtraEditors.Controls;
using Health.BE.Enums;
using DevExpress.XtraGrid.Columns;


namespace Health.Front.Events
{
    public partial class frm_EventDetails_MetodoComplementario : frmBase_Dialog
    {
        MedicalEventDetail_ViewBE selectedDetails = null;
        
        GridHitInfo _HitInfo = null;
         MedicalEventBE CurentEvent;


        public frm_EventDetails_MetodoComplementario()
        {
            InitializeComponent();
        }

        public frm_EventDetails_MetodoComplementario(MedicalEventBE medicalEevent)
        {
            InitializeComponent();
            colColEnabled.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value;
            colColEnabled.FilterInfo = new ColumnFilterInfo("[ColEnabled] = true");
            //---------------MedicalEventDetailType---------------
            //12000	CEI10-Diagnosis                                   
            //12001	Tratamiento TTO                                   
            //12002	Metodo Complementarios                            
            //12003	Rehabilitación                                    

            ParametroList items = new ParametroList();

            items.Add(new ParametroBE { Nombre = Enum.GetName(typeof(CommonValuesEnum), CommonValuesEnum.Ninguno), IdParametro = (int)CommonValuesEnum.Ninguno });
            items.Add(new ParametroBE(870, "Relevante actual"));
            items.Add(new ParametroBE(871, "Relevante Crónico"));
            items.Add(new ParametroBE(872, "Presuntivo"));
            parametroBEBindingSource.DataSource = items;

           
            this.CurentEvent = medicalEevent;
        }
        private void frm_EventDetails_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            Initialize();
        }

        public  void Initialize()
        {

            
            if (this.CurentEvent.MedicalEventDetailList == null)
                this.CurentEvent.MedicalEventDetailList = new MedicalEventDetailList();

            medicalEventDetailViewListBindingSource.DataSource = this.CurentEvent.DetailView_MetodosComplementarios;
            gridControl_Details.RefreshDataSource();

            var pmo = ServiceCalls.PMOFileList.Where(p =>
                  (p.Type.Equals((int)PMOEnum.Diagnostico_Imagenes) ||
                  p.Type.Equals((int)PMOEnum.Odontológicas) ||
                  p.Type.Equals((int)PMOEnum.Diagnostico_Analisis_Clinico)) &&
                  p.HasChild.Equals(false)).OrderBy(p => p.Id);
            //Int32 c = pmo.Count();
            this.pMOFileListBindingSource.DataSource = pmo;
            //this.pMOFileListBindingSource_Quirurgico.DataSource = Controller.PMOFileList.Where(p =>
            //    p.Type.Equals((int)PMOEnum.Quirurgicas) && p.HasChild.Equals(false)).OrderBy(p => p.Id);

        }

        private void aceptCancelButtonBar1_ClickOkCancelEvent(object sender, DialogResult result)
        {
            this.DialogResult = result;

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                if (String.IsNullOrEmpty(txtCEI10.EditValue.ToString()))
                    return;
                var exist = this.CurentEvent.DetailView_MetodosComplementarios.Any(p => p.Code.Equals(txtCEI10.EditValue.ToString().Trim()));
                if (!exist)
                {
                    MedicalEventDetail_ViewBE wMedicalEventDetailBE = new MedicalEventDetail_ViewBE();

                    if (cmbAlertDiagnosis.EditValue != null)
                        if ((int)cmbAlertDiagnosis.EditValue != (int)CommonValuesEnum.Ninguno)
                        {
                            wMedicalEventDetailBE.RelevanceType = Convert.ToInt16(cmbAlertDiagnosis.EditValue);
                            wMedicalEventDetailBE.RelevanceTypeName = cmbAlertDiagnosis.Text;
                        }
                    wMedicalEventDetailBE.Id = -1;
                    wMedicalEventDetailBE.DetailType = (Int16)MedicalEventDetailType.Metodo_Complementarios;
                    wMedicalEventDetailBE.Desc = txtCEI10.Text; //Diagnosis
                    wMedicalEventDetailBE.Observations = txtObservación.Text;
                    wMedicalEventDetailBE.Code = txtCEI10.EditValue.ToString();
                    wMedicalEventDetailBE.ActiveRelevance = true;
                    wMedicalEventDetailBE.EntityState = Fwk.Bases.EntityState.Added;
                    wMedicalEventDetailBE.CreatedDate = System.DateTime.Now;
                    this.CurentEvent.DetailView_MetodosComplementarios.Add(wMedicalEventDetailBE);
                    this.Close();
                }
                else
                {
                    this.MessageViewer.Show("El diagnóstico ya fue agregado anteriormente");
                    this.DialogResult = System.Windows.Forms.DialogResult.None;

                }
            }


        }


        private void gridView_Details_MouseDown(object sender, MouseEventArgs e)
        {
            _HitInfo = gridView_Details.CalcHitInfo(new Point(e.X, e.Y));
            selectedDetails = ((MedicalEventDetail_ViewBE)gridView_Details.GetRow(_HitInfo.RowHandle));
            if (selectedDetails == null) return;

            if (selectedDetails.MedicalEventId.Equals(selectedDetails.MedicalEventId))
            {
                btnQuitarDiag.Enabled = true;
                return;
            }

            btnQuitarDiag.Enabled = false;
            
        }

        private void btnQuitarDiag_Click(object sender, EventArgs e)
        {
            QuitMedicamentFromGridView();
        }

        void QuitMedicamentFromGridView()
        {
            if (selectedDetails == null) return;

            //MedicalEventDetailBE det = CurentEvent.MedicalEventDetailList.Where(p => p.Id.Equals(selectedDetails.Id)).FirstOrDefault();
            //Si ahun no se envio a la BD se elimina de la coleccion
            if (selectedDetails.Id < 0)

                CurentEvent.DetailView_MetodosComplementarios.Remove(selectedDetails);
            else
            {
                selectedDetails.EntityState = Fwk.Bases.EntityState.Deleted;
                selectedDetails.ColEnabled = false;
            }

            gridView_Details.RefreshData();
            gridControl_Details.RefreshDataSource();
        }
    }
}
