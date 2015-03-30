
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.Isvc.RetriveMedicalEventDetails;
using Health.Back;

using Health.BE;
using Health.BE.Enums;


namespace Health.Svc
{
    /// <summary>
    ///Retorna medicamentos que el Patient toma regularmente
    /// La medicacion debe estar no suspendida y vigente
    /// Tambien retorna medicacion actual temporal (Esto falta desarrollar) 
    /// </summary>
    public class RetriveMedicalEventDetailsService : BusinessService<RetriveMedicalEventDetailsReq, RetriveMedicalEventDetailsRes>
    {
        public override RetriveMedicalEventDetailsRes Execute(RetriveMedicalEventDetailsReq pServiceRequest)
        {
            RetriveMedicalEventDetailsRes wRes = new RetriveMedicalEventDetailsRes();
            if (pServiceRequest.BusinessData.MedicalEventId.HasValue)
            {
                wRes.BusinessData = MedicalEventDAC.Retrive_MedicalEventDetail_ViewList(pServiceRequest.BusinessData.MedicalEventId.Value);
            }
            else
            {
                wRes.BusinessData = MedicalEventDAC.Retrive_MedicalEventDetail_ViewList_Patinet(pServiceRequest.BusinessData.PatientId);
            }
          
            return wRes;

        }
        

    }

}
