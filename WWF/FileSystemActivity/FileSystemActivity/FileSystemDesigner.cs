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
using System.Collections;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Drawing;

namespace FileSystemActivity
{
    /// <summary>
    /// Implements design-time services for the activity component.
    /// </summary>
    public sealed class FileSystemDesigner : ActivityDesigner
    {
        protected override void Initialize(Activity activity)
        {
            base.Initialize(activity);

            // Change the designer theme for this activity
            this.DesignerTheme.BackColorStart = Color.White;
            this.DesignerTheme.BackColorEnd = ColorTranslator.FromHtml("#F9CB5A");
            this.DesignerTheme.BackgroundStyle = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.DesignerTheme.BorderColor = ColorTranslator.FromHtml("#BF8311");
            this.DesignerTheme.ForeColor = Color.Black;
        }

        /// <summary>
        /// Overridden to remove properties at design-time.
        /// </summary>
        /// <param name="properties"></param>
        protected override void PreFilterProperties(IDictionary properties)
        {
            base.PreFilterProperties(properties);
            if (this.Activity != null && this.Activity is FileSystem)
            {
                CommandType command = ((FileSystem)this.Activity).Command;
                if (command != CommandType.CopyFile && command != CommandType.MoveFile && command != CommandType.MoveDirectory)
                    properties.Remove("Destination");
                if (command != CommandType.DeleteDirectory && command != CommandType.FindFiles)
                    properties.Remove("Recursive");
                if (command != CommandType.CopyFile && command != CommandType.MoveFile && command != CommandType.MoveDirectory)
                    properties.Remove("Overwrite");
                if (command != CommandType.OpenFile && command != CommandType.CloseFile)
                    properties.Remove("FileStream");
                if (command != CommandType.OpenTextFile && command != CommandType.CloseFile)
                    properties.Remove("StreamReader");
                if (command == CommandType.CloseFile)
                {
                    properties.Remove("Source");

                    //jamescon:
                    //Bind bind = ((FileSystem)this.Activity).GetBinding(FileSystem.StreamReaderProperty);
                    ActivityBind bind = ((FileSystem)this.Activity).GetBinding(FileSystem.StreamReaderProperty);
                    if (bind != null && bind.UserData.Count > 0)
                        properties.Remove("FileStream");
                    else
                    {
                        bind = ((FileSystem)this.Activity).GetBinding(FileSystem.FileStreamProperty);
                        if (bind != null && bind.UserData.Count > 0)
                            properties.Remove("StreamReader");
                    }
                }
                if (command != CommandType.OpenFile)
                {
                    properties.Remove("FileMode");
                    properties.Remove("FileAccess");
                }
                if (command != CommandType.FindFiles)
                {
                    properties.Remove("SearchPattern");
                    properties.Remove("FileList");
                }
            }
        }

        /// <summary>
        /// Overridden to refresh properties list.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnActivityChanged(ActivityChangedEventArgs e)
        {
            base.OnActivityChanged(e);
            if (e.Member != null)
            {
                if (e.Member.Name == "Command")
                    TypeDescriptor.Refresh(e.Activity);
            }
        }
    }
}
