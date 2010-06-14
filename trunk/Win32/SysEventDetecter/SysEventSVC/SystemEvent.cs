﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Fwk.Exceptions;
using Fwk.Logging;

namespace SysEventSVC
{
    /// <summary>
    /// Este servicio procesa la cola de MSMQ por lotes
    /// Aqui van llegando lotes de mensages.-
    /// </summary>
    [ServiceBehavior(ReleaseServiceInstanceOnTransactionComplete = false,
       TransactionIsolationLevel = System.Transactions.IsolationLevel.Serializable,
       ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class SystemEvent : ISystemEvent
    {

        #region ISystemEvent Members
        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void SubmitMessage_Queue(byte[] message, DateTime time)
        {
            try
            {
                ReceivedInfoProc.Process(message, time);
            }
            catch (Exception ex)
            {
                if (Convert.ToBoolean( System.Configuration.ConfigurationManager.AppSettings["PerformLog"]))
                {
                    Event ev = new Event();
                    ev.AppId = "SystemEvent service";
                    ev.LogType = EventType.Error;
                    ev.Message.Text = ExceptionHelper.GetAllMessageException(ex);
                    ev.Source = "SystemEvent MSMQ deamon";
                    
                    StaticLogger.Log( Fwk.Logging.Targets.TargetType.WindowsEvent , ev,null,null);
                }
            }
        }

        #endregion
    }
}
