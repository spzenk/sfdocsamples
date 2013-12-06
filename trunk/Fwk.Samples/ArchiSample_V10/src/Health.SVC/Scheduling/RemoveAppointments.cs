using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Health.BE;


using System.Xml.Serialization;

using Fwk.Bases;

namespace Health.Isvc.RemoveAppointment
{   
    [Serializable]
    public class RemoveAppointmentReq : Fwk.Bases.Request<Param>
    {
        public RemoveAppointmentReq()
        {
            base.ServiceName = "RemoveAppointmentService";
        }
    }

    [Serializable]
    public class Param : Entity
    {
        public int AppointmentId { get; set; }
    }


    [Serializable]
    public class RemoveAppointmentRes : Fwk.Bases.Response<DummyContract>
    {
    }
   
}
