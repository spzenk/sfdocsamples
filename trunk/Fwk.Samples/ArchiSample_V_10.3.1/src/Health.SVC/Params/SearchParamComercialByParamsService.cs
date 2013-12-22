using System;
using System.Collections.Generic;
using Health.Entities;
using Fwk.Bases;

using Health.Isvc.SearchParametroByParams;
using Health.Back;
using Health.BE;
namespace Health.Svc
{
    /// <summary>
    /// 
    /// </summary>
    public class SearchParametroByParamsService : BusinessService<SearchParametroByParamsReq, SearchParametroByParamsRes>
    {
        public override SearchParametroByParamsRes Execute(SearchParametroByParamsReq pServiceRequest)
        {
            SearchParametroByParamsRes wRes = new SearchParametroByParamsRes();

         
            wRes.BusinessData = ParametroDAC.GetByParams(pServiceRequest.BusinessData.IdTipoParametro, 
                pServiceRequest.BusinessData.IdParametroRef, pServiceRequest.BusinessData.Vigente,
                string.Empty);
            return wRes;
        }

       
    }
}
