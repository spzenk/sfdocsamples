
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.BE;

namespace Health.Isvc.UpdatePlanVacunacion
{

    [Serializable]
    public class UpdatePlanVacunacionReq : Fwk.Bases.Request<PlanVacunacion_FullViewList>
    {

        public UpdatePlanVacunacionReq()
        {
            base.ServiceName = "UpdatePlanVacunacionService";
        }
    }

    //public class Params : Fwk.Bases.Entity
    //{
    //    public PatientBE Patient { get; set; }
    //}

    [Serializable]
    public class UpdatePlanVacunacionRes : Fwk.Bases.Response<DummyContract>
    {
    }

    
}