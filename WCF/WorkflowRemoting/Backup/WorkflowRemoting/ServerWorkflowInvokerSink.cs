//*****************************************************************************
//    Description.....Custom Remoting for Workflow
//                                
//    Author..........Roman Kiss, rkiss@pathcom.com
//    Copyright © 2006 ATZ Consulting Inc. (see included license.rtf file)        
//                        
//    Date Created:    07/07/06
//
//    Date        Modified By     Description
//-----------------------------------------------------------------------------
//    07/07/06    Roman Kiss     Initial Revision
//*****************************************************************************
//
#region References
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Collections;
using System.Text;
using System.IO;
using System.Reflection;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Workflow.Runtime;
using System.Workflow.Activities;
#endregion


namespace RKiss.WorkflowRemoting
{
	#region classes
	/// <summary>Server Sink Provider class</summary>
	public class ServerWorkflowInvoker : IServerChannelSinkProvider
	{
		#region constants
		#endregion

		#region private members
		private string	_strChannelName = "Unknown";				    // channel name
		private string	_strProviderName = "WorkflowInvoker";			// name of the provider
		private string  _strProviderId = Guid.NewGuid().ToString();     // provider Id
        private int     _intTimeOutInSec = 60;                          // response timeout
        private string  _strDesc = "Server Workflow Invoker";		// description
		private IServerChannelSinkProvider _Next = null;				// next provider
		#endregion

