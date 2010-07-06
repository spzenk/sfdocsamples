using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using System.Xml.Serialization;

namespace Allus.Cnn.ISVC.UpdateReceivedMessages
{
    [Serializable]
    public class UpdateReceivedMessagesRequest : Request<Param>
    {

        public UpdateReceivedMessagesRequest()
        {
            this.ServiceName = "UpdateReceivedMessagesService";
        }
    }

    #region BusinessData

    [XmlInclude(typeof(Param)), Serializable]
    public class Param : Entity
    {

        #region [Private Members]

        private bool? _Confirmed;
        private System.Guid _MessageId;
        private System.String _Receptor;

        #endregion

        #region [Properties]

         public  bool? Confirmed
        {
            get { return _Confirmed; }
            set { _Confirmed = value; }
        }


        #region [MessageId]

        public System.Guid MessageId
        {
            get { return _MessageId; }
            set { _MessageId = value; }
        }
        #endregion

        #region [Receptor]
        public String Receptor
        {
            get { return _Receptor; }
            set { _Receptor = value; }
        }
        #endregion

        #endregion
    }
    #endregion
}

