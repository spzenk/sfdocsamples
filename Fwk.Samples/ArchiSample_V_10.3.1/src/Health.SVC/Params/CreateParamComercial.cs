using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Health.BE;


using System.Xml.Serialization;

using Fwk.Bases;

namespace Health.Isvc.CreateParametro
{   
    [Serializable]
    public class CreateParametroReq : Fwk.Bases.Request< ParametroBE>
    {

        public CreateParametroReq()
        {
            base.ServiceName = "CreateParametroService";
        }
    }



    [Serializable]
    public class CreateParametroRes : Fwk.Bases.Response<DummyContract>
    {
    }
   
}
