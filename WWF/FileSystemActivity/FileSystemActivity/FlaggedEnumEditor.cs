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
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Security.Permissions;

namespace FileSystemActivity
{
    /// <summary>
    /// Provides a user interface for representing and editing the values of the Enum type at design-time.
    /// </summary>
    public sealed class FlaggedEnumEditor : UITypeEditor
    {
        private IWindowsFormsEditorService editorService;

        [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
        public FlaggedEnumEditor()
        {
        }

        /// <summary>
        /// Edits the value of the specified object using the editor style indicated by GetEditStyle.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="provider"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (context != null && context.Instance != null && context.PropertyDescriptor != null && provider != null)
            {
                Type propertyType = context.PropertyDescriptor.PropertyType;
                if (propertyType.IsEnum)
                {
                    editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));   
                 
                    ListBox listBox = new ListBox();
                    listBox.BorderStyle = BorderStyle.None;
                    listBox.MouseClick += new MouseEventHandler(OnMouseClick);
                    foreach (string enumName in (string[])Enum.GetNames(propertyType))
                        listBox.Items.Add(enumName);

                    editorService.DropDownControl(listBox);
                    if (listBox.SelectedIndices.Count > 0)
                        value = Enum.ToObject(propertyType, Enum.Parse(propertyType, listBox.SelectedItem.ToString()));
                }
            }
            return value;
        }

        /// <summary>
        /// Closes the editor window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMouseClick(object sender, MouseEventArgs e)
        {
            if (editorService != null)
                editorService.CloseDropDown();
        }

        /// <summary>
        /// Gets the editor style used by the EditValue method.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            if (context != null && context.Instance != null)
            {
                return UITypeEditorEditStyle.DropDown;
            }
            return base.GetEditStyle(context);
        }
    }
}