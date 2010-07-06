using System;
using System.Collections;
using System.Data;
using Fwk.Bases;
using Fwk.Exceptions;
using Allus.Cnn.Common;
using Allus.Cnn.Common.BE;
using Allus.Cnn.Common.DAC;
using Allus.Cnn.ISVC.SearchRelatedDomainsByUser;

namespace Allus.Cnn.SVC
{
    public class SearchRelatedDomainsByUserService : BusinessService<SearchRelatedDomainsByUserReq, SearchRelatedDomainsByUserRes>
    {
        public override SearchRelatedDomainsByUserRes Execute(SearchRelatedDomainsByUserReq pServiceRequest)
        {
            SearchRelatedDomainsByUserRes res = new SearchRelatedDomainsByUserRes();

            if (pServiceRequest.BusinessData.ColaboratorData.UserId < 0)
            {
                pServiceRequest.BusinessData.ColaboratorData.UserId =
                    AlertDAC.GetColaboratorDataByParams(pServiceRequest.BusinessData.ColaboratorData.Username).UserId;
            }
            res.BusinessData = AlertDAC.SearchRelatedDomainsByUser(pServiceRequest.BusinessData.ColaboratorData.UserId);

            return res;
        }
    }
}