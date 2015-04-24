﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Health.Back.BE;
using Health.Isvc.RetriveResourceSchedulingAndAppoinments;
using Health.Front.profesional;
using Fwk.HelperFunctions;
using Health.BE;
using Health.BE.Enums;

namespace Health.Front.Scheduler
{
    [ToolboxItem(true)]
    public partial class uc_shedule_profesional_timeline : Xtra_UC_Base
    {
        #region
        public event EventHandler OnChangeStatusEvent;

        internal string Title
        {
            get { return this.Title; }
            set { this.Title = value; }
        }
        void OnChangeStatus(AppoimantsStatus_SP status)
        {
            if (OnChangeStatusEvent != null)
                OnChangeStatusEvent(status, new EventArgs());
        }

        internal ResourceSchedulingList ProfesionalSchedulerList;
        internal Profesional_FullViewBE SelectedProfesionalBE;
        [Browsable(false)]
        internal AppointmentBE SelectedAppointment
        {
            get
            {
                return uc_ShiftsControls1.SelectedAppointment;

            }
        }
        DateTime CurrentDateTime;
        Dictionary<int, RetriveResourceSchedulingAndAppoinmentsRes> turnos = new Dictionary<int, RetriveResourceSchedulingAndAppoinmentsRes>();
        #endregion

        internal uc_shedule_profesional_timeline()
        {
            InitializeComponent();

            if (DesignMode) return;
            lblProfesional.Text = string.Empty;
            CurrentDateTime = DateTime.Now;
            lblFechaSeleccionada.Text = CurrentDateTime.ToLongDateString();

            uc_ShiftsControls1.SetContextMenuVisible(true, true, false, true, true);
        }

        internal void Set_ProfesionalChanged()
        {
            this.Cursor = Cursors.WaitCursor;
            Update_ShiftsControls();
            this.Cursor = Cursors.Default;
        }

        internal void SetDateChanged(DateTime date)
        {
            this.Cursor = Cursors.WaitCursor;
            CurrentDateTime = DateFunctions.GetStartDateTime(date);
            Update_ShiftsControls();
            this.Cursor = Cursors.Default;

        }

        void Update_ShiftsControls()
        {
            if (DesignMode) return;
            if (SelectedProfesionalBE == null) return;
            //Obtener la programacion del profesional 
            RetriveResourceSchedulingAndAppoinmentsRes res = ServiceCalls.RetriveResourceSchedulingAndAppoinments(SelectedProfesionalBE.IdProfesional, CurrentDateTime,false,ServiceCalls.CurrentHealthInstitution.HealthInstitutionId);

            if (uc_ShiftsControls1.profesional != SelectedProfesionalBE)
            {
                if (SelectedProfesionalBE.Foto!=null)



                    if (SelectedProfesionalBE.Foto != null)
                    {
                        this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
                        pictureEdit1.Image = Fwk.HelperFunctions.TypeFunctions.ConvertByteArrayToImage(SelectedProfesionalBE.Foto);
                    }
                    else
                    {
                        this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Clip;
                        if (SelectedProfesionalBE.Sexo.Equals((Int16)Sexo.Masculino))
                        {
                            pictureEdit1.Image = Health.Front.Base.Properties.Resource.User_M;
                        }
                        else
                        {
                            pictureEdit1.Image = Health.Front.Base.Properties.Resource.User_F;
                        }
                    }


                uc_ShiftsControls1.profesional = SelectedProfesionalBE;
        
                
               
                lblProfesional.Text = SelectedProfesionalBE.ApellidoNombre;
                lblEspesialidad.Text = SelectedProfesionalBE.NombreEspecialidad;
            }

            if (uc_ShiftsControls1.Date != CurrentDateTime)
            {
                uc_ShiftsControls1.Date = CurrentDateTime;
                lblFechaSeleccionada.Text = CurrentDateTime.ToLongDateString();
            }

            uc_ShiftsControls1.ShiftSchedulingList = res.BusinessData.ResourceSchedulerList;
            uc_ShiftsControls1.AppointmentList = res.BusinessData.AppoimentsList;
            ProfesionalSchedulerList = res.BusinessData.ResourceSchedulerList;

            lblDAysWeek.Text = uc_ShiftsControls1.ShiftSchedulingList.GetCommonDays().Replace("|", ", ");
            uc_ShiftsControls1.Refresh();
 
        }

        /// <summary>
        /// El identificador de 
        /// </summary>
        /// <param name="idProfesional"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        //RetriveResourceSchedulingAndAppoinmentsRes GetProfesionalSchedule(int idProfesional, DateTime date)
        //{
        //    RetriveResourceSchedulingAndAppoinmentsRes res = null;
        //    //if (turnos.ContainsKey(idProfesional))
        //    //    res = turnos[idProfesional];
        //    //else
        //    //{
        //        res = Controller.RetriveResourceSchedulingAndAppoinments(idProfesional, date,false,Controller.CurrentHealthInstitution.HealthInstitutionId);
        //        //turnos.Add(idProfesional, res);
        //    //}
        //    return res;
        //}

        private void btnViewResourceScheduling_Click(object sender, EventArgs e)
        {
            if (SelectedProfesionalBE == null) return;
            using (frmProfesionalCard frm = new frmProfesionalCard(Fwk.Bases.EntityUpdateEnum.UPDATED, SelectedProfesionalBE.IdProfesional))
            {
                //frm.Pupulate(SelectedProfesionalBE.IdProfesional);
                frm.ShowDialog();
            }
        }

        

        private void uc_ShiftsControls1_OnCreateAppoimentsEvent(object sender, EventArgs e)
        {
            turnos.Remove(SelectedProfesionalBE.IdProfesional);
            Update_ShiftsControls();
        }

        private void uc_ShiftsControls1_OnChangeStatusEvent(object sender, EventArgs e)
        {
            OnChangeStatus((AppoimantsStatus_SP)sender);
        }

        private void uc_ShiftsControls1_ShiftsDoubleClick(object sender, EventArgs e)
        {

        }

    }
}