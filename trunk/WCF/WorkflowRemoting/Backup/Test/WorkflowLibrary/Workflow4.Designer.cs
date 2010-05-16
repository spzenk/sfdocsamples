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
	partial class Workflow4
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
            System.Workflow.ComponentModel.ActivityBind activitybind4 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding4 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind5 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding5 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            this.Adapter2 = new RKiss.ActivityLibrary.AdapterActivity();
            this.Return = new RKiss.ActivityLibrary.ReturnActivity();
            this.transactionScopeActivity1 = new System.Workflow.ComponentModel.TransactionScopeActivity();
            this.Adapter = new RKiss.ActivityLibrary.AdapterActivity();
            this.Connector = new RKiss.ActivityLibrary.ConnectorActivity();
            // 
            // Adapter2
            // 
            this.Adapter2.MethodName = "Fire";
            this.Adapter2.Name = "Adapter2";
            activitybind1.Name = "Workflow4";
            activitybind1.Path = "Connector_msg1";
            workflowparameterbinding1.ParameterName = "msg";
            workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.Adapter2.Parameters.Add(workflowparameterbinding1);
            this.Adapter2.Type = typeof(InterfaceContract.IFireTest);
            this.Adapter2.Uri = "@asyncWorkflow";
            // 
            // Return
            // 
            this.Return.ConnectorActivityName = "Connector";
            this.Return.Name = "Return";
            activitybind2.Name = "Workflow4";
            activitybind2.Path = "Return__ReturnValue_1";
            workflowparameterbinding2.ParameterName = "(ReturnValue)";
            workflowparameterbinding2.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.Return.Parameters.Add(workflowparameterbinding2);
            // 
            // transactionScopeActivity1
            // 
            this.transactionScopeActivity1.Activities.Add(this.Adapter2);
            this.transactionScopeActivity1.Name = "transactionScopeActivity1";
            this.transactionScopeActivity1.TransactionOptions.IsolationLevel = System.Transactions.IsolationLevel.Serializable;
            // 
            // Adapter
            // 
            this.Adapter.MethodName = "SayHello";
            this.Adapter.Name = "Adapter";
            activitybind3.Name = "Workflow4";
            activitybind3.Path = "Connector_msg1";
            workflowparameterbinding3.ParameterName = "msg";
            workflowparameterbinding3.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            activitybind4.Name = "Workflow4";
            activitybind4.Path = "Return__ReturnValue_1";
            workflowparameterbinding4.ParameterName = "(ReturnValue)";
            workflowparameterbinding4.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            this.Adapter.Parameters.Add(workflowparameterbinding3);
            this.Adapter.Parameters.Add(workflowparameterbinding4);
            this.Adapter.Type = typeof(InterfaceContract.ITest);
            this.Adapter.Uri = "wf://localhost/MyWorkflow5";
            // 
            // Connector
            // 
            this.Connector.MethodName = "SayHello";
            this.Connector.Name = "Connector";
            activitybind5.Name = "Workflow4";
            activitybind5.Path = "Connector_msg1";
            workflowparameterbinding5.ParameterName = "msg";
            workflowparameterbinding5.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind5)));
            this.Connector.Parameters.Add(workflowparameterbinding5);
            this.Connector.Type = typeof(InterfaceContract.ITest);
            this.Connector.Received += new System.EventHandler(this.Connector_Received);
            // 
            // Workflow4
            // 
            this.Activities.Add(this.Connector);
            this.Activities.Add(this.Adapter);
            this.Activities.Add(this.transactionScopeActivity1);
            this.Activities.Add(this.Return);
            this.Name = "Workflow4";
            this.CanModifyActivities = false;

		}

		#endregion

        private RKiss.ActivityLibrary.AdapterActivity Adapter2;
        private TransactionScopeActivity transactionScopeActivity1;
        private RKiss.ActivityLibrary.AdapterActivity Adapter;
        private RKiss.ActivityLibrary.ReturnActivity Return;
        private RKiss.ActivityLibrary.ConnectorActivity Connector;
















    }
}
