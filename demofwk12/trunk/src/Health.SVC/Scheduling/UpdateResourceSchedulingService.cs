using System;
using System.Collections.Generic;
using Health.Entities;
using Fwk.Bases;

using Health.Isvc.UpdateResourceScheduling;
using Health.Back;
using Health.BE;
namespace Health.Svc
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateResourceSchedulingService : BusinessService<UpdateResourceSchedulingReq, UpdateResourceSchedulingRes>
    {
        public override UpdateResourceSchedulingRes Execute(UpdateResourceSchedulingReq pServiceRequest)
        {
            UpdateResourceSchedulingRes wRes = new UpdateResourceSchedulingRes();
            if (pServiceRequest.BusinessData != null)
                SchedulingDAC.Update(pServiceRequest.BusinessData, new Guid(pServiceRequest.ContextInformation.UserId));

            return wRes;
        }


    }
}
