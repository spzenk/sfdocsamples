
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.Isvc.UpdatePlanVacunacion;
using Health.Back;


namespace Health.Svc
{

    public class UpdatePlanVacunacionService : BusinessService<UpdatePlanVacunacionReq, UpdatePlanVacunacionRes>
    {
        public override UpdatePlanVacunacionRes Execute(UpdatePlanVacunacionReq pServiceRequest)
        {
            UpdatePlanVacunacionRes wRes = new UpdatePlanVacunacionRes();
            Guid wLastAccessUserId = Guid.Parse(pServiceRequest.ContextInformation.UserId);

            PatientsDAC.UpdatePlanVacunacion(pServiceRequest.BusinessData, wLastAccessUserId);


            return wRes;
        }


    }
}


