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
using Fwk.HelperFunctions;
using Health.BE;
using Health.BE.Enums;

namespace Health.Front.Scheduler
{
    [DefaultEvent("ShiftsDoubleClick")]
    [ToolboxItem(true)]
    public partial class uc_ShiftsControls : Xtra_UC_Base
    {
        #region



        TimespamView SelectedTimespamView;
        GridHitInfo _HitInfo = null;

        [Browsable(false)]
        internal AppointmentBE SelectedAppointment
        {
            get
            {
                if (SelectedTimespamView != null)
                    return SelectedTimespamView.Appointment;
                else
                    return null;
            }
        }

        public event EventHandler ShiftsDoubleClick;
        public event EventHandler OnCreateAppoimentsEvent;
        public event EventHandler OnChangeStatusEvent;

        void OnChangeStatus(AppoimantsStatus_SP status)
        {
            if (OnChangeStatusEvent != null)
                OnChangeStatusEvent(status, new EventArgs());
        }

        internal Profesional_FullViewBE profesional { get; set; }
        List<TimespamView> _TimespamViewList;
        internal AppointmentList AppointmentList { get; set; }
        internal ResourceSchedulingList ShiftSchedulingList { get; set; }
        internal DateTime Date = DateTime.Now;
        #endregion

        public uc_ShiftsControls()
        {
            InitializeComponent();

        }


        public override void Refresh()
        {
            if (this.DesignMode) return;
            this.Date = Fwk.HelperFunctions.DateFunctions.GetStartDateTime(this.Date);
            _TimespamViewList = Get_ArrayOfTimes();

           
            TimespamView wTimespamView = null;
    
            if (AppointmentList != null)
            {
                //Recorrer todos los turnos a partir de Date
                foreach (AppointmentBE a in AppointmentList.Where<AppointmentBE>(p => DateFunctions.GetStartDateTime(p.Start.Value).Equals(this.Date) 
                    && !p.IsExceptional))
                    
                {
                    TimeSpan t = a.TimeStart_timesp;
                    //Este cilo permite pintar Varios appointments como uno solo
                    //El caso se da cuando el usuario selecciona varios concecutivos y los asigna a un TURNO. Por lo tanto se crea un 
                    //solo Appoiment en la bace de datos donde TimeStart_timesp y TimeEnd_timesp incluira todos los turnos seleccionados
                    while (true)
                    {
                        //Creo ej: 10:15 para buscarlo dentro de los TimesView de la Grilla
                        string wTimeStart = String.Concat(t.ToString("hh"), ":", t.ToString("mm"));
                        wTimespamView = _TimespamViewList.Where<TimespamView>(p => p.TimeString.Equals(wTimeStart)).FirstOrDefault<TimespamView>();

                        if (wTimespamView != null)
                        {
                            wTimespamView.Appointment = a;
                        }
                        t = t.Add(TimeSpan.FromMinutes(a.Duration.Value));
                        //Revisar que pasa si t > a.TimeEnd_timesp
                        if (t >= a.TimeEnd_timesp) break;

                    }
                }
            }

            #region sobreturnos
            //Si existen sobreturnos agregarlos al la lista de timelines
            var sobreturnos = AppointmentList.Where<AppointmentBE>(p => p.IsExceptional);

            Insert_Sobreturnos(sobreturnos.ToList());
            #endregion

             _TimespamViewList.Sort(new TimeSpanComparer());
            //_TimespamViewList = _TimespamViewList.OrderBy(p => p.Time).ToList<TimespamView>();
            timespamViewBindingSource.DataSource = _TimespamViewList;
           

            gridControl2.RefreshDataSource();
            gridView2.RefreshData();
            base.Refresh();
        }

        /// <summary>
        /// Sobreturnos
        /// </summary>
        /// <param name="list"></param>
        void Insert_Sobreturnos(List<AppointmentBE> list)
        {
            TimespamView wTimespamView =null;
            foreach(AppointmentBE appointment in  list)
            {
                wTimespamView = new TimespamView();
                wTimespamView.Appointment = appointment;
                wTimespamView.Time = TimeSpan.Parse(appointment.TimeStart);
                wTimespamView.Duration = appointment.Duration.Value;
                wTimespamView.Name = "Excepsional";
            
                _TimespamViewList.Add(wTimespamView);
            }
            
            
          
        }

