using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Health.Front.Scheduler;
using Health.BE;
using Health.BE.Enums;

namespace Health.Front.Patients
{
    public partial class uc_PatientAppoiments : Xtra_UC_Base
    {

        Patient_Appointments_ViewBE SelectedAppointment;
        GridHitInfo _HitInfo = null;
        DateTime Date = DateTime.Now;
        PatientBE _SelectedPatientBE = null;

        public uc_PatientAppoiments()
        {
            InitializeComponent();
        }

        public override void Populate(object filter)
        {
            _SelectedPatientBE = (PatientBE)filter;

            ///Retrive
            appointmentListBindingSource.DataSource = Controller.RetrivePatientAppoinments(_SelectedPatientBE.PatientId, System.DateTime.Now, null);

            this.uc_PatientCard1.Populate(filter);
        }



        private void gridView2_MouseDown(object sender, MouseEventArgs e)
        {


            _HitInfo = gridView2.CalcHitInfo(new Point(e.X, e.Y));
            SelectedAppointment = ((Patient_Appointments_ViewBE)gridView2.GetRow(_HitInfo.RowHandle));
            if (SelectedAppointment == null) return;
            if (e.Button != System.Windows.Forms.MouseButtons.Right) return;

            if (SelectedAppointment == null)
            {
                m_atenderToolStripMenuItem.Enabled = false;
                m_cerrarTurnoToolStripMenuItem.Enabled = false;
                m_SetCanceled.Enabled = false;
                return;
            }

            if (gridView2.SelectedRowsCount > 1)
            {
                m_atenderToolStripMenuItem.Enabled = false;
                m_SetCanceled.Enabled = false;
                m_cerrarTurnoToolStripMenuItem.Enabled = false;
            }
            else
            {
                if (SelectedAppointment.Status == (int)AppoimantsStatus_SP.Expirado)
                {
                    m_atenderToolStripMenuItem.Enabled = false;
                    m_enEsperaToolStripMenuItem.Enabled = false;
                    m_SetCanceled.Enabled = false;
                    m_cerrarTurnoToolStripMenuItem.Enabled = false;
                    return;
                }
                if (SelectedAppointment.Status == (int)AppoimantsStatus_SP.Reservado)
                {
                    m_atenderToolStripMenuItem.Enabled = true;
                    m_enEsperaToolStripMenuItem.Enabled = true;
                    m_SetCanceled.Enabled = true;
                    m_cerrarTurnoToolStripMenuItem.Enabled = false;
                    return;

                }
                if (SelectedAppointment.Status == (int)AppoimantsStatus_SP.EnAtencion)
                {
                    m_atenderToolStripMenuItem.Enabled = false;
                    m_enEsperaToolStripMenuItem.Enabled = false;
                    m_SetCanceled.Enabled = false;
                    m_cerrarTurnoToolStripMenuItem.Enabled = true;

                    return;
                }
                if (SelectedAppointment.Status == (int)AppoimantsStatus_SP.Cerrado)
                {

                    m_atenderToolStripMenuItem.Enabled = false;
                    m_enEsperaToolStripMenuItem.Enabled = false;
                    m_SetCanceled.Enabled = false;
                    m_cerrarTurnoToolStripMenuItem.Enabled = false;
                    return;
                }
                if (SelectedAppointment.Status == (int)AppoimantsStatus_SP.Cancelado)
                {
                    m_atenderToolStripMenuItem.Enabled = true;
                    m_enEsperaToolStripMenuItem.Enabled = true;
                    m_SetCanceled.Enabled = false;
                    m_cerrarTurnoToolStripMenuItem.Enabled = false;

                    return;
                }
            }
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
          
            if (SelectedAppointment == null) return;
            ///Ver - consultar
            using (frmShiftAppointment frm = new frmShiftAppointment())
            {
                frm.State = Fwk.Bases.EntityUpdateEnum.NONE;
                
                //Este caso se presenta cuando la consulta no es por medio del mismo profesional 
                //sino de una secretaria que ve turnos de varios 
                //profesionales
                frm.Profesional = new Profesional_FullViewBE();
                frm.Profesional.Nombre = Controller.CurrentProfesional.Persona.Nombre;
                frm.Profesional.Apellido = Controller.CurrentProfesional.Persona.Apellido;
                frm.Profesional.IdEspecialidad = Controller.CurrentProfesional.IdEspecialidad;
                frm.Profesional.NombreEspecialidad = Controller.CurrentProfesional.NombreEspecialidad;
                frm.Profesional.IdProfesion = Controller.CurrentProfesional.IdProfesion;
                frm.AceptCancelButtonBar_Visible = false;
                frm.currentApt = SelectedAppointment.Get_Appointments();
                frm.Refresh();
                frm.ShowDialog();
            }
         
        }



       

        private void m_enEsperaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateStatus(AppoimantsStatus_SP.EnEspera);
        }

        private void m_atenderToolStripMenuItem_Click(object sender, EventArgs e)
        {
    
        }

        private void m_SetCanceled_Click(object sender, EventArgs e)
        {
            UpdateStatus(AppoimantsStatus_SP.Cancelado);
        }

        private void m_cerrarTurnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateStatus(AppoimantsStatus_SP.Cerrado);
        }

        void UpdateStatus(AppoimantsStatus_SP status)
        {
            try
            {
                SelectedAppointment.Status = (int)status;
                //TODO: Set SelectedTimespamView.Appoiment to canceled in datanbase

                AppointmentList appList = new AppointmentList();
           
                appList.Add(SelectedAppointment.Get_Appointments());
                
                //else
                //{
                //    var appList_aux = (from s in AppointmentList where s.GroupId.Equals(s) select s).ToList<AppointmentBE>();
                //    appList_aux.ForEach(p => { p.Status = (int)status; });
                //    appList.AddRange(appList_aux);
                //}
                Controller.UpdateAppoimentStatus(appList);


            }
            catch (Exception ex)
            {
                this.ExceptionViewer.Show(ex);
            }


            //OnChangeStatus(status);
            gridControl2.RefreshDataSource();
            gridView2.RefreshData();
        }
    }
}
