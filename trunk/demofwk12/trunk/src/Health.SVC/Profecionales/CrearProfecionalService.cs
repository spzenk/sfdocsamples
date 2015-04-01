using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.Isvc.CrearProfesional;
using Health.Back;

using Fwk.Security.BC;

namespace Health.Svc
{

    public class CrearProfesionalService : BusinessService<CrearProfesionalReq, CrearProfesionalRes>
    {
        public override CrearProfesionalRes Execute(CrearProfesionalReq pServiceRequest)
        {
            CrearProfesionalRes wRes = new CrearProfesionalRes();
            pServiceRequest.BusinessData.profesional.LastAccessUserId = Guid.Parse(pServiceRequest.ContextInformation.UserId);
            pServiceRequest.BusinessData.profesional.Persona.LastAccessUserId = Guid.Parse(pServiceRequest.ContextInformation.UserId);

            bool personaExiste = PersonasDAC.Exist(pServiceRequest.BusinessData.profesional.Persona.NroDocumento);

            //Lo primero es crear el inicio de sesion
            UserBC wUserBC = new UserBC(pServiceRequest.ContextInformation.AppId, pServiceRequest.SecurityProviderName);
            wUserBC.Create(pServiceRequest.BusinessData.User);
            wRes.BusinessData.UserId = Guid.Parse(pServiceRequest.BusinessData.User.ProviderId.ToString());
 
            if (personaExiste)
            {
                if (ProfesionalesDAC.Persona_EstaAsociada(pServiceRequest.BusinessData.profesional.Persona.NroDocumento))
                    throw new Fwk.Exceptions.FunctionalException(String.Format("El Nro documento {0} ya pertenece a otro profesional registrado",
                        pServiceRequest.BusinessData.profesional.Persona.NroDocumento));

                ProfesionalesDAC.Asociar(pServiceRequest.BusinessData.profesional);
            }
            else
            {
                pServiceRequest.BusinessData.profesional.Persona.UserId = wRes.BusinessData.UserId;
                ProfesionalesDAC.Create(pServiceRequest.BusinessData.profesional);
            }

            wRes.BusinessData.IdProfesional = pServiceRequest.BusinessData.profesional.IdProfesional;
            wRes.BusinessData.UserId = wRes.BusinessData.UserId;

            return wRes;
        }


    }
}


