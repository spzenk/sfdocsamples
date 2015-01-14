using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebChat.Common;
using WebChat.Data;

namespace WebChat.Logic
{
    public class ChatRoomDAC
    {
        /// <summary>
        /// Crea un chatroom en estado Waiting
        /// </summary>
        /// <param name="roomName"></param>
        /// <param name="creatorName"></param>
        /// <param name="maxUserNumber"></param>
        /// <param name="department"></param>
        /// <param name="createOnSessionId"></param>
        /// <param name="createdByUserName"></param>
        /// <returns></returns>
        internal static Guid CreateChatRoom(string roomName, string creatorName,
             int maxUserNumber, string department, int createOnSessionId, string createdByUserName)
        {
            tblChatRoom room = new tblChatRoom();
            room.ChatRoomID = Guid.NewGuid();
            room.ChatRoomName = roomName;
            room.CreatorName = creatorName;
            room.ChatRoomDepartment = department;
            room.MaxUserNumber = maxUserNumber;
            room.ChatRoomCreatedTime = DateTime.Now;
            room.CreateOnSessionId = createOnSessionId;
            room.CreatedByUserName = createdByUserName;
            room.Status = (int)Enumerations.ChatRoomStatus.Waiting;
            
            using (SessionDBDataContext db = new SessionDBDataContext())
            {

                db.tblChatRooms.InsertOnSubmit(room);
                db.SubmitChanges();
                
            }
            
            return room.ChatRoomID;
        }
        internal static void Update_Chatroom(Guid roomid, int status, DateTime? chekOutTime)
        {
            using (SessionDBDataContext db = new SessionDBDataContext())
            {
                var wtblChatRoom = db.tblChatRooms.SingleOrDefault(r => r.ChatRoomID == roomid);
                wtblChatRoom.Status = status;
                wtblChatRoom.ChekoutTime = chekOutTime;
                db.SubmitChanges();
            }

        }

        /// <summary>
        /// Verifica si esta lleno el chat room
        /// </summary>
        /// <param name="roomID"></param>
        /// <returns></returns>
        internal static bool IsRoomFull(Guid roomID)
        {
            using (SessionDBDataContext db = new SessionDBDataContext())
            {
                var chatRoom = db.tblChatRooms.Single(room => room.ChatRoomID.Equals(roomID));
                if (chatRoom != null)
                {
                    return chatRoom.MaxUserNumber == chatRoom.tblTalkers.Count(
                        t => t.CheckOutTime == null);
                }
                else
                {
                    return false;
                }
            }
        }

        internal static tblChatRoom GetChatRoom(Guid roomid)
        {

            SessionDBDataContext db = new SessionDBDataContext();

            return db.tblChatRooms.SingleOrDefault(r => r.ChatRoomID == roomid);

        }



        internal static List<tblChatRoom> SearchChatRoomList()
        {
            using (SessionDBDataContext db = new SessionDBDataContext())
            {
                return db.tblChatRooms.ToList();
            }
        }
        internal static List<tblChatRoom> GetChatRoomList(string sessionId, string userName)
        {
            SessionDBDataContext db = new SessionDBDataContext();
            return db.tblChatRooms.Where(p =>
                    (string.IsNullOrEmpty(sessionId) || p.CreateOnSessionId.Equals(sessionId))
                 && (string.IsNullOrEmpty(userName) || p.CreatedByUserName.Equals(userName))).ToList<tblChatRoom>();
        }

        /// <summary>
        /// Retorna todos los mensajes de un chatRoom
        /// </summary>
        /// <param name="roomid"></param>
        /// <returns></returns>
        internal static List<Message> RecieveMessage(Guid roomid, HttpContextBase context)
        {
            List<Message> result = new List<Message>();
            using (SessionDBDataContext db = new SessionDBDataContext())
            {
                var msgs = from messages in db.tblMessagePools
                           where messages.tblTalker.ChatRoomID.Equals(roomid)
                           select messages;

          

                foreach (tblMessagePool msg in msgs.ToList())
                {
                    result.Add(new Message(msg, context));
                }
                return result;
            }
            //tblChatRoom wRoom = ChatManager.GetChatRoom(roomGuid);
            //

            //if (db.tblMessagePools.Count( msg => room.tblTalkers.Contains(msg.tblTalker)) > 0)
            //{
            //    return (from messages in db.tblMessagePools
            //            where messages.tblTalker.ChatRoomID == room.ChatRoomID
            //            select messages).ToList();
            //}
            //else
            //{
            //    return null;
            //}
        }

        internal static void TryToDeleteChatMessageList(Guid roomid)
        {
        
            using (SessionDBDataContext db = new SessionDBDataContext())
            {
                var list = from m in db.tblMessagePools
                           where m.tblTalker.ChatRoomID.Equals(roomid)
                           select m;
                db.tblMessagePools.DeleteAllOnSubmit(list);
                db.SubmitChanges();
            }

            //var chatroom = ChatRoomDAC.GetChatRoom(roomid);
            //if (chatroom == null) return;
            //if (chatroom.tblTalkers.Count(t => t.CheckOutTime == null) == 0)
            //{
            //    var list = from m in db.tblMessagePools
            //               where m.tblTalker.ChatRoomID == roomid
            //               select m;
            //    db.tblMessagePools.DeleteAllOnSubmit(list);
            //    db.SubmitChanges();
            //}
        }
    }
}