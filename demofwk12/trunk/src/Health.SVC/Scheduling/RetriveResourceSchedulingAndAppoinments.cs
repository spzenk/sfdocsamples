using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Health.BE;


using System.Xml.Serialization;

using Fwk.Bases;

namespace Health.Isvc.RetriveResourceSchedulingAndAppoinments
{   
    [Serializable]
    public class RetriveResourceSchedulingAndAppoinmentsReq : Fwk.Bases.Request<Param>
    {

        public RetriveResourceSchedulingAndAppoinmentsReq()
        {
            base.ServiceName = "RetriveResourceSchedulingAndAppoinmentsService";
        }
    }



    [Serializable]
    public class RetriveResourceSchedulingAndAppoinmentsRes : Fwk.Bases.Request<Result>
    {
    }

    [Serializable]
    public class Param : Entity
    {
        public int ResourceId { get; set; }
        public DateTime Date { get; set; }
        public bool UseStartDate { get; set; }
        public Guid? HealthInstId { get; set; }
    }

    [Serializable]
    public class Result : Entity
    {
        public ResourceSchedulingList ResourceSchedulerList { get; set; }
        public AppointmentList AppoimentsList { get; set; }
    }
}
