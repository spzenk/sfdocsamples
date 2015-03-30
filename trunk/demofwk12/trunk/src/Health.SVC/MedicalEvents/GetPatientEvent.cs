using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.BE;


namespace Health.Isvc.GetPatientEvent
{
    [Serializable]
    public class GetPatientEventReq : Fwk.Bases.Request<Params>
    {
        public GetPatientEventReq()
        {
            base.ServiceName = "GetPatientEventService";
        }
    }
    [XmlInclude(typeof(Params)), Serializable]
    public class Params : Fwk.Bases.Entity
    {
        public int MedicalEventId { get; set; }
        
    }


    [Serializable]
    public class GetPatientEventRes : Fwk.Bases.Response<MedicalEventBE>
    {
        
    }

  
}
