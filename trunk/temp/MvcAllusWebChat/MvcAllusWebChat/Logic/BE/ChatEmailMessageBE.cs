using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Fwk.Bases;

namespace WebChat.Common.BE
{

    [XmlRoot("ChatEMailMessageList"), SerializableAttribute]
    public class ChatEMailMessageList : Entities<ChatEmailMessageBE>
    {}

    [XmlInclude(typeof(ChatEmailMessageBE)), Serializable]
    public class ChatEmailMessageBE : Entity
    {
        public System.Int32 ChatEmailMessageId { get; set; }
        public System.Int32 ChatRoomId { get; set; }
        public System.String EmailFrom { get; set; }
        public System.String DeliveredTo { get; set; }
        public System.String Body { get; set; }
        public System.String ErrorMessage { get; set; }
        public System.String Subject { get; set; }
        public System.String EmailCreated { get; set; }
    }
    

}
         

   
