﻿//TextTemplatingFileGenerator
//Use TextTemplatingFileGenerator on Custom tool tt file propertie

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a Fwk 10.0 Code Generator.
//     Runtime Version: 1.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// Author: marcelo 
// Date:   Tuesday, October 09, 2012
//</auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Linq;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;


namespace Health.BE
{
    #region Entities
    

    
    [XmlRoot("MedicalEventList"), SerializableAttribute]
    public partial class MedicalEventList : Fwk.Bases.Entities< MedicalEventBE >{}
    
       [XmlInclude(typeof(MedicalEventBE)), Serializable]
    public partial class MedicalEventBE : Fwk.Bases.Entity
    {
        #region Primitive Properties
    
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
            { _MedicalEventId = value;
    		}
    	}
    	
    	    private global::System.Int32 _MedicalEventId;
       
       
    
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
            { _PatientId = value;
    		}
    	}
    	
    	    private global::System.Int32 _PatientId;
       
       
    
        /// <summary>
        /// 
        /// </summary>
        public global::System.Int32 ProfesionalId
        {
            get
            {
                return _ProfesionalId;
            }
            set
            { _ProfesionalId = value;
    		}
    	}
    	
    	    private global::System.Int32 _ProfesionalId;
       
       
    
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
            { _CreatedDate = value;
    		}
    	}
    	
    	    private global::System.DateTime _CreatedDate;
       
       
    
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
            { _IdEspesialidad = value;
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
            { _IdTipoConsulta = value;
    		}
    	}
    	
    	    private Nullable<global::System.Int32> _IdTipoConsulta;
       
       
    
        /// <summary>
        /// 
        /// </summary>
        public global::System.String Motivo
        {
            get
            {
                return _Motivo;
            }
            set
            { _Motivo = value;
    		}
    	}
    	
    	    private global::System.String _Motivo;
       
       
    
        /// <summary>
        /// 
        /// </summary>
        public Nullable<global::System.Guid> CreatedUserId
        {
            get
            {
                return _CreatedUserId;
            }
            set
            { _CreatedUserId = value;
    		}
    	}
    	
    	    private Nullable<global::System.Guid> _CreatedUserId;
       
       
    
        /// <summary>
        /// 
        /// </summary>
        public global::System.String Evolucion
        {
            get
            {
                return _Evolucion;
            }
            set
            { _Evolucion = value;
    		}
    	}
    	
    	    private global::System.String _Evolucion;
       
       
    
        /// <summary>
        /// 
        /// </summary>
        public Nullable<global::System.Int32> MedicalEventId_Parent
        {
            get
            {
                return _MedicalEventId_Parent;
            }
            set
            { _MedicalEventId_Parent = value;
    		}
    	}
    	
    	    private Nullable<global::System.Int32> _MedicalEventId_Parent;
       
       
    
        /// <summary>
        /// 
        /// </summary>
        public global::System.String Diagnosis
        {
            get
            {
                return _Diagnosis;
            }
            set
            { _Diagnosis = value;
    		}
    	}
    	
    	    private global::System.String _Diagnosis;
       
       
    
        /// <summary>
        /// 
        /// </summary>
        public global::System.String CEI10_Code
        {
            get
            {
                return _CEI10_Code;
            }
            set
            { _CEI10_Code = value;
    		}
    	}
    	
    	    private global::System.String _CEI10_Code;
       
       
    
        /// <summary>
        /// 
        /// </summary>
        public global::System.Boolean IsDefinitive
        {
            get
            {
                return _IsDefinitive;
            }
            set
            { _IsDefinitive = value;
    		}
    	}
    	
    	    private global::System.Boolean _IsDefinitive;
       
       
    
        /// <summary>
        /// 
        /// </summary>
        public global::System.String MetodoComplementario
        {
            get
            {
                return _MetodoComplementario;
            }
            set
            { _MetodoComplementario = value;
    		}
    	}
    	
    	    private global::System.String _MetodoComplementario;
       
       
    
        /// <summary>
        /// 
        /// </summary>
        public Nullable<global::System.Int32> AppointmentId
        {
            get
            {
                return _AppointmentId;
            }
            set
            { _AppointmentId = value;
    		}
    	}
    	
    	    private Nullable<global::System.Int32> _AppointmentId;
       
       
    
        /// <summary>
        /// 
        /// </summary>
        public global::System.String PMOQuirurgico
        {
            get
            {
                return _PMOQuirurgico;
            }
            set
            { _PMOQuirurgico = value;
    		}
    	}
    	
    	    private global::System.String _PMOQuirurgico;
       
       
    
        /// <summary>
        /// 
        /// </summary>
        public Nullable<global::System.Guid> HealthInstitutionId
        {
            get
            {
                return _HealthInstitutionId;
            }
            set
            { _HealthInstitutionId = value;
    		}
    	}
    	
    	    private Nullable<global::System.Guid> _HealthInstitutionId;
       
       

        #endregion
            
            
            /// <summary>
            /// Empty Constructor
            /// </summary>
            public MedicalEventBE(){}

            

            }
    
    
    
    
    #endregion
    
}