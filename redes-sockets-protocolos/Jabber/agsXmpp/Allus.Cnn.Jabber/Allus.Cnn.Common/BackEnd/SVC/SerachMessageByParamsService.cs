using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Allus.Cnn.Common.DAC;
using Allus.Cnn.ISVC.SearchMessageByParams;
using Fwk.Bases;
namespace Allus.Cnn.SVC
{
   
    public class SearchMessageByParamsService : BusinessService<SearchMessageByParamsReq, SearchMessageByParamsRes>
    {
        public override SearchMessageByParamsRes Execute(SearchMessageByParamsReq pServiceRequest)
        {
            SearchMessageByParamsRes res = new SearchMessageByParamsRes();

            res.BusinessData.MessagesBECollection = AlertDAC.SearchMessageByParams(pServiceRequest.BusinessData.MessageParams,
                pServiceRequest.BusinessData.DateStart,
                pServiceRequest.BusinessData.DateEnd);

            return res;
        }
    }
}
