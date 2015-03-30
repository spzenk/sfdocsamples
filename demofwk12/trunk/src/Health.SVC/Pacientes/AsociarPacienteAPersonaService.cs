using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.Isvc.AsociarPatientAPersona;
using Health.Back;
using Health.Entities;

namespace Health.Svc
{
    /// <summary>
    /// Crea un Patient y lo asicia a una persona existente que no este asociada a otro pasiente
    /// </summary>
    public class AsociarPatientAPersonaService : BusinessService<AsociarPatientAPersonaReq, AsociarPatientAPersonaRes>
    {
        public override AsociarPatientAPersonaRes Execute(AsociarPatientAPersonaReq pServiceRequest)
        {
            AsociarPatientAPersonaRes wRes = new AsociarPatientAPersonaRes();
            pServiceRequest.BusinessData.Patient.LastAccessUserId = Guid.Parse(pServiceRequest.ContextInformation.UserId);
            pServiceRequest.BusinessData.Patient.Persona.LastAccessUserId = Guid.Parse(pServiceRequest.ContextInformation.UserId);

            if (PatientsDAC.Persona_EstaAsociada(pServiceRequest.BusinessData.Patient.Persona.NroDocumento))
            {
                throw new Fwk.Exceptions.FunctionalException(String.Format("El Nro documento {0} ya pertenece a otro paciente registrado",
                      pServiceRequest.BusinessData.Patient.Persona.NroDocumento));

            }
            else
            {
                PatientsDAC.Asociar(pServiceRequest.BusinessData.Patient);
            }



            ///Mutuales
            if (pServiceRequest.BusinessData.Mutuales != null)
                ObraSocialDAC.Create_MutualPorPaciente(pServiceRequest.BusinessData.Mutuales, pServiceRequest.BusinessData.Patient.PatientId);

            //Verifica si la persona asociada requiere actualizacion
            if(pServiceRequest.BusinessData.PersonaNeedsUpdate)
                PersonasDAC.Update(pServiceRequest.BusinessData.Patient.Persona);

            //Vacunas
            //if (pServiceRequest.BusinessData.AnteriorFechaNacimiento.HasValue)
            //    PatientsDAC.Update_FechaNAcimiento_PlanVacunacion(pServiceRequest.BusinessData.Patient.PatientId,
            //        pServiceRequest.BusinessData.AnteriorFechaNacimiento.Value, 
                    //pServiceRequest.BusinessData.Patient.Persona.FechaNacimiento   );
            return wRes;
        }


    }
}


