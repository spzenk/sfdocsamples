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
using System.Collections.Specialized;
using System.Drawing;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using System.Workflow.Runtime.Hosting;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Globalization;
using System.Drawing.Drawing2D;
#endregion

namespace RKiss.ActivityLibrary
{
    #region ConnectorDesignerTheme
    public sealed class ConnectorDesignerTheme : ActivityDesignerTheme
    {
        public ConnectorDesignerTheme(WorkflowTheme theme)
            : base(theme)
        {
            this.ForeColor = Color.FromArgb(0xff, 0, 0, 0);
            this.BorderColor = Color.FromArgb(0xff, 0x94, 0xb6, 0xf7);
            this.BorderStyle = DashStyle.Solid;
            this.BackColorStart = Color.FromArgb(0xff, 0xff, 0xff, 0xdf);
            this.BackColorEnd = Color.FromArgb(0xff, 0xa5, 0xc3, 0xf7);
            this.BackgroundStyle = LinearGradientMode.Horizontal;
        }
    }
    #endregion

    #region ConnectorActivityDesigner
    [ActivityDesignerTheme(typeof(ConnectorDesignerTheme))]
    public class ConnectorActivityDesigner : ActivityDesigner
    {
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
                    ConnectorActivity activity = e.Activity as ConnectorActivity;
                    if (activity != null)
                    {
                        activity.Parameters.Clear();

                        // refreshing corresponding ReturnActivity
                        if (activity.Parent != null)
                        {
                            foreach (Activity item in activity.Parent.Activities)
                            {
                                if ((item is ReturnActivity) && (((ReturnActivity)item).ConnectorActivityName == base.Activity.QualifiedName))
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
            ConnectorActivity activity = this.Activity as ConnectorActivity;
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
                            properties[pi.Name] = new ParameterBindingPropertyDescriptor<ConnectorActivity>(pi.Name, pi.ParameterType, new Attribute[] { new DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden), new BrowsableAttribute(true), new CategoryAttribute("Parameters"), new DescriptionAttribute(pi.ParameterType.FullName), new EditorAttribute(typeof(BindUITypeEditor), typeof(UITypeEditor))});
                        }
                    }
                }
            }
        }
    }
    #endregion
}

//#region InterfaceTypeBrowserEditor
//public class InterfaceTypeBrowserEditor2 : TypeBrowserEditor
//{
//    public override object EditValue(ITypeDescriptorContext typeDescriptorContext, IServiceProvider serviceProvider, object value)
//    {
//        return base.EditValue(typeDescriptorContext, serviceProvider, new InterfaceTypeFilterProvider2());
//    }
//}

//public class InterfaceTypeFilterProvider2 : ITypeFilterProvider
//{
//    public bool CanFilterType(Type type, bool throwOnError)
//    {
//        return type.IsInterface;
//    }

//    // Properties
//    public string FilterDescription
//    {
//        get { return "Browse and select Interface to reference:"; }
//    }
//}
//#endregion