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


        ServiceHost serviceHost;

        /// <summary>
        /// Comienza a leer la cola de manera asincrona
        /// </summary>
        public void StartResiveMessage()
        {
            try
            {

                CreateQueue(Poisoned.WcfService.Properties.Settings.Default.QueuePath);
                serviceHost = new ServiceHost(typeof(SystemEvent));
                serviceHost.Open();
            }
            catch (Exception ex)
            {
            
                ReceivedInfoProc.LogError(ex);
   
            }
        }
        public void StopResiveMessage()
        {
            serviceHost.Close();
        }

        public static void OnServiceFaulted(object sender, EventArgs e)
        {

            Event ev = new Event();
            ev.AppId = Poisoned.WcfService.Properties.Resource.Title;
            ev.LogType = EventType.Error;
            ev.Message.Text = Poisoned.WcfService.Properties.Resource.Title + " Faulted";
            ev.Source = Poisoned.WcfService.Properties.Resource.Title;

            StaticLogger.Log(Fwk.Logging.Targets.TargetType.Database, ev, null, "logs");
        }

        void Init()
        {
           try
            {
              
                //".\\Private$\\MyPrivateQueue";
                //@".\private$\TarifadorQueue";
//                SysEventQueue.Path = Poisoned.WcfService.Properties.Settings.Default.QueuePath;
                //CreateQueue(SysEventQueue.Path);

            }
            catch (Exception ex)
            {
                ReceivedInfoProc.LogError(ex);
          
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
