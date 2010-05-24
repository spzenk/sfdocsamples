//---------------------------------------------------------------------
//  This file is part of the WindowsWorkflow.NET web site samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
// 
//  THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
//---------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace WorkflowConsoleApplication1
{
	public sealed partial class Workflow2
	{
		#region Designer generated code
		
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.CanModifyActivities = true;
            this.forEach1 = new ForEachActivity.ForEach();
            this.cancellationHandlerActivity1 = new System.Workflow.ComponentModel.CancellationHandlerActivity();
            this.faultHandlersActivity1 = new System.Workflow.ComponentModel.FaultHandlersActivity();
            this.codeActivity2 = new System.Workflow.Activities.CodeActivity();
            // 
            // forEach1
            // 
            this.forEach1.Activities.Add(this.cancellationHandlerActivity1);
            this.forEach1.Activities.Add(this.faultHandlersActivity1);
            this.forEach1.Description = "A generic flow control activity that executes once for each item in a collection." +
                "";
            this.forEach1.Items = null;
            this.forEach1.Name = "forEach1";
            // 
            // cancellationHandlerActivity1
            // 
            this.cancellationHandlerActivity1.Name = "cancellationHandlerActivity1";
            // 
            // faultHandlersActivity1
            // 
            this.faultHandlersActivity1.Name = "faultHandlersActivity1";
            // 
            // codeActivity2
            // 
            this.codeActivity2.Name = "codeActivity2";
            // 
            // Workflow2
            // 
            this.Activities.Add(this.forEach1);
            this.Activities.Add(this.codeActivity2);
            this.Name = "Workflow2";
            this.CanModifyActivities = false;

		}

		#endregion

        private ForEachActivity.ForEach forEach1;
        private CancellationHandlerActivity cancellationHandlerActivity1;
        private CodeActivity codeActivity2;
        private FaultHandlersActivity faultHandlersActivity1;




    }
}
