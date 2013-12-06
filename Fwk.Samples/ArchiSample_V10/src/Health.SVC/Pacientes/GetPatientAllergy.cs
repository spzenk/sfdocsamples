using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.BE;


namespace Health.Isvc.GetPatientAllergy
{
    [Serializable]
    public class GetPatientAllergyReq : Fwk.Bases.Request<Params>
    {
        public GetPatientAllergyReq()
        {
            base.ServiceName = "GetPatientAllergyService";
        }
    }
    [XmlInclude(typeof(Params)), Serializable]
    public class Params : Fwk.Bases.Entity
    {
        public int PatientId { get; set; }
    }


    [Serializable]
    public class GetPatientAllergyRes : Fwk.Bases.Response<PatientAllergyBE>
    {
    }

  
}
