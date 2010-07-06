using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using System.Xml.Serialization;

namespace Allus.Cnn.Common.BE
{

    [XmlRoot("MessagesBECollection"), SerializableAttribute]
	public class MessagesBECollection :Entities<MessagesBE>
	{
	
	}
	
	[XmlInclude(typeof(MessagesBE)), Serializable]
	public class MessagesBE:Entity
	{
		#region [Private Members]
		private System.Guid _MessageId;
		private System.String _MessageText;
        private System.String _Url;
        private System.String _Title;
       
		private System.String _Sender;
		private System.DateTime? _Date;
        private System.String _MeshName;
        private System.String _MeshId;
        bool _requireConfirm = false;
        string _MachineIp;
        string _MachineName;
        int _ColaboratorsCountInMesh = 0;
        private Fwk.Xml.CData _Tag;
        public Fwk.Xml.CData Tag
        {
            get
            {
                return _Tag;
            }
            set
            {
                _Tag = value;
            }
        }

        
       
		#endregion
		
		#region [Properties]

        MessageType _MessageType = MessageType.None;
        int _PriorityEnum;

        public int Priority
        {
            get { return _PriorityEnum; }
            set { _PriorityEnum = value; }
        }
        public System.String Url
        {
            get { return _Url; }
            set { _Url = value; }
        }
        public System.String Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        public string MachineIp
        {
            get { return _MachineIp; }
            set { _MachineIp = value; }
        }
        public string MachineName
        {
            get { return _MachineName; }
            set { _MachineName = value; }
        }
        public int ColaboratorsCountInMesh
        {
            get { return _ColaboratorsCountInMesh; }
            set { _ColaboratorsCountInMesh = value; }
        }
        public bool RequireConfirm
        {
            get { return _requireConfirm; }
            set { _requireConfirm = value; }
        }
		#region [MessageId]
     
        public System.Guid MessageId
		{
			get { return _MessageId; }
			set { _MessageId = value;  }
		}
		#endregion
		#region [Message]
        [XmlElement(ElementName = "MessageText", DataType = "string")]
        public System.String MessageText
		{
			get { return _MessageText; }
			set { _MessageText = value;  }
		}
		#endregion
		#region [Sender]
		[XmlElement(ElementName = "Sender", DataType = "string")]
		public System.String Sender
		{
			get { return _Sender; }
			set { _Sender = value;  }
		}
		#endregion
		#region [Date]
		[XmlElement(ElementName = "Date", DataType = "dateTime")]
		public System.DateTime? Date
		{
			get { return _Date; }
			set { _Date = value;  }
		}
		#endregion
		#region [MeshName]
        [XmlElement(ElementName = "MeshName", DataType = "string")]
        public System.String MeshName
		{
            get { return _MeshName; }
            set { _MeshName = value; }
		}
		#endregion

        #region MeshId
        [XmlElement(ElementName = "MeshId", DataType = "string")]
        public System.String MeshId
        {
            get { return _MeshId; }
            set { _MeshId = value; }
        }
        #endregion
        #region [MessageType]
        public MessageType MessageType
        {
            get { return _MessageType; }
            set { _MessageType = value; }
        }
        #endregion

        #endregion
        [XmlIgnore()]
        public string  DisplayMessageType
        {
            get { return MessagesBE.GetMessageType(_MessageType); }
           
        }
        #region Methods
        /// <summary>
        /// Estatico par a que se pueda utilizar desde otroas apps
        /// </summary>
        /// <param name="pMessageType"></param>
        /// <returns></returns>
        public static string GetMessageType(MessageType pMessageType)
        {
            switch (pMessageType)
            {
                case MessageType.SimpleText:
                    return "Texto simple";

                case MessageType.RichText:
                    return "Texto enriquecido";

                case MessageType.Marquee:
                    return "Marquesina";

                case MessageType.Mail:
                    return "Correo";

                default:
                    return string.Empty;
            }
        }
        #endregion
    }
}
