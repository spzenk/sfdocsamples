using System;
using System.Data;
using System.Xml;
using System.Drawing;
using System.Collections;
using System.ComponentModel;


using System.Messaging;
using System.EnterpriseServices;

using System.Xml.Serialization;
using PelsoftComponent;

namespace MessageMoverClient
{
	/// <summary>
	/// Summary description for Helper.
	/// </summary>
	public class Helper
	{
		private  const string RUTA_COLA_ORIGEN = @".\private$\SourceQueue";
		private  const string RUTA_COLA_DESTINO = @".\private$\DestinationQueue";


		public enum QUEUE_PATCHS{RUTA_COLA_ORIGEN = 1,RUTA_COLA_DESTINO=2};

		public  Employee  DeserializeEmpleado(string XmlData)
		{
			System.Text.UTF8Encoding wEncoder = new System.Text.UTF8Encoding();
			try
			{
				XmlSerializer serializer = new XmlSerializer(typeof(Employee));

				System.IO.MemoryStream mStream = new System.IO.MemoryStream(wEncoder.GetBytes(XmlData));
				Employee Emp = (Employee)serializer.Deserialize(mStream);
				return Emp;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public  string SerealizeToXML(object pObject)
		{
			XmlSerializer wXmlSerialized = new XmlSerializer (pObject.GetType());
			XmlDocument xmlDoc = new XmlDocument ();
			System.IO.MemoryStream mStream = new System.IO.MemoryStream();
			try
			{
				wXmlSerialized.Serialize(mStream,pObject);
				
				mStream.Position =0;
				xmlDoc.Load(mStream);
				return xmlDoc.OuterXml;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		public  DataSet SerealizeToDataSet(object pObject)
		{
			XmlSerializer wXmlSerialized = new XmlSerializer (pObject.GetType());
			System.IO.MemoryStream mStream = new System.IO.MemoryStream();
			try
			{
				wXmlSerialized.Serialize(mStream,pObject);
				
				mStream.Position =0;
			
				DataSet wDts = new DataSet();
				wDts.ReadXml(mStream);
				return wDts;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		private System.IO.MemoryStream  SerealizeToStream(object pObject)
		{
			XmlSerializer wXmlSerialized = new XmlSerializer (pObject.GetType());
			XmlDocument xmlDoc = new XmlDocument ();

			System.IO.MemoryStream mStream = new System.IO.MemoryStream();

			try
			{
				wXmlSerialized.Serialize(mStream,pObject);
				
				mStream.Position =0;
			
				return mStream;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		private void CreateIfNotExitQueue()
		{
			try
			{
				if (System.Messaging.MessageQueue.Exists(RUTA_COLA_ORIGEN)) 
				{
					System.Messaging.MessageQueue queue = new System.Messaging.MessageQueue(RUTA_COLA_ORIGEN);
					if (!queue.Transactional) 
					{
						System.Messaging.MessageQueue.Delete(RUTA_COLA_ORIGEN);
						System.Messaging.MessageQueue.Create(RUTA_COLA_ORIGEN, true);
					}
				}
				else 
				{
					System.Messaging.MessageQueue.Create(RUTA_COLA_ORIGEN, true);
				}

				if (System.Messaging.MessageQueue.Exists(RUTA_COLA_DESTINO)) 
				{
					System.Messaging.MessageQueue queue = new System.Messaging.MessageQueue(RUTA_COLA_DESTINO);
					if (!queue.Transactional) 
					{
						System.Messaging.MessageQueue.Delete(RUTA_COLA_DESTINO);
						System.Messaging.MessageQueue.Create(RUTA_COLA_DESTINO, true);
					}
				}
				else 
				{
					System.Messaging.MessageQueue.Create(RUTA_COLA_DESTINO, true);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}



		#region --[Metodos con las colas]--
		public void MoveOrigenToDestino()
		{
			try
			{
				PelsoftComponent.MessageMover mover = new PelsoftComponent.MessageMover();

				mover.Source = new System.Messaging.MessageQueue(RUTA_COLA_ORIGEN);
				mover.Destination = new System.Messaging.MessageQueue(RUTA_COLA_DESTINO);
				
				mover.MoveSourceToDestination();

			}
			catch(Exception ex)
			{
				throw ex;
			}
		}		
		public string ExtractFromQueue(QUEUE_PATCHS pQueuePatch)
		{
			try
			{
				PelsoftComponent.MessageMover mover = new PelsoftComponent.MessageMover();
				string strReturn="";

				if (pQueuePatch == QUEUE_PATCHS.RUTA_COLA_ORIGEN)
				{
					strReturn = mover.GetElementFromSource(RUTA_COLA_ORIGEN);
				}
				else
				{
					strReturn = mover.GetElementFromDestination(RUTA_COLA_DESTINO);
				}
			
				return strReturn ;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public void InsertIntoQueue(QUEUE_PATCHS pQueuePatch,string pMessage)
		{
			try
			{
				PelsoftComponent.MessageMover mover = new PelsoftComponent.MessageMover();
				if (pQueuePatch == QUEUE_PATCHS.RUTA_COLA_ORIGEN)
				{
					 mover.InsertElementIntoSourceQueue(RUTA_COLA_ORIGEN,pMessage);
				}
				else
				{
					mover.InsertElementIntoDestinationQueue(RUTA_COLA_DESTINO,pMessage);
				}
			
				
			}
			catch(Exception ex)
			{
				throw ex;
			}

		}
		public int GetQueeuElementsCount(QUEUE_PATCHS pQueuePatch)
		{
			int wCount =0;
			PelsoftComponent.MessageMover mover = new PelsoftComponent.MessageMover();
			if (pQueuePatch == QUEUE_PATCHS.RUTA_COLA_ORIGEN)
			{
				wCount = mover.GetQueeuElementsCount(RUTA_COLA_ORIGEN);
			}
			else
			{
				wCount = mover.GetQueeuElementsCount(RUTA_COLA_DESTINO);
			}

			return wCount;
		}
		#endregion
	}

	


}
