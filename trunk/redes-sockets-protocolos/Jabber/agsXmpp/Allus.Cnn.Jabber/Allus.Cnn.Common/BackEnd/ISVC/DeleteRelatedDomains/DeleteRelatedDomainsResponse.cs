using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Fwk.Bases;
using Allus.Cnn.Common;

namespace Allus.Cnn.ISVC.DeleteRelatedDomains
{
    [Serializable]
    public class DeleteRelatedDomainsResponse : Response<Result>
    {

    }

    [Serializable]
    public class Result : Entity
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
}