		#region constructors
		/// <summary>Default constructor</summary>
		public ServerWorkflowInvoker()
		{
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="properties"></param>
		/// <param name="providerData"></param>
		public ServerWorkflowInvoker(IDictionary properties, ICollection providerData)
		{
			//from config file
			if(properties.Contains("name")) 
				_strProviderName = Convert.ToString(properties["name"]);
			if(properties.Contains("desc")) 
				_strDesc = Convert.ToString(properties["desc"]);
            if (properties.Contains("timeout"))
                _intTimeOutInSec = Convert.ToInt32(properties["timeout"]);
		}
		#endregion

	    #region properties
		/// <summary></summary>
		public string ProviderName	
		{	
			get { return _strProviderName; }
		}
		/// <summary></summary>
		public string ProviderId	
		{	
			get { return _strProviderId; }
		}
	    /// <summary></summary>
        public int TimeOut
        {
            get { return _intTimeOutInSec; }
        }
		#endregion

		#region IServerChannelSinkProvider
		/// <summary>
		/// 
		/// </summary>
		public string ChannelName		
		{ 
			get { return _strChannelName; } 
		}

		/// <summary>
		/// 
		/// </summary>
		public IServerChannelSinkProvider Next
		{
			get	{ return _Next;  }
			set { _Next = value; }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="channelData"></param>
		public void GetChannelData(IChannelDataStore channelData)	
		{	
			//nothing to do
		}
    
		//Create the Server Sink (actualy worker)
		/// <summary>
		/// 
		/// </summary>
		/// <param name="channel"></param>
		/// <returns></returns>
		public IServerChannelSink CreateSink(IChannelReceiver channel)
		{
			_strChannelName = channel.ChannelName;
			IServerChannelSink NextSink = null;
			IServerChannelSink Sink = null;

			try 
			{
				if(_Next != null) 
				{
					NextSink = _Next.CreateSink(channel);
				}
				
				//create sink
				Sink = new ServerWorkflowInvokerSink(this, NextSink);
			}
			catch(Exception ex) 
			{
				Trace.WriteLine(string.Format("{0}/{1}.CreateSink catch {2}",	_strChannelName, _strProviderName, ex.Message)); 
			}		
			return Sink;
		}
		#endregion
	}


	/// <summary>
	/// 
	/// </summary>
	public class ServerWorkflowInvokerSink : BaseChannelObjectWithProperties, IServerChannelSink
	{	
		#region constant
		
		#endregion

		#region private members
		private IServerChannelSink		_Next = null;
		private ServerWorkflowInvoker	_Provider = null;
		#endregion
    
		#region constructors
		/// <summary>
		/// 
		/// </summary>
		/// <param name="provider"></param>
		/// <param name="next"></param>
        public ServerWorkflowInvokerSink(IServerChannelSinkProvider provider, IServerChannelSink next) 
		{
            if (next.NextChannelSink != null)
                throw new RemotingException("The ServerWorkflowInvokerSink must be last provider in the channel.");

			_Next = next;
            _Provider = provider as ServerWorkflowInvoker;

            Trace.WriteLine(string.Format("{0}:ServerWorkflowInvokerSink has been constructed", _Provider.ProviderName));
		}
		#endregion

	    #region IServerChannelSink
		/// <summary>
		/// 
		/// </summary>
		public IServerChannelSink NextChannelSink 
		{
			get { return _Next;	}
			set { _Next = value; }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sinkStack"></param>
		/// <param name="state"></param>
		/// <param name="msg"></param>
		/// <param name="headers"></param>
		/// <param name="stream"></param>
		public void AsyncProcessResponse(IServerResponseChannelSinkStack sinkStack, 
			object state, 
			IMessage msg , 
			ITransportHeaders headers , 
			Stream stream) 
		{
			Trace.WriteLine(string.Format("{0}:PubServerSink AsyncProcessResponse", _Provider.ProviderName));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sinkStack"></param>
		/// <param name="state"></param>
		/// <param name="msg"></param>
		/// <param name="headers"></param>
		/// <returns></returns>
		public Stream GetResponseStream(IServerResponseChannelSinkStack sinkStack, 
			object state, 
			IMessage msg , 
			ITransportHeaders headers) 
		{
			return null;
		}

		/// <summary>
		/// 
		/// </summary>
		public ServerProcessing ProcessMessage(IServerChannelSinkStack sinkStack, IMessage requestMsg, ITransportHeaders requestHeaders, Stream requestStream, 
			out IMessage responseMsg, out ITransportHeaders responseHeaders, out Stream responseStream)
		{
			// scope state
			ServerProcessing servproc = ServerProcessing.Complete;
			responseMsg = null;
            responseHeaders = null;
            responseStream = new MemoryStream();
            IMethodCallMessage mcm = null;
            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                //Are we in the business?
                if (_Next != null)
                {
                    if (requestMsg == null && requestStream != null)
                    {
                        // we are supporting only binary formatter
                        requestMsg = (IMessage)bf.Deserialize(requestStream);
                        requestStream.Close();
                    }

                    mcm = requestMsg as IMethodCallMessage;
                    if (mcm == null)
                        throw new NullReferenceException("IMethodCallMessage after deserialization");

                    // LogicalCallContext
                    LCC.CopyFrom(mcm);
                    LogicalWorkflowContext lwc = LCC.LogicalWorkflowContext;
                    Guid workflowInstanceId = lwc.GetAndClearWorkflowId();
                    bool bGetWorkflowById = !workflowInstanceId.Equals(Guid.Empty);

                     // create workflow
                    Invoker invoker = null;
                    if (bGetWorkflowById)
                    {
                        invoker = WorkflowInvoker.Create(workflowInstanceId);
                    }
                    else
                    {
                        string endpoint = mcm.Uri;
                        if (string.IsNullOrEmpty(endpoint))
                        {
                            endpoint = requestHeaders["__RequestUri"] as string;
                        }
                        if (string.IsNullOrEmpty(endpoint))
                            throw new NullReferenceException("Internal error - missing endpoint");
                      
                        // create workflow instance
                        Type workflowType = RemotingServices.GetServerTypeForUri(endpoint.TrimStart('/'));
                        invoker = WorkflowInvoker.Create(workflowType, lwc.WorkflowInitData);
                    }

                    // send remoting message to the workflow
                    invoker.SendMessage(mcm);

                    // handle response
                    if (!RemotingServices.IsOneWay(mcm.MethodBase))
                    {
                        // wait for response
                        invoker.WaitForResponse(_Provider.TimeOut);
                        object response = invoker.GetResponse<object>();

                        // return message back to the caller (Note that this version is not allow to change a CallContext!!) 
                        responseMsg = (IMessage)new ReturnMessage(response, null, 0, null, mcm);
                    }
                }
                else
                {
                    throw new RemotingException("Internal error in the channel stack");
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                responseMsg = (IMessage)new ReturnMessage(ex, mcm);
            }
            finally
            {
                responseHeaders = requestHeaders;
                if (responseMsg != null)
                {
                    // serialize response to the wire transport
                    bf.Serialize(responseStream, responseMsg);
                    responseStream.Position = 0;
                }
            }
			return servproc;
		}
		#endregion
	}
	#endregion
}





