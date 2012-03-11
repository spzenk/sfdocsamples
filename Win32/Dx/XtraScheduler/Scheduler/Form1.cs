using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using DevExpress.XtraScheduler.Drawing;
using DevExpress.Schedule;

namespace Scheduler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            TimeScaleCollection scales = schedulerControl1.TimelineView.Scales;

            scales.BeginUpdate();

            try
            {
                scales.Clear();
                scales.Add(new CustomTimeScaleDay());
                scales.Add(new CustomTimeScaleHour());
                schedulerControl1.DayView.TimeScale = TimeSpan.FromMinutes(12);

                this.schedulerStorage1.Appointments.Mappings.Description = "Requester";
                this.schedulerStorage1.Appointments.Mappings.End = "fecha Fin";
                this.schedulerStorage1.Appointments.Mappings.Label = "Tipo";
                this.schedulerStorage1.Appointments.Mappings.ResourceId = "TypistID";
                this.schedulerStorage1.Appointments.Mappings.Start = "Fecha inicio";
                this.schedulerStorage1.Appointments.Mappings.Subject = "CaseNr";
                this.schedulerStorage1.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("IdPaciente", "IdPaciente"));
                //this.schedulerStorage1.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("IdPaciente", "AssignmentText"));
                //schedulerControl1.DayView.TimeSlots.Add(new DevExpress.XtraScheduler.TimeSlot(TimeSpan.FromMinutes(15), "1 minutes"));

                //DateTime d1 = new DateTime(2012, 1, 1, 9, 0, 0);

                //DateTime d2 = new DateTime(2012, 1, 1, 16, 30, 0);


                //         schedulerControl1.DayView.VisibleTime.Start = System.TimeSpan.Parse("9:00:00");
                //schedulerControl1.DayView.VisibleTime.End = System.TimeSpan.Parse("12.09:00:00");
                //schedulerControl1.Views.DayView.VisibleTime.Start = System.TimeSpan.Parse("9:00:00");
                //schedulerControl1.Views.DayView.VisibleTime.End = System.TimeSpan.Parse("12.09:00:00");

                //schedulerControl1.DayView.VisibleTime = new TimeOfDayInterval(TimeSpan.FromHours(9), TimeSpan.FromHours(12));


                //TimeInterval interva1 = new TimeInterval( TimeSpan.FromHours(15));
                //TimeInterval interva2 = new TimeInterval(d2, TimeSpan.FromHours(15));
                //TimeIntervalCollection cooll = new TimeIntervalCollection();
                //cooll.Add(new TimeOfDayInterval(TimeSpan.FromHours(10), TimeSpan.FromHours(13)));
                //cooll.Add(interva2);
                //schedulerControl1.DayView.SetVisibleIntervals(cooll);


               

                printProperties();
                FillData();
            }
            finally
            {
                scales.EndUpdate();

            }




        }
        //bool IsIntervalAllowed(TimeInterval interval, DateTime dayStart)
        //{
        //    TimeInterval lunchTime = new TimeInterval(dayStart.Add(restrictedArea.Start),
        //        dayStart.Add(restrictedArea.End));
        //    return !interval.IntersectsWithExcludingBounds(lunchTime);
        //}    

        void FillData()
        {
            AppointmentCustomFieldMapping customNameMapping = new AppointmentCustomFieldMapping("CustomIdResource", "CustomIdResource");
            //AppointmentCustomFieldMapping customStatusMapping = new AppointmentCustomFieldMapping("CustomStatus", "CustomStatus");
            schedulerStorage1.Appointments.CustomFieldMappings.Add(customNameMapping);
            //schedulerStorage1.Appointments.CustomFieldMappings.Add(customStatusMapping);
            FillResourcesStorage(schedulerStorage1.Resources.Items);
            FillAppointmentsStorage(schedulerStorage1.Appointments.Items);
        }

        static void FillAppointmentsStorage(AppointmentCollection c)
        {
            DevExpress.XtraScheduler.Appointment wAppointment;
            using (DataClasses1DataContext dc = new DataClasses1DataContext())
            {
                foreach (Appointment a in dc.Appointments)
                {
                    wAppointment = new DevExpress.XtraScheduler.Appointment (a.Start.Value,a.End.Value);
                    wAppointment.Subject = a.Subject;
                    wAppointment.StatusId = a.Status.Value;
                    c.Add(wAppointment);
                }
         
            
            }
            
        }
        static void FillResourcesStorage(ResourceCollection c)
        {
            Resource r;
            using (DataClasses1DataContext dc = new DataClasses1DataContext())
            {
                foreach (Profecional a in dc.Profecionals)
                {
                    r = new Resource(a.IdProfecional, String.Concat(a.Persona.Nombre, ", ", a.Persona.Apellido));
                    c.Add(r);
                }
            }
        }
        void printProperties()
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine("WorkTime.Start  " + schedulerControl1.DayView.WorkTime.Start.ToString());
            s.AppendLine("WorkTime.End " + schedulerControl1.DayView.WorkTime.End.ToString());
            s.AppendLine("VisibleTime.Start  " + schedulerControl1.DayView.VisibleTime.Start.ToString());
            s.AppendLine("VisibleTime.End " + schedulerControl1.DayView.VisibleTime.End.ToString());
            memoEdit1.Text = s.ToString();
        }

        DevExpress.XtraScheduler.Appointment CreateApp(DateTime startDateTime, int hours, int minutes, string subjet)
        {
            DevExpress.XtraScheduler.Appointment a = new DevExpress.XtraScheduler.Appointment(startDateTime, new TimeSpan(hours, minutes, 0), subjet);


            return a;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            schedulerControl1.BeginUpdate();
            schedulerControl1.DayView.WorkTime.Start = TimeSpan.FromHours(9);
            schedulerControl1.DayView.WorkTime.End = TimeSpan.FromHours(12.5);

            //schedulerControl1.Views.DayView.VisibleTime.Start = System.TimeSpan.Parse("9:00:00");
            //schedulerControl1.Views.DayView.VisibleTime.End = System.TimeSpan.Parse("12.09:00:00");

            schedulerControl1.WorkDays.Clear();
            schedulerControl1.WorkDays.Add(WeekDays.Friday | WeekDays.Monday);

            schedulerControl1.EndUpdate();

            printProperties();
        }



        private void schedulerControl1_QueryWorkTime(object sender, QueryWorkTimeEventArgs e)
        {

            e.WorkTimes.Add(new TimeOfDayInterval(TimeSpan.FromHours(10), TimeSpan.FromHours(13)));
            e.WorkTimes.Add(new TimeOfDayInterval(TimeSpan.FromHours(14), TimeSpan.FromHours(16)));
            printProperties();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            schedulerControl1.DayView.ShowAllDayArea = checkBox1.Checked;

        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            schedulerControl1.DayView.ShowWorkTimeOnly = checkBox2.Checked;
        }

        private void schedulerControl1_CustomDrawTimeCell(object sender, CustomDrawObjectEventArgs e)
        {
            HatchBrush brickBrush = new HatchBrush(HatchStyle.DiagonalBrick, Color.LightYellow, Color.Firebrick);
            Brush solidBrush = new SolidBrush(Color.Plum);
            SelectableIntervalViewInfo cells = e.ObjectInfo as SelectableIntervalViewInfo;

            if (cells != null)
            {
                if (cells.Selected)
                {
                    e.Graphics.FillRectangle(solidBrush, e.Bounds);
                    e.Handled = true;
                }
                else if (cells.Interval.Start.Day == 13)
                {
                    e.Graphics.FillRectangle(brickBrush, e.Bounds);
                    e.Handled = true;
                }

            }

            SchedulerViewCellBase cell = e.ObjectInfo as SchedulerViewCellBase;
            if (cell != null && IsHoliday(cell.Interval))
            {
                cell.Appearance.BackColor = Color.Tomato;
            }
        }


        private WorkDaysCollection Holidays { get { return schedulerControl1.WorkDays; } }

        private void btnAddHoliday_Click(object sender, EventArgs e)
        {
            DayIntervalCollection days = new DayIntervalCollection();
            days.Add(schedulerControl1.SelectedInterval);

            schedulerControl1.BeginUpdate();
            try
            {
                for (int i = 0; i < days.Count; i++)
                    AddHoliday(days[i].Start);
            }
            finally
            {
                schedulerControl1.EndUpdate();
            }

        }

        private void AddHoliday(DateTime holidayDate)
        {
            TimeInterval interval = new TimeInterval(holidayDate, TimeSpan.FromDays(1));
            if (!IsHoliday(interval))
                Holidays.AddHoliday(holidayDate, string.Format("Holiday-{0}", holidayDate.ToShortDateString()));
        }
        private bool IsHoliday(TimeInterval interval)
        {

            for (int i = 0; i < Holidays.Count; i++)
            {
                Holiday holiday = Holidays[i] as Holiday;
                if (holiday != null)
                {
                    TimeInterval holidayInterval = new TimeInterval(holiday.Date, TimeSpan.FromDays(1));
                    if (holidayInterval.IntersectsWithExcludingBounds(interval))
                        return true;
                }
            }
            return false;
        }

        private void schedulerControl1_InitNewAppointment(object sender, AppointmentEventArgs e)
        {


            //.IntersectsWithExcludingBounds(interval))
        }

        private void schedulerControl1_AllowAppointmentCreate(object sender, AppointmentOperationEventArgs e)
        {

            TimeInterval holidayInterval = new TimeInterval(schedulerControl1.SelectedInterval.Start, schedulerControl1.SelectedInterval.End);
            if (!schedulerControl1.WorkDays.IsWorkDay(holidayInterval.Start))
                e.Allow = false;

        }

        //http://documentation.devexpress.com/#WindowsForms/CustomDocument2288
        private void schedulerControl1_EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e)
        {
            DevExpress.XtraScheduler.Appointment apt = e.Appointment;
            bool openRecurrenceForm = apt.IsRecurring &&    schedulerStorage1.Appointments.IsNewAppointment(apt);

            // Create a custom form.
            MyAppointmentForm myForm = new MyAppointmentForm((SchedulerControl)sender,     apt, openRecurrenceForm);
            myForm.LookAndFeel.ParentLookAndFeel = schedulerControl1.LookAndFeel;
            e.DialogResult = myForm.ShowDialog();
            schedulerControl1.Refresh();
            e.Handled = true;
        }

        private void schedulerControl1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.Menu.Id == SchedulerMenuItemId.DefaultMenu)
            {
                SchedulerMenuItem item = e.Menu.GetMenuItemById(SchedulerMenuItemId.NewAppointment);

                if (item != null)
                    // Rename the menu item for the 'New Appointment' action. 
                    item.Caption = "Crear editar turnos";
            }
        }

        private void schedulerStorage1_AppointmentsInserted(object sender, PersistentObjectsEventArgs e)
        {
            foreach (DevExpress.XtraScheduler.Appointment a in (DevExpress.XtraScheduler.AppointmentBaseCollection)(e.Objects))
            {
                Scheduler.Appointment db_a = new Scheduler.Appointment();
                db_a.IdPaciente = Convert.ToInt32(a.CustomFields["IdPaciente"]);
                //db_a.IdProfecional = (int)a.CustomFields[""];
                db_a.Label = a.LabelId;
                db_a.ResourceId = (int)a.ResourceId;
                db_a.Status = a.StatusId;

                db_a.Subject = a.Subject;
                db_a.Description = a.Description;
                db_a.Start = a.Start;
                db_a.End = a.End;
                db_a.Duration =  Convert.ToDecimal(a.Duration.TotalHours);
                db_a.Location = a.Location;

                db_a.Range = (int)a.RecurrenceInfo.Range;
                db_a.Month = a.RecurrenceInfo.Month;
                db_a.Periodicity = a.RecurrenceInfo.Periodicity;

                using (DataClasses1DataContext dc = new DataClasses1DataContext())
                {
                    //dc.Appointments.InsertOnSubmit(db_a);
                }
            }

        }

    }
}
