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
    /// <summary>
    /// 
    /// </summary>
    public class RetrivePersonasService : BusinessService<RetrivePersonasReq, RetrivePersonasRes>
    {
        public override RetrivePersonasRes Execute(RetrivePersonasReq pServiceRequest)
        {
            RetrivePersonasRes res;

            if (string.IsNullOrEmpty(pServiceRequest.BusinessData.Nombre))
                throw new Fwk.Exceptions.FunctionalException("Negro mandame los datos");
            res = new RetrivePersonasRes();


            PersonasDAC.SearchByParams(pServiceRequest.BusinessData.Nombre, pServiceRequest.BusinessData.Apellido);


            return res;
        }
    }

}
