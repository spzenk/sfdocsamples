using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace SysEventDetecterService
{
    internal class EventChecker
    {
        private System.Diagnostics.EventLog eventLog1;
       
        internal void Start()
        {
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.eventLog1.EnableRaisingEvents = true;
            this.eventLog1.Log = "Application";
            this.eventLog1.Source = "EventChecker";
            //SystemEvents.UserPreferenceChanging += new        UserPreferenceChangingEventHandler(SystemEvents_UserPreferenceChanging);
            //SystemEvents.PaletteChanged += new EventHandler(SystemEvents_PaletteChanged);
            //SystemEvents.DisplaySettingsChanged += new EventHandler(SystemEvents_DisplaySettingsChanged);
            SystemEvents.SessionEnded += new SessionEndedEventHandler(SystemEvents_SessionEnded);
            SystemEvents.SessionSwitch += new SessionSwitchEventHandler(SystemEvents_SessionSwitch);
            SystemEvents.PowerModeChanged += new PowerModeChangedEventHandler(SystemEvents_PowerModeChanged);
            
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
            eventLog1.WriteEntry(string.Concat(Environment.UserName, Environment.MachineName, "PowerModeChanged", e.Mode.ToString()));
        }

        void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            eventLog1.WriteEntry(string.Concat(Environment.UserName, Environment.MachineName, "SessionSwitch", e.Reason.ToString()));
        }

        void SystemEvents_SessionEnded(object sender, SessionEndedEventArgs e)
        {
            eventLog1.WriteEntry(string.Concat(Environment.UserName, Environment.MachineName, "SessionEnded", e.Reason.ToString()));
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

    }
}
