using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scheduler
{
    
    public class ResourceSchedulingBE
    {
        public ResourceSchedulingBE()
        { }
        public ResourceSchedulingBE(ResourceScheduling obj)
        {
            Nombre = obj.Description;
            this.TimeStart = TimeSpan.Parse(obj.TimeStart);//"14:34"
            this.TimeEnd = TimeSpan.Parse(obj.TimeEnd);//"14:34"
            this.Duration = (decimal)obj.Duration;
            this.WeekOfMonth = obj.WeekOfMonth;
            this.WeekDays = obj.WeekDays;
        }
        public string Nombre { get; set; }
        public int? WeekOfMonth { get; set; }
        public decimal Duration { get; set; }

       
        /// <summary>
        /// Combinacion en base 64 de dias de la semana
        /// EJ: 
        /// 0000000 ningundia = 0
        /// 0000011  LUN y martes Viernes  = 3
        /// </summary>
        public int? WeekDays { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public String WeekDays_List
        {
            get { return GetDayNames(); }
            set { }
        }

        /// <summary>
        /// Hora de inicio HH:MM
        /// </summary>
        public TimeSpan TimeStart { get; set; }
        /// <summary>
        /// Hora Fin HH:MM
        /// </summary>
        public TimeSpan TimeEnd { get; set; }

        /// <summary>
        /// Determina si el dia de la fecha [date] pertenece a la confuguracion [WeekDays] mediante opoeraciones logicas y binarias
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public bool Date_IsContained(DateTime date)
        {
            DevExpress.XtraScheduler.WeekDays weekDay = DevExpress.XtraScheduler.WeekDays.EveryDay;

            switch (date.DayOfWeek)
            {
                case DayOfWeek.Monday://Lunes
                    {
                        weekDay = DevExpress.XtraScheduler.WeekDays.Monday;
                        break;
                    }
                case DayOfWeek.Tuesday://Martes
                    {
                        weekDay = DevExpress.XtraScheduler.WeekDays.Tuesday;
                        break;
                    }
                case DayOfWeek.Wednesday://Miercoles
                    {
                        weekDay = DevExpress.XtraScheduler.WeekDays.Wednesday;
                        break;
                    }
                case DayOfWeek.Thursday://Jueves
                    {
                        weekDay = DevExpress.XtraScheduler.WeekDays.Thursday;
                        break;
                    }
                case DayOfWeek.Friday://Viernes
                    {
                        weekDay = DevExpress.XtraScheduler.WeekDays.Friday;
                        break;
                    }
                case DayOfWeek.Saturday://Sabado
                    {
                        weekDay = DevExpress.XtraScheduler.WeekDays.Saturday;

                        break;
                    }
                case DayOfWeek.Sunday://Domingo
                    {
                        weekDay = DevExpress.XtraScheduler.WeekDays.Sunday;
                        break;
                    }
            }
            bool[] bin1 = CreateBoolArray((int)weekDay);
            bool[] bin2 = CreateBoolArray(this.WeekDays.Value);

            return Math(bin1, bin2);
        }

        string GetDayNames()
        {
            bool[] weekdays_to_bin_Array = CreateBoolArray(this.WeekDays.Value);
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

        public List<TimespamView> Get_ArrayOfTimes(DateTime date)
        {

            //List<TimespamView> times = new List<TimespamView>();
            //currentDate = Fwk.HelperFunctions.DateFunctions.GetStartDateTime(currentDate);
            //TimeSpan t = this.TimeStart;
            //TimespamView wTimespamView;
            //while (true)
            //{
            //    wTimespamView = new TimespamView();
            //    wTimespamView.Time = t;
            //    times.Add(wTimespamView);
            //    if ((this.TimeEnd - t).TotalMinutes >= 0)
            //        t = t.Add(TimeSpan.FromMinutes((Double)Duration));
            //    else
            //        break;
            //}
            return ResourceSchedulingBE.Get_ArrayOfTimes(date, this.TimeStart, this.TimeEnd, (double)this.Duration);
        }

        public static List<TimespamView> Get_ArrayOfTimes(DateTime currentDate,TimeSpan start ,TimeSpan end,Double duration)
        {
            List<TimespamView> times = new List<TimespamView>();
            currentDate = Fwk.HelperFunctions.DateFunctions.GetStartDateTime(currentDate);
            TimeSpan t = start;
            TimespamView wTimespamView;
            while (true)
            {
                wTimespamView = new TimespamView();
                wTimespamView.Time = t;
                wTimespamView.Description = "";
                times.Add(wTimespamView);
                if ((end - t).TotalMinutes >= 0)
                    t = t.Add(TimeSpan.FromMinutes(duration));
                else
                    break;
            }
            return times;
        }

        public static explicit operator ResourceSchedulingBE(ResourceScheduling obj)
        {
            return new ResourceSchedulingBE(obj);
        }

       
    }

    public class TimespamView
    {
        public TimespamView()
        { }
        public TimespamView(DateTime date)
        {
            //this.Time = new DateTime(date.Ticks);
        }
        public TimespamView(string value)
        {
            //this.Time =  System.TimeSpan.Parse(String.Format("{0}:{0}",)
        }

        public TimeSpan Time { get; set; }
        public String Description { get; set; }

        public string TimeString
        {
            get 
            {
                return String.Concat( Time.ToString("hh"),":" ,Time.ToString("mm"))  ;
            }
            
        }

        public static explicit operator TimespamView(string obj)
        {
            return new TimespamView(obj);
        }
        public static explicit operator TimespamView(DateTime date)
        {
            return new TimespamView(date);
        }

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
