using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using Health.Entities;
using Health.BE;
using Fwk.Bases;

namespace Health.Isvc.DeleteParametro
{   
    [Serializable]
    public class DeleteParametroReq : Fwk.Bases.Request<Params>
    {

        public DeleteParametroReq()
        {
            base.ServiceName = "DeleteParametroService";
        }
    }
    
    [XmlInclude(typeof(Params)), Serializable]
    public class Params : Entity
    {
        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        int _Id;

        public int IdParametro
        {
            get { return _Id; }
            set { _Id = value; }
        }

    }



    [Serializable]
    public class DeleteParametroRes : Fwk.Bases.Response<DummyContract>
    {
    }
   
}
