using System;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;


namespace Epiron.Back.Bases.ISVC.RetriveCaptionsByCultureInfo
{
    [Serializable]
    public class RetriveCaptionsByCultureInfoReq : Request<Params>
    {
        public RetriveCaptionsByCultureInfoReq()
        {
            this.ServiceName = "RetriveCaptionsByCultureInfoService";
            
        }
    }

    #region [BussinesData]
    public class Params : Entity
    {
        public string Culture { get; set; }
    }
    #endregion

}