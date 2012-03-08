using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler;

namespace Scheduler
{
    public partial class DiseñarTurnos : Form
    {
        SchedulerShift _SchedulerShift = new SchedulerShift();
        List<SchedulerShift> list = new List<SchedulerShift>();
        public DiseñarTurnos()
        {
            InitializeComponent();
            dateEdit1.DateTime = System.DateTime.Now;


        }

        void Set_SchedulerShift()
        {
            _SchedulerShift = new SchedulerShift();
            _SchedulerShift.Duration = (int)Convert.ToInt32(durationEdit1.Duration.TotalMinutes);
            _SchedulerShift.WeekDays = (int)weeklyRecurrenceControl1.RecurrenceInfo.WeekDays;
            DateTime d = Convert.ToDateTime(timeEdit_From.EditValue);
            //_SchedulerShift.Star =  System.TimeSpan.Parse(String.Format"{0}:{0}:{0}")
            _SchedulerShift.Star = d.TimeOfDay;
            d = Convert.ToDateTime(timeEdit_To.EditValue);
            _SchedulerShift.End = d.TimeOfDay;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Set_SchedulerShift();
            list.Add(_SchedulerShift);
            schedulerShiftBindingSource.DataSource = list;
            gridControl1.RefreshDataSource();
            bool x = _SchedulerShift.Date_IsContained(dateEdit1.DateTime);
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {


        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            List<TimespamView> s = _SchedulerShift.Get_ArrayOfTimes(System.DateTime.Now);
            timespamViewBindingSource.DataSource = s;
            gridControl2.RefreshDataSource();
        }
    }

    public class SchedulerShift
    {
        public string Nombre { get; set; }

        public int Duration { get; set; }
        public int WeekDays { get; set; }
        public String WeekDays_List
        {
            get { return GetDayNames(); }
            set { }
        }
        public TimeSpan Star { get; set; }
        public TimeSpan End { get; set; }

        public bool Date_IsContained(DateTime date)
        {
            DevExpress.XtraScheduler.WeekDays weekDays = DevExpress.XtraScheduler.WeekDays.EveryDay;

            switch (date.DayOfWeek)
            {
                case DayOfWeek.Monday://Lunes
                    {
                        weekDays = DevExpress.XtraScheduler.WeekDays.Monday;
                        break;
                    }
                case DayOfWeek.Tuesday://Martes
                    {
                        weekDays = DevExpress.XtraScheduler.WeekDays.Tuesday;
                        break;
                    }
                case DayOfWeek.Wednesday://Miercoles
                    {
                        weekDays = DevExpress.XtraScheduler.WeekDays.Wednesday;
                        break;
                    }
                case DayOfWeek.Thursday://Jueves
                    {
                        weekDays = DevExpress.XtraScheduler.WeekDays.Thursday;
                        break;
                    }
                case DayOfWeek.Friday://Viernes
                    {
                        weekDays = DevExpress.XtraScheduler.WeekDays.Friday;
                        break;
                    }
                case DayOfWeek.Saturday://Sabado
                    {
                        weekDays = DevExpress.XtraScheduler.WeekDays.Saturday;

                        break;
                    }
                case DayOfWeek.Sunday://Domingo
                    {
                        weekDays = DevExpress.XtraScheduler.WeekDays.Sunday;
                        break;
                    }
            }
            bool[] bin1 = CreateBoolArray((int)weekDays);
            bool[] bin2 = CreateBoolArray(this.WeekDays);

            return Math(bin1, bin2);
        }

        string GetDayNames()
        {
            bool[] weekdays_to_bin_Array = CreateBoolArray(this.WeekDays);
            List<String> str = new List<String>();
            for (int i = 0; i < weekdays_to_bin_Array.Length; i++)
            {
                if (weekdays_to_bin_Array[i])
                {
                    str.Add(Get_DayName_Spanish(i));
                }
            }
            return string.Join("|", str);
        }
        /// <summary>
        /// SAB	VIE	JUE	MIE	MAR	LUN	DOM
        /// </summary>
        /// <param name="val"></param>
        /// <param name="index"></param>
        public static string Get_DayName_Spanish(int index)
        {

            DaynName_Spanish h = (DaynName_Spanish)index;

            return h.ToString();
        }
        /// <summary>
        /// 0000111
        /// 1000001 return True
        /// 
        /// 100000
        /// 000010 return False
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        bool Math(bool[] a, bool[] b)
        {

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] && b[i]) return true;
            }
            return false;
        }

        /// <summary>
        /// Crea vector booleano y rellena hasta 7 con false en caso de no existir
        /// </summary>
        /// <param name="weekdays"></param>
        /// <returns></returns>
        bool[] CreateBoolArray(int weekdays)
        {

            String weekdays_to_bin = Convert.ToString((weekdays), 2);
            Char[] weekdays_to_bin_Array = weekdays_to_bin.ToArray();

            Stack<Boolean> cola = new Stack<bool>();

            for (int i = weekdays_to_bin_Array.Length - 1; i >= 0; i--)
            {
                string s = weekdays_to_bin_Array[i].ToString();
                bool val = Convert.ToBoolean(Convert.ToInt16(s));
                cola.Push(val);
            }
            for (int i = 0; i < 7 - weekdays_to_bin_Array.Length; i++)
            {
                cola.Push(false);
            }

            return cola.ToArray<Boolean>();

        }

        public List<TimespamView> Get_ArrayOfTimes(DateTime currentDate)
        {
            
            List<TimespamView> times = new List<TimespamView>();
            currentDate = Fwk.HelperFunctions.DateFunctions.GetStartDateTime(currentDate);
            TimeSpan t = this.Star;
            TimespamView wTimespamView ;
            while (true)
            {
                wTimespamView = new TimespamView ();
                wTimespamView.Time= t;
                times.Add(wTimespamView);
                if ((this.End - t).TotalMinutes >= 0)
                    t = t.Add(TimeSpan.FromMinutes(Duration));
                else
                    break;
            }
            return times;
        }

    }

    public class TimespamView

    {
        public TimeSpan Time{get;set;} 
        public String Description{get;set;}

    }
    public enum DaynName_Spanish
    {
        //SAB	VIE	JUE	MIE	MAR	LUN	DOM

        Sabado = 0,
        Viernes = 1,
        Juevaes = 2,
        Miercoles = 3,
        Martes = 4,
        Lunes = 5,
        Domingo = 6


    }
}
