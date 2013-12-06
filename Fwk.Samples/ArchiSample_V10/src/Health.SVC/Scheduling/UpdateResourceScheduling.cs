using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Health.BE;


using System.Xml.Serialization;

using Fwk.Bases;

namespace Health.Isvc.UpdateResourceScheduling
{   
    [Serializable]
    public class UpdateResourceSchedulingReq : Fwk.Bases.Request< ResourceSchedulingList>
    {

        public UpdateResourceSchedulingReq()
        {
            base.ServiceName = "UpdateResourceSchedulingService";
        }
    }



    [Serializable]
    public class UpdateResourceSchedulingRes : Fwk.Bases.Response<DummyContract>
    {
    }
   
}
