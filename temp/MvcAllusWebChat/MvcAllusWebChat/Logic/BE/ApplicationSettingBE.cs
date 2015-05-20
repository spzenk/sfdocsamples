using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebChat.Common.BE
{
    public class ApplicationSettingBE
    {
        public Int32 SettingId { get; set; }
        public String Description { get; set; }
        public String Value { get; set; }
        public Int32 PCApplicationSettings { get; set; }
    }
}