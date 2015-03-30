using System;
using System.Linq;
using System.Collections.Generic;
using Health.Entities;
using Fwk.Bases;

using Health.Isvc.RetriveAppointment;
using Health.Back;
using Health.BE;
using Health.BE.Enums;
namespace Health.Svc
{
    /// <summary>
    /// Retorna Appoinments para profesionales. Antes de retornarlos chequea que no hallan expirado.- Si es 
    /// así actualiza a expirado
    /// </summary>
    public class RetriveAppointmentService : BusinessService<RetriveAppointmentReq, RetriveAppointmentRes>
    {
        public override RetriveAppointmentRes Execute(RetriveAppointmentReq pServiceRequest)
        {
            RetriveAppointmentRes wRes = new RetriveAppointmentRes();

            wRes.BusinessData.AppoimentsList = SchedulingDAC.Retrive_ProfessionalAppointment(pServiceRequest.BusinessData.StartDate,
                pServiceRequest.BusinessData.Status, pServiceRequest.BusinessData.ResourseId, pServiceRequest.BusinessData.HealthInstId);

            Guid g = new Guid(pServiceRequest.ContextInformation.UserId);
            //TODO: Mejorar ciclo

            foreach (AppointmentBE appointment in wRes.BusinessData.AppoimentsList.Where(p => 
                p.Status.Equals((int)AppoimantsStatus_SP.Reservado)))
            {
                if (appointment.End <= DateTime.Now)
                {
                    Health.Back.SchedulingDAC.Update_Appointment_Status(appointment.AppointmentId, AppoimantsStatus_SP.Expirado,(g));
                }
            }

            return wRes;
        }

       
    }
}
