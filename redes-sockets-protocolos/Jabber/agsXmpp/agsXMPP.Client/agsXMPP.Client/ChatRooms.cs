using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace agsXMPP.Client
{


    public class ChatRooms:agsXMPP.Client.IItems
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

        public Dictionary<string ,Jid> JidList
        {
            get { return _roomJidList; }
            set { _roomJidList = value; }
        }
    }

    public class Partisipants : agsXMPP.Client.IItems
    {
        string servername;
      
        public string Servername
        {
            get { return servername; }
            set { servername = value; }
        }
        Dictionary<string, Jid> _roomJidList = new Dictionary<string, Jid>();

        public Dictionary<string, Jid> JidList
        {
            get { return _roomJidList; }
            set { _roomJidList = value; }
        }
    }


}
