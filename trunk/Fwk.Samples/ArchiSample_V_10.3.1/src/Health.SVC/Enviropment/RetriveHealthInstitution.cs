using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.BE;


namespace Health.Isvc.RetriveHealthInstitution
{
    [Serializable]
    public class RetriveHealthInstitutionReq : Fwk.Bases.Request<Params>
    {
        public RetriveHealthInstitutionReq()
        {
            base.ServiceName = "RetriveHealthInstitutionService";
        }
    }
    [XmlInclude(typeof(Params)), Serializable]
    public class Params : Fwk.Bases.Entity
    {
        public string TextToSearch { get; set; }
        public int? ProfesionalId { get; set; }
    }


    [Serializable]
    public class RetriveHealthInstitutionRes : Fwk.Bases.Response<HealthInstitutionList>
    {
        
    }

  
}
