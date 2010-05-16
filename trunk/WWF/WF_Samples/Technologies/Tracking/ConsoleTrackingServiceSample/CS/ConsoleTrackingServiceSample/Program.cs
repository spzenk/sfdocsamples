//---------------------------------------------------------------------
//  This file is part of the Windows Workflow Foundation SDK Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------

using System;
using System.Threading;
using System.Workflow.Runtime;

namespace Microsoft.Samples.Workflow.ConsoleTrackingServiceSample
{
    class Program
    {
        static AutoResetEvent waitHandle = new AutoResetEvent(false);

        static void Main()
        {
            // Create WorkflowRuntime
            using (WorkflowRuntime workflowRuntime = new WorkflowRuntime())
            {
                // Add ConsoleTrackingService
                workflowRuntime.AddService(new ConsoleTrackingService());

                // Subscribe to workflow events
                workflowRuntime.WorkflowCompleted += OnWorkflowCompleted;
                workflowRuntime.WorkflowTerminated += OnWorkflowTerminated;

                // Start WorkflowRuntime
                workflowRuntime.StartRuntime();

                // Execute the SampleWorkflow Workflow
                Console.WriteLine("Executing the workflow...");
                workflowRuntime.CreateWorkflow(typeof(SampleWorkflow)).Start();

                // Wait for the Workflow Completion
                waitHandle.WaitOne();

                // Stop Runtime
                workflowRuntime.StopRuntime();
            }
        }

        static void OnWorkflowCompleted(object sender, WorkflowCompletedEventArgs e)
        {
            waitHandle.Set();
        }

        static void OnWorkflowTerminated(object sender, WorkflowTerminatedEventArgs e)
        {
            Console.WriteLine(e.Exception.Message);
            waitHandle.Set();
        }
    }
}
