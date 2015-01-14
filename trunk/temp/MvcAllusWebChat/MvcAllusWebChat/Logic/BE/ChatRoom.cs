/****************************** Module Header ******************************\
* Module Name:    ChatRoom.cs
* Project:        CSASPNETAJAXWebChat
* Copyright (c) Microsoft Corporation
*
* The project illustrates how to design a simple AJAX web chat application. 
* We use jQuery, ASP.NET AJAX at client side and Linq to SQL at server side.
* In this sample, we could create a chat room and invite someone
* else to join in the room and start to chat.
* 
* In this file, we create a DataContract class which used to serialize the
* ChatRoom data to the client side.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
*
\*****************************************************************************/

using System;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using WebChat.Data;
using WebChat.Common;

namespace WebChat.Logic
{
    
    public class ChatRoom
    {

    
        public Guid RoomID { get; private set; }
        public Int32 CreatedOnSessionId { get; set; }
        
        public string RoomName { get; private set; }
        
        public int MaxUser { get; private set; }
        
        public int CurrentUser { get; private set; }
        
        public string CreatorName { get;  set; }

        
        public string ChatRoomDepartment { get; private set; }

        
        public DateTime ChatRoomCreatedTime { get; private set; }

        
        public DateTime? ChatRoomChekOutTime { get; private set; }

        
        public String Status { get; private set; }
        public ChatRoom()
        { }
        public ChatRoom(Guid id)
        {
            
            var room = ChatManager.GetChatRoom( id);
            if (room != null)
            {
                RoomID = id;
                RoomName = room.ChatRoomName;
                MaxUser = room.MaxUserNumber;
                CurrentUser = room.tblTalkers.Count(t => t.CheckOutTime == null);
                CreatorName = room.CreatorName;
                ChatRoomChekOutTime = room.ChekoutTime;
                ChatRoomCreatedTime = room.ChatRoomCreatedTime;
                ChatRoomDepartment = room.ChatRoomDepartment;
                Enumerations.ChatRoomStatus s = (Enumerations.ChatRoomStatus)Enum.Parse(typeof(Enumerations.ChatRoomStatus), room.Status.ToString());
                switch (s)
                {
                    case Enumerations.ChatRoomStatus.Waiting:
                        {
                            Status = "En espera de atención";
                            break;
                        }
                    case Enumerations.ChatRoomStatus.Active:
                        {
                            Status = "Activo";
                            break;
                        }
                    case Enumerations.ChatRoomStatus.ClosedByOwner:
                        {
                            Status = "Cerrado por cliente";
                            break;
                        }
                    case Enumerations.ChatRoomStatus.ExpiredTimeout:
                        {
                            Status = "Expiro";
                            break;
                        }

                }
            }




        }


        public ChatRoom(tblChatRoom room)
        {

            
            if (room != null)
            {
                RoomID = room.ChatRoomID;
                RoomName = room.ChatRoomName;
                MaxUser = room.MaxUserNumber;
                CurrentUser = room.tblTalkers.Count(t => t.CheckOutTime == null);
                CreatorName = room.CreatorName;
                ChatRoomChekOutTime = room.ChekoutTime;
                ChatRoomCreatedTime = room.ChatRoomCreatedTime;
                ChatRoomDepartment = room.ChatRoomDepartment;
                CreatedOnSessionId = room.CreateOnSessionId;
                Enumerations.ChatRoomStatus s = (Enumerations.ChatRoomStatus)Enum.Parse(typeof(Enumerations.ChatRoomStatus), room.Status.ToString());
                switch (s)
                {
                    case Enumerations.ChatRoomStatus.Waiting:
                        {
                            Status = "En espera de atención";
                            break;
                        }
                    case Enumerations.ChatRoomStatus.Active:
                        {
                            Status = "Activo";
                            break;
                        }
                    case Enumerations.ChatRoomStatus.ClosedByOwner:
                        {
                            Status = "Cerrado por cliente";
                            break;
                        }
                    case Enumerations.ChatRoomStatus.ClosedByOperator:
                        {
                            Status = "Cerrado por operador";
                            break;
                        }
                    case Enumerations.ChatRoomStatus.ExpiredTimeout:
                        {
                            Status = "Expiro";
                            break;
                        }

                }
            }




        }

        public ChatRoom(Guid chatRoomId, int sessionId)
        {
            

            var room = ChatManager.GetChatRoom(chatRoomId);
            if (room != null)
            {
                RoomID = chatRoomId;
                RoomName = room.ChatRoomName;
                MaxUser = room.MaxUserNumber;
                CurrentUser = room.tblTalkers.Count(t => t.CheckOutTime == null);
                CreatorName = room.CreatorName;
                ChatRoomChekOutTime = room.ChekoutTime;
                ChatRoomCreatedTime = room.ChatRoomCreatedTime;
                ChatRoomDepartment = room.ChatRoomDepartment;
                CreatedOnSessionId = sessionId;
                Enumerations.ChatRoomStatus s = (Enumerations.ChatRoomStatus)Enum.Parse(typeof(Enumerations.ChatRoomStatus), room.Status.ToString());
                switch (s)
                {
                    case Enumerations.ChatRoomStatus.Waiting:
                        {
                            Status = "En espera de atención";
                            break;
                        }
                    case Enumerations.ChatRoomStatus.Active:
                        {
                            Status = "Activo";
                            break;
                        }
                    case Enumerations.ChatRoomStatus.ClosedByOwner:
                        {
                            Status = "Cerrado por cliente";
                            break;
                        }
                    case Enumerations.ChatRoomStatus.ExpiredTimeout:
                        {
                            Status = "Expiro";
                            break;
                        }

                }
            }

        }



        public int TalkerOwnerId { get; set; }
    }
}