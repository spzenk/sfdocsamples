using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.BE;

using Fwk.Security.Common;

namespace Health.Isvc.GetProfesional
{

    [Serializable]
    public class GetProfesionalReq : Fwk.Bases.Request<Params>
    {

        public GetProfesionalReq()
        {
            base.ServiceName = "GetProfesionalService";
        }
    }
    [Serializable]
    public class Params : Fwk.Bases.Entity
    {
        public int? IdProfesional { get; set; }
        public Guid? UserGuid { get; set; }
        
        public bool IncludeScheduler { get; set; }
        public bool IncludeSecurityInfo { get; set; }
        public Guid? HealthInstitutionId { get; set; }

        public bool IncludeAllInstitutions { get; set; }
    }

    [Serializable]
    public class GetProfesionalRes : Fwk.Bases.Response<Result>
    {


    }
    [Serializable]
    public class Result : Fwk.Bases.Entity
    {
        public ProfesionalBE profesional { get; set; }
        public ResourceSchedulingList ResourceSchedulerList { get; set; }
        public User User { get; set; }

        public HealthInstitution_ProfesionalBE HealthInstitution_Profesional { get; set; }

        public HealthInstitution_ProfesionalList HealthInstitution_ProfesionalList { get; set; }
    }
}