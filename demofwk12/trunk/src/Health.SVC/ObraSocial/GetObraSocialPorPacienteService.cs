using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.Isvc.GetObraSocialPorPatient;
using Health.Back;

using Health.BE;


namespace Health.Svc
{
    /// <summary>
    /// 
    /// </summary>
    public class GetObraSocialPorPatientService : BusinessService<GetObraSocialPorPatientReq, GetObraSocialPorPatientRes>
    {
        public override GetObraSocialPorPatientRes Execute(GetObraSocialPorPatientReq pServiceRequest)
        {
            GetObraSocialPorPatientRes wRes = new GetObraSocialPorPatientRes();

            wRes.BusinessData = ObraSocialDAC.RetriveByIdPatient(pServiceRequest.BusinessData.PatientId);

            
            return wRes;
        }
    }
}
