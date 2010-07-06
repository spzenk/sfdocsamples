using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using System.Xml.Serialization;

namespace Allus.Cnn.Common.BE
{

    public enum PriorityEnum {  Low= 0, Medium=1,Hight = 2 }
    /// <summary>
    /// Clase que reprecenta un mensaje enviado a los colaboradores del sistema
    /// </summary>
    [XmlInclude(typeof(AlertMessage)), Serializable]
    public class AlertMessage :Entity
    {
        string _MeshName;

        public string MeshName
        {
            get { return _MeshName; }
            set { _MeshName = value; }
        }

        String _MeshId;

        public String MeshId
        {
            get { return _MeshId; }
            set { _MeshId = value; }
        }

        bool _Read = false;

        public bool Read
        {
            get { return _Read; }
            set { _Read = value; }
        }
        bool _requireConfirm = false;

        public bool RequireConfirm
        {
            get { return _requireConfirm; }
            set 
            {
                _requireConfirm = value;
            }
        }
        Guid _MessageGuid;

        public Guid MessageGuid
        {
            get { return _MessageGuid; }
            set { _MessageGuid = value; }
        }

        private bool? _Confirmed = null ;

        public bool? Confirmed
        {
            get { return _Confirmed; }
            set
            {_Confirmed = value;}
        }

        //private bool _RichText;

        //public bool RichText
        //{
        //    get { return _RichText; }
        //    set { _RichText = value; }
        //}

        string _Text;

        public string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }

        string _Url;

        public string Url
        {
            get { return _Url; }
            set { _Url = value; }
        }

        string _Title;

        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        DateTime _Date;

        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        System.Byte[] _Picture;

       
        [System.Xml.Serialization.XmlElementAttribute("Picture", DataType = "base64Binary")]
        public System.Byte[] Picture
        {
            get { return _Picture; }
            set { _Picture = value; }
        }
        int _PriorityEnum;

        public int Priority
        {
            get { return _PriorityEnum; }
            set { _PriorityEnum = value; }
        }

        MessageType _MessageType = MessageType.SimpleText;
        public MessageType MessageType
        {
            get { return _MessageType; }
            set { _MessageType = value; }
        }

        private Fwk.Xml.CData _Tag = new Fwk.Xml.CData();
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
        private System.String _Sender;
        #region [Sender]
        [XmlIgnore()]
        public System.String Sender
        {
            get { return _Sender; }
            set { _Sender = value; }
        }
        #endregion

        private System.String _TextNoRtf;

        public System.String TextNoRtf
        {
            get { return _TextNoRtf; }
            set { _TextNoRtf = value; }
        }


   }
    /// <summary>
    /// Colección generíca de objetos AlertMessage.
    /// </summary>
    [XmlRoot("AlertMessageList"), SerializableAttribute]
    public class AlertMessageList : Entities<AlertMessage>
    {
    }
}
