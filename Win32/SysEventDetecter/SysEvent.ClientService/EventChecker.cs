using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Security.Principal;
using SysEvent.Common;

namespace SysEventDetecterService
{
    internal class EventChecker
    {
        private System.Diagnostics.EventLog eventLog1;
        private System.Diagnostics.EventLog eventLog_Security;
        string LogedUserName;
        internal void Start()
        {
            this.eventLog1 = new System.Diagnostics.EventLog();

            this.eventLog1.Log = "Application";
            this.eventLog1.Source = "SysEventChecker";
            this.eventLog1.EnableRaisingEvents = true;
            SystemEvents.SessionEnded += new SessionEndedEventHandler(SystemEvents_SessionEnded);
            SystemEvents.SessionSwitch += new SessionSwitchEventHandler(SystemEvents_SessionSwitch);
            SystemEvents.PowerModeChanged += new PowerModeChangedEventHandler(SystemEvents_PowerModeChanged);
            eventLog1.WriteEntry(WindowsIdentity.GetCurrent().Name, System.Diagnostics.EventLogEntryType.SuccessAudit);


            this.eventLog_Security = new System.Diagnostics.EventLog();
            this.eventLog_Security.EnableRaisingEvents = true;
            this.eventLog_Security.Log = "Security";
            this.eventLog_Security.EntryWritten += new System.Diagnostics.EntryWrittenEventHandler(eventLog_Security_EntryWritten);

        }

        void eventLog_Security_EntryWritten(object sender, System.Diagnostics.EntryWrittenEventArgs e)
        {
            if (e.Entry.EventID == 528 || e.Entry.EventID == 529)
            {
                LogedUserName = e.Entry.Message;
            }

        }
        internal void Stop()
        {
            SystemEvents.SessionEnded -= new SessionEndedEventHandler(SystemEvents_SessionEnded);
            SystemEvents.SessionSwitch -= new SessionSwitchEventHandler(SystemEvents_SessionSwitch);
            SystemEvents.PowerModeChanged -= new PowerModeChangedEventHandler(SystemEvents_PowerModeChanged);

            this.eventLog1.Dispose();
        }
        void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {

            Log(EventTypeEnum.PowerModeChanged, e.Mode.ToString());

        }

        void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            Log(EventTypeEnum.SessionSwitch, e.Reason.ToString());
        }

        void SystemEvents_SessionEnded(object sender, SessionEndedEventArgs e)
        {
            Log(EventTypeEnum.SessionEnded, e.Reason.ToString());
        }


        // This method is called when a user preference changes.
        static void SystemEvents_UserPreferenceChanging(object sender, UserPreferenceChangingEventArgs e)
        {


        }

        // This method is called when the palette changes.
        static void SystemEvents_PaletteChanged(object sender, EventArgs e)
        {

        }

        // This method is called when the display settings change.
        static void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {

        }

        void Log(EventTypeEnum type, string msg)
        {
            SysEventMessage s = new SysEventMessage();
            s.UserName = WindowsIdentity.GetCurrent().Name;
            s.EventType = type;
            s.MachineName = Environment.MachineName;
            s.Message = msg;
            s.GeneratedTime = DateTime.Now;

            eventLog1.WriteEntry(Helpers.SerializeToXml(s), System.Diagnostics.EventLogEntryType.SuccessAudit, 7000);
        }



    }
}
