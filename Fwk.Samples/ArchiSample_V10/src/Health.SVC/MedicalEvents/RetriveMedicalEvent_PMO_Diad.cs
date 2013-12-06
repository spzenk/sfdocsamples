using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.BE;


namespace Health.Isvc.RetriveMedicalEventPMO_Diag
{
    [Serializable]
    public class RetriveMedicalEventPMO_DiagReq : Fwk.Bases.Request<Params>
    {
        public RetriveMedicalEventPMO_DiagReq()
        {
            base.ServiceName = "RetriveMedicalEventPMO_DiagService";
        }
    }
    [XmlInclude(typeof(Params)), Serializable]
    public class Params : Fwk.Bases.Entity
    {
        public int PatientId { get; set; }
        public bool Retrive_CEI10 { get; set; }
        public bool Retrive_PMOQuir { get; set; }
        public bool Retrive_PMOMetodoComplementario { get; set; }
    }


    [Serializable]
    public class RetriveMedicalEventPMO_DiagRes : Fwk.Bases.Response<MedicalEventPMO_Diag_List>
    {
        
    }

  
}
