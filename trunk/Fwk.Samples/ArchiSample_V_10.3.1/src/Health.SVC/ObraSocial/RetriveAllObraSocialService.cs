using System;
using System.Collections.Generic;
using Health.Entities;
using Fwk.Bases;

using Health.Isvc.RetriveAllObraSocial;
using Health.Back;
using Health.BE;
namespace Health.Svc
{
    /// <summary>
    /// 
    /// </summary>
    public class RetriveAllObraSocialService : BusinessService<RetriveAllObraSocialReq, RetriveAllObraSocialRes>
    {
        public override RetriveAllObraSocialRes Execute(RetriveAllObraSocialReq pServiceRequest)
        {
            RetriveAllObraSocialRes wRes = new RetriveAllObraSocialRes();

           wRes.BusinessData.ObraSocialList = ObraSocialDAC.RetriveAll();


            return wRes;
        }

       
    }
}
