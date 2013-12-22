using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Health.BE;


using System.Xml.Serialization;

using Fwk.Bases;

namespace Health.Isvc.CreateResourceScheduling
{   
    [Serializable]
    public class CreateResourceSchedulingReq : Fwk.Bases.Request< ResourceSchedulingList>
    {

        public CreateResourceSchedulingReq()
        {
            base.ServiceName = "CreateResourceSchedulingService";
        }
    }



    [Serializable]
    public class CreateResourceSchedulingRes : Fwk.Bases.Response<DummyContract>
    {
    }
   
}
