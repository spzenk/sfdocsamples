using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Fwk.Bases;
using Allus.Cnn.Common;
using Allus.Cnn.Common.BE;

namespace Allus.Cnn.ISVC.SearchRelatedDomainsByUser
{
    [Serializable]
    public class SearchRelatedDomainsByUserReq : Request<Param>
    {
        public SearchRelatedDomainsByUserReq()
        {
            this.ServiceName = "SearchRelatedDomainsByUserService";
        }
    }

    #region [BussinesData]

    [XmlInclude(typeof(Param)), Serializable]
    public class Param : Entity
    {
        #region [Private Members]

        private ColaboratorData _ColaboratorData = new ColaboratorData ();

        #endregion


        #region [Properties]

        public ColaboratorData ColaboratorData
        {
            get { return _ColaboratorData; }
            set { _ColaboratorData = value; }
        }

        #endregion
    }

    #endregion
}