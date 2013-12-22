using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.BE;


namespace Health.Isvc.CreateUpdatePatientMedicament
{
    [Serializable]
    public class CreateUpdatePatientMedicamentReq : Fwk.Bases.Request<PatientMedicament_ViewBE>
    {
        public CreateUpdatePatientMedicamentReq()
        {
            base.ServiceName = "CreateUpdatePatientMedicamentService";
        }
    }
   

    [Serializable]
    public class CreateUpdatePatientMedicamentRes : Fwk.Bases.Response<DummyContract>
    {
    }

  
}
