using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebChat.Common.Models;
using WebChat.Data;

namespace WebChat.Common.Models
{
    public class SentEmailModel : BaseModel
    {
        public string UserPhone { get; set; }
        public string UserEmail { get; set; }
        public string UserMessage { get; set; }
    }
}