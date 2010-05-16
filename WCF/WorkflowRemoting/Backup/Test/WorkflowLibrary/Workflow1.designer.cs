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

namespace WorkflowLibrary
{
	partial class Workflow1
	{
		#region Designer generated code
		
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
		private void InitializeComponent()
		{
            this.CanModifyActivities = true;
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding1 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding2 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind3 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding3 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            this.Return = new RKiss.ActivityLibrary.ReturnActivity();
            this.codeActivity2 = new System.Workflow.Activities.CodeActivity();
            this.Adapter = new RKiss.ActivityLibrary.AdapterActivity();
            this.codeActivity1 = new System.Workflow.Activities.CodeActivity();
            this.Connector = new RKiss.ActivityLibrary.ConnectorActivity();
            // 
            // Return
            // 
            this.Return.ConnectorActivityName = "Connector";
            this.Return.Name = "Return";
            this.Return.Invoking += new System.EventHandler(this.callExternalMethodActivity1_MethodInvoking);
            // 
            // codeActivity2
            // 
            this.codeActivity2.Name = "codeActivity2";
            this.codeActivity2.ExecuteCode += new System.EventHandler(this.codeActivity2_ExecuteCode);
            // 
            // Adapter
            // 
            this.Adapter.MethodName = "SayHello";
            this.Adapter.Name = "Adapter";
            activitybind1.Name = "Workflow1";
            activitybind1.Path = "connectorActivity1_msg1";
            workflowparameterbinding1.ParameterName = "msg";
            workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            activitybind2.Name = "Workflow1";
            activitybind2.Path = "adapterActivity1__ReturnValue_1";
            workflowparameterbinding2.ParameterName = "(ReturnValue)";
            workflowparameterbinding2.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.Adapter.Parameters.Add(workflowparameterbinding1);
            this.Adapter.Parameters.Add(workflowparameterbinding2);
            this.Adapter.Type = typeof(InterfaceContract.ITest);
            this.Adapter.Uri = "wcf://myWorkflow2";
            // 
            // codeActivity1
            // 
            this.codeActivity1.Name = "codeActivity1";
            this.codeActivity1.ExecuteCode += new System.EventHandler(this.codeActivity1_ExecuteCode);
            // 
            // Connector
            // 
            this.Connector.MethodName = "SayHello";
            this.Connector.Name = "Connector";
            activitybind3.Name = "Workflow1";
            activitybind3.Path = "connectorActivity1_msg1";
            workflowparameterbinding3.ParameterName = "msg";
            workflowparameterbinding3.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            this.Connector.Parameters.Add(workflowparameterbinding3);
            this.Connector.Type = typeof(InterfaceContract.ITest);
            // 
            // Workflow1
            // 
            this.Activities.Add(this.Connector);
            this.Activities.Add(this.codeActivity1);
            this.Activities.Add(this.Adapter);
            this.Activities.Add(this.codeActivity2);
            this.Activities.Add(this.Return);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

		}

		#endregion

        private RKiss.ActivityLibrary.ReturnActivity Return;
        private CodeActivity codeActivity2;
        private RKiss.ActivityLibrary.AdapterActivity Adapter;
        private CodeActivity codeActivity1;
        private RKiss.ActivityLibrary.ConnectorActivity Connector;










































































    }
}
