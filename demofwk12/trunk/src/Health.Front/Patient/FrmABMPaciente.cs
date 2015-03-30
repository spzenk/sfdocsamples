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
using Health.Isvc.GetPatient;
using Fwk.UI.Forms;
using Health.BE;

namespace Health.Front
{
    public partial class FrmABMPatient : frmBase_Dialog
    {
        internal MutualPorPacienteList MutualList;
        internal MutualPorPacienteList MutualListAux;
        MutualBE selectedMutual;
        GridHitInfo _HitInfo = null;

        internal PatientBE Patient { get; set; }
        public FrmABMPatient()
        {
            InitializeComponent();

        }
        public FrmABMPatient(Fwk.Bases.EntityUpdateEnum state)
        {
            InitializeComponent();
            this.State = state;
        }

        public override void Refresh()
        {
            this.mutualListBindingSource.DataSource = ServiceCalls.RetriveAllObraSocial();
            this.MutualPorPacienteBEBindingSource.DataSource = MutualList;

            gridView2.RefreshData();
            if (State == Fwk.Bases.EntityUpdateEnum.NEW)
            {
                lblTitulo.Text = "Alta de paciente";
                Patient = new PatientBE();
                Patient.Persona = new PersonaBE();
                MutualList = new MutualPorPacienteList();
                MutualListAux = new MutualPorPacienteList();
                uc_Persona1.Populate(Patient.Persona, State);
            }
            if (State == Fwk.Bases.EntityUpdateEnum.UPDATED)
            {
                lblTitulo.Text = "Actualización de paciente";
                GetPatientRes res = ServiceCalls.GetPatient(Patient.PatientId);
                MutualList = (MutualPorPacienteList)res.BusinessData.Mutuales;
                MutualListAux = (MutualPorPacienteList)res.BusinessData.Mutuales.Clone();

                uc_Persona1.Populate(Patient.Persona, State);

            }
            this.MutualPorPacienteBEBindingSource.DataSource = MutualListAux;

            uc_MedioContacto1.Persona = Patient.Persona;
            uc_Persona1.Refresh();
            uc_MedioContacto1.Init();
            gridControl_MutualXPatient.RefreshDataSource();
            InitSecurity();
            base.Refresh();
        }
        
        void InitSecurity()
        {
            bool _allowEdit = FormBase.CheckRule("admin_patients_abm");
            uc_Persona1.Enabled = _allowEdit;
            btnAdd.Enabled = uc_MedioContacto1.Enabled = _allowEdit;
            aceptCancelButtonBar1.AceptButtonEnabled = _allowEdit;
            gridControl_MutualXPatient.Enabled = _allowEdit;
            gridControl2.Enabled = _allowEdit;
        }

        private void FrmABMPatient_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            this.uc_Persona1.Init();
            this.Refresh();


        }

