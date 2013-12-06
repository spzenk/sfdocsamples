using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.Isvc.RetrivePersonas;
using Health.Back;

using Health.BE;


namespace Health.Svc
{

    public class RetrivePersonasService : BusinessService<RetrivePersonasReq, RetrivePersonasRes>
    {
        public override RetrivePersonasRes Execute(RetrivePersonasReq pServiceRequest)
        {
            RetrivePersonasRes wRes = new RetrivePersonasRes();
            List<PersonaBE> pers = PersonasDAC.SearchByParams(pServiceRequest.BusinessData.Nombre, pServiceRequest.BusinessData.Apellido);
            wRes.BusinessData.AddRange(pers);


            return wRes;
        }


    }

}
