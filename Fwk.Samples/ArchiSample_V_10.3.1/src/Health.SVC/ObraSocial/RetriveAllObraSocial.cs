using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Health.BE;


using System.Xml.Serialization;

using Fwk.Bases;

namespace Health.Isvc.RetriveAllObraSocial
{   
    [Serializable]
    public class RetriveAllObraSocialReq : Fwk.Bases.Request<Param>
    {

        public RetriveAllObraSocialReq()
        {
            base.ServiceName = "RetriveAllObraSocialService";
        }
    }



    [Serializable]
    public class RetriveAllObraSocialRes : Fwk.Bases.Request<Result>
    {
    }

    [Serializable]
    public class Param : Entity
    {
        public int? Status { get; set; }
        public DateTime? StartDate { get; set; }
    }

    [Serializable]
    public class Result : Entity
    {

        public MutualList ObraSocialList { get; set; }
    }
}
