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
using System.Workflow.Activities;

namespace Microsoft.Samples.Workflow.DynamicUpdateFromWorkflow
{
    public partial class ApprovalStepWorkflow : SequentialWorkflowActivity
    {

        public ApprovalStepWorkflow()
        {
            this.InitializeComponent();
        }

        private void OnPOApproved(object sender, EventArgs e)
        {
            Console.WriteLine("  PO Approved");
        }
    }
}