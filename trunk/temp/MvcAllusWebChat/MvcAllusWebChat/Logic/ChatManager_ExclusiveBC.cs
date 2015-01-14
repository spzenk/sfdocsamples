using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebChat.Common;
using WebChat.Data;

namespace WebChat.Logic
{
    public class ChatManager_ExclusiveBC
    {

        public static void TryTo_JoinChatRoom(Guid chatRoomID, HttpContextBase context, string alias, bool isOperator)
        {
            if (isOperator)
                TryTo_JoinChatRoom_Operator(chatRoomID,context,alias);
            else
                TryTo_JoinChatRoom_Client(chatRoomID, context, alias);
        }


        public static void TryTo_JoinChatRoom_Operator(Guid chatRoomID, HttpContextBase context, string alias)
        {


            tblChatRoom chatRoom = ChatRoomDAC.GetChatRoom(chatRoomID);
            if (chatRoom == null)
            {
                throw new Exception("El chat expiró o no se encuentra abilitado");
            }

            SessionFullview session = SessionDAC.GetSession(context.Session.SessionID,chatRoomID);

            //Si es el operador se debe actualizar la session Id q creo el chat
            if (session == null)
            {
                //Para el caso en que se alla creado con aterioridad el chatroom pero la session alla cambiada o alla cambiao de explorador
                SessionDAC.Try_UpdateChatroom_New_OwnerSession(context, chatRoomID);
            }

            if (session != null)
            {
                if (session.Status.Equals(Enumerations.ChatRoomStatus.ClosedByOwner))
                {
                    throw new Exception("El chat fue cerrado");
                }

                if (session.Status.Equals(Enumerations.ChatRoomStatus.ExpiredTimeout))
                {
                    throw new Exception("El chat expiró");
                }
            }

            JoinChatRoom(chatRoomID, context, alias);
        }

        private static void TryTo_JoinChatRoom_Client(Guid chatRoomID, HttpContextBase context, string alias)
        {
            tblChatRoom chatRoom = ChatRoomDAC.GetChatRoom(chatRoomID);
            if (chatRoom.Status.Equals(Enumerations.ChatRoomStatus.ClosedByOwner))
            {
                throw new Exception("El chat fue cerrado");
            }

            if (chatRoom.Status.Equals(Enumerations.ChatRoomStatus.ExpiredTimeout))
            {
                throw new Exception("El chat expiró");
            }

            JoinChatRoom(chatRoomID, context, alias);
        }
       
        /// <summary>
        /// Aqui Owner es el operador
        /// </summary>
        /// <param name="chatRoomID"></param>
        /// <param name="context"></param>
        /// <param name="alias"></param>
        /// <returns></returns>
        static void JoinChatRoom(Guid chatRoomID, HttpContextBase context, string alias)
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
            if (TalkersDAC.CheckTimeOut(sessionUID, chatRoomID))
            {
                return;
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
                //Si el q se une no es cliente (owner del chatroom) verifiuca el estado enespera para pasarlo a active
                if (!talker.IsOwner)
                {
                    if (room.Status.Equals((int)Enumerations.ChatRoomStatus.Waiting))
                        ChatRoomDAC.Update_Chatroom(chatRoomID, (int)Enumerations.ChatRoomStatus.Active, null);
                }
                TalkersDAC.Create(talker);
              
                return;
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
                    if (talker.IsOwner)
                    {
                        ChatRoomDAC.Update_Chatroom(chatRoomID, (int)Enumerations.ChatRoomStatus.ClosedByOwner, DateTime.Now);
                    }

                    //Si un operador abandona el chat y es el unico se pone en espera
                    int wTalkers_Count = TalkersDAC.Talkers_Count(chatRoomID, talker.TalkerID);

                    if (talker.IsOwner == false && wTalkers_Count <= 1)
                    {
           

                        //wtblChatRoom.ChekoutTime = DateTime.Now;
                        //wtblChatRoom.Status = (int)Enumerations.ChatRoomStatus.Waiting;
                        ChatRoomDAC.Update_Chatroom(chatRoomID, (int)Enumerations.ChatRoomStatus.Waiting, null);
                    }

                    db.SubmitChanges();
                }
            }
            //TryToDeleteChatMessageList(ChatRoomID);
        }




        
    }
}