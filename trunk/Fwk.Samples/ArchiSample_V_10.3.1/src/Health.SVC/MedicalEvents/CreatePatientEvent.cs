using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.BE;


namespace Health.Isvc.CreatePatientEvent
{
    [Serializable]
    public class CreatePatientEventReq : Fwk.Bases.Request<MedicalEventBE>
    {
        public CreatePatientEventReq()
        {
            base.ServiceName = "CreatePatientEventService";
        }
    }
   
   
    [Serializable]
    public class CreatePatientEventRes : Fwk.Bases.Response<Result>
    {
    }
    [Serializable]
    public class Result : Entity
    {
        public int EventId { get; set; }
    }

  
}
