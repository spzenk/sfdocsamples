using System;
using System.Collections.Generic;
using Health.Entities;
using Fwk.Bases;

using Health.Isvc.CreateResourceScheduling;
using Health.Back;
using Health.BE;
namespace Health.Svc
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateResourceSchedulingService : BusinessService<CreateResourceSchedulingReq, CreateResourceSchedulingRes>
    {
        public override CreateResourceSchedulingRes Execute(CreateResourceSchedulingReq pServiceRequest)
        {
            CreateResourceSchedulingRes wRes = new CreateResourceSchedulingRes();

            SchedulingDAC.Create(pServiceRequest.BusinessData, new Guid(pServiceRequest.ContextInformation.UserId));

            return wRes;
        }

       
    }
}
