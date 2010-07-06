using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Fwk.Bases;
using Fwk.Exceptions;
using Allus.Cnn.Common;
using Allus.Cnn.Common.DAC;
using Allus.Cnn.ISVC.SearchMessagesReadConfirmed;
using Allus.Cnn.Common.BE;

namespace Allus.Cnn.Common.BackEnd.SVC
{
    public class SearchMessagesReadConfirmedService : BusinessService<SearchMessagesReadConfirmedRequest, SearchMessagesReadConfirmedResponse>
    {
        public override SearchMessagesReadConfirmedResponse Execute(SearchMessagesReadConfirmedRequest pServiceRequest)
        {
            SearchMessagesReadConfirmedResponse res = new SearchMessagesReadConfirmedResponse();
            res.BusinessData.ColaboratorDataList = AlertDAC.SearchMessages_ReadConfirmed(pServiceRequest.BusinessData.MessageId, pServiceRequest.BusinessData.ColaboratorData);

            return res;
        }
    }
}


