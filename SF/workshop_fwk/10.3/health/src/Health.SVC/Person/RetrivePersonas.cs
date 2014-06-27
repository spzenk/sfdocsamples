using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.BE;


namespace Health.Isvc.RetrivePersonas
{

    [Serializable]
    public class RetrivePersonasReq : Fwk.Bases.Request<Params>
    {
        public RetrivePersonasReq()
        {
            base.ServiceName = "RetrivePersonasService";
        }
    }
    [XmlInclude(typeof(Params)), Serializable]
    public class Params : Fwk.Bases.Entity
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int NroDocumento { get; set; }
    }


    [Serializable]
    public class RetrivePersonasRes : Fwk.Bases.Response<PersonaList>
    {
    }

    
}
