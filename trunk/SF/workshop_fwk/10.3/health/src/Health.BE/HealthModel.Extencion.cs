using System;
using System.Linq;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;
using Health.Back.BE;
using Health.BE.Enums;

namespace Health.BE
{
    

  

    public partial class PatientBE
    {
        public PersonaBE Persona { get; set; }
    }





    public partial class PersonaBE
    {
        
     

        public String ApellidoNombre
          {
            get {
                return this._Apellido + this.Nombre
            }
        }
    }

    
  

 
}

