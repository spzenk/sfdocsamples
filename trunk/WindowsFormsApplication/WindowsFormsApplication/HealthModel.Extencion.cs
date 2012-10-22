using System;
using System.Linq;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;


namespace Health.BE
{

    [XmlRoot("PatientMedicament_ViewList"), SerializableAttribute]
    public partial class PatientMedicament_ViewList : Fwk.Bases.Entities<PatientMedicament_ViewBE> { }

    [XmlInclude(typeof(PatientMedicament_ViewBE)), Serializable]
    public partial class PatientMedicament_ViewBE : Fwk.Bases.Entity
    {

        public string MedicamentStatusInfo { get; set; }
        #region Primitive Properties

        /// <summary>
        /// 
        /// </summary>
        public global::System.Int32 PatientMedicamentId
        {
            get
            {
                return _PatientMedicamentId;
            }
            set
            {
                _PatientMedicamentId = value;
            }
        }

        private global::System.Int32 _PatientMedicamentId;



        /// <summary>
        /// 
        /// </summary>
        public global::System.DateTime CreatedDate
        {
            get
            {
                return _CreatedDate;
            }
            set
            {
                _CreatedDate = value;
            }
        }

        private global::System.DateTime _CreatedDate;



        /// <summary>
        /// 
        /// </summary>
        public global::System.Boolean IsPermanent
        {
            get
            {
                return _IsPermanent;
            }
            set
            {
                _IsPermanent = value;
            }
        }

        private global::System.Boolean _IsPermanent;



        /// <summary>
        /// 
        /// </summary>
        public global::System.Boolean IsSuspended
        {
            get
            {
                return _IsSuspended;
            }
            set
            {
                _IsSuspended = value;
            }
        }

        private global::System.Boolean _IsSuspended;



        /// <summary>
        /// 
        /// </summary>
        public global::System.String MedicamentName
        {
            get
            {
                return _MedicamentName;
            }
            set
            {
                _MedicamentName = value;
            }
        }

        private global::System.String _MedicamentName;



        /// <summary>
        /// 
        /// </summary>
        public global::System.Int16 Periodicity_hours
        {
            get
            {
                return _Periodicity_hours;
            }
            set
            {
                _Periodicity_hours = value;
            }
        }

        private global::System.Int16 _Periodicity_hours;



        /// <summary>
        /// 
        /// </summary>
        public global::System.Int16 DaysCount
        {
            get
            {
                return _DaysCount;
            }
            set
            {
                _DaysCount = value;
            }
        }

        private global::System.Int16 _DaysCount;



        /// <summary>
        /// 
        /// </summary>
        public global::System.Int32 MedicalEventId
        {
            get
            {
                return _MedicalEventId;
            }
            set
            {
                _MedicalEventId = value;
            }
        }

        private global::System.Int32 _MedicalEventId;



        /// <summary>
        /// 
        /// </summary>
        public Nullable<global::System.Int32> PatientMedicamentId_Parent
        {
            get
            {
                return _PatientMedicamentId_Parent;
            }
            set
            {
                _PatientMedicamentId_Parent = value;
            }
        }

        private Nullable<global::System.Int32> _PatientMedicamentId_Parent;



        /// <summary>
        /// 
        /// </summary>
        public global::System.String NombreProfesional
        {
            get
            {
                return _NombreProfesional;
            }
            set
            {
                _NombreProfesional = value;
            }
        }

        private global::System.String _NombreProfesional;



        /// <summary>
        /// 
        /// </summary>
        public global::System.String ApellidoProfesional
        {
            get
            {
                return _ApellidoProfesional;
            }
            set
            {
                _ApellidoProfesional = value;
            }
        }

        private global::System.String _ApellidoProfesional;



        /// <summary>
        /// 
        /// </summary>
        public global::System.Int32 PatientId
        {
            get
            {
                return _PatientId;
            }
            set
            {
                _PatientId = value;
            }
        }

        private global::System.Int32 _PatientId;



        /// <summary>
        /// 
        /// </summary>
        public global::System.String MedicamentPresentation
        {
            get
            {
                return _MedicamentPresentation;
            }
            set
            {
                _MedicamentPresentation = value;
            }
        }

        private global::System.String _MedicamentPresentation;



        /// <summary>
        /// 
        /// </summary>
        public global::System.Boolean Enabled
        {
            get
            {
                return _Enabled;
            }
            set
            {
                _Enabled = value;
            }
        }

        private global::System.Boolean _Enabled;



        /// <summary>
        /// 
        /// </summary>
        public global::System.String Dosis
        {
            get
            {
                return _Dosis;
            }
            set
            {
                _Dosis = value;
            }
        }

        private global::System.String _Dosis;



        /// <summary>
        /// 
        /// </summary>
        public global::System.Int32 IdEspesialidad
        {
            get
            {
                return _IdEspesialidad;
            }
            set
            {
                _IdEspesialidad = value;
            }
        }

        private global::System.Int32 _IdEspesialidad;



        /// <summary>
        /// 
        /// </summary>
        public Nullable<global::System.Int32> IdTipoConsulta
        {
            get
            {
                return _IdTipoConsulta;
            }
            set
            {
                _IdTipoConsulta = value;
            }
        }

        private Nullable<global::System.Int32> _IdTipoConsulta;



        /// <summary>
        /// 
        /// </summary>
        public global::System.String NombreEspesialidad
        {
            get
            {
                return _NombreEspesialidad;
            }
            set
            {
                _NombreEspesialidad = value;
            }
        }

        private global::System.String _NombreEspesialidad;



        /// <summary>
        /// 
        /// </summary>
        public global::System.String NombreTipoConsulta
        {
            get
            {
                return _NombreTipoConsulta;
            }
            set
            {
                _NombreTipoConsulta = value;
            }
        }

        private global::System.String _NombreTipoConsulta;



        #endregion


        /// <summary>
        /// Empty Constructor
        /// </summary>
        public PatientMedicament_ViewBE() { }

   
    }
    
    
    public partial class MedicalEventBE
    {

        public PatientMedicament_ViewList PatientMedicaments { get; set; }
        public string NombreApellidoProfecional { get; set; }
        public string NombreEspesialidad { get; set; }

        public string InstitucionRazonSocial { get; set; }

    }
  
}

