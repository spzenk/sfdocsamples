

using System;
using System.Web;
using System.Runtime.Serialization;
using EpironChatLogs;


namespace WebChat.Logic
{
    
    public class Message
    {
        public string Talker { get;  set; }
        
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

        public Message(SMSMessage message, HttpContextBase session)
        {
            Talker = "Yo";//message.tblTalker.tblSession.UserAlias;
            MessageData = message.Message;
            SendTime = message.SMSCreated;
            IsFriend = true;// (message.tblTalker.tblSession.SessionID != session.Session.SessionID);
        }
    }
}