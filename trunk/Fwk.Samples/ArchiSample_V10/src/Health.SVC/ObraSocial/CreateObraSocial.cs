using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.BE;

namespace Health.Isvc.CreateObraSocial
{

    [Serializable]
    public class CreateObraSocialReq : Fwk.Bases.Request<Params>
    {

        public CreateObraSocialReq()
        {
            base.ServiceName = "CreateObraSocialService";
            
        }
    }

    public class Params : Fwk.Bases.Entity
    {
        public MutualBE Mutual { get; set; }
    }

    [Serializable]
    public class CreateObraSocialRes : Fwk.Bases.Response<DummyContract>
    {


    }
   
}