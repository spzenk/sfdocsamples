

using System;
using System.Web;
using System.Runtime.Serialization;
using EpironChatLogs;


namespace WebChat.Logic
{
    
    public class Message
    {
        public String  Talker { get;  set; }
        public Int32 UserId { get; set; }
        public string MessageData { get;  set; }
        
        public DateTime SendTime { get;  set; }
        
        
        public bool IsFriend { get;  set; }

        public Message(WebChat.Data.tblMessagePool message, HttpContextBase session)
        {
            Talker = message.tblTalker.tblSession.UserAlias;
            MessageData = message.message;
            SendTime =  message.SendTime;
            IsFriend = (message.tblTalker.tblSession.SessionID != session.Session.SessionID);
        }
        public Message()
        { }

        public Message(ChatMessage message, HttpContextBase session)
        {
            Talker = "Yo";//message.tblTalker.tblSession.UserAlias;
            UserId = message.ChatUserId;
            MessageData = message.ChatMessage1;
            SendTime = message.ChatMessageDate;
            IsFriend = true;// (message.tblTalker.tblSession.SessionID != session.Session.SessionID);
        }
    }
}