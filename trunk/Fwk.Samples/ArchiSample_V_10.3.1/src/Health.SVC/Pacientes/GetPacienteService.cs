using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.Isvc.GetPatient;
using Health.Back;

using Health.BE;


namespace Health.Svc
{
    /// <summary>
    /// 
    /// </summary>
    public class GetPatientService : BusinessService<GetPatientReq, GetPatientRes>
    {
        public override GetPatientRes Execute(GetPatientReq pServiceRequest)
        {
            GetPatientRes wRes = new GetPatientRes();

            wRes.BusinessData.Patient = PatientsDAC.GetById(pServiceRequest.BusinessData.Id);
            wRes.BusinessData.Mutuales = ObraSocialDAC.RetriveByIdPatient(pServiceRequest.BusinessData.Id);
            return wRes;
        }
    }
}
