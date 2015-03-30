
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.Isvc.RetriveHealthInstitution;
using Health.Back;

using Health.BE;


namespace Health.Svc
{
    /// <summary>
    ///Retorna eventos realizados a un determinado Patient
    /// 
    /// 
    /// </summary>
    public class RetriveHealthInstitutionService : BusinessService<RetriveHealthInstitutionReq, RetriveHealthInstitutionRes>
    {
        public override RetriveHealthInstitutionRes Execute(RetriveHealthInstitutionReq pServiceRequest)
        {
            RetriveHealthInstitutionRes wRes = new RetriveHealthInstitutionRes();

            wRes.BusinessData = HealthInstitutionDAC.RetriveHealthInstitutionByParams(pServiceRequest.BusinessData.TextToSearch);


            return wRes;
        }


    }

}
