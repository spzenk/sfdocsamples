using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Health.BE;


using System.Xml.Serialization;

using Fwk.Bases;

namespace Health.Isvc.UpdateAppointmentStatus
{   
    [Serializable]
    public class UpdateAppointmentStatusReq : Fwk.Bases.Request<AppointmentList>
    {

        public UpdateAppointmentStatusReq()
        {
            base.ServiceName = "UpdateAppointmentStatusService";
        }
    }



    [Serializable]
    public class UpdateAppointmentStatusRes : Fwk.Bases.Response<DummyContract>
    {
    }
   
}
