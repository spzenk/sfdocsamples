using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebChat.Data;


namespace WebChat.Common.Models
{

    public class SendMessageModel
    {
        public Int32 ChatRoomID { get; set; }
        public Int32 TalkerID { get; set; }
        public String TalkerName { get; set; }
        public String Message { get; set; }

        public Int32 UserId { get; set; }

        public Int32 RecordId { get; set; }

    }

}