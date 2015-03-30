using System;
using System.Linq;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;
using Health.Back.BE;
using Health.BE.Enums;

namespace Health.BE
{
    public partial class MedicalEventDetail_ViewList : Fwk.Bases.Entities<MedicalEventDetail_ViewBE>
    {
        public MedicalEventDetail_ViewList Get_Diagnosis()
        {
            return Get_Detail(MedicalEventDetailType.CEI10_Diagnosis);
        }
        public MedicalEventDetail_ViewList Get_Metodo_Complementarios()
        {
            return Get_Detail(MedicalEventDetailType.Metodo_Complementarios);
        }
        public MedicalEventDetail_ViewList Get_Quirurgicos()
        {
            return Get_Detail(MedicalEventDetailType.Quirurgico);
        }

        MedicalEventDetail_ViewList Get_Detail(MedicalEventDetailType detailType)
        {
            var list = this.Where(p => p.DetailType.Equals((Int16)detailType));
            MedicalEventDetail_ViewList wMedicalEventDetail_ViewList = new MedicalEventDetail_ViewList();
            wMedicalEventDetail_ViewList.AddRange(list);
            return wMedicalEventDetail_ViewList;
        }
    }

    public partial class MedicalEventDetail_ViewBE : Fwk.Bases.Entity
    {
        /// <summary>
        /// Solo para propositos de visualizacion en grilla
        /// </summary>
        private Boolean _ColEnabled = true;

        public Boolean ColEnabled
        {
            get { return _ColEnabled; }
            set { _ColEnabled = value; }
        }
    }
    public partial class MedicalEventDetailBE : Fwk.Bases.Entity
    {
        /// <summary>
        /// Constructor a partir de la vista <see cref="MedicalEventDetail_ViewBE"/>
        /// </summary>
        /// <param name="view"></param>
        public MedicalEventDetailBE(MedicalEventDetail_ViewBE det_view)
        {
            this.Id = det_view.Id;
            this.Description = det_view.Desc;
            this.Code = det_view.Code;
            this.DetailType = det_view.DetailType;
            this.Observations = det_view.Observations;
            this.RelevanceType = det_view.RelevanceType;
            this.ActiveRelevance = det_view.ActiveRelevance;
            this.EntityState = det_view.EntityState;
            
        }

    }
    public partial class ParametroBE : Fwk.Bases.Entity
    {
        public ParametroBE(int idParametro,String name)
        {
            this.Nombre = name;
            this.IdParametro = idParametro;
        }
    }
    public partial class HealthInstitutions_SuscriptionRequestsList : Fwk.Bases.Entities<HealthInstitutions_SuscriptionRequestsBE>
    { }
    public partial class HealthInstitutions_SuscriptionRequestsBE : Fwk.Bases.Entity
    {

        public DateTime? RequestSend { get; set; }

        public string Nombre_From { get; set; }
        public string Apellido_From { get; set; }
        public string FullName_From
        {
            get { return String.Concat(this.Apellido_From.Trim(), ", ", this.Nombre_From.Trim()); }
                }
        public string Nombre_To { get; set; }
        public string Apellido_To { get; set; }
        public string FullName_To
        {
            get { return String.Concat(this.Apellido_To.Trim(), ", ", this.Nombre_To.Trim()); }
        }
        public bool SenderIsOwner { get; set; }

      
        public Guid HealthInsId { get; set; }

        public string HealthInstName{ get; set; }
        public string Message { get; set; }
        public int Profesional_From { get; set; }
        public int Profesional_To { get; set; }
        public int? Status { get; set; }
        public string SubscriptionState
        {
            get
            {
                if (this.Status.HasValue)
                    switch ((SubscriptionRequestStatus)this.Status)
                    {
                        case SubscriptionRequestStatus.EnEspera:
                            {
                                return "En espera";
                            }
                        case SubscriptionRequestStatus.Expirado:
                            {
                                return "Expirado";
                            }
                        case SubscriptionRequestStatus.Rechazado:
                            {
                                return "Rechazado";
                            }
                    }
                return string.Empty;
            }
        }

