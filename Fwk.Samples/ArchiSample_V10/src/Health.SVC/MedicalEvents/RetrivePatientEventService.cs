
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.Isvc.RetrivePatientEvent;
using Health.Back;

using Health.BE;


namespace Health.Svc
{
    /// <summary>
    ///Retorna eventos realizados a un determinado Patient
    /// 
    /// 
    /// </summary>
    public class RetrivePatientEventService : BusinessService<RetrivePatientEventReq, RetrivePatientEventRes>
    {
        public override RetrivePatientEventRes Execute(RetrivePatientEventReq pServiceRequest)
        {
            RetrivePatientEventRes wRes = new RetrivePatientEventRes();

            wRes.BusinessData = MedicalEventDAC.RetrivePatientEvent(pServiceRequest.BusinessData.PatientId);

            

            return wRes;
        }


    }

}
