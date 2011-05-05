using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Poisoned.WcfService;
using System.Data.Common;
using Fwk.Logging;
using Fwk.Exceptions;
using System.Data.SqlClient;
using Fwk.Logging.Targets;
using Fwk.HelperFunctions;

namespace Poisoned.WcfService
{
    internal static class ReceivedInfoProc
    {
        internal static void Process(Byte[] messageInBytes, DateTime time)
        {
            try
            {
                String wStrMessage = Encoding.ASCII.GetString((Byte[])messageInBytes);
                SysEventMessage wSysEvent = (SysEventMessage)SerializationFunctions.DeserializeFromXml(typeof(SysEventMessage), wStrMessage);

                //throw new Exception();

            }
            catch (Exception ex)
            {
                ReceivedInfoProc.LogError_WE(ex);
              
            }
        }
              

        private static void InsertPing(SysEventMessage pSysEventMessage)
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
            }
        }



  

        internal static void LogError(Exception ex)
        {
            try
            {
                if (Convert.ToBoolean(Poisoned.WcfService.Properties.Settings.Default.PerformLog))
                {
                    Event ev = new Event();
                    ev.AppId = Poisoned.WcfService.Properties.Resource.Title;
                    ev.LogType = EventType.Error;
                    ev.Message.Text = ExceptionHelper.GetAllMessageException(ex);
                    ev.Source = Poisoned.WcfService.Properties.Resource.Title;
                    ev.LogDate = DateTime.Now;
                    ev.Machine = Environment.MachineName;
                    ev.User = Environment.UserName;

                    StaticLogger.Log(Fwk.Logging.Targets.TargetType.Database, ev, null, "CnnStringKey");
                }
            }
            catch (Exception Logex)
            {
                LogError_WE(Logex);
            }
        }

        internal static void LogError(string msg)
        {
            try
            {
                if (Convert.ToBoolean(Poisoned.WcfService.Properties.Settings.Default.PerformLog))
                {
                    Event ev = new Event();
                    ev.AppId = Poisoned.WcfService.Properties.Resource.Title;
                    ev.LogType = EventType.Error;
                    ev.Message.Text = msg;
                    ev.Source = Poisoned.WcfService.Properties.Resource.Title;
                    ev.LogDate = DateTime.Now;
                    ev.Machine = Environment.MachineName;
                    ev.User = Environment.UserName;

                    StaticLogger.Log(Fwk.Logging.Targets.TargetType.Database, ev, null, "CnnStringKey");
                }
            }
            catch (Exception Logex)
            {
                LogError_WE(Logex);
            }
        }

        internal static void LogError_WE(Exception ex)
        {
            if (Convert.ToBoolean(Poisoned.WcfService.Properties.Settings.Default.PerformLog))
            {
                Event ev = new Event();
                ev.AppId = Poisoned.WcfService.Properties.Resource.Title;
                ev.LogType = EventType.Error;
                ev.Message.Text = ExceptionHelper.GetAllMessageException(ex);
                ev.Source = Poisoned.WcfService.Properties.Resource.Title;
                ev.LogDate = DateTime.Now;
                ev.Machine = Environment.MachineName;
                ev.User = Environment.UserName;
                StaticLogger.Log(Fwk.Logging.Targets.TargetType.WindowsEvent, ev, null, null);
            }
            throw ex;
        }

        private static void LogCLientError(SysEventMessage wSysEvent)
        {
            try
            {
                if (Convert.ToBoolean(Poisoned.WcfService.Properties.Settings.Default.PerformLog))
                {
                    Event ev = new Event();
                    ev.AppId = Poisoned.WcfService.Properties.Resource.Title;
                    ev.LogType = EventType.Error;
                    ev.Message.Text = wSysEvent.EventDescription;
                    ev.Source = wSysEvent.HostDescription;
                    ev.LogDate = wSysEvent.EventDate;
                    ev.Machine = wSysEvent.HostName;
                    ev.User = wSysEvent.UserLogin;
                    StaticLogger.Log(Fwk.Logging.Targets.TargetType.Database, ev, null, "CnnStringKey");
                }
            }
            catch (Exception Logex)
            {
                LogError_WE(Logex);
            }
        }
    }
}
