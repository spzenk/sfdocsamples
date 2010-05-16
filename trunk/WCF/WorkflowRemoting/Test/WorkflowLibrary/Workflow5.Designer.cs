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
	partial class Workflow5
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
            this.Return = new RKiss.ActivityLibrary.ReturnActivity();
            // 
            // Return
            // 
            this.Return.ConnectorActivityName = "Workflow5";
            this.Return.Name = "Return";
            activitybind1.Name = "Workflow5";
            activitybind1.Path = "Workflow5_msg1";
            workflowparameterbinding1.ParameterName = "(ReturnValue)";
            workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.Return.Parameters.Add(workflowparameterbinding1);
            // 
            // Workflow5
            // 
            this.Activities.Add(this.Return);
            this.MethodName = "SayHello";
            this.Name = "Workflow5";
            activitybind2.Name = "/Self";
            activitybind2.Path = "Workflow5_msg1";
            workflowparameterbinding2.ParameterName = "msg";
            workflowparameterbinding2.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.Parameters.Add(workflowparameterbinding2);
            this.Type = typeof(InterfaceContract.ITest);
            this.Received += new System.EventHandler(this.Workflow5_Received);
            this.CanModifyActivities = false;

		}

		#endregion

        private RKiss.ActivityLibrary.ReturnActivity Return;






    }
}
