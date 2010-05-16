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
using System.Globalization;
using System.Diagnostics;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Design;
using System.Reflection;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using System.Workflow.Runtime.Hosting; 
#endregion


namespace RKiss.ActivityLibrary
{
    #region AdapterDesignerTheme
    public sealed class AdapterDesignerTheme : ActivityDesignerTheme
    {
        public AdapterDesignerTheme(WorkflowTheme theme)
            : base(theme)
        {
            //this.ForeColor = Color.FromArgb(0xff, 0, 0, 0);
            //this.BorderColor = Color.FromArgb(0xff, 0x73, 0x79, 0xa5);
            //this.BorderStyle = DashStyle.Solid;
            //this.BackColorStart = Color.FromArgb(0xff, 0xdf, 0xe8, 0xff);
            //this.BackColorEnd = Color.FromArgb(0xff, 0x95, 0xb3, 0xff);
            //this.BackgroundStyle = LinearGradientMode.Horizontal;

            this.ForeColor = Color.FromArgb(0xff, 0, 0, 0);
            this.BorderColor = Color.FromArgb(0xff, 0x94, 0xb6, 0xf7);
            this.BorderStyle = DashStyle.Solid;
            this.BackColorStart = Color.FromArgb(0xff, 0xff, 0xff, 0xff);
            this.BackColorEnd = Color.FromArgb(0xff, 0xa5, 0xc3, 0xf7);
            this.BackgroundStyle = LinearGradientMode.Horizontal;

        }
    }
    #endregion

    #region AdapterRemotingDesigner
    [ActivityDesignerTheme(typeof(AdapterDesignerTheme))]
    public class AdapterDesigner : ActivityDesigner
    {
        protected override void OnActivityChanged(ActivityChangedEventArgs e)
        {
            Trace.WriteLine("AdapterActivity - OnActivityChanged");

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
                    (e.Activity as AdapterActivity).Parameters.Clear();
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
            AdapterActivity activity = this.Activity as AdapterActivity;
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
                            properties[pi.Name] = new ParameterBindingPropertyDescriptor<AdapterActivity>(pi.Name, pi.ParameterType, new Attribute[] { new DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden), new BrowsableAttribute(true), new CategoryAttribute("Parameters"), new DescriptionAttribute(pi.ParameterType.FullName), new EditorAttribute(typeof(BindUITypeEditor), typeof(UITypeEditor)) });
                        }
                        if ((mi.ReturnType != typeof(void)))
                        {
                            properties["(ReturnValue)"] = new ParameterBindingPropertyDescriptor<AdapterActivity>("(ReturnValue)", mi.ReturnType, new Attribute[] { new DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden), new BrowsableAttribute(true), new CategoryAttribute("Parameters"), new DescriptionAttribute(mi.ReturnType.FullName), new EditorAttribute(typeof(BindUITypeEditor), typeof(UITypeEditor)) });
                        }
                    }
                }
            }
        }
    }
    #endregion
}
