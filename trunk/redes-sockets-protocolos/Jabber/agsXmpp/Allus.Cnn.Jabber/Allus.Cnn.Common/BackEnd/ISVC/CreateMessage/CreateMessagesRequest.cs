using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Fwk.Bases;
using Allus.Cnn.Common;

namespace Allus.Cnn.ISVC.CreateMessage
{
        [Serializable]
        public class CreateMessagesRequest : Request<Param>
        {
            public CreateMessagesRequest()
            {
                this.ServiceName = "CreateMessagesService";
            }
        }

        #region [BussinesData]


        [XmlInclude(typeof(Param)), Serializable]
        public class Param : Entity
        {
            #region [Private Members]

            private System.String _MessageText;
            private System.String _Url;
            private System.String _Title;

            private System.String _Sender;

            private System.DateTime? _Date;
            
            private String _MeshName;
            private System.String _MeshId;

            private System.Guid _MessageId;
            private bool _RequireConfirm;
            string _MachineIp;
            string _MachineName;
            int _ColaboratorsCountInMesh = 0;

            int _PriorityEnum =0;
            MessageType _MessageType = MessageType.SimpleText;

            public MessageType MessageType
            {
                get { return _MessageType; }
                set { _MessageType = value; }
            }
           
            #endregion
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
            #region [Properties] 

            #region [RequireConfirm]
            public bool RequireConfirm
            {
                get { return _RequireConfirm; }
                set { _RequireConfirm = value; }
            }
            #endregion

            #region [MessageId]

            public System.Guid MessageId
            {
                get { return _MessageId; }
                set { _MessageId = value; }
            }
            #endregion

            #region [Message]

            public String MessageText
            {
                get { return _MessageText; }
                set { _MessageText = value; }
            }
            #endregion

            #region [Sender]
            [XmlElement(ElementName = "Sender", DataType = "string")]
            public String Sender
            {
                get { return _Sender; }
                set { _Sender = value; }
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

            #region [MeshName]
            [XmlElement(ElementName = "MeshName", DataType = "string")]
            public String MeshName
            {
                get { return _MeshName; }
                set { _MeshName = value; }
            }
            #endregion

            #region MeshId
            [XmlElement(ElementName = "MeshId", DataType = "string")]
            public String MeshId
            {
                get { return _MeshId; }
                set { _MeshId = value; }
            }
            #endregion

            #endregion

        }

        #endregion

}
