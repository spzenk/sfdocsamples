
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.Isvc.AuthHealthInstitution;
using Health.Back;
using Fwk.Exceptions;



namespace Health.Svc
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthHealthInstitutionService : BusinessService<AuthHealthInstitutionReq, AuthHealthInstitutionRes>
    {
        public override AuthHealthInstitutionRes Execute(AuthHealthInstitutionReq pServiceRequest)
        {
            AuthHealthInstitutionRes wRes = new AuthHealthInstitutionRes();

            wRes.BusinessData.Authenticated = HealthInstitutionDAC.AuthenticateUser(pServiceRequest.BusinessData.HealthInstId, pServiceRequest.BusinessData.ProfesionalId,pServiceRequest.BusinessData.UserId);
            //wRes.BusinessData.HealthInstitution_ProfesionalBE = HealthInstitutionDAC.Get_HealthInstitution_Profesional((pServiceRequest.BusinessData.HealthInstId, pServiceRequest.BusinessData.ProfesionalId));

            if (wRes.BusinessData.Authenticated == false)
            {
                wRes.BusinessData.Message = "No es un usuario autorizado para ingresar en la institución seleccionada";
                 
            }

            //string cultura = Fwk.ServiceManagement.ServiceMetadata.ProviderSection.GetProvider(pServiceRequest.ContextInformation.ProviderName).DefaultCulture;
            //string cultura2 = pServiceRequest.ContextInformation.DefaultCulture;
            return wRes;
        }


    }

}
