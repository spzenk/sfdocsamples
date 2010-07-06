using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using System.Xml.Serialization;

namespace Allus.Cnn.ISVC.CreateReceivedMessages
{
    [Serializable]
    public class CreateReceivedMessagesRequest : Request<Param>
    {
        public CreateReceivedMessagesRequest()
        {
            this.ServiceName = "CreateReceivedMessagesService";
        }
    }

    #region BusinessData

    [XmlInclude(typeof(Param)), Serializable]
    public class Param : Entity
    {

        #region [Private Members]
        private System.Guid _MessageId;
        private bool? _Confirmed;
        private System.String _Receptor;

        private System.DateTime? _Date;

      
        #endregion


        #region [Properties]

        #region Confirmed
        public bool? Confirmed
        {
            get { return _Confirmed; }
            set { _Confirmed = value; }
        }
        #endregion

        #region [MessageId]

        public System.Guid MessageId
        {
            get { return _MessageId; }
            set { _MessageId = value; }
        }
        #endregion

        #region [Receptor]
        [XmlElement(ElementName = "Receptor", DataType = "string")]
        public String Receptor
        {
            get { return _Receptor; }
            set { _Receptor = value; }
        }
        #endregion

        #region [Date]
        [XmlElement(ElementName = "Date", DataType = "dateTime")]
        public DateTime? Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        #endregion

        #endregion
    }
    #endregion

}
