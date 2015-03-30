using System;
using System.Collections.Generic;
using Health.Entities;
using Fwk.Bases;

using Health.Isvc.CreateAppointments;
using Health.Back;
using Health.BE;
namespace Health.Svc
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateAppointmentsService : BusinessService<CreateAppointmentsReq, CreateAppointmentsRes>
    {
        public override CreateAppointmentsRes Execute(CreateAppointmentsReq pServiceRequest)
        {
            CreateAppointmentsRes wRes = new CreateAppointmentsRes();

            SchedulingDAC.Create_Appointments(pServiceRequest.BusinessData, new Guid(pServiceRequest.ContextInformation.UserId));

            return wRes;
        }

       
    }
}