        /// <summary>
        /// Contruye los intervalos de tiempo para ShiftSchedulingList del profesional 
        /// </summary>
        /// <returns></returns>
        List<TimespamView> Get_ArrayOfTimes()
        {
            _TimespamViewList = new List<TimespamView>();
            List<TimespamView> partialList = null;
            //recorrer la lista de programacion de tiempos o lista de turnos del profesional
            foreach (ResourceSchedulingBE ShiftScheduling in ShiftSchedulingList)
            {
                partialList = ShiftScheduling.Get_ArrayOfTimes(this.Date, true);
                if (partialList != null)
                    _TimespamViewList.AddRange(partialList);

            }
            //_TimespamViewList.Sort(new TimeSpanComparer());
            return _TimespamViewList;
        }

        private void gridView2_MouseDown(object sender, MouseEventArgs e)
        {


            _HitInfo = gridView2.CalcHitInfo(new Point(e.X, e.Y));
            SelectedTimespamView = ((TimespamView)gridView2.GetRow(_HitInfo.RowHandle));
            if (SelectedTimespamView == null) return;
            if (e.Button != System.Windows.Forms.MouseButtons.Right) return;

            
            //double hora = SelectedTimespamView.Time.TotalHours;
            DateTime selectedTime = new DateTime(Date.Year, Date.Month, Date.Day, SelectedTimespamView.Time.Hours, SelectedTimespamView.Time.Minutes, 0);
            //TimeSpan tNow = new TimeSpan( System.DateTime.Now.Hour);
            //double hora2 = tNow.TotalHours;

            //Si ya paso
            if (DateTime.Compare(selectedTime, System.DateTime.Now) < 0)
            {
                mAsignarToolStripMenuItem.Enabled = false;
                mSetCanceled.Enabled = false;
                mCerrarTurnoToolStripMenuItem.Enabled = false;
                m_sobreturnoToolStripMenuItem.Enabled = false;
                return;
            }

            if (SelectedTimespamView.Appointment == null)
            {
                mAsignarToolStripMenuItem.Enabled = true;
                mCerrarTurnoToolStripMenuItem.Enabled = false;
                mSetCanceled.Enabled = false;
                m_sobreturnoToolStripMenuItem.Enabled = false;
                return;
            }
            
            //Si se selecciona el ultimo
            if (SelectedTimespamView == _TimespamViewList[_TimespamViewList.Count - 1])
            {
                m_sobreturnoToolStripMenuItem.Text = "Sobreturno";// Enum.GetName(typeof(AppoimantsStatus_SP), AppoimantsStatus_SP.Sobreturno);
                m_sobreturnoToolStripMenuItem.Tag = AppoimantsStatus_SP_type.Sobreturno;
            }
            else
            {
                m_sobreturnoToolStripMenuItem.Text = "Entreturno";// Enum.GetName(typeof(AppoimantsStatus_SP), AppoimantsStatus_SP.Entreturno);
                m_sobreturnoToolStripMenuItem.Tag = AppoimantsStatus_SP_type.Entreturno;
            }
            if (gridView2.SelectedRowsCount > 1)
            {
                mAsignarToolStripMenuItem.Enabled = false;
                mSetCanceled.Enabled = false;
                mCerrarTurnoToolStripMenuItem.Enabled = false;
                m_sobreturnoToolStripMenuItem.Enabled = false;
            }
            else
            {


                if (SelectedTimespamView.Appointment.IsExceptional)
                {
                    mAsignarToolStripMenuItem.Enabled = false;
                    mCerrarTurnoToolStripMenuItem.Enabled = false;
                    mSetCanceled.Enabled = true;
                    mEnEsperaToolStripMenuItem.Enabled = false;
                    m_atenderToolStripMenuItem.Enabled = true;
                    m_sobreturnoToolStripMenuItem.Enabled = false;
                }


                if (SelectedTimespamView.Appointment.Status == (int)AppoimantsStatus_SP.EnEspera)
                {
                    mAsignarToolStripMenuItem.Enabled = false;
                    mSetCanceled.Enabled = true;
                    mCerrarTurnoToolStripMenuItem.Enabled = false;
                    mEnEsperaToolStripMenuItem.Enabled = false ;
                    
                    m_sobreturnoToolStripMenuItem.Enabled = true;

                    m_atenderToolStripMenuItem.Enabled = true;
                }

                if (SelectedTimespamView.Appointment.Status == (int)AppoimantsStatus_SP.Reservado)
                {
                    mAsignarToolStripMenuItem.Enabled = false;
                    mSetCanceled.Enabled = true;
                    mCerrarTurnoToolStripMenuItem.Enabled = false;
                    mEnEsperaToolStripMenuItem.Enabled = true;
                    m_atenderToolStripMenuItem.Enabled = true;
                    m_sobreturnoToolStripMenuItem.Enabled = true ;
                }
                if (SelectedTimespamView.Appointment.Status == (int)AppoimantsStatus_SP.EnAtencion)
                {

                    mAsignarToolStripMenuItem.Enabled = false;
                    mCerrarTurnoToolStripMenuItem.Enabled = true;
                    mSetCanceled.Enabled = false;
                    mEnEsperaToolStripMenuItem.Enabled = false;
                    m_atenderToolStripMenuItem.Enabled = false;
                    m_sobreturnoToolStripMenuItem.Enabled = false;
                }
                if (SelectedTimespamView.Appointment.Status == (int)AppoimantsStatus_SP.Cerrado)
                {

                    mAsignarToolStripMenuItem.Enabled = false;
                    mCerrarTurnoToolStripMenuItem.Enabled = false;
                    mSetCanceled.Enabled = false;
                    mEnEsperaToolStripMenuItem.Enabled = false;
                    m_atenderToolStripMenuItem.Enabled = false;
                    m_sobreturnoToolStripMenuItem.Enabled = false;
                }
                if (SelectedTimespamView.Appointment.Status == (int)AppoimantsStatus_SP.Cancelado)
                {
                    mAsignarToolStripMenuItem.Enabled = true;
                    mCerrarTurnoToolStripMenuItem.Enabled = false;
                    mSetCanceled.Enabled = false;
                    mEnEsperaToolStripMenuItem.Enabled = false;
                    m_atenderToolStripMenuItem.Enabled = false;
                    m_sobreturnoToolStripMenuItem.Enabled = true;
                }


            }
        }