        public string SubscriptionMessage
        {
            get
            {
                
                if (this.Status.HasValue)
                    switch ((SubscriptionRequestStatus)this.Status)
                    {
                        case SubscriptionRequestStatus.EnEspera:
                            {
                                return string.Concat(SubscriptionState, " enviado el ", this.RequestSend.ToString());
                            }
                        case SubscriptionRequestStatus.Expirado:
                            {
                                return "Solicitud expiró";
                            }
                        case SubscriptionRequestStatus.Rechazado:
                            {
                                return "Solicitud fue rechazada";
                            }
                    }
                return string.Empty;
            }
        }
        
    }

    /// <summary>
    /// 
    /// </summary>
    public partial class HealthInstitutionBE
    {
        public string AddresseToString
        {
            get
            {
                System.Text.StringBuilder s = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(this.Street))
                    s.Append(string.Concat("Calle: ", this.Street, " ", this.StreetNumber, " ", this.Floor));

                if (!string.IsNullOrEmpty(this.City))
                    s.Append(string.Concat(",", this.City, " ", this.ZipCode));
                if (!string.IsNullOrEmpty(this.Province))
                    s.Append(string.Concat(", ", this.Province));

                if (!string.IsNullOrEmpty(this.Country))
                    s.Append(string.Concat(", ", this.Country));

                return s.ToString();
            }
        }

        public string Country { get; set; }

