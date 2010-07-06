using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Fwk.Bases;
using Allus.Cnn.Common;
using Allus.Cnn.Common.BE;

namespace Allus.Cnn.ISVC.GetAllRelatedDomains
{
    [Serializable]
    public class GetAllRelatedDomainsResponse : Response<Result>
    {

    }

    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Entity
    {
        #region [Fields]

        private DomainList _RelatedDomains;
        private DomainList _AllDomains;

        #endregion


        #region [Properties]

        public DomainList RelatedDomains
        {
            get { return _RelatedDomains; }
            set { _RelatedDomains = value; }
        }

        public DomainList AllDomains
        {
            get { return _AllDomains; }
            set { _AllDomains = value; }
        }

        #endregion
    }
}