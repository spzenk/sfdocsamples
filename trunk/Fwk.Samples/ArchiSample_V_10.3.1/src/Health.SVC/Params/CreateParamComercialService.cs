using System;
using System.Collections.Generic;
using Health.Entities;
using Fwk.Bases;

using Health.Isvc.CreateParametro;
using Health.Back;
using Health.BE;
namespace Health.Svc
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateParametroService : BusinessService<CreateParametroReq, CreateParametroRes>
    {
        public override CreateParametroRes Execute(CreateParametroReq pServiceRequest)
        {
            CreateParametroRes wRes = new CreateParametroRes();

            ParametroDAC.Create(pServiceRequest.BusinessData, new Guid(pServiceRequest.ContextInformation.UserId), pServiceRequest.ContextInformation.AppId);

            return wRes;
        }

       
    }
}
