using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.BE;


namespace Health.Isvc.GetPlanVacunacion
{
    [Serializable]
    public class GetPlanVacunacionReq : Fwk.Bases.Request<Params>
    {
        public GetPlanVacunacionReq()
        {
            base.ServiceName = "GetPlanVacunacionService";
        }
    }
    [XmlInclude(typeof(Params)), Serializable]
    public class Params : Fwk.Bases.Entity
    {
        public int IdPatient { get; set; }
    }


    [Serializable]
    public class GetPlanVacunacionRes : Fwk.Bases.Response<PlanVacunacion_FullViewList>
    {
    }

  
}
