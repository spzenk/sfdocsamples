using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Health.BE;


using System.Xml.Serialization;

using Fwk.Bases;

namespace Health.Isvc.GetAppoinmentByParams
{   
    [Serializable]
    public class GetAppoinmentByParamsReq : Fwk.Bases.Request<Param>
    {

        public GetAppoinmentByParamsReq()
        {
            base.ServiceName = "GetAppoinmentByParamsService";
        }
    }



    [Serializable]
    public class GetAppoinmentByParamsRes : Fwk.Bases.Response<Result>
    {
    }

    [Serializable]
    public class Param : Entity
    {


        public int? AppointmentId { get; set; }
    }

    [Serializable]
    public class Result : Entity
    {

        public AppointmentBE AppointmentBE { get; set; }
    }
}
