using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.Isvc.UpdatePatient;
using Health.Back;


namespace Health.Svc
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdatePatientService : BusinessService<UpdatePatientReq, UpdatePatientRes>
    {
        public override UpdatePatientRes Execute(UpdatePatientReq pServiceRequest)
        {
            UpdatePatientRes wRes = new UpdatePatientRes();
            pServiceRequest.BusinessData.Patient.LastAccessUserId = Guid.Parse(pServiceRequest.ContextInformation.UserId);
            pServiceRequest.BusinessData.Patient.Persona.LastAccessUserId = Guid.Parse(pServiceRequest.ContextInformation.UserId);
            PatientsDAC.Update(pServiceRequest.BusinessData.Patient);

            //Vacunas
            if (pServiceRequest.BusinessData.AnteriorFechaNacimiento.HasValue)
                PatientsDAC.Update_FechaNAcimiento_PlanVacunacion(pServiceRequest.BusinessData.Patient.PatientId,
                    pServiceRequest.BusinessData.AnteriorFechaNacimiento.Value,
                    pServiceRequest.BusinessData.Patient.Persona.FechaNacimiento);

            if (pServiceRequest.BusinessData.Mutuales != null)
                if (pServiceRequest.BusinessData.Mutuales.Count != 0)
                    ObraSocialDAC.Update_MutualPorPaciente(pServiceRequest.BusinessData.Mutuales, pServiceRequest.BusinessData.Patient.PatientId);
            return wRes;
        }


    }
}


