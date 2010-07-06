using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Fwk.Bases;
using Allus.Cnn.Common;
using Allus.Cnn.Common.BE;

namespace Allus.Cnn.ISVC.GetAllRelatedDomains
{
    [Serializable]
    public class GetAllRelatedDomainsRequest : Request<Param>
    {
        public GetAllRelatedDomainsRequest()
        {
            this.ServiceName = "GetAllRelatedDomainsService";
        }
    }

    #region [BussinesData]

    [XmlInclude(typeof(Param)), Serializable]
    public class Param : Entity
    {
        #region [Fields]

        private System.String _Dummy;

        #endregion


        #region [Properties]

        public System.String Dummy
        {
            get { return _Dummy; }
            set { _Dummy = value; }
        }

        #endregion
    }

    #endregion
}