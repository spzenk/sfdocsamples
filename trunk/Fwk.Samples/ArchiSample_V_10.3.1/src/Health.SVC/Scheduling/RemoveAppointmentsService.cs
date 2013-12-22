using System;
using System.Collections.Generic;
using Health.Entities;
using Fwk.Bases;

using Health.Isvc.RemoveAppointment;
using Health.Back;
using Health.BE;
namespace Health.Svc
{
    /// <summary>
    /// 
    /// </summary>
    public class RemoveAppoimentService : BusinessService<RemoveAppointmentReq, RemoveAppointmentRes>
    {
        public override RemoveAppointmentRes Execute(RemoveAppointmentReq pServiceRequest)
        {
            RemoveAppointmentRes wRes = new RemoveAppointmentRes();

            SchedulingDAC.RemoveAppointment(pServiceRequest.BusinessData.AppointmentId);
            

            return wRes;
        }

       
    }
}
