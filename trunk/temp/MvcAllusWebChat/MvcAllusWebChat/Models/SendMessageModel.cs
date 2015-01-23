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
        public Int32 RoomId { get; set; }
        public Int32 UserId { get; set; }
        public Int32 RecordId { get; set; }
        public String Message { get; set; }
    }

}