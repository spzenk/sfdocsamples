using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebChat.Data;


namespace WebChat.Common.Models
{
    public class ChatRoomGridModel : BaseModel
    {
        public List<tblChatRoom> ChatRoomList { get; set; }

        public bool IsConfigavailable { get; set; }

        //Appsettings
        public int RetriveMessage_Timer { get; set; }
        public int GetRecord_Timer { get; set; }
        public string VersionWeb { get; set; }
        public int GetRecordIdTries { get; set; }
        public int ClientInactivityTimeOut { get; set; }
        public int GetRecord_TimeOut { get; set; }
        public bool EmailAvailable { get; set; }
        public int MaxLength_Message { get; set; }

        //Exception
        public bool HaveException { get; set; }


    }
    public class ChatRoomFromUrlModel
    {
        public ChatRoomFromUrlModel()
        {
            this.OperatrCount = -1;
        }
        public Int32 UserId { get; set; }
        public Int32 RoomId { get; set; }
        public String RecordId { get; set; }

        public String ClientName { get; set; }
        public String ClientEmail { get; set; }
        public Guid? ChatConfigId { get; set; }
        public Int32 MessageId { get; set; }

        public bool IsConfigavailable { get; set; }


        public int OperatrCount { get; set; }

        public bool userAlreadySigned { get; set; }

        //Appsettings
        public int RetriveMessage_Timer { get; set; }
        public int GetRecord_Timer { get; set; }
        public string VersionWeb { get; set; }
        public int GetRecordIdTries { get; set; }
        public int ClientInactivityTimeOut { get; set; }
        public int GetRecord_TimeOut { get; set; }
        public bool EmailAvailable { get; set; }
        public int MaxLength_Message { get; set; }


        //Surveys
        public bool SurveyAvailable { get; set; }
        public int? ChatSurveyConfigId { get; set; }
        public string ChatSurveyConfigURL { get; set; }
        public string ChatSurveyConfigText { get; set; }

        //Exception
        public bool HaveException { get; set; }


    }
    public class ChatRoomModel
    {

        public String ClientName { get; set; }
        public String ClientEmail { get; set; }
        public Int32 ChatConfigId { get; set; }


    }
    public class ChatRoomCreationModel
    {
        public Guid? ChatConfigId { get; set; }
        public String Phone { get; set; }
        public String InitialMessage { get; set; }
        public Guid ChatRoomID { get; set; }

        public String ClientName { get; set; }
        public String ClientEmail { get; set; }
    }

}