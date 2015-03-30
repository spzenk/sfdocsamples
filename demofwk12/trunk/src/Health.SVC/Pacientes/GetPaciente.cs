using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.BE;


namespace Health.Isvc.GetPatient
{
    [Serializable]
    public class GetPatientReq : Fwk.Bases.Request<Params>
    {
        public GetPatientReq()
        {
            base.ServiceName = "GetPatientService";
        }
    }
    [XmlInclude(typeof(Params)), Serializable]
    public class Params : Fwk.Bases.Entity
    {
        public int Id { get; set; }
    }


    [Serializable]
    public class GetPatientRes : Fwk.Bases.Response<Result>
    {
    }

    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Fwk.Bases.Entity
    {
        public PatientBE Patient { get; set; }
        public MutualPorPacienteList Mutuales { get; set; }
    }
}
