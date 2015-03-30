using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Health.Back.BE;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Health.Entities;
using Health.BE;
using Health.BE.Enums;

namespace Health.Front.Scheduler
{
    [ToolboxItem(true)]
    public partial class uc_AllShiftGrid : Xtra_UC_Base
    {
        public event EventHandler ChangeStatusEvent;

        void OnChangeStatus(AppoimantsStatus_SP status)
        {
            if (ChangeStatusEvent != null)
                ChangeStatusEvent(status,new EventArgs ());
        }
            
        internal ProfesionalBE profesional;
        internal AppointmentBE SelectedAppointment;
        GridHitInfo _HitInfo = null;
        DateTime Date = DateTime.Now;
        string tittle;
        public uc_AllShiftGrid()
        {
            InitializeComponent();
            tittle= this.lblTitle.Text;
        }

        public override void Refresh()
        {
            if (profesional != null)
            {
                this.appointmentListBindingSource.DataSource = ServiceCalls.RetriveAppointment(null, this.Date, profesional.IdProfesional,ServiceCalls.CurrentHealthInstitution.HealthInstitutionId);
                this.m_cerrarTurnoToolStripMenuItem.Visible = false;
                this.m_enEsperaToolStripMenuItem.Visible = false;
                this.m_SetCanceled.Visible = false;
            }
            else
            {
                this.m_atenderToolStripMenuItem.Visible = false;
                this.appointmentListBindingSource.DataSource = ServiceCalls.RetriveAppointment(null, this.Date);
            }

            gridControl2.RefreshDataSource();
            gridView2.RefreshData();
            this.lblTitle.Text = String.Concat (tittle," Desde :", Date.ToLongDateString());


            
            base.Refresh();
        }

        private void gridView2_MouseDown(object sender, MouseEventArgs e)
        {


            _HitInfo = gridView2.CalcHitInfo(new Point(e.X, e.Y));
            SelectedAppointment = ((AppointmentBE)gridView2.GetRow(_HitInfo.RowHandle));
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
            //Esta siendo consultado por un medico
            //if (profesional.IdProfesional != null && profesional.IdProfesion.Value.Equals((int)RubroProfesionalEnum.Medico))
            //{
            //    if (SelectedAppointment.Status == (int)AppoimantsStatus_SP.Reservado)
            //    {
            //        //Actualizar el estado a En atencion
            //        UpdateStatus(AppoimantsStatus_SP.EnAtencion);
            //    }
            //}
            //else
            //{
            if (SelectedAppointment == null) return;
            ///Ver - consultar
            using (frmShiftAppointment frm = new frmShiftAppointment())
            {
                frm.State = Fwk.Bases.EntityUpdateEnum.NONE;
               
                //Este caso se presenta cuando la consulta no es por medio del mismo profesional 
                //sino de una secretaria que ve turnos de varios 
                //profesionales
                frm.Profesional = new Profesional_FullViewBE();

                frm.AceptCancelButtonBar_Visible = false;
                if (this.profesional == null)
                {

                    //Busco el profesional
                    this.profesional = ServiceCalls.GetProfesional(SelectedAppointment.ResourceId, false, false,false).BusinessData.profesional;
                    //Relleno frm.profesional con info minima
                    frm.Profesional.Nombre = this.profesional.Persona.Nombre;
                    frm.Profesional.Apellido = this.profesional.Persona.Apellido;
                    frm.Profesional.IdEspecialidad = this.profesional.IdEspecialidad;
                    frm.Profesional.NombreEspecialidad = this.profesional.NombreEspecialidad;
                    frm.Profesional.IdProfesion = this.profesional.IdProfesion;


                }
                else
                {
                    frm.Profesional.Nombre = this.profesional.Persona.Nombre;
                    frm.Profesional.Apellido = this.profesional.Persona.Apellido;
                    frm.Profesional.IdEspecialidad = this.profesional.IdEspecialidad;
                    frm.Profesional.NombreEspecialidad = this.profesional.NombreEspecialidad;
                    frm.Profesional.IdProfesion = this.profesional.IdProfesion;
                }


                frm.currentApt = SelectedAppointment;
                frm.Refresh();
                frm.ShowDialog();
            }
            //}
        }

        internal void SetDateChanged(DateTime dateTime)
        {
            Date = dateTime;
            this.Refresh();
        }

        private void m_SetCanceled_Click(object sender, EventArgs e)
        {
            UpdateStatus(AppoimantsStatus_SP.Cancelado);
        }

        private void m_cerrarTurnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateStatus(AppoimantsStatus_SP.Cerrado);
        }
        private void atenderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Actualizar el estado a En atencion
            UpdateStatus(AppoimantsStatus_SP.EnAtencion);
        }
        private void enEsperaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateStatus(AppoimantsStatus_SP.EnEspera);

        }
      
        void UpdateStatus(AppoimantsStatus_SP status)
        {
            try
            {
                SelectedAppointment.Status = (int)status;
                //TODO: Set SelectedTimespamView.Appoiment to canceled in database

                AppointmentList appList = new AppointmentList();
                //if (!String.IsNullOrEmpty(SelectedTimespamView.Appointment.GroupId))
                appList.Add(SelectedAppointment);
                //else
                //{
                //    var appList_aux = (from s in AppointmentList where s.GroupId.Equals(s) select s).ToList<AppointmentBE>();
                //    appList_aux.ForEach(p => { p.Status = (int)status; });
                //    appList.AddRange(appList_aux);
                //}
                ServiceCalls.UpdateAppoiment(appList);

                
            }
            catch (Exception ex)
            {
                this.ExceptionViewer.Show(ex);
            }

           
            OnChangeStatus(status);
            //gridControl2.RefreshDataSource();
            //gridView2.RefreshData();
            Refresh();
        }

      
        
    }
}
