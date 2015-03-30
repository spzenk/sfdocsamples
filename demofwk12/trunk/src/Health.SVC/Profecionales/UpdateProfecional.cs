

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.BE;

namespace Health.Isvc.UpdateProfesional
{
    [Serializable]
    public class UpdateProfesionalReq : Fwk.Bases.Request<Param>
    {

        public UpdateProfesionalReq()
        {
            base.ServiceName = "UpdateProfesionalService";
        }
    }
    public class Param : Fwk.Bases.Entity
    {
        public ProfesionalBE profesional { get; set; }
        public Fwk.Security.Common.User User { get; set; }

        public Guid? HealthInstitutionId { get; set; }
    }

    [Serializable]
    public class UpdateProfesionalRes : Fwk.Bases.Response<Result>
    {


    }
    public class Result : Fwk.Bases.Entity
    {
        public int IdPersona { get; set; }
    }
}