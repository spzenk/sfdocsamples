
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.Isvc.GetPatientAllergy;
using Health.Back;
using Health.BE;



namespace Health.Svc
{
    /// <summary>
    /// 
    /// </summary>
    public class GetPatientAllergyService : BusinessService<GetPatientAllergyReq, GetPatientAllergyRes>
    {
        public override GetPatientAllergyRes Execute(GetPatientAllergyReq pServiceRequest)
        {
            GetPatientAllergyRes wRes = new GetPatientAllergyRes();

            wRes.BusinessData =PatientsDAC.GetPatientAllergy(pServiceRequest.BusinessData.PatientId);

            if (wRes.BusinessData == null)
            {
                wRes.BusinessData = new PatientAllergyBE();
                wRes.BusinessData.AllergyId = -1;
            }
            return wRes;
        }


    }

}
