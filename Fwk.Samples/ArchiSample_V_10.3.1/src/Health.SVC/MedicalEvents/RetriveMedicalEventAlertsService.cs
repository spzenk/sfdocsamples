
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.Isvc.RetriveMedicalEventAlerts;
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
    public class RetriveMedicalEventAlertsService : BusinessService<RetriveMedicalEventAlertsReq, RetriveMedicalEventAlertsRes>
    {
        public override RetriveMedicalEventAlertsRes Execute(RetriveMedicalEventAlertsReq pServiceRequest)
        {
            RetriveMedicalEventAlertsRes wRes = new RetriveMedicalEventAlertsRes();

            MedicalEventAlert_ViewList wList = new MedicalEventAlert_ViewList();

            wRes.BusinessData = MedicalEventDAC.Retrive_MedicalEventAlerts(pServiceRequest.BusinessData.PatientId, pServiceRequest.BusinessData.StartDate, pServiceRequest.BusinessData.RetriveHistory);
            return wRes;



    

        }
        

    }

}
