using System;
using System.Collections.Generic;
using Health.Entities;
using Fwk.Bases;
using Health.Isvc.DeleteParametro;
using Health.Back;

namespace Health.Svc
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteParametroService : BusinessService<DeleteParametroReq, DeleteParametroRes>
    {
        public override DeleteParametroRes Execute(DeleteParametroReq pServiceRequest)
        {
            DeleteParametroRes wRes = new DeleteParametroRes();
            ParametroDAC.Delete(pServiceRequest.BusinessData.IdParametro);
            return wRes;
        }

       
    }
}
