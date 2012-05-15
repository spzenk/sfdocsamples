using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace WebApplication_ChekSession
{
    public class SessionMannager
    {

        internal static void Check_ActiveSession(MembershipUser user, string sessionId)
        {
            

            if (user != null)
            {
//                Dictionary<string, DateTime> activeUsers = (Dictionary<string, DateTime>)Application["activeUsers"];

                //if (!activeUsers.ContainsKey(user.UserName))
                if (Any_ActiveSession(user.UserName))
                {
                    //activeUsers.Add(user.UserName, System.DateTime.Now);
                    Reg_ActiveSession(sessionId,user.UserName);
                }
            }
        }


        bool Any_ActiveSession(string userName)
        {
            using (SessionsDataDataContext dc = new SessionsDataDataContext("SessionsConnectionString"))
            {

                return dc.ActiveSessions.Any(s => s.UserName.Equals(userName));
            }
        }

        static void Reg_ActiveSession(string sessionId, string userName)
        {
            using (SessionsDataDataContext dc = new SessionsDataDataContext("SessionsConnectionString"))
            {
                ActiveSession a = new ActiveSession();
                a.UserName = userName;
                a.SessionID = sessionId;
                a.LoggedInDate = DateTime.Now;
                dc.ActiveSessions.InsertOnSubmit(a);
                dc.SubmitChanges();
            }
        }
        static void Remove_ActiveSession(string userName)
        {
            using (SessionsDataDataContext dc = new SessionsDataDataContext("SessionsConnectionString"))
            {

                ActiveSession a = dc.ActiveSessions.Where(s=> s.UserName.Equals(userName)).FirstOrDefault<ActiveSession>();
                if (a != null)
                {
                    SessionHistory wSessionHistory = new SessionHistory();

                    wSessionHistory.UserName = a.UserName;
                    wSessionHistory.SessionID = a.SessionID;
                    wSessionHistory.StatusDate = a.LoggedInDate;
                    wSessionHistory.Status = "Log_In";
                    dc.SessionHistories.InsertOnSubmit(wSessionHistory);
                
                    wSessionHistory = new SessionHistory();

                    wSessionHistory.UserName = a.UserName;
                    wSessionHistory.SessionID = a.SessionID;
                    wSessionHistory.StatusDate = DateTime.Now;
                    wSessionHistory.Status = "Log_Out";
                    dc.SessionHistories.InsertOnSubmit(wSessionHistory);
                    dc.ActiveSessions.DeleteOnSubmit(a);
                    dc.SubmitChanges();
                }
            
            }
        }
    }
}