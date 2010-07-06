using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Fwk.Bases;
using Allus.Cnn.Common;

namespace Allus.Cnn.ISVC.DeleteRelatedDomains
{
    [Serializable]
    public class DeleteRelatedDomainsRequest : Request<Param>
    {
        public DeleteRelatedDomainsRequest()
        {
            this.ServiceName = "DeleteRelatedDomainsService";
        }
    }

    #region [BussinesData]

    [XmlInclude(typeof(Param)), Serializable]
    public class Param : Entity
    {
        #region [Private Members]

        private System.Int32 _UserId;

        #endregion


        #region [Properties]

        public System.Int32 UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }

        #endregion
    }

    #endregion
}
