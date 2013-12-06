using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.BE;


namespace Health.Isvc.CreateUpdatePatientAllergy
{
    [Serializable]
    public class CreateUpdatePatientAllergyReq : Fwk.Bases.Request<PatientAllergyBE>
    {
        public CreateUpdatePatientAllergyReq()
        {
            base.ServiceName = "CreateUpdatePatientAllergyService";
        }
    }
   

    [Serializable]
    public class CreateUpdatePatientAllergyRes : Fwk.Bases.Response<DummyContract>
    {
    }

  
}