        private void aceptCancelButtonBar1_ClickOkCancelEvent(object sender, DialogResult result)
        {

            if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                this.DialogResult = result;
                this.Close();
            }
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                if (uc_Persona1.HasErrors())
                {
                    this.xtraTabControl1.SelectedTabPage = xtraTabPage1;
                    return;
                }
                this.DialogResult = result;
                try
                {
                    uc_Persona1.SetPersona();
                    uc_MedioContacto1.SetPersona();

                    if (State == Fwk.Bases.EntityUpdateEnum.NEW)
                    {
                        this.MutualList = MutualListAux;
                        if (Patient.Persona.IdPersona == 0)
                            ServiceCalls.CrearPatient(Patient, this.MutualList);
                        else
                            ServiceCalls.AsociarPatientAPersona(Patient, this.MutualList);

                        this.MessageViewer.Show(String.Format("{0} se creo con exito", Patient.Persona.ApellidoNombre.Trim()));
                        this.Close();
                    }
                    if (State == Fwk.Bases.EntityUpdateEnum.UPDATED)
                    {
                        CheckMutualChanges();
                        ServiceCalls.UpdatePatient(Patient, this.MutualList, uc_Persona1.AnteriorFechaNacimiento);
                        this.MessageViewer.Show(String.Format("{0} se actualizó con exito", Patient.Persona.ApellidoNombre.Trim()));
                        this.Close();
                    }

                }
                catch (Exception ex)
                {
                    this.ExceptionViewer.Show(ex);
                    this.DialogResult = System.Windows.Forms.DialogResult.None;
                }

            }
        }

        void CheckMutualChanges()
        {
            foreach (MutualPorPacienteBE aux in this.MutualListAux)
            {
                MutualPorPacienteBE mutual = MutualList.Where(p => p.IdMutual.Equals(aux.IdMutual)).FirstOrDefault<MutualPorPacienteBE>();
                if (mutual != null)
                {
                    //Si cambio halgo
                    if (mutual.IsActive != aux.IsActive || mutual.NroAfiliadoMutual != aux.NroAfiliadoMutual)
                    {
                        mutual.EntityState = Fwk.Bases.EntityState.Changed;
                        mutual.IsActive = aux.IsActive;
                        mutual.NroAfiliadoMutual = aux.NroAfiliadoMutual;
                    }
                }
                else
                {
                    if (aux.IsActive)
                    {
                        aux.EntityState = Fwk.Bases.EntityState.Added;
                        MutualList.Add(aux);
                    }
                }

            }
            //Elimino de la lista las mutuales no modificadas
            MutualList.RemoveAll(p=>p.EntityState.Equals(Fwk.Bases.EntityState.Unchanged));

        }

        private void gridView2_MouseDown(object sender, MouseEventArgs e)
        {
            _HitInfo = gridView2.CalcHitInfo(new Point(e.X, e.Y));
            selectedMutual = ((MutualBE)gridView2.GetRow(_HitInfo.RowHandle));

        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            if (selectedMutual == null) return;
            if (MutualListAux.Exists(p => p.IdMutual.Equals(selectedMutual.IdMutual))) return;
            MutualPorPacienteBE mutual = new MutualPorPacienteBE();
            mutual.EntityState = Fwk.Bases.EntityState.Added;
            mutual.IdMutual = selectedMutual.IdMutual;
            mutual.IsActive = true;
            mutual.NombreMutual = selectedMutual.Nombre;
            MutualListAux.Add(mutual);
            gridControl_MutualXPatient.RefreshDataSource();
        }

        /// <summary>
        /// Mutual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (MutualListAux.Exists(p => p.IdMutual.Equals(selectedMutual.IdMutual))) return;
            MutualPorPacienteBE mutual = new MutualPorPacienteBE();
            mutual.EntityState = Fwk.Bases.EntityState.Added;
            mutual.IdMutual = selectedMutual.IdMutual;
            mutual.IsActive = true;
            mutual.NombreMutual = selectedMutual.Nombre;
            MutualListAux.Add(mutual);


            gridControl_MutualXPatient.RefreshDataSource();


        }

        private void uc_Persona1_PersonaChanged(object sender, EventArgs e)
        {
            uc_MedioContacto1.Persona = uc_Persona1.Persona;
            this.Patient.Persona = uc_Persona1.Persona;
            uc_MedioContacto1.Init();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colNroAfiliadoMutual || e.Column == colIsActive)
            {
                MutualPorPacienteBE wMutualPorPacienteBE = ((MutualPorPacienteBE)gridView1.GetRow(gridView1.FocusedRowHandle));
                //Si es recientemente agregada no modificar el estado
                if (wMutualPorPacienteBE.EntityState == Fwk.Bases.EntityState.Added) return;

                wMutualPorPacienteBE.EntityState = Fwk.Bases.EntityState.Changed;
            }


        }


        MutualPorPacienteBE selectedMutualPorPacienteBE;
        GridHitInfo _HitInfo1 = null;
        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {

            _HitInfo1 = gridView1.CalcHitInfo(new Point(e.X, e.Y));
            selectedMutualPorPacienteBE = ((MutualPorPacienteBE)gridView1.GetRow(_HitInfo1.RowHandle));
       
        }

        private void miDesactivar_Click(object sender, EventArgs e)
        {
            if (selectedMutualPorPacienteBE == null) return;
            if (MutualList.Exists(p => p.IdMutual.Equals(selectedMutualPorPacienteBE.IdMutual)))
            {
                selectedMutualPorPacienteBE.IsActive = false;
                selectedMutualPorPacienteBE.EntityState = Fwk.Bases.EntityState.Changed;
            }
            else
            {
                MutualListAux.Remove(selectedMutualPorPacienteBE);
                gridControl_MutualXPatient.RefreshDataSource();
            }
        }

        private void miActivar_Click(object sender, EventArgs e)
        {
            if (selectedMutualPorPacienteBE == null) return;
            if (MutualList.Exists(p => p.IdMutual.Equals(selectedMutualPorPacienteBE.IdMutual)))
            {
                selectedMutualPorPacienteBE.IsActive = true;
                selectedMutualPorPacienteBE.EntityState = Fwk.Bases.EntityState.Changed;
            }
        }


    }
}
