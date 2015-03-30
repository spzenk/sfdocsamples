
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.Isvc.CreatePatientEvent;
using Health.Back;

using Health.BE;


namespace Health.Svc
{
    /// <summary>
    /// Performs the patien event creation 
    /// Create Medicaments
    /// </summary>
    public class CreatePatientEventService : BusinessService<CreatePatientEventReq, CreatePatientEventRes>
    {
        public override CreatePatientEventRes Execute(CreatePatientEventReq pServiceRequest)
        {
            CreatePatientEventRes wRes = new CreatePatientEventRes();

            int id = MedicalEventDAC.CreateMedicalEvent(pServiceRequest.BusinessData, Guid.Parse(pServiceRequest.ContextInformation.UserId));
            if (pServiceRequest.BusinessData.PatientMedicaments != null)
            {
                foreach (PatientMedicament_ViewBE patientMedicament in pServiceRequest.BusinessData.PatientMedicaments)
                {
                    if (patientMedicament.EntityState != Fwk.Bases.EntityState.Unchanged)
                    {
                        
                        if (patientMedicament.PatientMedicamentId_Parent.HasValue)
                            PatientsDAC.DisablePatientMedicaments(patientMedicament.PatientMedicamentId_Parent.Value, Guid.Parse(pServiceRequest.ContextInformation.UserId), BE.Enums.MedicamentStatus.Finalizado);
                        
                        patientMedicament.MedicalEventId = id;
                        PatientsDAC.AddPatientMedicaments(patientMedicament, Guid.Parse(pServiceRequest.ContextInformation.UserId));
                    }
                }
            }
            wRes.BusinessData.EventId = id;
            return wRes;
        }


    }

}
