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

namespace Microsoft.Samples.Workflow.Delay
{
    class Program
    {
        static AutoResetEvent waitHandle = new AutoResetEvent(false);

        static void Main()
        {
            // Start the workflow runtime engine.
            using (WorkflowRuntime workflowRuntime = new WorkflowRuntime())
            {
                workflowRuntime.StartRuntime();

                Console.WriteLine("Starting the workflow");

                // Listen for the workflow events
                workflowRuntime.WorkflowCompleted += OnWorkflowCompleted;
                workflowRuntime.WorkflowTerminated += OnWorkflowTerminated;

                // Start the workflow and wait for it to complete
                Type type = typeof(DelayWorkflow);
                workflowRuntime.CreateWorkflow(type).Start();

                waitHandle.WaitOne();

                // Stop the workflow runtime engine.
                workflowRuntime.StopRuntime();
            }
        }

        // This method will be called when a workflow instance is completed
        // waitHandle is set so the main thread can continue
        static void OnWorkflowCompleted(object sender, WorkflowCompletedEventArgs e)
        {
            waitHandle.Set();
        }

        // This method is called when the workflow terminates and does not complete
        // This should not occur in this sample; however, it is good practice to include a
        // handler for this event so the host application can manage workflows that are
        // unexpectedly terminated (e.g. unhandled workflow exception).
        // waitHandle is set so the main thread can continue
        static void OnWorkflowTerminated(object sender, WorkflowTerminatedEventArgs e)
        {
            Console.WriteLine(e.Exception.Message);
            waitHandle.Set();
        }
    }
}
