
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.Isvc.RetriveMedicalEventPMO_Diag;
using Health.Back;

using Health.BE;


namespace Health.Svc
{
    /// <summary>
    ///
    /// 
    /// 
    /// </summary>
    public class RetriveMedicalEventPMO_DiagService : BusinessService<RetriveMedicalEventPMO_DiagReq, RetriveMedicalEventPMO_DiagRes>
    {
        public override RetriveMedicalEventPMO_DiagRes Execute(RetriveMedicalEventPMO_DiagReq pServiceRequest)
        {
            RetriveMedicalEventPMO_DiagRes wRes = new RetriveMedicalEventPMO_DiagRes();

            if (pServiceRequest.BusinessData.Retrive_CEI10)
                wRes.BusinessData = NomenclatorDAC.Search_CEI10(pServiceRequest.BusinessData.PatientId);
            if (pServiceRequest.BusinessData.Retrive_PMOMetodoComplementario)
                wRes.BusinessData = NomenclatorDAC.Search_PMO_MetodoComplementario(pServiceRequest.BusinessData.PatientId);
            if (pServiceRequest.BusinessData.Retrive_PMOQuir)
                wRes.BusinessData = NomenclatorDAC.Search_PMO_Quirurgico(pServiceRequest.BusinessData.PatientId);
            return wRes;
        }


    }

}
