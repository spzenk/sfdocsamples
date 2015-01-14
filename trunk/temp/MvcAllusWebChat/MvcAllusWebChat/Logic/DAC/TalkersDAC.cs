using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebChat.Data;

namespace WebChat.Logic
{
    public class TalkersDAC
    {


        public static Int32 Create(tblTalker talker)
        {
            using (SessionDBDataContext db = new SessionDBDataContext())
            {
                db.tblTalkers.InsertOnSubmit(talker);
                db.SubmitChanges();
                return talker.TalkerID;
            }
            return -1;
        }
        /// <summary>
        /// True si Talker con sessionUID , chatRoomID y CheckOutTime == null
        /// Si Talcker tiene CheckOutTime null no crea nada
        /// </summary>
        /// <returns></returns>
        public static Boolean CheckTimeOut(int sessionUID,Guid chatRoomID)
        {
            bool checkOutTime=false;
            using (SessionDBDataContext db = new SessionDBDataContext())
            {
                checkOutTime = (db.tblTalkers.Count(t => t.ChatRoomID.Equals(chatRoomID) &&
                                            t.SessionID.Equals(sessionUID) &&
                                            t.CheckOutTime == null) > 0);
            }
            return checkOutTime;
        }

        /// <summary>
        /// Busca el contexto del cliente para chatear
        /// </summary>
        /// <param name="ChatRoomID"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static tblTalker FindTalker(Guid ChatRoomID, HttpContextBase context)
        {
            using (SessionDBDataContext db = new SessionDBDataContext())
            {
                var session = SessionDAC.GetSession(context.Session.SessionID);
                if (session != null)
                {
                    var rsl = db.tblTalkers.FirstOrDefault(
                        t => t.ChatRoomID == ChatRoomID &&
                        t.SessionID == session.UID);
                    return rsl;
                }
                return null;
                //throw new Exception("Abandono la sessión");
            }
        }

        public static List<tblTalker> GetRoomTalkerList(Guid ChatRoomID)
        {
            SessionDBDataContext db = new SessionDBDataContext();
            var rsl = from d in db.tblTalkers
                      where d.CheckOutTime == null && d.ChatRoomID == ChatRoomID
                      select d;
            return rsl.ToList();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomID"></param>
        /// <param name="not_included_talker"></param>
        /// <returns></returns>
        public static int Talkers_Count(Guid roomID, int? not_included_talker)
        {
            using (SessionDBDataContext db = new SessionDBDataContext())
            {
                var rsl = db.tblChatRooms.Single(room => room.ChatRoomID == roomID);
                if (rsl != null)
                {
                    return rsl.tblTalkers.Count(t => t.CheckOutTime == null &&
                        ((not_included_talker.HasValue == false) || t.TalkerID.Equals(not_included_talker.Value) == false));
                }
                else
                    return 0;

            }
        }
    }
}