        public HealthInstitution_ProfesionalList ProfesionalList { get; set; }
        public HealtInstitute_UsersInRolesList UsersInRoles { get; set; }
        
    }

    public partial class HealthInstitution_ProfesionalBE
    {
        public string FullName { get; set; }
        public string[] Roles { get; set; }

    }

    /// <summary>
    /// 
    /// </summary>
    public partial class Patient_Appointments_ViewBE
    {

        /// <summary>
        /// Mapeo de 
        /// </summary>
        /// <param name="pPatient_Appointments_ViewBE"></param>
        /// <returns></returns>
        public  AppointmentBE Get_Appointments()
        {
            AppointmentBE wAppointmentBE = new AppointmentBE();
            wAppointmentBE.AppointmentId = this.AppointmentId;
            wAppointmentBE.Duration = this.Duration;
            wAppointmentBE.End = this.End;
            wAppointmentBE.Start = this.Start;
            wAppointmentBE.Status = this.Status;
            wAppointmentBE.Description = this.Description;
            wAppointmentBE.ResourceId = this.ResourceId;
            
            wAppointmentBE.Location = this.Location;
            wAppointmentBE.Subject = this.Subject;
            wAppointmentBE.ProfesionalAppointment = new ProfesionalAppointmentBE ();
            wAppointmentBE.ProfesionalAppointment.PatientId = this.PatientId;
            //wAppointmentBE.ProfesionalAppointment.IdMotivoConsulta = this.IdMotivoConsulta;

            return wAppointmentBE;
        }
    }

    public partial class MedicalEvent_ViewBE
    {
        public int Year
        {
            get {return this.CreatedDate.Year; }
        }
        public String Month
        {
            get {
                
                return string.Concat(this.CreatedDate.Month, " - ", Enum.GetName(typeof(MonthsNames_ES), this.CreatedDate.Month)); 
            }
        }
        public MedicalEventDetailList MedicalEventDetailList { get; set; }
     }
    public partial class PatientAllergyBE
    {
        public string OtherNames { get; set; }
        public override string ToString()
        {
            System.Text.StringBuilder str = null;
            if (
                 this.AnimalAllergy
                 || this.ChemicalAllergy
                 || this.FoodAllergy
                 || this.InsectAllergy
                 || this.MiteAllergy
                 || this.MedicamentsAllergy
                 || this.PollenAllergy
                 || this.SunAllergy
                 || !string.IsNullOrEmpty(this._OtherAllergy))
            {
                str = new System.Text.StringBuilder();
            }

            if (str == null) return string.Empty;
            if (this.AnimalAllergy)
                str.AppendLine("Alergia los anmales  \r\n");
            if (this.FoodAllergy)
                str.AppendLine("Alergia los alimentos \r\n");
            if (this.InsectAllergy)
                str.AppendLine("Alergia los insectos \r\n");

            if (this.MiteAllergy)
                str.AppendLine("Alergia los ácaros \r\n");
            if (this.MedicamentsAllergy)
                str.AppendLine("Alergia los alimentos \r\n");
            if (this.PollenAllergy)
                str.AppendLine("Alergia al polen \r\n");





            if (this.SunAllergy)
                str.AppendLine("Alergia al Sol \r\n");

            if (!string.IsNullOrEmpty(this.GeneralDetails))
            {
                str.AppendLine("Descripcion gral de la/s alergia/s \r\n");
                str.AppendLine(GeneralDetails);
            }
            //Controller.OtherAllergiesList
            //TODO: Rellenar patient allergy
            if (!string.IsNullOrEmpty(this.OtherNames))
            {
                str.AppendLine("Espesificación de alergia/s anteriores: \r\n");
                str.AppendLine(OtherNames);
            }

            return str.ToString();
        }
    }

    public partial class MedicalEventBE
    {

        MedicalEventDetailList _MedicalEventDetailList = new MedicalEventDetailList();

        public MedicalEventDetailList MedicalEventDetailList
        {
            get { return _MedicalEventDetailList; }
            set { _MedicalEventDetailList = value; }
        }
        public PatientMedicament_ViewList PatientMedicaments { get; set; }
        public string NombreApellidoProfesional { get; set; }
        public string NombreEspesialidad { get; set; }

        public string InstitucionRazonSocial { get; set; }
        public MedicalEventDetail_ViewList DetailView_Diagnosis { get; set; }
        public MedicalEventDetail_ViewList DetailView_MetodosComplementarios { get; set; }
        public MedicalEventDetail_ViewList DetailView_Quirurgicos { get; set; }

        //public MedicalEventDetailList MedicalEventDetailList { get; set; }
        public MedicalEventDetail_ViewList MedicalEventDetail_ViewList { get; set; }
    }


    public partial class PatientMedicament_ViewBE
    {

        //public String MedicamentStatusInfo
        //{
        //    get
        //    {
        //        if (this.IsPermanent && this.IsSuspended)
        //            return "Permanente Supendida";
        //        if (this.IsPermanent && !this.IsSuspended)
        //            return "Permanente";

        //        if (!this.IsPermanent && this.IsSuspended)
        //            return "Suspendida";

        //        if (!this.IsPermanent && !this.IsSuspended && !this.Enabled)
        //            return "Finalizo tratamiento";

        //        if (!this.IsPermanent && !this.IsSuspended && this.Enabled)
        //            return "Actual";

        //        return String.Empty;
        //    }
        //}

        public string StatusDescription
        {
            get {
                
                return Enum.GetName(typeof(MedicamentStatus), (MedicamentStatus)Status);
            }
        }

        public String ApellidoNombre
        {
            get
            {
                return String.Concat(this.ApellidoProfesional.Trim(), ", ", this.NombreProfesional.Trim());
            }
        }

       

    }
    public partial class PatientBE
    {
        public PersonaBE Persona { get; set; }
    }





    public partial class ProfesionalBE
    {
        public PersonaBE Persona { get; set; }
        public string NombreEspecialidad { get; set; }
        public string UserName { get; set; }

        public bool UpdateSecurityInfo { get; set; }
    }

    public partial class Profesional_FullViewBE
    {
        public String ApellidoNombre
        {
            get
            {
                return String.Concat(this.Apellido.Trim(), ", ", this.Nombre.Trim());
            }
        }

        public HealthInstitution_ProfesionalBE HealthInstitution_Profesional  { get; set; }
    }
    public partial class PersonaBE
    {
        /// <summary>
        /// Establecer el valor por defecto
        /// </summary>
        //public PersonaBE()
        //{
        //    _IdPersona = -1;
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String GetLabelEdad()
        {
            int y = 0;
            int m = 0;
            int d = 0;

            Fwk.HelperFunctions.DateFunctions.Get_Age(_FechaNacimiento, out  y, out  m, out  d);

            //Menor de 3 años
            if (y < 3)
            {
                //Si tiene solo dias
                if (y == 0 && m == 0)
                    return String.Format("{0} días", d);
                //Si tiene solo meses y dias
                if (y == 0)
                    return String.Format(" {0} meses y {1} días", m, d);

                //Si tiene y año cumplido
                return String.Format("{0} Años, {1} meses y {2} días", y, m, y);
            }
            //entre 3 y 10 solo años y meses
            if (y >= 3 && y < 10)
                return String.Format("{0} Años, {1} meses ", y, m);

            return String.Format("{0} Años", y);
        }

        public String ApellidoNombre
          {
            get {
                return String.Concat(this.Apellido.Trim(), ", ", this.Nombre.Trim()); 
            }
        }
    }

    public partial class ResourceSchedulingList
    {

        /// <summary>
        /// Retorna los dias encomun en todas las planificaciones de turnos
        /// </summary>
        /// <returns></returns>
        public  string GetCommonDays()
        {
            bool[] aux = new bool[] { false, false, false, false, false, false, false };
            foreach (ResourceSchedulingBE be in this)
            {
                aux = ResourceSchedulingBE.GetCommonDays(be.WeekDays_BinArray, aux);
            }

            return ResourceSchedulingBE.GetDayNames(aux);
        }
    }

    public partial class ResourceSchedulingBE
    {

 

        /// <summary>
        /// Hora de inicio HH:MM
        /// </summary>
        public TimeSpan TimeStart_timesp
        {
            get { return TimeSpan.Parse(this.TimeStart); }
        }
        /// <summary>
        /// Hora Fin HH:MM
        /// </summary>
        public TimeSpan TimeEnd_timesp
        {
            get { return TimeSpan.Parse(this.TimeEnd); }
        }


        #region Operaciones con weekDays
        /// Retorna un array binario con los dias en comun: 
        /// a = 111110
        /// b = 010101
        /// res=111111
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        internal static bool[] GetCommonDays(bool[] a, bool[] b)
        {

            for (int i = 0; i < a.Length; i++)
            {
                b[i] = a[i] || b[i];
            }

            return b;
        }

        bool[] weekDays_BinArray;
        /// <summary>
        /// 
        /// </summary>
        public bool[] WeekDays_BinArray
        {
            get
            {
            if (!this.WeekDays.HasValue)
                    this.WeekDays = 0;
                if (weekDays_BinArray == null)
                    weekDays_BinArray = CreateBoolArray(this.WeekDays.Value);
                return weekDays_BinArray;
            }

        }


        /// <summary>
        /// 
        /// </summary>
        public String WeekDays_List
        {
            get { return GetDayNames(); }
            set { }
        }

        /// <summary>
        /// Determina si el dia de la fecha [date] pertenece a la confuguracion [WeekDays] mediante opoeraciones logicas y binarias
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public bool Date_IsContained(DateTime date)
        {
            WeekDays_EN weekDay = WeekDays_EN.EveryDay;

            switch (date.DayOfWeek)
            {
                case DayOfWeek.Monday://Lunes
                    {
                        weekDay = WeekDays_EN.Monday;
                        break;
                    }
                case DayOfWeek.Tuesday://Martes
                    {
                        weekDay = WeekDays_EN.Tuesday;
                        break;
                    }
                case DayOfWeek.Wednesday://Miercoles
                    {
                        weekDay = WeekDays_EN.Wednesday;
                        break;
                    }
                case DayOfWeek.Thursday://Jueves
                    {
                        weekDay = WeekDays_EN.Thursday;
                        break;
                    }
                case DayOfWeek.Friday://Viernes
                    {
                        weekDay = WeekDays_EN.Friday;
                        break;
                    }
                case DayOfWeek.Saturday://Sabado
                    {
                        weekDay = WeekDays_EN.Saturday;

                        break;
                    }
                case DayOfWeek.Sunday://Domingo
                    {
                        weekDay = WeekDays_EN.Sunday;
                        break;
                    }
            }
            bool[] bin1 = CreateBoolArray((int)weekDay);
            return Math(bin1, WeekDays_BinArray);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="weekDays">Numero que repreenta una combinacion binaria de dias semana</param>
        /// <returns></returns>
        public bool HasDaysInCommon(int weekDays)
        {
            bool[] weekDays_array = CreateBoolArray(weekDays);

            return !Math(weekDays_array, WeekDays_BinArray);
        }
        /// <summary>
        /// Busca si hay dias en comun
        /// </summary>
        /// <param name="weekDays"></param>
        /// <returns></returns>
        public bool HasDaysInCommon(bool[] weekDays_array)
        {
            return Math(weekDays_array, WeekDays_BinArray);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="weekdays_to_bin_Array"></param>
        /// <returns></returns>
        public static string GetDayNames(bool[] weekdays_to_bin_Array)
        {
            List<String> str = new List<String>();

            for (int i = weekdays_to_bin_Array.Length - 1; i >= 0; i--)
            {
                if (weekdays_to_bin_Array[i])
                {
                    str.Add(ResourceSchedulingBE.Get_DayName_Spanish(i));
                }
            }
            return string.Join("|", str);
        }

        /// <summary>
        /// Retorna lista con nombres de dias correspondientes
        /// </summary>
        /// <returns></returns>
        string GetDayNames()
        {
            bool[] weekdays_to_bin_Array = CreateBoolArray(this.WeekDays.Value);
            return GetDayNames(weekdays_to_bin_Array);
            //List<String> str = new List<String>();

            //for (int i = weekdays_to_bin_Array.Length-1; i >= 0; i--)
            //{
            //    if (weekdays_to_bin_Array[i])
            //    {
            //        str.Add(ResourceSchedulingBE.Get_DayName_Spanish(i));
            //    }
            //}
            //return string.Join("|", str);
        }

        /// <summary>
        /// SAB	VIE	JUE	MIE	MAR	LUN	DOM
        /// </summary>
        /// <param name="val"></param>
        /// <param name="index"></param>
        public static string Get_DayName_Spanish(int index)
        {
            DayNamesIndex_ES h = (DayNamesIndex_ES)index;
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
        /// Resultado Valor
        /// 0000100	4
        /// 0000101	5
        /// 0000110	6
        /// 0000111	7
        /// 0001000	8
        /// 0001001	9
        /// 0001010	10
        /// </summary>
        /// <param name="weekdays">4</param>
        /// <returns>0000100</returns>
        bool[] CreateBoolArray(int weekdays)
        {
            ///Convierte un número a base 2 o binario
            String weekdays_to_bin = Convert.ToString((weekdays), 2);
            //Creo un vector de caracteres con el string anterior 
            Char[] weekdays_to_bin_Array = weekdays_to_bin.ToArray();

            //Creo una pila LIFO
            Stack<Boolean> stackk = new Stack<Boolean>();
            //string s;
            //Recorro el vector desde atras y los voy metiendo en la pila
            for (int i = weekdays_to_bin_Array.Length - 1; i >= 0; i--)
            {
                //s = weekdays_to_bin_Array[i].ToString();
                bool val = Convert.ToBoolean(Convert.ToInt16(weekdays_to_bin_Array[i].ToString()));
                //                bool val = Convert.ToBoolean(Convert.ToInt16(weekdays_to_bin_Array[i]));
                stackk.Push(val);
            }

            //Completo la pila con con falses hasta llegar a 7 posiciones (i < 7 - weekdays_to_bin_Array.Length)
            //Es desir: Si weekdays_to_bin_Array tiene =  11 dado q weekdays fue 3 completo la pila con 11+00000,
            //de modo q al hacer ToArray me quede : 0000011

            for (int i = 0; i < 7 - weekdays_to_bin_Array.Length; i++)
            {
                stackk.Push(false);
            }

            return stackk.ToArray<Boolean>();

        }

        #endregion


        /// <summary>
        /// Retorna una lista de objetos TimespamView
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<TimespamView> Get_ArrayOfTimes(DateTime date)
        {
            return ResourceSchedulingBE.Get_ArrayOfTimes(date, this.TimeStart_timesp, this.TimeEnd_timesp, this.Duration.Value, this.Description);
        }

        /// <summary>
        /// Retorna una lista de objetos TimespamView
        /// </summary>
        /// <param name="date"></param>
        /// <param name="chekWith"></param>
        /// <returns></returns>
        public List<TimespamView> Get_ArrayOfTimes(DateTime date, Boolean chekWith)
        {
            if (chekWith)
            {
                if (!Date_IsContained(date))
                    return null;
            }
            return ResourceSchedulingBE.Get_ArrayOfTimes(date, this.TimeStart_timesp, this.TimeEnd_timesp, this.Duration.Value, this.Description);
        }

        /// <summary>
        /// Retorna una lista de objetos TimespamView
        /// </summary>
        /// <param name="currentDate">Fehca actual</param>
        /// <param name="start">Hora inicio</param>
        /// <param name="end">Hora fin</param>
        /// <param name="duration">duracion del intervalo</param>
        /// <param name="name">Nombre</param>
        /// <returns></returns>
        public static List<TimespamView> Get_ArrayOfTimes(DateTime currentDate, TimeSpan start, TimeSpan end, Double duration, string name)
        {
            List<TimespamView> times = new List<TimespamView>();
            currentDate = Fwk.HelperFunctions.DateFunctions.GetStartDateTime(currentDate);
            TimeSpan t = start;
            TimespamView wTimespamView;
            while (true)
            {
                //Para este algoritmo colaboro el cuero mrenaudo 
                //if ((end - t).TotalMinutes >= 0)
                if ((end - t).TotalMinutes >= duration)
                {
                    wTimespamView = new TimespamView(currentDate);
                    wTimespamView.Time = t;
                    wTimespamView.Duration = duration;
                    wTimespamView.Name = name;

                    times.Add(wTimespamView);

                    t = t.Add(TimeSpan.FromMinutes(duration));

                }
                else
                    break;
            }
            return times;
        }


    }

    public partial class AppointmentBE
    {
        
        
        public ProfesionalAppointmentBE ProfesionalAppointment { get; set; }
        /// <summary>
        /// Hora de inicio HH:MM
        /// </summary>
        public TimeSpan TimeStart_timesp
        {
            
            get { return new TimeSpan (Start.Value.Ticks); }
        }
        /// <summary>
        /// Hora Fin HH:MM
        /// </summary>
        public TimeSpan TimeEnd_timesp
        {
            get { return new TimeSpan(End.Value.Ticks); }
        }
        /// <summary>
        /// Hora de inicio HH:MM
        /// </summary>
        public String TimeStart
        {
            get {

                return String.Concat(TimeStart_timesp.ToString("hh"), ":", TimeStart_timesp.ToString("mm"));
            //return String.Format("{0}:{1}", this.TimeStart.ToString("hh"), this.TimeStart.ToString("mm"));
            }
        }
        /// <summary>
        /// Hora Fin HH:MM
        /// </summary>
        public String TimeEnd
        {
            get { return String.Concat(TimeEnd_timesp.ToString("hh"), ":", TimeEnd_timesp.ToString("mm")); }//String.Format("{0}:{1}", this.End.Value.Hour, this.End.Value.Minute); }
        }
    }

    /// <summary>
    /// Representa un intervalo de tiempo puntual generado a partir del la programacion de turnos del Profesional.
    /// Una lista de TimespamView por ejemplo podria representar los intervalos de tiempo de disponibilidad 
    /// horaria para un prefecional en un dia determinada y turno determinado
    /// 
    /// Este elemento es utilizado para rellenar las grillas donde aparecen los turnos otorgados y turnos disponible.
    /// Un turno disponible es un turno inexistente o un turno no registrado en la base de datos.
    /// </summary>
    public class TimespamView
    {
        long? nowTicks = null;
        public TimespamView()
        {
            
            nowTicks = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second).Ticks;
            
        }
        public TimespamView(string value)
        {
            //this.Time =  System.TimeSpan.Parse(String.Format("{0}:{0}",)
            nowTicks = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second).Ticks;
        }
        public TimespamView(DateTime date)
        {
            //Menor que cero t1 es menor que t2.

            //Para fechas date anterior a hoy no se usa nowTicks
            

            //El pasado u hoy
            if (date.CompareTo(DateTime.Now) <= 0)
                nowTicks = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second).Ticks;

            //Futuro Siempre esta libre siempre y cuando no esta en otro estado
            if (date.CompareTo(DateTime.Now) > 0)
                nowTicks = -1;
        }

        public bool IsExceptional
        {
            get
            {
                if (Appointment != null)
                    return Appointment.IsExceptional;

                return false;
            }
        }
     

        public int? Status
        {
            get
            {
                if (Appointment != null)
                    return Appointment.Status;

                if (!nowTicks.HasValue)
                    return (int)AppoimantsStatus_SP.Nulo;

                if (nowTicks.Equals(-1)) return (int)AppoimantsStatus_SP.Libre;

                //Si tiempo final del TimespamView es mayor a ahora elta libre
                long t = Time.Add(TimeSpan.FromMinutes(Duration)).Ticks;


                if (nowTicks < t)
                    return (int)AppoimantsStatus_SP.Libre;
                else
                    return (int)AppoimantsStatus_SP.Nulo;
            }

        }

        public TimeSpan Time { get; set; }
        public String Description
        {
            get
            {

                if (Appointment != null)
                    return Appointment.Subject;

                return String.Empty;
            }
           
        }
    
        public AppointmentBE Appointment { get; set; }
        public String Name { get; set; }
        public string TimeString
        {
            get
            {
                return String.Concat(Time.ToString("hh"), ":", Time.ToString("mm"));
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

        public double Duration { get; set; }
    }

    public partial class MutualPorPacienteBE
    {
        public string NombreMutual { get; set; }
    }
}

