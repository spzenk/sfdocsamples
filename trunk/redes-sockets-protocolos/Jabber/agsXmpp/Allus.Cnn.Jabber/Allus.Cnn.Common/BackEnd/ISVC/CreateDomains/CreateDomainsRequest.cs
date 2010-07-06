using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Fwk.Bases;
using Allus.Cnn.Common;
using Allus.Cnn.Common.BE;

namespace Allus.Cnn.ISVC.CreateDomains
{
    [Serializable]
    public class CreateDomainsRequest : Request<Param>
    {
        public CreateDomainsRequest()
        {
            this.ServiceName = "CreateDomainsService";
        }
    }

    #region [BussinesData]

    [XmlInclude(typeof(Param)), Serializable]
    public class Param : Entity
    {
        #region [Private Members]

        private System.String _UserName;
        private DomainList _DomainList;

        #endregion


        #region [Properties]

        public System.String UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        public DomainList DomainList
        {
            get { return _DomainList; }
            set { _DomainList = value; }
        }

        #endregion
    }

    #endregion
}
