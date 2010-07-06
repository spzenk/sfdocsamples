using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using System.Xml.Serialization;
using Allus.Cnn.Common;
using Allus.Cnn.Common.BE;

namespace Allus.Cnn.ISVC.SearchMessagesReadConfirmed
{
    [Serializable]
    public class SearchMessagesReadConfirmedRequest : Request<Param>
    {
        public SearchMessagesReadConfirmedRequest()
        {
            this.ServiceName = "SearchMessagesReadConfirmedService";
        }

    }

    #region [BussinesData]

    [XmlInclude(typeof(Param)), Serializable]
    public class Param : Entity
    {
        #region [Private Members]
        private ColaboratorData _ColaboratorData;
        private System.Guid _MessageId;
        #endregion


        #region [Properties]

        public ColaboratorData ColaboratorData
        {
            get { return _ColaboratorData; }
            set { _ColaboratorData = value; }
        }

        public System.Guid MessageId
        {
            get { return _MessageId; }
            set { _MessageId = value; }
        }

        #endregion
    }

    #endregion
}
