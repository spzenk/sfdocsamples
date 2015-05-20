using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebChat.Logic.BE
{
    public class GetRecordIdBE
    {
        public int? RecordId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserName { get; set; }
        public int chatRoomStatusFromEtl { get; set; }
    }
}