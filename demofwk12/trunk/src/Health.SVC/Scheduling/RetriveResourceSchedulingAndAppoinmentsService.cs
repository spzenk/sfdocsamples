using System;
using System.Linq;
using System.Collections.Generic;
using Health.Entities;
using Fwk.Bases;

using Health.Isvc.RetriveResourceSchedulingAndAppoinments;
using Health.Back;
using Health.BE;
using Health.BE.Enums;
namespace Health.Svc
{
    /// <summary>
    /// Retorna los turnos asignados a un profesionale
    /// </summary>
    public class RetriveResourceSchedulingAndAppoinmentsService : BusinessService<RetriveResourceSchedulingAndAppoinmentsReq, RetriveResourceSchedulingAndAppoinmentsRes>
    {
        public override RetriveResourceSchedulingAndAppoinmentsRes Execute(RetriveResourceSchedulingAndAppoinmentsReq pServiceRequest)
        {
            RetriveResourceSchedulingAndAppoinmentsRes wRes = new RetriveResourceSchedulingAndAppoinmentsRes();

            wRes.BusinessData.ResourceSchedulerList = SchedulingDAC.RetriveBy_ResourceId(pServiceRequest.BusinessData.ResourceId, pServiceRequest.BusinessData.HealthInstId);

            if (pServiceRequest.BusinessData.UseStartDate)
                wRes.BusinessData.AppoimentsList = SchedulingDAC.Retrive_Appointment_By_Params_1(pServiceRequest.BusinessData.ResourceId, pServiceRequest.BusinessData.Date, null, pServiceRequest.BusinessData.HealthInstId);
            else
                wRes.BusinessData.AppoimentsList = SchedulingDAC.Retrive_Appointment_By_Params_2(pServiceRequest.BusinessData.ResourceId, pServiceRequest.BusinessData.Date, null, pServiceRequest.BusinessData.HealthInstId);

            Guid g = new Guid(pServiceRequest.ContextInformation.UserId);
            foreach (AppointmentBE appointment in wRes.BusinessData.AppoimentsList.Where(p =>
             p.Status.Equals((int)AppoimantsStatus_SP.Reservado)))
            {
                if (appointment.End <= DateTime.Now)
                {
                    Health.Back.SchedulingDAC.Update_Appointment_Status(appointment.AppointmentId, AppoimantsStatus_SP.Expirado, (g));
                }
            }

            return wRes;
        }


    }
}
