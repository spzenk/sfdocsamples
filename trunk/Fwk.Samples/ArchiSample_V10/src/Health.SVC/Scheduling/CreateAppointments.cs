using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Health.BE;


using System.Xml.Serialization;

using Fwk.Bases;

namespace Health.Isvc.CreateAppointments
{   
    [Serializable]
    public class CreateAppointmentsReq : Fwk.Bases.Request<AppointmentList>
    {

        public CreateAppointmentsReq()
        {
            base.ServiceName = "CreateAppointmentsService";
        }
    }



    [Serializable]
    public class CreateAppointmentsRes : Fwk.Bases.Response<DummyContract>
    {
    }
   
}
