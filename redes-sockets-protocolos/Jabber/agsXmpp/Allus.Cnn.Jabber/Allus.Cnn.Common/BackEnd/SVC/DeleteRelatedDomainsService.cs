using System;
using System.Collections;
using System.Data;
using Fwk.Bases;
using Fwk.Exceptions;
using Allus.Cnn.Common;
using Allus.Cnn.Common.BE;
using Allus.Cnn.Common.DAC;
using Allus.Cnn.ISVC.DeleteRelatedDomains;

namespace Allus.Cnn.SVC
{
    public class DeleteRelatedDomainsService : BusinessService<DeleteRelatedDomainsRequest, DeleteRelatedDomainsResponse>
    {
        public override DeleteRelatedDomainsResponse Execute(DeleteRelatedDomainsRequest pServiceRequest)
        {
            DeleteRelatedDomainsResponse res = new DeleteRelatedDomainsResponse();

            AlertDAC.DeleteRelatedDomains(pServiceRequest.BusinessData.UserId);

            return res;
        }
    }
}