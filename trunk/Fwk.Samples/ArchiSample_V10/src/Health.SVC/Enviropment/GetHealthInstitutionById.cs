using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Health.BE;


using System.Xml.Serialization;

using Fwk.Bases;

namespace Health.Isvc.GetHealthInstitutionById
{   
    [Serializable]
    public class GetHealthInstitutionByIdReq : Fwk.Bases.Request<Param>
    {

        public GetHealthInstitutionByIdReq()
        {
            base.ServiceName = "GetHealthInstitutionByIdService";
        }
    }



    [Serializable]
    public class GetHealthInstitutionByIdRes : Fwk.Bases.Response<HealthInstitutionBE>
    {
    }

    [Serializable]
    public class Param : Entity
    {
        public Guid HealthInstId { get; set; }
    }

   
}
