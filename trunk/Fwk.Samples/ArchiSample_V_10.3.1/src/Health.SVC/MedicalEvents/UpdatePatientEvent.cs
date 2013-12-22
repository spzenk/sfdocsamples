using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.BE;


namespace Health.Isvc.UpdatePatientEvent
{
    [Serializable]
    public class UpdatePatientEventReq : Fwk.Bases.Request<MedicalEventBE>
    {
        public UpdatePatientEventReq()
        {
            base.ServiceName = "UpdatePatientEventService";
        }
    }
   
   
    [Serializable]
    public class UpdatePatientEventRes : Fwk.Bases.Response<DummyContract>
    {
    }
 

  
}
