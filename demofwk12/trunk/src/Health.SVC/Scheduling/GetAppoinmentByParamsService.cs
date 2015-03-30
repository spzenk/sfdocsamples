using System;
using System.Linq;
using System.Collections.Generic;
using Health.Entities;
using Fwk.Bases;

using Health.Isvc.GetAppoinmentByParams;
using Health.Back;
using Health.BE;
using Health.BE.Enums;
namespace Health.Svc
{
    /// <summary>
    /// Obtiene Appoinment . Antes de retornarlo chequea que no hallan expirado.- Si es 
    /// así actualiza a expirado
    /// </summary>
    public class GetAppoinmentByParamsService : BusinessService<GetAppoinmentByParamsReq, GetAppoinmentByParamsRes>
    {
        public override GetAppoinmentByParamsRes Execute(GetAppoinmentByParamsReq pServiceRequest)
        {
            GetAppoinmentByParamsRes wRes = new GetAppoinmentByParamsRes();

            wRes.BusinessData.AppointmentBE = SchedulingDAC.Get_Appointment_By_Id(pServiceRequest.BusinessData.AppointmentId.Value);
            Guid g = new Guid(pServiceRequest.ContextInformation.UserId);

          
            if (wRes.BusinessData.AppointmentBE.Status == (int)AppoimantsStatus_SP.Reservado
                && wRes.BusinessData.AppointmentBE.End <= DateTime.Now)
            {
                Health.Back.SchedulingDAC.Update_Appointment_Status(wRes.BusinessData.AppointmentBE.AppointmentId, AppoimantsStatus_SP.Expirado, (g));
            }
            //TODO Chequear  En Atencion
            //if (wRes.BusinessData.AppointmentBE.Status == (int)AppoimantsStatus_SP.EnAtencion
            //   && wRes.BusinessData.AppointmentBE.End <= DateTime.Now)
            //{
            //    Health.Back.SchedulingDAC.Update_Appointment_Status(wRes.BusinessData.AppointmentBE.AppointmentId, AppoimantsStatus_SP.Expirado, (g));
            //}
            return wRes;
        }


    }
}
