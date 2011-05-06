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

            }
            catch (Exception ex)
            {
                LogError(ex);

            }
        }

        internal static SysEventMessage GetSysEventMessage(Byte[] messageInBytes)
        {
            SysEventMessage wSysEvent = null;
            try
            {
                String wStrMessage = Encoding.ASCII.GetString((Byte[])messageInBytes);
                wSysEvent = (SysEventMessage)SerializationFunctions.DeserializeFromXml(typeof(SysEventMessage), wStrMessage);

            }
            catch (Exception ex)
            {
                LogError(ex);
            }
            return wSysEvent;
        }



  

        internal static void LogError(Exception ex)
        {
            
            if (Convert.ToBoolean(Poisoned.WcfService.Properties.Settings.Default.PerformLog))
            {
                Event ev = new Event();
                ev.AppId = Poisoned.WcfService.Properties.Resource.Title;
                ev.LogType = EventType.Error;
                ev.Message.Text = ExceptionHelper.GetAllMessageException(ex); 
                ev.Source = Poisoned.WcfService.Properties.Resource.Title;


                StaticLogger.Log(Fwk.Logging.Targets.TargetType.File, ev, "Error.xml", string.Empty);
            }
     
        }

        internal static void LogError(string msg)
        {
           
               LogError(new Exception(msg));
            
        }

   

     
    }
}
