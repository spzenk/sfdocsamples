using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.BE;


namespace Health.Isvc.RetrivePatientMedicaments
{
    [Serializable]
    public class RetrivePatientMedicamentsReq : Fwk.Bases.Request<Params>
    {
        public RetrivePatientMedicamentsReq()
        {
            base.ServiceName = "RetrivePatientMedicamentsService";
        }
    }
    [XmlInclude(typeof(Params)), Serializable]
    public class Params : Fwk.Bases.Entity
    {
        public int PatientId { get; set; }
        public bool RetriveHistory { get; set; }
        public int? MedicalEventId { get; set; }
    }


    [Serializable]
    public class RetrivePatientMedicamentsRes : Fwk.Bases.Response<PatientMedicament_ViewList>
    {
        
    }

  
}
