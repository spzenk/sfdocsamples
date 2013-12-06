using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.BE;


namespace Health.Isvc.RetriveProfesionales
{
   
    [Serializable]
    public class RetriveProfesionalesReq : Fwk.Bases.Request<Params>
    {
        public RetriveProfesionalesReq()
        {
            base.ServiceName = "RetriveProfesionalesService";
        }
    }
    [XmlInclude(typeof(Params)), Serializable]
    public class Params : Fwk.Bases.Entity
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public Guid? HealthInstId { get; set; }
        
    }


    [Serializable]
    public class RetriveProfesionalesRes : Fwk.Bases.Response<Profesional_FullViewList>
    {
    }

    //[XmlInclude(typeof(Result)), Serializable]
    //public class Result : Fwk.Bases.Entity
    //{
    //    public ProfesionalList ProfesionalList { get; set; }
    //}
}
