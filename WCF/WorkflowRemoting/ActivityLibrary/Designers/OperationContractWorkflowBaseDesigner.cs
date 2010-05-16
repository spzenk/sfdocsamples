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
using System.Diagnostics;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
#endregion

namespace RKiss.ActivityLibrary
{
   #region OperationContractWorkflowDesigner
    public class OperationContractWorkflowDesigner : SequentialWorkflowRootDesigner
    {
        protected override SequentialWorkflowHeaderFooter Header
        {
            get
            {
                base.Header.Text = "OperactionContract Workflow";
                return base.Header;
            }
        }

        protected override void OnActivityChanged(ActivityChangedEventArgs e)
        {
            Trace.WriteLine("ConnectorActivity - OnActivityChanged");

            base.OnActivityChanged(e);
            if (e.Member != null)
            {
                if (e.Member.Name == "Type")
                {
                    if (base.Activity.Site != null)
                    {
                        Activity activity = e.Activity;
                        PropertyDescriptor descriptor = TypeDescriptor.GetProperties(base.Activity)["MethodName"];
                        if (descriptor != null)
                        {
                            descriptor.SetValue(base.Activity, string.Empty);
                        }
                    }
                }
                else if (e.Member.Name == "MethodName")
                {
                    OperationContractWorkflowBase activity = e.Activity as OperationContractWorkflowBase;
                    if (activity != null)
                    {
                        activity.Parameters.Clear();

                        //refresh corresponding ReturnActivity
                        if (activity.Parent == null)
                        {
                            foreach (Activity item in activity.Activities)
                            {
                                if ((item is ReturnActivity) && (((ReturnActivity)item).ConnectorActivityName == activity.QualifiedName))
                                {
                                    (item as ReturnActivity).ConnectorActivityName = string.Empty;
                                    (item as ReturnActivity).Parameters.Clear();
                                    TypeDescriptor.Refresh(item);
                                }
                            }
                        }
                    }
                }
                if ((e.Member.Name == "Type") || (e.Member.Name == "MethodName"))
                {
                    TypeDescriptor.Refresh(e.Activity);
                }
            }

        }

        protected override void PreFilterProperties(IDictionary properties)
        {
            base.PreFilterProperties(properties);
            OperationContractWorkflowBase activity = this.Activity as OperationContractWorkflowBase;
            if (activity != null && activity.Type != null && activity.MethodName != null)
            {
                MethodInfo mi = activity.Type.GetMethod(activity.MethodName);
                if (mi != null)
                {
                    //get the parameters and add them as properties
                    ParameterInfo[] pis = mi.GetParameters();
                    if (pis != null)
                    {
                        foreach (ParameterInfo pi in pis)
                        {
                            //add a new parameter
                            properties[pi.Name] = new ParameterBindingPropertyDescriptor<ConnectorActivity>(pi.Name, pi.ParameterType, new Attribute[] { new DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden), new BrowsableAttribute(true), new CategoryAttribute("Parameters"), new DescriptionAttribute(pi.ParameterType.FullName), new EditorAttribute(typeof(BindUITypeEditor), typeof(UITypeEditor)) });
                        }
                    }
                }
            }
        }
    }
    #endregion
}
