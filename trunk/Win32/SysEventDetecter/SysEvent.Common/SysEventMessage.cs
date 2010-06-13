using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SysEvent.Common
{
    [Serializable]
    public class SysEventMessage 
    {
        DateTime _GeneratedTime;

        public DateTime GeneratedTime
        {
            get { return _GeneratedTime; }
            set { _GeneratedTime = value; }
        }
 
        string _UserName;

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        string _MachineName;

        public string MachineName
        {
            get { return _MachineName; }
            set { _MachineName = value; }
        }
        EventTypeEnum _EventType;

        public EventTypeEnum EventType
        {
            get { return _EventType; }
            set { _EventType = value; }
        }

        string _Message;

        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }

    }
}
