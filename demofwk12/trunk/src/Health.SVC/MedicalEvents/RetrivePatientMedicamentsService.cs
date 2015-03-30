
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.Isvc.RetrivePatientMedicaments;
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
    public class RetrivePatientMedicamentsService : BusinessService<RetrivePatientMedicamentsReq, RetrivePatientMedicamentsRes>
    {
        public override RetrivePatientMedicamentsRes Execute(RetrivePatientMedicamentsReq pServiceRequest)
        {
            RetrivePatientMedicamentsRes wRes = new RetrivePatientMedicamentsRes();
            PatientMedicament_ViewList wPatientMedicament_ViewBE = new PatientMedicament_ViewList();
            if (pServiceRequest.BusinessData.RetriveHistory)
            {
                wRes.BusinessData = PatientsDAC.RetrivePatientMedicamentsAlls(pServiceRequest.BusinessData.PatientId);
                return wRes;
            }
            else
            {
                if (pServiceRequest.BusinessData.MedicalEventId.HasValue)
                    wPatientMedicament_ViewBE = PatientsDAC.RetrivePatientMedicaments(pServiceRequest.BusinessData.PatientId, pServiceRequest.BusinessData.MedicalEventId.Value,true);
                else
                    wPatientMedicament_ViewBE = PatientsDAC.RetrivePatientMedicaments(pServiceRequest.BusinessData.PatientId);
            }

            DateTime currentDate = Fwk.HelperFunctions.DateFunctions.GetStartDateTime(DateTime.Now);

            if (wPatientMedicament_ViewBE.Count != 0) wRes.BusinessData = new PatientMedicament_ViewList();

            //Realizar aqui actualizacion de medicacion NO permanente que sobrepaso dias resetados por el medico. Enabled = FALSE
            foreach (PatientMedicament_ViewBE item in wPatientMedicament_ViewBE)
            {
                ///Ignorar si la consulta es por id . Por que si viene el id del requetst es por que se esta creando en este momento
                if (!(pServiceRequest.BusinessData.MedicalEventId.HasValue && item.MedicalEventId.Equals(pServiceRequest.BusinessData.MedicalEventId)))
                {
                    if (currentDate > Fwk.HelperFunctions.DateFunctions.GetStartDateTime(item.CreatedDate).AddDays(item.DaysCount) && !item.Status.Equals((int)MedicamentStatus.Permanente))
                    {
                        PatientsDAC.DisablePatientMedicaments(item.PatientMedicamentId, Guid.Parse(pServiceRequest.ContextInformation.UserId), MedicamentStatus.Finalizado);
                        //wRes.BusinessData.Remove(item);
                    }
                    else
                    {
                        wRes.BusinessData.Add(item);
                    }
                }
                else
                {
                    wRes.BusinessData.Add(item);
                }
            }

            return wRes;
        }


    }

}
