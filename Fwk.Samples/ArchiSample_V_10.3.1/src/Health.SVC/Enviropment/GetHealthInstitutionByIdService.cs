using System;
using System.Linq;
using System.Collections.Generic;
using Health.Entities;
using Fwk.Bases;

using Health.Isvc.GetHealthInstitutionById;
using Health.Back;
using Health.BE;
namespace Health.Svc
{
    /// <summary>
    /// Retorna InstitucionBE 
    /// </summary>
    public class GetHealthInstitutionByIdService : BusinessService<GetHealthInstitutionByIdReq, GetHealthInstitutionByIdRes>
    {
        public override GetHealthInstitutionByIdRes Execute(GetHealthInstitutionByIdReq pServiceRequest)
        {
            GetHealthInstitutionByIdRes wRes = new GetHealthInstitutionByIdRes();

            wRes.BusinessData = HealthInstitutionDAC.GetById(pServiceRequest.BusinessData.HealthInstId,null);


            return wRes;

          
        }

       
    }
}
