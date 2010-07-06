using System;
using System.Collections;
using System.Data;
using Fwk.Bases;
using Fwk.Exceptions;
using Allus.Cnn.Common;
using Allus.Cnn.Common.BE;
using Allus.Cnn.Common.DAC;
using Allus.Cnn.ISVC.CreateDomains;

namespace Allus.Cnn.SVC
{
    public class CreateDomainsService : BusinessService<CreateDomainsRequest, CreateDomainsResponse>
    {
        public override CreateDomainsResponse Execute(CreateDomainsRequest pServiceRequest)
        {
            CreateDomainsResponse res = new CreateDomainsResponse();

            AlertDAC.CreateDomains(pServiceRequest.BusinessData.UserName, pServiceRequest.BusinessData.DomainList);

            return res;
        }
    }
}