        private void m_sobreturnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmShiftAppointment frm = new frmShiftAppointment())
            {
                AppoimantsStatus_SP_type status = (AppoimantsStatus_SP_type)m_sobreturnoToolStripMenuItem.Tag;

                AppointmentBE app = SelectedTimespamView.Appointment.Clone<AppointmentBE>();
                app.Subject = string.Concat(Enum.GetName(typeof(AppoimantsStatus_SP_type), status), " a las : ", SelectedTimespamView.Appointment.TimeEnd);
                app.Status =(int) AppoimantsStatus_SP.Reservado;
                app.IsExceptional = true;

                frm.Profesional = profesional;
                frm.State = Fwk.Bases.EntityUpdateEnum.NEW;
                
                app.ResourceId = profesional.IdProfesional;
                app.HealthInstitutionId = Controller.CurrentHealthInstitution.HealthInstitutionId;
                app.CreationDate = System.DateTime.Now;
                //DateTime date = Fwk.HelperFunctions.DateFunctions.GetStartDateTime(this.Date);
                //List<TimespamView> wTimespamViewList = null;
               
                //app.Start = date.Add(wTimespamViewList[0].Time);
                //app.Duration = wTimespamViewList[0].Duration;
                //if (wTimespamViewList.Count > 1)
                //    app.End = date.Add(wTimespamViewList[wTimespamViewList.Count - 1].Time);
                //else
                //    app.End = date.Add(wTimespamViewList[0].Time).AddMinutes(wTimespamViewList[0].Duration);

                frm.currentApt = app;
                frm.Refresh();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    
                   
                    try
                    {
                        Controller.CreateAppointments(app);
                        if (OnCreateAppoimentsEvent != null)
                            OnCreateAppoimentsEvent(app, new EventArgs());
                    }

                    catch (Exception ex)
                    {
                        this.ExceptionViewer.Show(ex);
                    }
                    //gridControl2.RefreshDataSource();
                    //gridView2.RefreshData();
                }

            }
            Refresh();
            //UpdateStatus((AppoimantsStatus_SP)m_sobreturnoToolStripMenuItem.Tag);

        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            if (ShiftsDoubleClick != null)
                ShiftsDoubleClick(sender, e);
        }

        public List<TimespamView> GetSelectedShifts()
        {
            List<TimespamView> list = new List<TimespamView>();
            TimespamView shift;
            foreach (int i in gridView2.GetSelectedRows())
            {
                shift = ((TimespamView)gridView2.GetRow(i));

                list.Add(shift);
            }
            var c = list.GroupBy(p => p.Name);
            if (c.Count() > 1)
                throw new Exception("Seleccione horarios del mismo intervalo de tiempo en los cuales trabaja el profesional");

            return list;
        }

        private void mSetCanceled_Click(object sender, EventArgs e)
        {
            UpdateStatus(AppoimantsStatus_SP.Cancelado);
        }

        /// <summary>
        /// 
        /// Almacen del Appoiment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void asignarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmShiftAppointment frm = new frmShiftAppointment())
            {
                AppointmentBE app = new AppointmentBE();
                frm.Profesional = profesional;
                frm.State = Fwk.Bases.EntityUpdateEnum.NEW;
                app.Status = (int)AppoimantsStatus_SP.Reservado;
                app.ResourceId = profesional.IdProfesional;
                app.HealthInstitutionId = Controller.CurrentHealthInstitution.HealthInstitutionId;

                DateTime date = Fwk.HelperFunctions.DateFunctions.GetStartDateTime(this.Date);
                List<TimespamView> wTimespamViewList = null;
                try
                {
                    wTimespamViewList = GetSelectedShifts();
                }
                catch (Exception ex)
                {
                    this.ExceptionViewer.Show(ex);
                    return;
                }
                app.Start = date.Add(wTimespamViewList[0].Time);
                app.Duration = wTimespamViewList[0].Duration;
                if (wTimespamViewList.Count > 1)
                    app.End = date.Add(wTimespamViewList[wTimespamViewList.Count - 1].Time);
                else
                    app.End = date.Add(wTimespamViewList[0].Time).AddMinutes(wTimespamViewList[0].Duration);

                frm.currentApt = app;
                frm.Refresh();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    ///todo: analizar como crear grupos de turnos
                    foreach (TimespamView timeView in wTimespamViewList)
                    {
                        timeView.Appointment = app;
                    }
                    try
                    {
                        Controller.CreateAppointments(app);
                        if (OnCreateAppoimentsEvent != null)
                            OnCreateAppoimentsEvent(app, new EventArgs());
                    }

                    catch (Exception ex)
                    {
                        this.ExceptionViewer.Show(ex);
                    }
                    gridControl2.RefreshDataSource();
                    gridView2.RefreshData();
                }

            }
        }

        private void cerrarTurnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateStatus(AppoimantsStatus_SP.Cerrado);
        }

        void UpdateStatus(AppoimantsStatus_SP status)
        {
            AppointmentList appList = new AppointmentList();
            SelectedTimespamView.Appointment.Status = (int)status;

            if (status.Equals(AppoimantsStatus_SP.Cancelado) )
            {
                if (SelectedTimespamView.Appointment.IsExceptional                    )
                {
                    appList.Add(SelectedTimespamView.Appointment);
                    
                    Controller.RemoveAppoiment(SelectedTimespamView.Appointment.AppointmentId);

                    OnChangeStatus(status);
                    Refresh();
                    return;
                }
            }
            //    AppointmentBE app =  SelectedTimespamView.Appointment.Clone<AppointmentBE>();
            //    app.Subject = string.Concat(Enum.GetName(typeof(AppoimantsStatus_SP),status), " a las : ", SelectedTimespamView.Appointment.TimeEnd);
            //    app.Status = (int)status;
            //    appList.Add(app);
               
            //    try
            //    {
            //        Controller.CreateAppointments(app);
                    
            //        if (OnCreateAppoimentsEvent != null)
            //            OnCreateAppoimentsEvent(app, new EventArgs());

                   
            //    }

            //    catch (Exception ex)
            //    {
            //        this.ExceptionViewer.Show(ex);
            //    }

            //}

            try
            {
      
                appList.Add(SelectedTimespamView.Appointment);
        
                Controller.UpdateAppoiment(appList);

                OnChangeStatus(status);
                Refresh();
            }
            catch (Exception ex)
            {
                this.ExceptionViewer.Show(ex);
            }
        }

        /// <summary>
        /// En espera es cuando el pasiente llega al hospital y se notifica de que llego
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enEsperaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateStatus(AppoimantsStatus_SP.EnEspera);
        }

        public void SetContextMenuVisible(bool asignar, bool cerrar,bool atender, bool espera,bool cancelar )
        {
            mAsignarToolStripMenuItem.Visible = asignar;
            mCerrarTurnoToolStripMenuItem.Visible = cerrar;
            mSetCanceled.Visible = cancelar;
            mEnEsperaToolStripMenuItem.Visible = espera;
            m_atenderToolStripMenuItem.Visible = atender;
        }

        private void m_atenderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateStatus(AppoimantsStatus_SP.EnAtencion);
        }

     
      
    }

}

