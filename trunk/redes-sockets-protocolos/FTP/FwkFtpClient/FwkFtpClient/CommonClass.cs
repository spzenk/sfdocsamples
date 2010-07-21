using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fwk.Net
{

    [Serializable]
    public class SocketClient
    {
        string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        string user;

        public string User
        {
            get { return user; }
            set { user = value; }
        }
        string _Server;

        public string Server
        {
            get { return _Server; }
            set { _Server = value; }
        }
        string _Port;

        public string Port
        {
            get { return _Port; }
            set { _Port = value; }
        }



    }
}
