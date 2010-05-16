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
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Globalization;
using System.Drawing.Drawing2D;
#endregion

namespace RKiss.ActivityLibrary
{

    #region ReturnActivityDesignerTheme
    public sealed class ReturnActivityDesignerTheme : ActivityDesignerTheme
    {
        public ReturnActivityDesignerTheme(WorkflowTheme theme)
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

    #region ReturnActivityDesigner
    [ActivityDesignerTheme(typeof(ReturnActivityDesignerTheme))]
    public class ReturnActivityDesigner : ActivityDesigner
    {
        protected override void OnActivityChanged(ActivityChangedEventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("ReturnActivity - OnActivityChanged");

            base.OnActivityChanged(e);
            base.OnActivityChanged(e);
            if ((e.Member != null) && (e.Member.Name == "ConnectorActivityName"))
            {
                (e.Activity as ReturnActivity).Parameters.Clear();
                TypeDescriptor.Refresh(e.Activity);
            }

        }
        protected override void PreFilterProperties(IDictionary properties)
        {
            System.Diagnostics.Trace.WriteLine("ReturnActivity - PreFilterProperties");

            base.PreFilterProperties(properties);
            if (((ITypeProvider)base.GetService(typeof(ITypeProvider))) == null)
            {
                throw new InvalidOperationException("Missing ITypeProvider Service");
            }
            ReturnActivity activity = base.Activity as ReturnActivity;
            activity.GetParameterPropertyDescriptors(properties);
        }
    }
    #endregion

    #region ConnectorActivityDropDownEditor
    public class ConnectorActivityDropDownEditor : UITypeEditor
    {
        IWindowsFormsEditorService _editorService = null;
        ITypeDescriptorContext _context = null;
        object _selectedObject = null;

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext typeDescriptorContext)
        {
            return UITypeEditorEditStyle.DropDown;
        }
        public override object EditValue(ITypeDescriptorContext typeDescriptorContext, IServiceProvider serviceProvider, object value)
        {
            System.Diagnostics.Trace.WriteLine("ReturnActivity - dropdown list ...");

            if (typeDescriptorContext == null)
                throw new ArgumentNullException("typeDescriptorContext");
            if (serviceProvider == null)
                throw new ArgumentNullException("serviceProvider");

            this._editorService = (IWindowsFormsEditorService)serviceProvider.GetService(typeof(IWindowsFormsEditorService));
            this._context = typeDescriptorContext;

            ReturnActivity activity = null;
            object[] instances = this._context.Instance as object[];
            if (instances != null && instances.Length > 0)
                activity = instances[0] as ReturnActivity;
            else
                activity = this._context.Instance as ReturnActivity;

            ListBox lb = this.CreateDropDownList(activity);
            lb.BorderStyle = BorderStyle.None;
            lb.SelectedIndexChanged += new EventHandler(this.dataSourceDropDown_SelectedIndexChanged);
            this._editorService.DropDownControl(lb);

            return (this._selectedObject != null && lb.SelectedIndex != -1) ? this._selectedObject : value;
        }
        private void dataSourceDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._editorService.CloseDropDown();
            this._selectedObject = null;
            ListBox lb = sender as ListBox;
            if (lb == null)
                throw new ArgumentNullException("sender");

            if (lb.SelectedIndex >= 0)
            {
                this._selectedObject = lb.Items[lb.SelectedIndex];
            }
        }
        private ListBox CreateDropDownList(Activity activity)
        {
            ListBox lb = new ListBox();
            try
            {
                if (activity != null && activity.Parent != null)
                {
                    // no return value
                    lb.Items.Add("(None)");

                    CompositeActivity rootActivity = Helpers.GetRootActivity(activity) as CompositeActivity;
                    if (rootActivity is OperationContractWorkflowBase)
                    {
                        lb.Items.Add(rootActivity.QualifiedName);
                    }

                    // list of possible returned value
                    List<Activity> list = new List<Activity>();
                    Helpers.GetAllEnabledActivities(rootActivity, list);
                    foreach (Activity item in list)
                    {
                        if (item.QualifiedName == activity.QualifiedName)
                        {
                            break;
                        }
                        if (item is ConnectorActivity)
                        {
                            lb.Items.Add(item.QualifiedName);
                        }
                    }
                }
                else
                {
                    Trace.WriteLine("ReturnActivity - dropdown list, no activity found");
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }
            return lb;
        }
    }
    #endregion
}
