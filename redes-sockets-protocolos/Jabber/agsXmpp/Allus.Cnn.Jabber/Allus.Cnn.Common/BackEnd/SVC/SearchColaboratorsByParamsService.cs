using System;
using System.Collections;
using System.Data;
using Fwk.Bases;
using Fwk.Exceptions;
using Allus.Cnn.Common;
using Allus.Cnn.Common.DAC;
using Allus.Cnn.ISVC.SearchColaboratorsByParams;

namespace Allus.Cnn.SVC
{
    public class SearchColaboratorsByParamsService : BusinessService<SearchColaboratorsByParamsRequest, SearchColaboratorsByParamsResponse>
    {
        public override SearchColaboratorsByParamsResponse Execute(SearchColaboratorsByParamsRequest pServiceRequest)
        {
            SearchColaboratorsByParamsResponse res = new SearchColaboratorsByParamsResponse();

            res.BusinessData.ColaboratorDataList = AlertDAC.SearchColaboratorsByParams(pServiceRequest.BusinessData.ColaboratorData);

            return res;
        }
    }
}