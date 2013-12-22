using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Health.BE;


using System.Xml.Serialization;

using Fwk.Bases;

namespace Health.Isvc.RetriveAppointment
{   
    [Serializable]
    public class RetriveAppointmentReq : Fwk.Bases.Request<Param>
    {

        public RetriveAppointmentReq()
        {
            base.ServiceName = "RetriveAppointmentService";
        }
    }



    [Serializable]
    public class RetriveAppointmentRes : Fwk.Bases.Response<Result>
    {
    }

    [Serializable]
    public class Param : Entity
    {
        public int? Status { get; set; }
        public DateTime? StartDate { get; set; }

        public int? ResourseId { get; set; }
        public Guid? HealthInstId { get; set; }
        

    }

    [Serializable]
    public class Result : Entity
    {
        public ResourceSchedulingList ResourceSchedulerList { get; set; }
        public AppointmentList AppoimentsList { get; set; }
    }
}
