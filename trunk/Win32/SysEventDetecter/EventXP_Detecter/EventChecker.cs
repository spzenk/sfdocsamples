using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Diagnostics;
using System.Threading;


namespace EventXP_Detecter
{


    public class Management
    {
        //Thread procedure, start this thread from within OnStart of from
        //your own service thread procedure.
        //Initialize an Eventlog event watcher to look for Security events
        //with EventIdentifier = 528 (Logon events)
        //Note that 528 is valid for W2K, XP, W2K3, this value is not valid
        public void WatchLogonEvent(object stateObject)
        {
            AutoResetEvent stopWatcher = stateObject as AutoResetEvent;
            WqlEventQuery q = new WqlEventQuery();
            q.EventClassName = "__InstanceCreationEvent";
            q.WithinInterval = new TimeSpan(0, 0, 3);
            q.Condition = @"TargetInstance ISA 'Win32_NtLogEvent' 
                            and TargetInstance.LogFile='Security' 
                            and TargetInstance.EventIdentifier=528";

            try
            {
                using (ManagementEventWatcher watcher = new ManagementEventWatcher(q))
                {
                    watcher.EventArrived += new EventArrivedEventHandler(LogonEventArrived);
                    watcher.Start();
                    // wait for a stop event
                    stopWatcher.WaitOne();
                    watcher.Stop();
                }
            }
            catch (Exception e)
            {
                // log the event and stop the thread in case of failure, ...here dump the exception to the debugger
                Debug.WriteLine(e);
            }
        }


        // Handle the event, this sample eventhandler dumps all properties
        //to the debugger
        static void LogonEventArrived(object sender, EventArrivedEventArgs e)
        {
            foreach (PropertyData pd in e.NewEvent.Properties)
            {
                ManagementBaseObject mbo = null;
                if ((mbo = pd.Value as ManagementBaseObject) != null)
                {
                    foreach (PropertyData prop in mbo.Properties)
                    {
                        string eventMessage = string.Format("{0} - {1}", prop.Name, prop.Value);
                        // Parse the "InsertionString" property ... to filter what you need
                        // For demo purposes dump the string to the debugger
                        Debug.WriteLine(eventMessage);
                    }
                }
            }
        }



        ManagementEventWatcher _watcher;
        ManagementEventWatcher _watcher2;
        public  void OnStart()
        {
            string query1 = "Win32_PowerManagementEvent";
            string query2 = "Select * from Win32_PowerManagementEvent";
            string query3 = "select * from __instanceCreationEvent within 10 where targetInstance isa \"win32_Process\"";

            WqlEventQuery query = new WqlEventQuery(query2);
            
            //WqlEventQuery queryUsb =new WqlEventQuery(eventName,new TimeSpan(0, 0, 1),"TargetInstance isa \"Win32_USBControllerDevice\"");
            
            
          
            _watcher = new ManagementEventWatcher(query);
            _watcher.EventArrived += new EventArrivedEventHandler(watcher_EventArrived);
            _watcher.Start();


            _watcher2 = new ManagementEventWatcher(new WqlEventQuery(query3));
            _watcher2.EventArrived += new EventArrivedEventHandler(_watcher2_EventArrived);
            _watcher2.Start();
        }

        void _watcher2_EventArrived(object sender, EventArrivedEventArgs e)
        {
            StringBuilder x = new StringBuilder();
            foreach (PropertyData p in e.NewEvent.Properties)
            {
                x.Append(p.Name);

            }
        }

        public void OnStop()
        {
            _watcher.Stop();
        }

        void watcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            try
            {
                //int eventType = Convert.ToInt32(e.NewEvent.Properties["EventType"].Value);

                StringBuilder x = new StringBuilder();
                foreach (PropertyData p in e.NewEvent.Properties)
                {
                    x.Append(p.Name);

                }
                //switch (eventType)
                //{
                //    case 4:
                        
                //        break;
                //    case 7:
                        
                //        break;
                //}
            }
            catch (Exception ex)
            {
                //Log(ex.Message); 
            }
        } 
 

    }
}
    

