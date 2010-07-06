using System;
using System.Collections;
using System.Data;
using Fwk.Bases;
using Fwk.Exceptions;
using Allus.Cnn.Common;
using Allus.Cnn.Common.BE;
using Allus.Cnn.Common.DAC;
using Allus.Cnn.ISVC.GetAllRelatedDomains;

namespace Allus.Cnn.SVC
{
    public class GetAllRelatedDomainsService : BusinessService<GetAllRelatedDomainsRequest, GetAllRelatedDomainsResponse>
    {
        public override GetAllRelatedDomainsResponse Execute(GetAllRelatedDomainsRequest pServiceRequest)
        {
            GetAllRelatedDomainsResponse res = new GetAllRelatedDomainsResponse();

            DomainList wRelatedDomains;
            DomainList wAllDomains;

            AlertDAC.GetAllRelatedDomains(out wRelatedDomains, out wAllDomains);

            res.BusinessData.RelatedDomains = wRelatedDomains;
            res.BusinessData.AllDomains = wAllDomains;

            return res;
            
        }
    }
}