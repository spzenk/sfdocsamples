
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.Isvc.GetPatientEvent;
using Health.Back;

using Health.BE;


namespace Health.Svc
{
    /// <summary>
    ///Retorna un evento realizados a un determinado Patient
    ///Retorna MedicalEventDetail_ViewList del propieo evento y de eventos anteriores que sean relevante y esten con relevancia activa
    /// 
    /// 
    /// </summary>
    public class GetPatientEventService : BusinessService<GetPatientEventReq, GetPatientEventRes>
    {
        public override GetPatientEventRes Execute(GetPatientEventReq pServiceRequest)
        {
            GetPatientEventRes wRes = new GetPatientEventRes();

            wRes.BusinessData = MedicalEventDAC.GetEvent(pServiceRequest.BusinessData.MedicalEventId);
            var details = MedicalEventDAC.Retrive_MedicalEventDetail_ViewList(pServiceRequest.BusinessData.MedicalEventId);
            wRes.BusinessData.DetailView_Quirurgicos = details.Get_Quirurgicos();
            wRes.BusinessData.DetailView_Diagnosis = details.Get_Diagnosis();
            wRes.BusinessData.DetailView_MetodosComplementarios = details.Get_Metodo_Complementarios(); 
            return wRes;
        }


    }

}
