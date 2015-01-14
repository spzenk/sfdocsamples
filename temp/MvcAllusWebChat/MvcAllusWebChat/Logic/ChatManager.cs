
using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using WebChat.Data;
using WebChat.Common;

namespace WebChat.Logic
{
    public class ChatManager
    {
        #region Send & Recieve Message
        public static void SendMessage(Int32 talkerId, string message)
        {
           using( SessionDBDataContext db = new SessionDBDataContext())
           {
               tblMessagePool msgpool = new tblMessagePool();
               msgpool.message = message;
               msgpool.SendTime = DateTime.Now;
               msgpool.talkerID = talkerId;
               db.tblMessagePools.InsertOnSubmit(msgpool);
               db.SubmitChanges();
           }
        }

       

        /// <summary>
        /// Retorna todos los mensajes de un chatRoom
        /// </summary>
        /// <param name="roomid"></param>
        /// <returns></returns>
        public static List<Message> RecieveMessage(Guid roomid, HttpContextBase context)
        {

            return ChatRoomDAC.RecieveMessage(roomid, context);

        }

        private static void TryToDeleteChatMessageList(Guid roomid)
        {
            ChatRoomDAC.TryToDeleteChatMessageList(roomid);
            
        }

        #endregion

        #region ChatRoom Management

        public static List<tblChatRoom>  SearchChatRoomList()
        {
            return ChatRoomDAC.SearchChatRoomList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomName"></param>
        /// <param name="creatorName"></param>
        /// <param name="maxUserNumber"></param>
        /// <param name="department"></param>
        /// <param name="createOnSessionId"></param>
        /// <param name="createdByUserName"></param>
        /// <returns></returns>
        public static Guid CreateChatRoom(string roomName, string creatorName,
             int maxUserNumber, string department, int createOnSessionId, string createdByUserName)
        {
            return ChatRoomDAC.CreateChatRoom( roomName,  creatorName,      maxUserNumber,  department,  createOnSessionId,  createdByUserName);
        }

       

        /// <summary>
        /// 1-Try create session
        /// 2-CheckTimeOut
        /// </summary>
        /// <param name="chatRoomID"></param>
        /// <param name="context"></param>
        /// <param name="alias"></param>
        /// <returns></returns>
        public static bool JoinChatRoom(Guid chatRoomID, HttpContextBase context, string alias)
        {
            if (!ChatRoomDAC.IsRoomFull(chatRoomID))
            {
                Int32 sessionUID = -1;
                
                //Si la session no existe la crea
                if (SessionDAC.SessionExist(context.Session.SessionID) == false)
                {
                    sessionUID = SessionDAC.CreateSession(context, alias);
                }
                else
                {
                    //Obtener la session
                    var session = SessionDAC.GetSession(context.Session.SessionID);
                    sessionUID = session.UID;
                }
                //Si Talcker tiene CheckOutTime null no crea nada
                //De lo contrario lo crea para ese chatroom particular
                if (TalkersDAC.CheckTimeOut(sessionUID,chatRoomID))
                {
                    return false;
                }
                else
                {
                    var room = ChatRoomDAC.GetChatRoom(chatRoomID);
                    #region Set talker
                    tblTalker talker = new tblTalker();
                    talker.ChatRoomID = chatRoomID;
                    talker.CheckInTime = DateTime.Now;
                    talker.CheckOutTime = null;
                    talker.SessionID = sessionUID;
                    //Es talker dueño si las session del chatroom = context.Session
                    talker.IsOwner = room.CreateOnSessionId.Equals(context.Session.SessionID);
                    #endregion
                    //Si el q se une no es cliente (owner del chatroom) verifica el estado enespera para pasarlo a active
                    if (!talker.IsOwner)
                    {
                        if (room.Status.Equals((int)Enumerations.ChatRoomStatus.Waiting))
                            ChatRoomDAC.Update_Chatroom(chatRoomID, (int)Enumerations.ChatRoomStatus.Active, null);
                    }
                    TalkersDAC.Create(talker);
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
       
       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chatRoomID"></param>
        /// <param name="sessionID"></param>
        public static void LeaveChatRoom(Guid chatRoomID, string sessionID)
        {
            SessionDBDataContext db = new SessionDBDataContext();



            tblSession session = SessionDAC.GetSession(sessionID);

            if (session != null)
            {
                //Obtiene el usuario 
                var talker = db.tblTalkers.FirstOrDefault(
                    t => t.ChatRoomID.Equals(chatRoomID) &&
                    t.SessionID.Equals(session.UID) &&
                    !t.CheckOutTime.HasValue);

                if (talker != null)
                {
                    talker.CheckOutTime = DateTime.Now;
                   // tblChatRoom wtblChatRoom = GetChatRoom(chatRoomID);
                    if (talker.IsOwner)
                    {
                        ///TODO: set ChatRoomChekOutTime if taleker is owner
                       
                        //wtblChatRoom.ChekoutTime = DateTime.Now;
                        //wtblChatRoom.Status = (int)Enumerations.ChatRoomStatus.ClosedByOwner;
                        ChatRoomDAC.Update_Chatroom(chatRoomID, (int)Enumerations.ChatRoomStatus.ClosedByOwner, DateTime.Now);

                    }
                    //Si un operador abandona el chat y es el unico se pone en espera
                    int wTalkers_Count = TalkersDAC.Talkers_Count(chatRoomID, talker.TalkerID);
                    if (talker.IsOwner == false && wTalkers_Count <=1)
                    {
                        ChatRoomDAC.Update_Chatroom(chatRoomID, (int)Enumerations.ChatRoomStatus.ClosedByOperator, null);
                    }

                    db.SubmitChanges();
                }
            }
            //TryToDeleteChatMessageList(ChatRoomID);
        }




   
        #endregion



        internal static tblChatRoom GetChatRoom(Guid id)
       {
          return ChatRoomDAC.GetChatRoom(id);
       }

        
        /// <summary>
        /// Busca el contexto del cliente para chatear
        /// </summary>
        /// <param name="ChatRoomID"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static tblTalker FindTalker(Guid chatRoomID, HttpContextBase context)
        {
           return TalkersDAC.FindTalker(chatRoomID,context);
           
        }
    }
}