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

        SystemEvent _SystemEvent = null;
        SystemEventPoison _SystemEventPoison = null;
        /// <summary>
        /// Comienza a leer la cola de manera asincrona
        /// </summary>
        public void StartResiveMessage()
        {
            try
            {
               _SystemEvent = new SystemEvent();
               _SystemEvent.StartService();
               _SystemEvent.OnLogEvent += new EventHandler(SystemEvent_OnLogEvent);
           }
            catch (Exception ex)
            {
                ReceivedInfoProc.LogError(ex);
            }
        }
        /// <summary>
        /// Comienza a leer la cola de manera asincrona
        /// </summary>
        public void StartResivePoisonedMessage()
        {
            try
            {
                _SystemEventPoison = new SystemEventPoison();
                _SystemEventPoison.StartService();
                _SystemEventPoison.OnLogEvent += new EventHandler(SystemEvent_OnLogEvent);
            }
            catch (Exception ex)
            {
                ReceivedInfoProc.LogError(ex);
            }
        }

        void SystemEvent_OnLogEvent(object sender, EventArgs e)
        {
            Log(sender.ToString());
        }

      
        public void StopResiveMessage()
        {
            _SystemEvent.StopService();
            
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
