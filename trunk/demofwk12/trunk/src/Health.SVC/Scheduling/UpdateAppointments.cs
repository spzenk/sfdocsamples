using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Health.BE;


using System.Xml.Serialization;

using Fwk.Bases;

namespace Health.Isvc.UpdateAppointments
{   
    [Serializable]
    public class UpdateAppointmentsReq : Fwk.Bases.Request<AppointmentList>
    {

        public UpdateAppointmentsReq()
        {
            base.ServiceName = "UpdateAppointmentsService";
        }
    }



    [Serializable]
    public class UpdateAppointmentsRes : Fwk.Bases.Response<DummyContract>
    {
    }
   
}
