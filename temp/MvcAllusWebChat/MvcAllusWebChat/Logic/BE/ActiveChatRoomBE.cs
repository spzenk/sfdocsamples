using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebChat.Common.BE
{
    public class ActiveChatRoomBE
    {
        public DateTime ChatMessageDate {get;set;}
        public Int32 ChatRoomId {get;set;}
        public Int32 ChatMessageId { get; set; }
        public WebChat.Common.Enumerations.ChatRoomStatus Status { get; set; } 
        
    }
}