using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.BE;


namespace Health.Isvc.AuthHealthInstitution
{
    [Serializable]
    public class AuthHealthInstitutionReq : Fwk.Bases.Request<Params>
    {
        public AuthHealthInstitutionReq()
        {
            base.ServiceName = "AuthHealthInstitutionService";
        }
    }
    [XmlInclude(typeof(Params)), Serializable]
    public class Params : Fwk.Bases.Entity
    {
        public Guid HealthInstId { get; set; }
        public Guid? UserId { get; set; }
        public int? ProfesionalId { get; set; }
        
    }


    [Serializable]
    public class AuthHealthInstitutionRes : Fwk.Bases.Response<Result>
    {
    }

    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Fwk.Bases.Entity
    {
        public bool Authenticated { get; set; }
        public string Message { get; set; }
        public HealthInstitution_ProfesionalBE HealthInstitution_ProfesionalBE { get; set; }
    }
}
