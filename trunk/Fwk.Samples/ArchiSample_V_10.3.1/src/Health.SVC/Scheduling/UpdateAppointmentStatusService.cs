using System;
using System.Collections.Generic;
using Health.Entities;
using Fwk.Bases;

using Health.Isvc.UpdateAppointmentStatus;
using Health.Back;
using Health.BE;
using Health.BE.Enums;
namespace Health.Svc
{
    /// <summary>
    /// Actualiza solo estados de Appointment
    /// </summary>
    public class UpdateAppointmentStatusService : BusinessService<UpdateAppointmentStatusReq, UpdateAppointmentStatusRes>
    {
        public override UpdateAppointmentStatusRes Execute(UpdateAppointmentStatusReq pServiceRequest)
        {
            UpdateAppointmentStatusRes wRes = new UpdateAppointmentStatusRes();

            foreach (AppointmentBE app in pServiceRequest.BusinessData)
            {
                SchedulingDAC.Update_Appointment_Status(app.AppointmentId, (AppoimantsStatus_SP)app.Status, new Guid(pServiceRequest.ContextInformation.UserId));
            }
            return wRes;
        }
      
    }
}
