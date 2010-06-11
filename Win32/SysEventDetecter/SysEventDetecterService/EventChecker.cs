using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Security.Principal;

namespace SysEventDetecterService
{
    internal class EventChecker
    {
        private System.Diagnostics.EventLog eventLog1;
       
        internal void Start()
        {
            this.eventLog1 = new System.Diagnostics.EventLog();
         
            this.eventLog1.Log = "Application";
            this.eventLog1.Source = "SysEventChecker";
            this.eventLog1.EnableRaisingEvents = true;
            //SystemEvents.UserPreferenceChanging += new        UserPreferenceChangingEventHandler(SystemEvents_UserPreferenceChanging);
            //SystemEvents.PaletteChanged += new EventHandler(SystemEvents_PaletteChanged);
            //SystemEvents.DisplaySettingsChanged += new EventHandler(SystemEvents_DisplaySettingsChanged);
            SystemEvents.SessionEnded += new SessionEndedEventHandler(SystemEvents_SessionEnded);
            SystemEvents.SessionSwitch += new SessionSwitchEventHandler(SystemEvents_SessionSwitch);
            SystemEvents.PowerModeChanged += new PowerModeChangedEventHandler(SystemEvents_PowerModeChanged);
            eventLog1.WriteEntry(WindowsIdentity.GetCurrent().Name,System.Diagnostics.EventLogEntryType.SuccessAudit);
            
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

         void Log(EventTypeEnum type,string msg)
        {


            SysEvent s = new SysEvent();
            s.UserName = WindowsIdentity.GetCurrent().Name;
            s.EventType = type;
            s.MachineName = Environment.MachineName;
            s.Message = msg;

            eventLog1.WriteEntry(Helpers.SerializeToXml(s), System.Diagnostics.EventLogEntryType.SuccessAudit, 7000);
        }


        
    }
}
