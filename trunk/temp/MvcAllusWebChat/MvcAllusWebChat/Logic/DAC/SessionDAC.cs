
using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using WebChat.Data;


namespace WebChat.Logic
{
    public class SessionDAC
    {
        /// <summary>
        /// Obtiene SessionFullview
        /// </summary>
        /// <param name="sessionID">Opcional</param>
        /// <param name="alias">Opcional</param>
        /// <param name="chatRoomID"></param>
        /// <returns></returns>
        public static SessionFullview GetSession(string sessionID, Guid chatRoomID)
        {
            using (SessionDBDataContext db = new SessionDBDataContext())
            {
                var session = db.SessionFullviews.Where(s =>
                    s.ChatRoomID.Equals(chatRoomID) &&
       
                    (string.IsNullOrEmpty(sessionID) || s.SessionID.Equals(sessionID))
                    ).FirstOrDefault();

                return session;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="chatRoomID"></param>
        internal static void Try_UpdateChatroom_New_OwnerSession(HttpContextBase context, Guid chatRoomID)
        {
            //using (SessionDBDataContext db = new SessionDBDataContext())
            //{

            //    tblChatRoom chatRoom_db = db.tblChatRooms.FirstOrDefault(s => s.ChatRoomID == chatRoomID);
            //    if (chatRoom_db != null)
            //    {
            //        tblSession session_db = db.tblSessions.FirstOrDefault(s => s.SessionID == chatRoom_db.CreateOnSessionId);
            //        if (session_db != null)
            //        {
            //            //Actualizo
            //            chatRoom_db.CreateOnSessionId = context.Session.SessionID;
            //            session_db.SessionID = context.Session.SessionID;

            //            db.SubmitChanges();
            //        }
            //    }
            //}
        }
        public static tblSession GetSession(string sessionID)
        {
            SessionDBDataContext db = new SessionDBDataContext();
            var session = db.tblSessions.FirstOrDefault(
                s => s.SessionID.Equals(sessionID));
            return session;
        }

        public static bool SessionExist(String sessionID)
        {
            Boolean exist = false;
            using (SessionDBDataContext db = new SessionDBDataContext())
            {
                exist = db.tblSessions.Any(s => s.SessionID.Equals(sessionID));
            }
            return exist;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="userAlias"></param>
        /// <returns>sessionUID</returns>
        public static int CreateSession(HttpContextBase context, string userAlias)
        {
            try
            {
                SessionDBDataContext db = new SessionDBDataContext();

                tblSession session = new tblSession();
                session.SessionID = context.Session.SessionID;
                session.IP = context.Request.UserHostAddress;
                if (string.IsNullOrEmpty(userAlias))
                    userAlias = session.IP;
                session.UserAlias = userAlias;
                db.tblSessions.InsertOnSubmit(session);
                db.SubmitChanges();
                return session.UID;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// Retorna el primer chat asociado a la session : Util para cuando el chat es creado por un cliente con un unico chatroom posible
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        internal static ChatRoom RetriveFirstChatroom(int sessionId)
        {
            ChatRoom wChatRoom = null;
            try
            {
                using (SessionDBDataContext db = new SessionDBDataContext())
                {
                    if (db.tblChatRooms.Any(p => p.CreateOnSessionId.Equals(sessionId)))
                    {
                        var tblChat = db.tblChatRooms.Where(p => p.CreateOnSessionId.Equals(sessionId)).FirstOrDefault();

                         wChatRoom = new ChatRoom(tblChat);

                       
                    }
                }
                return wChatRoom;
            }  
            catch(Exception ex)
            { throw ex; }
        }
    }
}