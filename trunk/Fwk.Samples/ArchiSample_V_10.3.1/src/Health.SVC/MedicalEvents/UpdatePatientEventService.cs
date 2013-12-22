
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.Isvc.UpdatePatientEvent;
using Health.Back;

using Health.BE;
using Health.BE.Enums;


namespace Health.Svc
{
    /// <summary>
    /// Performs the patien event creation 
    /// Create Medicaments
    /// </summary>
    public class UpdatePatientEventService : BusinessService<UpdatePatientEventReq, UpdatePatientEventRes>
    {
        public override UpdatePatientEventRes Execute(UpdatePatientEventReq pServiceRequest)
        {
            UpdatePatientEventRes wRes = new UpdatePatientEventRes();

            MedicalEventDAC.UpdateMedicalEvent(pServiceRequest.BusinessData, Guid.Parse(pServiceRequest.ContextInformation.UserId));

            int currentMedicalEventId = pServiceRequest.BusinessData.MedicalEventId;

           

              
            

            if (pServiceRequest.BusinessData.MedicalEventDetailList != null)
            {

                foreach (MedicalEventDetailBE medicalEventDetail in pServiceRequest.BusinessData.MedicalEventDetailList)
                {
                    medicalEventDetail.MedicalEventId = currentMedicalEventId;


                    if (medicalEventDetail.EntityState == EntityState.Added)
                    {
                        MedicalEventDAC.Insert_MedicalEventDetail(medicalEventDetail, Guid.Parse(pServiceRequest.ContextInformation.UserId));

                        if (medicalEventDetail.DetailType.Equals(AlertTypeEnum.Diagnosis))
                        {
                            if (medicalEventDetail.RelevanceType.HasValue)
                            {
                                MedicalEventDAC.Create_MedicalEventAlert(currentMedicalEventId, medicalEventDetail.Description, (AlertTypeEnum)medicalEventDetail.DetailType, medicalEventDetail.Id);
                            }
                        }
                    }

                    //Si en medio de la atencion gravo y luego el profesional se arrepiente y decide quitar el medicamento este debe se eliminado fisicamente
                    if (medicalEventDetail.EntityState == EntityState.Deleted)
                        MedicalEventDAC.Remove_MedicalEventDetail(medicalEventDetail.Id);
                }
              
            }

            if (pServiceRequest.BusinessData.PatientMedicaments != null)
            {
                //Selecciono medicamentos generados en otros eventos medicos
                var otherMedicaments = pServiceRequest.BusinessData.PatientMedicaments.Where(p => 
                    !p.MedicalEventId.Equals(currentMedicalEventId) &&
                    p.EntityState== EntityState.Changed);

                ///Si cambio algun medicamento de unevento anterior este es deshbilitado y se genera uno nuevo en el actual evento medico
                ///Logrando asi un hstorial
                foreach (PatientMedicament_ViewBE patientMedicament in otherMedicaments)
                {
                    PatientsDAC.DisablePatientMedicaments(patientMedicament.PatientMedicamentId, 
                        Guid.Parse(pServiceRequest.ContextInformation.UserId), 
                        BE.Enums.MedicamentStatus.Deshabilitado);

                }

                //|| p.PatientMedicamentId.Equals(-1)
                var currentMedicaments = pServiceRequest.BusinessData.PatientMedicaments.Where(p =>
                   p.MedicalEventId.Equals(currentMedicalEventId) );

                foreach (PatientMedicament_ViewBE patientMedicament in currentMedicaments)
                {
                    patientMedicament.MedicalEventId = currentMedicalEventId;

     
                    if(patientMedicament.EntityState == EntityState.Added)
                        PatientsDAC.AddPatientMedicaments(patientMedicament, Guid.Parse(pServiceRequest.ContextInformation.UserId));

                    //Si modifique del mismo event Id (Esto se da por que el medico desidio guardar y luego modifico el evento si cerrar pantall
                    // y nuevamente preciona gurdar )
                    if (patientMedicament.EntityState == EntityState.Changed )
                        PatientsDAC.UpdatePatientMedicaments(patientMedicament, Guid.Parse(pServiceRequest.ContextInformation.UserId));

                    //Si en medio de la atencion gravo y luego el profesional se arrepiente y decide quitar el medicamento este debe se eliminado fisicamente
                    if (patientMedicament.EntityState == EntityState.Deleted   )
                        PatientsDAC.RemovePatientMedicaments(patientMedicament.PatientMedicamentId);
                }


            }
            
            return wRes;
        }


    }

}
