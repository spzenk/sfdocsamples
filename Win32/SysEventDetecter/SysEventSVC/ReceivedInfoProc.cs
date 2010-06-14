using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysEvent.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using Fwk.Logging;
using Fwk.Exceptions;
using System.Data.SqlClient;
namespace SysEventSVC
{
    internal static class ReceivedInfoProc
    {
        internal static void Process(Byte[] messageInBytes, DateTime time)
        {
            String wStrMessage = Encoding.ASCII.GetString((Byte[])messageInBytes);
            SysEventMessage wSysEvent = (SysEventMessage)SysEvent.Common.Helpers.DeserializeFromXml(typeof(SysEventMessage), wStrMessage);
            //Insert(wSysEvent);

        }
        /// <summary>
        /// Insert
        /// </summary>
        ///<param name="pReceivedInfoBE">ReceivedInfoBE</param>
        /// <returns>void</returns>
        /// <Date>2008-08-09T12:28:45</Date>
        /// <Author>moviedo</Author>
        static void Insert(SysEventMessage pSysEventMessage)
        {
            Database wDataBase = null;
            DbCommand wCmd = null;

            try
            {
                wDataBase = DatabaseFactory.CreateDatabase("syseventdata");
                wCmd = wDataBase.GetStoredProcCommand("ReceivedInfo_i");



                /// timeDayHours
                wDataBase.AddInParameter(wCmd, "EventType", System.Data.DbType.String, pSysEventMessage.EventType);
                /// timeDayMinutes
                wDataBase.AddInParameter(wCmd, "GeneratedTime", System.Data.DbType.Date, pSysEventMessage.GeneratedTime);
                /// durationHours
                wDataBase.AddInParameter(wCmd, "MachineName", System.Data.DbType.String, pSysEventMessage.MachineName);
                /// durationMinutes
                wDataBase.AddInParameter(wCmd, "Message", System.Data.DbType.String, pSysEventMessage.Message);
                /// durationTenthMinutes
                wDataBase.AddInParameter(wCmd, "UserName", System.Data.DbType.String, pSysEventMessage.UserName);



                wDataBase.ExecuteNonQuery(wCmd);

            }


            catch (Exception ex)
            {
                
                    LogError(ex);
                
            }



        }
        internal static Boolean PingToSQL()
        {
            Database wDataBase = DatabaseFactory.CreateDatabase("syseventdata");
            string wConnectionString = wDataBase.CreateConnection().ConnectionString;

            using (SqlConnection wCnn = new SqlConnection(wConnectionString))
            {
                try
                {

                    wCnn.Open();

                    wCnn.Close();
                    return true;

                }
                catch (Exception ex)
                {
                    LogError(ex);
                    return false;
                }
            }
        }

        internal static void LogError(Exception ex)
        {
            if (Convert.ToBoolean(SysEventSVC.Properties.Settings.Default.PerformLog))
            {
                Event ev = new Event();
                ev.AppId = SysEventSVC.Properties.Resource.Title;
                ev.LogType = EventType.Error;
                ev.Message.Text = ExceptionHelper.GetAllMessageException(ex);
                ev.Source = SysEventSVC.Properties.Resource.Title;

                StaticLogger.Log(Fwk.Logging.Targets.TargetType.Database, ev, null, "logs");
            }
        }
    }
}
