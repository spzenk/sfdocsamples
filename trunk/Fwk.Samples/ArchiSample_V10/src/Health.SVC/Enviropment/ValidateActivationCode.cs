using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.BE;


namespace Health.Isvc.ValidateActivationCode
{
    [Serializable]
    public class ValidateActivationCodeReq : Fwk.Bases.Request<Params>
    {
        public ValidateActivationCodeReq()
        {
            base.ServiceName = "ValidateActivationCodeService";
        }
    }
    [XmlInclude(typeof(Params)), Serializable]
    public class Params : Fwk.Bases.Entity
    {
        public String Code { get; set; }
        public bool IsRegister { get; set; }
    }


    [Serializable]
    public class ValidateActivationCodeRes : Fwk.Bases.Response<HealthInstitutionBE>
    {
    }

  
}
