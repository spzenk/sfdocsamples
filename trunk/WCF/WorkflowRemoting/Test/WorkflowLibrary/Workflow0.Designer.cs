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
	partial class Workflow0
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
            this.Return = new RKiss.ActivityLibrary.ReturnActivity();
            this.codeActivity1 = new System.Workflow.Activities.CodeActivity();
            this.Connector = new RKiss.ActivityLibrary.ConnectorActivity();
            // 
            // Return
            // 
            this.Return.ConnectorActivityName = "(None)";
            this.Return.Name = "Return";
            // 
            // codeActivity1
            // 
            this.codeActivity1.Name = "codeActivity1";
            this.codeActivity1.ExecuteCode += new System.EventHandler(this.codeActivity1_ExecuteCode);
            // 
            // Connector
            // 
            this.Connector.MethodName = "OneWay";
            this.Connector.Name = "Connector";
            activitybind1.Name = "Workflow0";
            activitybind1.Path = "Connector_msg1";
            workflowparameterbinding1.ParameterName = "msg";
            workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.Connector.Parameters.Add(workflowparameterbinding1);
            this.Connector.Type = typeof(InterfaceContract.ITest);
            // 
            // Workflow0
            // 
            this.Activities.Add(this.Connector);
            this.Activities.Add(this.codeActivity1);
            this.Activities.Add(this.Return);
            this.Name = "Workflow0";
            this.CanModifyActivities = false;

		}

		#endregion

        private RKiss.ActivityLibrary.ReturnActivity Return;
        private CodeActivity codeActivity1;
        private RKiss.ActivityLibrary.ConnectorActivity Connector;






    }
}
