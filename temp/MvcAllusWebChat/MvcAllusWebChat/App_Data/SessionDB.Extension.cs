using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebChat.Common;

namespace WebChat.Data
{
    public partial class tblChatRoom
    {
        /// <summary>
        /// returns first splited field [0], split separator $
        /// </summary>
        public string ClientName
        {
            get
            {
                if (this.ChatRoomName.Split('$').Length > 1)
                    return this.ChatRoomName.Split('$')[0];
                else
                    return string.Empty;
            }
        }
        /// <summary>
        /// returns second splited  field [1], split separator $
        /// </summary>
        public string Email
        {
            get
            {
                if (this.ChatRoomName.Split('$').Length > 1)
                    return this.ChatRoomName.Split('$')[1];
                else
                    return string.Empty;
            }
        }
        public string ChatRoomClientUrl
        {
            get
            {
                return "URL del chatroom"; //String.Format("rep/Modules/chat_sn.aspx?i={1}", WebChat.Master.BaseURL, this.ChatRoomID.ToString());
               
            }
        }

        public String StatusLeyend {
            get {
                return GetStatus();
            }
        }

        String GetStatus()
        {
            Enumerations.ChatRoomStatus s = (Enumerations.ChatRoomStatus)Enum.Parse(typeof(Enumerations.ChatRoomStatus), this.Status.ToString());
            switch (s)
            {
                case Enumerations.ChatRoomStatus.Waiting:
                    {
                        return  "En espera de atención";
                        
                    }
                case Enumerations.ChatRoomStatus.Active:
                    {
                        return  "Activo";
                        
                    }
                case Enumerations.ChatRoomStatus.ClosedByOwner:
                    {
                        return  "Cerrado por cliente";
                     
                    }
                case Enumerations.ChatRoomStatus.ExpiredTimeout:
                    {
                        return  "Expiro";
                        
                    }

            }
            return String.Empty;
        }
    }
}