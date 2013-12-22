using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.BE;


namespace Health.Isvc.RetrivePatientEvent
{
    [Serializable]
    public class RetrivePatientEventReq : Fwk.Bases.Request<Params>
    {
        public RetrivePatientEventReq()
        {
            base.ServiceName = "RetrivePatientEventService";
        }
    }
    [XmlInclude(typeof(Params)), Serializable]
    public class Params : Fwk.Bases.Entity
    {
        public int PatientId { get; set; }

        
        
    }


    [Serializable]
    public class RetrivePatientEventRes : Fwk.Bases.Response<MedicalEvent_ViewList>
    {
        
    }

  
}
