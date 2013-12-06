using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.BE;


namespace Health.Isvc.GetObraSocialPorPatient
{
    [Serializable]
    public class GetObraSocialPorPatientReq : Fwk.Bases.Request<Params>
    {
        public GetObraSocialPorPatientReq()
        {
            base.ServiceName = "GetObraSocialPorPatientService";
        }
    }
    [XmlInclude(typeof(Params)), Serializable]
    public class Params : Fwk.Bases.Entity
    {
        public int PatientId { get; set; }
    }


    [Serializable]
    public class GetObraSocialPorPatientRes : Fwk.Bases.Response<MutualPorPacienteList>
    {
    }

    
}
