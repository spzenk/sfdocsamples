using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using System.Xml.Serialization;

namespace Allus.Cnn.Common.BE
{

    [XmlInclude(typeof(ReceivedMessagesBE)), Serializable]
    public class ReceivedMessagesBE : Entity
    {
        #region [Private Members]
        private System.Guid _MessageId;
        private System.String _Receptor;
        private System.DateTime? _Date;
        private bool? _Confirmed;

        #endregion

        #region [Properties]

        #region [MessageId]
        public System.Guid MessageId
        {
            get { return _MessageId; }
            set { _MessageId = value; }
        }
        #endregion

        #region [Receptor]
        [XmlElement(ElementName = "Receptor", DataType = "string")]
        public System.String Receptor
        {
            get { return _Receptor; }
            set { _Receptor = value; }
        }
        #endregion
        #region [Date]
        [XmlElement(ElementName = "Date", DataType = "dateTime")]
        public System.DateTime? Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        #endregion
        #region [Confirmed]
        public bool? Confirmed
        {
            get { return _Confirmed; }
            set { _Confirmed = value; }

        }
        #endregion
        #endregion

    }
}
