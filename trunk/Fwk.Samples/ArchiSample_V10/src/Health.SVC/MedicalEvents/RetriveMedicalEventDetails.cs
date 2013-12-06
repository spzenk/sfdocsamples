using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.BE;


namespace Health.Isvc.RetriveMedicalEventDetails
{
    [Serializable]
    public class RetriveMedicalEventDetailsReq : Fwk.Bases.Request<Params>
    {
        public RetriveMedicalEventDetailsReq()
        {
            base.ServiceName = "RetriveMedicalEventDetailsService";
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
    public class RetriveMedicalEventDetailsRes : Fwk.Bases.Response<MedicalEventDetail_ViewList>
    {
        
    }

  
}
