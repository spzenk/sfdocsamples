using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using Fwk.Exceptions;
using System.ServiceModel;
using Fwk.Configuration;
using System.Messaging;
using System.Timers;
using Fwk.Logging;

namespace Poisoned.WcfService
{

    public partial class MessageQueueProcess_MSMQ : Component
    {
        public event EventHandler OnLogEvent = null;
        ServiceHost serviceHost;
        public MessageQueueProcess_MSMQ()
        {
            InitializeComponent();
            
        }

        public MessageQueueProcess_MSMQ(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
           
        }



        /// <summary>
        /// Comienza a leer la cola de manera asincrona
        /// </summary>
        public void StartResiveMessage()
        {
            try
            {
               serviceHost =  SystemEvent.StartService();
               serviceHost.Closing += new EventHandler(serviceHost_Closing);
               serviceHost.Faulted += new EventHandler(serviceHost_Faulted);
                //serviceHost = new ServiceHost(typeof(SystemEventDLQ));

                //// Open the ServiceHostBase to create listeners and start listening for messages.
                //serviceHost.Open();
           }
            catch (Exception ex)
            {
                ReceivedInfoProc.LogError(ex);
            }
        }

      
        public void StopResiveMessage()
        {
            SystemEvent.StopService(serviceHost);
            
        }

        void serviceHost_Faulted(object sender, EventArgs e)
        {
            Log("Faulted host service " + sender.ToString());
        }
        void serviceHost_Closing(object sender, EventArgs e)
        {
            Log("cerrando host service ");
        }

        void Log(string msg)
        {
            if (OnLogEvent != null)
            {
                OnLogEvent(msg, new EventArgs());
            }
        }
      

     

       


        /// <summary>
        ///  Create the transacted MSMQ queue if necessary.
        /// </summary>
        /// <param name="queuePath"></param>
        void CreateQueue(string queuePath)
        {

            try
            {
                if (!MessageQueue.Exists(queuePath))
                {
                    MessageQueue.Create(queuePath, true);

                    // Create a new trustee to represent the "system" user group.
                    Trustee tr = new Trustee("SYSTEM");
                    MessageQueueAccessControlEntry entry = new MessageQueueAccessControlEntry(tr, MessageQueueAccessRights.FullControl, AccessControlEntryType.Allow);
                    // Apply the MessageQueueAccessControlEntry to the queue.
                    SysEventQueue.SetPermissions(entry);
                    
                    if (!string.IsNullOrEmpty(Properties.Settings.Default.AdministratorGroupName))
                    {
                        tr = new Trustee(Properties.Settings.Default.AdministratorGroupName);
                        entry = new MessageQueueAccessControlEntry(tr, MessageQueueAccessRights.FullControl, AccessControlEntryType.Allow);
                        SysEventQueue.SetPermissions(entry);
                    }
                }

            }
            catch (MessageQueueException ex)
            {
                ReceivedInfoProc.LogError(ex);
          
            }
        }
    }
}
