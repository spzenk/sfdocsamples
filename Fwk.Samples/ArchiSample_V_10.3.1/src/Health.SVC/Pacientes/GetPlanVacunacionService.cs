
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.Isvc.GetPlanVacunacion;
using Health.Back;



namespace Health.Svc
{

    public class GetPlanVacunacionService : BusinessService<GetPlanVacunacionReq, GetPlanVacunacionRes>
    {
        public override GetPlanVacunacionRes Execute(GetPlanVacunacionReq pServiceRequest)
        {
            GetPlanVacunacionRes wRes = new GetPlanVacunacionRes();

            wRes.BusinessData =PatientsDAC.GetPlanVacunacion(pServiceRequest.BusinessData.IdPatient);


            return wRes;
        }


    }

}
