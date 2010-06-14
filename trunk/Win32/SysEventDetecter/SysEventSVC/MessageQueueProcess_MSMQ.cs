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

namespace SysEventSVC
{
    //public delegate void MessageArriveHandler(ReceivedInfoBE msg);
    public partial class MessageQueueProcess_MSMQ : Component
    {
        #region Properties
        //public event MessageArriveHandler OnMessageArrive;

        //void Do_OnMessageArrive(ReceivedInfoBE msg)
        //{
        //    if (OnMessageArrive != null)
        //    {
        //        OnMessageArrive(msg);
        //    }

        //}
      
        private System.Timers.Timer MessageQueueProcessTimer = null;
       

        Boolean m_DeamonEnabled = true;


    

        #endregion

        public MessageQueueProcess_MSMQ()
        {
            InitializeComponent();
            Init();
        }

        public MessageQueueProcess_MSMQ(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            Init();
        }




        /// <summary>
        /// Comienza a leer la cola de manera asincrona
        /// </summary>
        public void StartResiveMessage()
        {
            try
            {
             

                // Create the transacted MSMQ queue if necessary.
                if (!MessageQueue.Exists(SysEventSVC.Properties.Settings.Default.QueuePath))
                    MessageQueue.Create(SysEventSVC.Properties.Settings.Default.QueuePath, true);


                // Create a ServiceHost for the CDRService type.
                ServiceHost serviceHost = new ServiceHost(typeof(SystemEvent));

                /*  ServiceThrottlingBehavior throttle = new ServiceThrottlingBehavior();
                  throttle.MaxConcurrentCalls = 5;
                  serviceHost.Description.Behaviors.Add(throttle);*/

                // Hook on to the service host faulted events
                //serviceHost.Faulted += new EventHandler(OnServiceFaulted);

                // Open the ServiceHostBase to create listeners and start listening for messages.
                serviceHost.Open();
               
            }
            catch (Exception ex)
            {
                
                    ReceivedInfoProc.LogError(ex);
                
            }
        }

        public static void OnServiceFaulted(object sender, EventArgs e)
        {

            Event ev = new Event();
            ev.AppId = SysEventSVC.Properties.Resource.Title;
            ev.LogType = EventType.Error;
            ev.Message.Text = SysEventSVC.Properties.Resource.Title + " Faulted";
            ev.Source = SysEventSVC.Properties.Resource.Title;

            StaticLogger.Log(Fwk.Logging.Targets.TargetType.Database, ev, null, "logs");
        }

        void Init()
        {
           try
            {
              
                //".\\Private$\\MyPrivateQueue";
                //@".\private$\TarifadorQueue";
                SysEventQueue.Path = SysEventSVC.Properties.Settings.Default.QueuePath;
                CreateQueue(SysEventQueue.Path);

            }
            catch (Exception ex)
            {
                ReceivedInfoProc.LogError(ex);

            }
        

            //Esto ya se establece en desing time

            MessageQueueProcessTimer = new System.Timers.Timer();
            MessageQueueProcessTimer.Interval = 15000;
            MessageQueueProcessTimer.Elapsed += new System.Timers.ElapsedEventHandler(MessageQueueProcessTimer_Elapsed);

   

        }
        void MessageQueueProcessTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

            if (ReceivedInfoProc.PingToSQL())
            {
                MessageQueueProcessTimer.Stop();
                m_DeamonEnabled = true;
                StartResiveMessage();
            }
        }

        /// <summary>
        /// Obtiene todos los msg de MSMQ
        /// </summary>
        /// <returns></returns>
        //public ReceivedInfoList GetAllMessageFromMSMQ_NoRemoveMessages()
        //{
        //    ReceivedInfoList wReceivedInfoList = new ReceivedInfoList();
        //    int id = 1;


        //    Message[] wMessageCollection = this.SysEventQueue.GetAllMessages();
        //    foreach (Message msg in wMessageCollection)
        //    {
        //        // Display the label of each message.

        //        ReceivedInfoBE wReceivedInfoBE = new ReceivedInfoBE();
        //        wReceivedInfoBE.id = id++;
        //        wReceivedInfoBE.timeDayHours = msg.Label;
        //        wReceivedInfoList.Add(wReceivedInfoBE);
        //    }




        //    return wReceivedInfoList;
        //}


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
