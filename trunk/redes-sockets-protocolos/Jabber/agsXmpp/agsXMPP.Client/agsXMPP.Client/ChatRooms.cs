using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace agsXMPP.Client
{


    public class ChatRooms
    {
        string servername;
        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Servername
        {
            get { return servername; }
            set { servername = value; }
        }
        Dictionary<string,Jid> _roomJidList = new Dictionary<string,Jid>();

        public Dictionary<string ,Jid> RoomJidList
        {
            get { return _roomJidList; }
            set { _roomJidList = value; }
        }
    }
}
