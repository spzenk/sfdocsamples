using System;
using System.Messaging;
using System.EnterpriseServices;
namespace PelsoftComponent
{
	[System.EnterpriseServices.TransactionAttribute( System.EnterpriseServices.TransactionOption.Required)]
	public class MessageMover : System.EnterpriseServices.ServicedComponent
	{
		#region --[Private Members]--
		private System.Messaging.MessageQueue sourceQueue;
		private System.Messaging.MessageQueue destinationQueue;
		#endregion

		#region --[Constructors]--
		public MessageMover()
		{
		}
		#endregion

		#region --[Public Properties]--
		public System.Messaging.MessageQueue Source 
		{
			get 
			{
				return sourceQueue;
			}
			set
			{
				sourceQueue = value;
			}
		}
		public System.Messaging.MessageQueue Destination
		{
			get 
			{
				return destinationQueue;
			}
			set
			{
				destinationQueue = value;
			}
		}


		#endregion


		#region [Gets Methods]
		[System.EnterpriseServices.AutoComplete()]
		public string GetElementFromDestination(string pQueuePach)
		{
			System.Messaging.Message sourceMessage;
			string str="";
			try
			{
				destinationQueue = new System.Messaging.MessageQueue(pQueuePach);
				((XmlMessageFormatter)destinationQueue.Formatter).TargetTypeNames = new string[]{"System.String"};
				if(destinationQueue.GetAllMessages ().Length >0)
				{
					sourceMessage = destinationQueue.Receive(System.Messaging.MessageQueueTransactionType.Automatic);
				
					//	destinationQueue.Formatter = new XmlMessageFormatter(new Type[]	{typeof(String)});
					((XmlMessageFormatter)destinationQueue.Formatter).TargetTypeNames = new string[]{"Empleado"};


					str = (string)sourceMessage.Body;
				}
			
				return str;
			}
			catch(MessageQueueException e)
			{
				throw e;
			}
					
		}

		[System.EnterpriseServices.AutoComplete()]
		public string GetElementFromSource(string pQueuePach)
		{
			System.Messaging.Message sourceMessage;
			string str="";
			
			try
			{
				sourceQueue = new System.Messaging.MessageQueue(pQueuePach);
				((XmlMessageFormatter)sourceQueue.Formatter).TargetTypeNames = new string[]{"System.String"};
				if(sourceQueue.GetAllMessages ().Length >0)
				{
					sourceMessage = sourceQueue.Receive(System.Messaging.MessageQueueTransactionType.Automatic);
					// Set the formatter.
					//	sourceQueue.Formatter = new XmlMessageFormatter(new Type[]	{typeof(String)});
					((XmlMessageFormatter)sourceQueue.Formatter).TargetTypeNames = new string[]{"Empleado"};

					str = (string)sourceMessage.Body;
				}
			
				return str;
			}
			catch(MessageQueueException e)
			{
				throw e;
			}
			catch(Exception e)
			{
				throw e;
			}
		}

		#endregion

		#region [Inserts Methods]
		[System.EnterpriseServices.AutoComplete()]
		public void InsertElementIntoDestinationQueue(string pQueuePach, string pElement)
		{
			try
			{
				Destination = new System.Messaging.MessageQueue(pQueuePach);
				Destination.Send(pElement, System.Messaging.MessageQueueTransactionType.Single);
			}
			catch(MessageQueueException e)
			{
				throw e;
			}
		}
		[System.EnterpriseServices.AutoComplete()]
		public void InsertElementIntoSourceQueue(string pQueuePach, string pElement)
		{
			try
			{
				Source = new System.Messaging.MessageQueue(pQueuePach);
				Source.Send(pElement, System.Messaging.MessageQueueTransactionType.Single);
				
			}
			catch(MessageQueueException e)
			{
				throw e;
			}
		}
		#endregion


		[System.EnterpriseServices.AutoComplete()]
		public void MoveSourceToDestination()
		{
			try
			{
				System.Messaging.Message sourceMessage;
				//Retira el primer elemento del la cola origen
				sourceMessage = sourceQueue.Receive(System.Messaging.MessageQueueTransactionType.Automatic);
				//Introduce el elemento anterior en el destino
				destinationQueue.Send(sourceMessage, System.Messaging.MessageQueueTransactionType.Automatic);
			}
			catch(MessageQueueException e)
			{
				throw e;
			}
		}

		public int GetQueeuElementsCount(string pQueuePach)
		{
			// Holds the count of Lowest priority messages.
			int numberItems = 0;

			// Connect to a queue.
			MessageQueue myQueue = new MessageQueue(pQueuePach);
    
			// Get a cursor into the messages in the queue.
			MessageEnumerator myEnumerator = myQueue.GetMessageEnumerator();

			// Specify that the messages's priority should be read.
			myQueue.MessageReadPropertyFilter.Priority = true;

			// Move to the next message and examine its priority.
			while(myEnumerator.MoveNext())
			{
				// Increase the count if priority is Lowest.
				if(myEnumerator.Current.Priority == MessagePriority.Lowest)
                    
					numberItems++;
			}

	
            
			return numberItems;
		}


	}

}
