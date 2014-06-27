using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Health.BE;
using System.Xml.Serialization;
using Fwk.Bases;

namespace Health.Isvc.SearchParametroByParams
{   
    [Serializable]
    public class SearchParametroByParamsReq : Fwk.Bases.Request<Params>
    {

        public SearchParametroByParamsReq()
        {
            base.ServiceName = "SearchParametroByParamsService";
        }
    }

    [XmlInclude(typeof(Params)), Serializable]
    public class Params : Entity
    {
        bool? vigente;

        public bool? Vigente
        {
            get { return vigente; }
            set { vigente = value; }
        }

        int? _IdTipoParametro;

        public int? IdTipoParametro
        {
            get { return _IdTipoParametro; }
            set { _IdTipoParametro = value; }
        }
        int? _IdParametroRef;

        public int? IdParametroRef
        {
            get { return _IdParametroRef; }
            set { _IdParametroRef = value; }
        }
        public int? Edad
        {
            get { return _IdParametroRef * 3; }
            set { _IdParametroRef = value; }
        }
    }


    [Serializable]
    public class SearchParametroByParamsRes : Fwk.Bases.Response<ParametroList>
    {
    }
  
}
