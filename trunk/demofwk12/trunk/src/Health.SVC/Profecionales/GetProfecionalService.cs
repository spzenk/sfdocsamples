using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Health.Isvc.GetProfesional;
using Health.Back;
using Fwk.Exceptions;
using Fwk.Bases;
using Health.BE;

namespace Health.Svc
{

    /// <summary>
    /// Obtine el profesional por IdProfesional o UserGuid
    /// Opcionalmente retorna ResourceSchedulerList
    /// Opcionalmente IncludeSecurityInfo: implica buscar User de aspnet sus roles y los roles de la institucion en cuestion si 
    /// es que HealthInstitutionId != NULL
    /// Opcionalmente se pueden retornar una lista de todas las relaciones del profesional con otras instituciones
    /// </summary>
    public class GetProfesionalService : BusinessService<GetProfesionalReq, GetProfesionalRes>
    {
        public override GetProfesionalRes Execute(GetProfesionalReq pServiceRequest)
        {
            GetProfesionalRes res = new GetProfesionalRes();

            if (pServiceRequest.BusinessData.IncludeScheduler && !pServiceRequest.BusinessData.IdProfesional.HasValue)
            {
                throw new FunctionalException("El servicio GetProfesional requiere el  IdProfesional para incluir la programacion del profesional");
            }

            if (pServiceRequest.BusinessData.IdProfesional.HasValue)
                res.BusinessData.profesional = ProfesionalesDAC.GetById(pServiceRequest.BusinessData.IdProfesional.Value);

            if (pServiceRequest.BusinessData.UserGuid.HasValue)
                res.BusinessData.profesional = ProfesionalesDAC.GetByUserGuid(pServiceRequest.BusinessData.UserGuid.Value);

            if (res.BusinessData.profesional == null)
            {
                throw new FunctionalException("El usuario no esta asociado a un profesional valido o habilitado en el sistema");
            }

            if (pServiceRequest.BusinessData.IncludeScheduler &&  pServiceRequest.BusinessData.IdProfesional.HasValue )
                res.BusinessData.ResourceSchedulerList = SchedulingDAC.RetriveBy_ResourceId(pServiceRequest.BusinessData.IdProfesional.Value, pServiceRequest.BusinessData.HealthInstitutionId.Value);

            Fwk.Security.BC.UserBC userBc = new Fwk.Security.BC.UserBC(pServiceRequest.ContextInformation.AppId, pServiceRequest.SecurityProviderName);
            Fwk.Security.Common.User user = new Fwk.Security.Common.User();
            Fwk.Security.Common.RolList rolList = null;

            if (pServiceRequest.BusinessData.IncludeSecurityInfo)
            {
                if (!string.IsNullOrEmpty(res.BusinessData.profesional.UserName))
                {
                    userBc.GetUserByParams(res.BusinessData.profesional.UserName, out user, out rolList);
                    var roles = from r in rolList select r.RolName;
                    user.Roles = roles.ToArray<string>();
                }
                res.BusinessData.User = user;

                ///Si != nul indica q se trata de un usuario profesional relacionado a una instoitución
                if (pServiceRequest.BusinessData.HealthInstitutionId.HasValue)
                {
                    HealthInstitution_ProfesionalBE wHealthInstitution_ProfesionalBE = HealthInstitutionDAC.Get_HealthInstitution_Profesional(pServiceRequest.BusinessData.HealthInstitutionId.Value, res.BusinessData.profesional.IdProfesional, null);
                    
                    res.BusinessData.User.Roles= res.BusinessData.User.Roles.Union(wHealthInstitution_ProfesionalBE.Roles).ToArray<String>();

                    res.BusinessData.HealthInstitution_Profesional = wHealthInstitution_ProfesionalBE;
                }

            }

            if (pServiceRequest.BusinessData.IncludeAllInstitutions)
            {
                res.BusinessData.HealthInstitution_ProfesionalList = 
                    ProfesionalesDAC.Retrive_HealthInstitution_Relationships(
                    res.BusinessData.profesional.IdProfesional);
            }
            return res;
        }


    }
}


