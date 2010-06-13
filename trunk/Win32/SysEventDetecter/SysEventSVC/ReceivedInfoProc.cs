using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysEvent.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using Fwk.Logging;
using Fwk.Exceptions;
namespace SysEventSVC
{
    internal static class ReceivedInfoProc
    {
        internal static void Process(Byte[] messageInBytes, DateTime time)
        {
            String wStrMessage = Encoding.ASCII.GetString((Byte[])messageInBytes);
            SysEventMessage wSysEvent = (SysEventMessage)SysEvent.Common.Helpers.DeserializeFromXml(typeof(SysEventMessage), wStrMessage);


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
                wDataBase = DatabaseFactory.CreateDatabase("tarifador");
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
                if (Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["PerformLog"]))
                {
                    Event ev = new Event();
                    ev.AppId = "SystemEvent service";
                    ev.LogType = EventType.Error;
                    ev.Message.Text = ExceptionHelper.GetAllMessageException(ex);
                    ev.Source = "SystemEvent MSMQ deamon";

                    StaticLogger.Log(Fwk.Logging.Targets.TargetType.Database, ev, null,"logs");
                }
            }



        }
    }
}
