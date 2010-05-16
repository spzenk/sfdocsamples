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
using System.Threading;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Reflection;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Runtime.Hosting;
#endregion

namespace RKiss.WorkflowRemoting
{
	public sealed class WorkflowHosting
	{
        public const string WorkflowRuntimeName = "__WorkflowRuntime";

        private WorkflowHosting() {}

        /// <summary>
        /// Attach WorkfowRuntime with default services
        /// </summary>
        public static WorkflowRuntime Attach() 
        {
            return Attach(null, null);
        }
        /// <summary>
        /// 
        /// </summary>
        public static WorkflowRuntime Attach(string workflowRuntimeConfig)
        {
            return Attach(workflowRuntimeConfig, null);
        }

        /// <summary>
        /// Attach WorkfowRuntime with services based on the config file
        /// </summary>
        /// <param name="configSectionName"></param>
        public static WorkflowRuntime Attach(string workflowRuntimeConfig, string localServicesConfig) 
        {
            ExternalDataExchangeService dataExchangeService = null;

            WorkflowRuntime workflowRuntime = AppDomain.CurrentDomain.GetData(WorkflowRuntimeName) as WorkflowRuntime;
            if (workflowRuntime == null)
            {
                lock (AppDomain.CurrentDomain.FriendlyName)
                {
                    if (workflowRuntime == null)
                    {
                        if (workflowRuntimeConfig == null)
                        {
                            // default services 
                            workflowRuntime = new WorkflowRuntime();
                        }
                        else
                        {
                            // add services from config file
                            workflowRuntime = new WorkflowRuntime(workflowRuntimeConfig);
                        }

                        if (workflowRuntime == null)
                        {
                            throw new NullReferenceException("The WorkflowRuntime initializing failed");
                        }

                        // exchange data between the host and workflow
                        dataExchangeService = workflowRuntime.GetService<ExternalDataExchangeService>();
                        if (dataExchangeService == null)
                        {
                            if (localServicesConfig == null)
                            {
                                dataExchangeService = new ExternalDataExchangeService();
                            }
                            else
                            {
                                dataExchangeService = new ExternalDataExchangeService(localServicesConfig);
                            }

                            // add service for exchange data
                            workflowRuntime.AddService(dataExchangeService);
                        }

                        // generic local service based on the Request/Response exchange pattern
                        InvokerLocalService invokerLocalService = (InvokerLocalService)dataExchangeService.GetService(typeof(InvokerLocalService));
                        if (invokerLocalService == null)
                        {
                            invokerLocalService = new InvokerLocalService(workflowRuntime);
                            dataExchangeService.AddService(invokerLocalService);
                        }

                        // Start all services registered in this container
                        workflowRuntime.StartRuntime();

                        AppDomain.CurrentDomain.SetData(WorkflowRuntimeName, workflowRuntime);
                    }
                }
            }
            return workflowRuntime;
        }

        public static void Detach()
        {
            WorkflowRuntime workflowRuntime = AppDomain.CurrentDomain.GetData(WorkflowRuntimeName) as WorkflowRuntime;
            if (workflowRuntime != null)
            {
                lock (AppDomain.CurrentDomain.FriendlyName)
                {
                    if (workflowRuntime != null)
                    {
                        workflowRuntime.StopRuntime();
                    }
                }
            }
        }

        public static WorkflowRuntime WorkflowRuntime
        {
            get
            {
                WorkflowRuntime workflowRuntime = AppDomain.CurrentDomain.GetData(WorkflowRuntimeName) as WorkflowRuntime;
                if (workflowRuntime == null)
                {
                    throw new NullReferenceException("The WorkflowRuntime is not hosted in the appDomain");
                }

                return workflowRuntime;
            }
        }      
	}
}
