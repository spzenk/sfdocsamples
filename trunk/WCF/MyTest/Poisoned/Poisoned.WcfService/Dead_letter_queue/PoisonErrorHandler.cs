using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.ServiceModel;
using System.Threading;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;

namespace Poisoned.WcfService
{
    public class PoisonErrorHandler : IErrorHandler
    {
        static WaitCallback orderProcessingCallback = new WaitCallback(SystemEvent.StartThreadProc);

        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            // no-op -we are not interested in this.
        }

        // Handle poison message exception by moving the offending message out of the way for regular processing to go on.
        public bool HandleError(Exception error)
        {
            MsmqPoisonMessageException poisonException = error as MsmqPoisonMessageException;
            if (null != poisonException)
            {
                long lookupId = poisonException.MessageLookupId;
                Console.WriteLine(" Poisoned message -message look up id = {0}", lookupId);

                // Get MSMQ queue name from app settings in configuration.

                System.Messaging.MessageQueue orderQueue = new System.Messaging.MessageQueue(SystemEvent.QueueName);
                System.Messaging.MessageQueue poisonMessageQueue = new System.Messaging.MessageQueue(SystemEvent.PoisonQueueName);
                System.Messaging.Message message = null;

                // Use a new transaction scope to remove the message from the main application queue and add it to the poison queue.
                // The poison message service processes messages from the poison queue.
                using (TransactionScope txScope = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    int retryCount = 0;
                    while (retryCount < 3)
                    {
                        retryCount++;

                        try
                        {
                            // Look up the poison message using the look up id.
                            message = orderQueue.ReceiveByLookupId(lookupId);
                            if (message != null)
                            {
                                // Send the message to the poison message queue.
                                poisonMessageQueue.Send(message, System.Messaging.MessageQueueTransactionType.Automatic);

                                // complete transaction scope
                                txScope.Complete();

                                Console.WriteLine("Moved poisoned message with look up id: {0} to poison queue: {1} ", lookupId, SystemEvent.PoisonQueueName);
                                break;
                            }

                        }
                        catch (InvalidOperationException)
                        {
                            //Code for the case when the message may still not be available in the queue because of a race condition in transaction or 
                            //another node in the farm may actually have taken the message.
                            if (retryCount < 3)
                            {
                                Console.WriteLine("Trying to move poison message but message is not available, sleeping for 10 seconds before retrying");
                                Thread.Sleep(TimeSpan.FromSeconds(10));
                            }
                            else
                            {
                                Console.WriteLine("Giving up on trying to move the message");
                            }
                        }

                    }
                }

                // Restart the service host.
                Console.WriteLine();
                Console.WriteLine("Restarting the service to process rest of the messages in the queue");
                Console.WriteLine("Press <ENTER> to stop the service");
                ThreadPool.QueueUserWorkItem(orderProcessingCallback);
                return true;
            }

            return false;
        }
    }

}
