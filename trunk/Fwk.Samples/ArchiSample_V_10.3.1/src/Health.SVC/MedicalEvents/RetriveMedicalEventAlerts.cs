using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.BE;


namespace Health.Isvc.RetriveMedicalEventAlerts
{
    [Serializable]
    public class RetriveMedicalEventAlertsReq : Fwk.Bases.Request<Params>
    {
        public RetriveMedicalEventAlertsReq()
        {
            base.ServiceName = "RetriveMedicalEventAlertsService";
        }
    }
    [XmlInclude(typeof(Params)), Serializable]
    public class Params : Fwk.Bases.Entity
    {
        public int PatientId { get; set; }
        public bool RetriveHistory { get; set; }
        public int? MedicalEventId { get; set; }

        public DateTime? StartDate { get; set; }
    }


    [Serializable]
    public class RetriveMedicalEventAlertsRes : Fwk.Bases.Response<MedicalEventAlert_ViewList>
    {
        
    }

  
}
