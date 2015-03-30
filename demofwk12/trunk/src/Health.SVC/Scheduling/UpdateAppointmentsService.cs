using System;
using System.Collections.Generic;
using Health.Entities;
using Fwk.Bases;

using Health.Isvc.UpdateAppointments;
using Health.Back;
using Health.BE;
namespace Health.Svc
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateAppointmentsService : BusinessService<UpdateAppointmentsReq, UpdateAppointmentsRes>
    {
        public override UpdateAppointmentsRes Execute(UpdateAppointmentsReq pServiceRequest)
        {
            UpdateAppointmentsRes wRes = new UpdateAppointmentsRes();

            if (pServiceRequest.BusinessData!=null)
                SchedulingDAC.Update_Appointments(pServiceRequest.BusinessData, new Guid(pServiceRequest.ContextInformation.UserId));

            return wRes;
        }
      
    }
}
