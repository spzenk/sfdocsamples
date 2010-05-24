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
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Drawing.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using System.Collections.Generic;
using System.IO;

namespace FileSystemActivity
{
    public enum CommandType
    {
        CloseFile =         0,
        CopyFile =          1,
        CreateDirectory =   2,
        DecryptFile =       3,
        DeleteDirectory =   4,
        DeleteFile =        5,
        EncryptFile =       6,
        FindFiles =         7,
        MoveDirectory =     8,
        MoveFile =          9,
        OpenFile =          10,
        OpenTextFile =      11
    }

    /// <summary>
    /// The FileSystem Activity provides the ability to perform File system operations/commands.
    /// </summary>
    [ToolboxBitmap(typeof(FileSystem), "FileSystem.png")]
    [ActivityValidator(typeof(FileSystemActivity.FileSystemValidator))]
    [DesignerAttribute(typeof(FileSystemActivity.FileSystemDesigner))]
    public partial class FileSystem : Activity, IDisposable
    {
        public FileSystem()
		{
			InitializeComponent();
            this.Command = CommandType.OpenFile;
            this.Recursive = true;
            this.FileMode = FileMode.Open;
            this.FileAccess = FileAccess.Read;
		}

        /// <summary>
        /// Overridden to implement the activity execution logic.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        protected override ActivityExecutionStatus Execute(ActivityExecutionContext context)
        {
            // Raise the CommandExecuting event
            base.RaiseEvent(CommandExecutingEvent, this, EventArgs.Empty);

            switch (this.Command)
            {
                case CommandType.CloseFile:
                    IOHelper.CloseFile(this.FileStream);
                    IOHelper.CloseFile(this.StreamReader);
                    break;
                case CommandType.CopyFile:
                    IOHelper.CopyFile(this.Source, this.Destination, this.Overwrite);
                    break;
                case CommandType.CreateDirectory:
                    IOHelper.CreateDirectory(this.Source);
                    break;
                case CommandType.DecryptFile:
                    IOHelper.DecryptFile(this.Source);
                    break;
                case CommandType.DeleteFile:
                    IOHelper.DeleteFile(this.Source);
                    break;
                case CommandType.DeleteDirectory:
                    IOHelper.DeleteDirectory(this.Source, this.Recursive);
                    break;
                case CommandType.EncryptFile:
                    IOHelper.EncryptFile(this.Source);
                    break;
                case CommandType.FindFiles:
                    this.FileList = IOHelper.FindFiles(this.Source, this.SearchPattern, this.Recursive);
                    break;
                case CommandType.MoveDirectory:
                    IOHelper.MoveDirectory(this.Source, this.Destination);
                    break;
                case CommandType.MoveFile:
                    IOHelper.MoveFile(this.Source, this.Destination, this.Overwrite);
                    break;
                case CommandType.OpenFile:
                    this.FileStream = IOHelper.OpenFile(this.Source, this.FileMode, this.FileAccess);
                    break;
                case CommandType.OpenTextFile:
                    this.StreamReader = IOHelper.OpenTextFile(this.Source);
                    break;
            }

            // Raise the CommandExecuted event
            base.RaiseEvent(CommandExecutedEvent, this, EventArgs.Empty);

            return ActivityExecutionStatus.Closed;
        }

        #region IDisposable Members

        private bool disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    IOHelper.CloseFile(this.FileStream);
                    IOHelper.CloseFile(this.StreamReader);
                }
            }
            disposed = true;
        }

        #endregion

        public static DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(FileSystemActivity.CommandType), typeof(FileSystemActivity.FileSystem));

        [DefaultValueAttribute(typeof(CommandType), "OpenFile")]
        [CategoryAttribute("FileSystem")]
        [DescriptionAttribute("The File System Command.")]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [ValidationOptionAttribute(ValidationOption.Optional)]
        [BrowsableAttribute(true)]
        public FileSystemActivity.CommandType Command
        {
            get
            {
                return ((CommandType)(base.GetValue(FileSystemActivity.FileSystem.CommandProperty)));
            }
            set
            {
                base.SetValue(FileSystemActivity.FileSystem.CommandProperty, value);
            }
        }

        public static DependencyProperty DestinationProperty = DependencyProperty.Register("Destination", typeof(System.String), typeof(FileSystemActivity.FileSystem));

        [CategoryAttribute("FileSystem")]
        [DescriptionAttribute("The destination path.")]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [ValidationOptionAttribute(ValidationOption.Optional)]
        [BrowsableAttribute(true)]
        public string Destination
        {
            get
            {
                return ((String)(base.GetValue(FileSystemActivity.FileSystem.DestinationProperty)));
            }
            set
            {
                base.SetValue(FileSystemActivity.FileSystem.DestinationProperty, value);
            }
        }

        public static DependencyProperty FileAccessProperty = DependencyProperty.Register("FileAccess", typeof(System.IO.FileAccess), typeof(FileSystemActivity.FileSystem));

        [Editor(typeof(FlaggedEnumEditor), typeof(UITypeEditor))]
        [DefaultValueAttribute(typeof(FileAccess), "Read")]
        [DescriptionAttribute("The operations that can be performed on the file.")]
        [CategoryAttribute("FileSystem")]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [ValidationOptionAttribute(ValidationOption.Optional)]
        [BrowsableAttribute(true)]
        public System.IO.FileAccess FileAccess
        {
            get
            {
                return ((FileAccess)(base.GetValue(FileSystemActivity.FileSystem.FileAccessProperty)));
            }
            set
            {
                base.SetValue(FileSystemActivity.FileSystem.FileAccessProperty, value);
            }
        }

        public static DependencyProperty FileListProperty = DependencyProperty.Register("FileList", typeof(System.IO.FileInfo[]), typeof(FileSystemActivity.FileSystem));

        [ReadOnlyAttribute(true)]
        [CategoryAttribute("FileSystem")]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [ValidationOptionAttribute(ValidationOption.Optional)]
        [BrowsableAttribute(false)]
        [DescriptionAttribute("Returns the file list matching the given search pattern.")]
        public System.IO.FileInfo[] FileList
        {
            get
            {
                return ((FileInfo[])(base.GetValue(FileSystemActivity.FileSystem.FileListProperty)));
            }
            private set
            {
                base.SetValue(FileSystemActivity.FileSystem.FileListProperty, value);
            }
        }

        public static DependencyProperty FileModeProperty = DependencyProperty.Register("FileMode", typeof(System.IO.FileMode), typeof(FileSystemActivity.FileSystem));

        [DefaultValueAttribute(typeof(FileMode), "Open")]
        [DescriptionAttribute("Specifies how the operating system should open a file.")]
        [CategoryAttribute("FileSystem")]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [ValidationOptionAttribute(ValidationOption.Optional)]
        [BrowsableAttribute(true)]
        public System.IO.FileMode FileMode
        {
            get
            {
                return ((FileMode)(base.GetValue(FileSystemActivity.FileSystem.FileModeProperty)));
            }
            set
            {
                base.SetValue(FileSystemActivity.FileSystem.FileModeProperty, value);
            }
        }

        public static DependencyProperty FileStreamProperty = DependencyProperty.Register("FileStream", typeof(System.IO.FileStream), typeof(FileSystemActivity.FileSystem));

        [ReadOnlyAttribute(true)]
        [DescriptionAttribute("The FileStream opened in the specified mode and source.")]
        [CategoryAttribute("FileSystem")]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [ValidationOptionAttribute(ValidationOption.Optional)]
        [BrowsableAttribute(true)]
        public System.IO.FileStream FileStream
        {
            get
            {
                return ((FileStream)(base.GetValue(FileSystemActivity.FileSystem.FileStreamProperty)));
            }
            set
            {
                base.SetValue(FileSystemActivity.FileSystem.FileStreamProperty, value);
            }
        }

        public static DependencyProperty OverwriteProperty = DependencyProperty.Register("Overwrite", typeof(System.Boolean), typeof(FileSystemActivity.FileSystem));

        [DefaultValueAttribute(false)]
        [CategoryAttribute("FileSystem")]
        [DescriptionAttribute("Specifies whether the destination can be overwritten.")]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [ValidationOptionAttribute(ValidationOption.Optional)]
        [BrowsableAttribute(true)]
        public bool Overwrite
        {
            get
            {
                return ((Boolean)(base.GetValue(FileSystemActivity.FileSystem.OverwriteProperty)));
            }
            set
            {
                base.SetValue(FileSystemActivity.FileSystem.OverwriteProperty, value);
            }
        }

        public static DependencyProperty RecursiveProperty = DependencyProperty.Register("Recursive", typeof(System.Boolean), typeof(FileSystemActivity.FileSystem));

        [DefaultValueAttribute(true)]
        [CategoryAttribute("FileSystem")]
        [DescriptionAttribute("Determines whether directories, subdirectories, and files in source path will be processed.")]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [ValidationOptionAttribute(ValidationOption.Optional)]
        [BrowsableAttribute(true)]
        public bool Recursive
        {
            get
            {
                return ((Boolean)(base.GetValue(FileSystemActivity.FileSystem.RecursiveProperty)));
            }
            set
            {
                base.SetValue(FileSystemActivity.FileSystem.RecursiveProperty, value);
            }
        }

        public static DependencyProperty SearchPatternProperty = DependencyProperty.Register("SearchPattern", typeof(System.String), typeof(FileSystemActivity.FileSystem));

        [CategoryAttribute("FileSystem")]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [ValidationOptionAttribute(ValidationOption.Optional)]
        [BrowsableAttribute(true)]
        [DescriptionAttribute("The search string, such as \"*.txt\". ")]
        public string SearchPattern
        {
            get
            {
                return ((String)(base.GetValue(FileSystemActivity.FileSystem.SearchPatternProperty)));
            }
            set
            {
                base.SetValue(FileSystemActivity.FileSystem.SearchPatternProperty, value);
            }
        }

        public static DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(System.String), typeof(FileSystemActivity.FileSystem));

        [CategoryAttribute("FileSystem")]
        [DescriptionAttribute("The source path.")]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [ValidationOptionAttribute(ValidationOption.Optional)]
        [BrowsableAttribute(true)]
        public string Source
        {
            get
            {
                return ((String)(base.GetValue(FileSystemActivity.FileSystem.SourceProperty)));
            }
            set
            {
                base.SetValue(FileSystemActivity.FileSystem.SourceProperty, value);
            }
        }

        public static DependencyProperty StreamReaderProperty = DependencyProperty.Register("StreamReader", typeof(System.IO.StreamReader), typeof(FileSystemActivity.FileSystem));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [ValidationOptionAttribute(ValidationOption.Optional)]
        [BrowsableAttribute(true)]
        [DescriptionAttribute("The StreamReader on the specified source.")]
        [CategoryAttribute("FileSystem")]
        public System.IO.StreamReader StreamReader
        {
            get
            {
                return ((System.IO.StreamReader)(base.GetValue(FileSystemActivity.FileSystem.StreamReaderProperty)));
            }
            set
            {
                base.SetValue(FileSystemActivity.FileSystem.StreamReaderProperty, value);
            }
        }

        public static DependencyProperty CommandExecutingEvent = DependencyProperty.Register("CommandExecuting", typeof(System.EventHandler), typeof(FileSystemActivity.FileSystem));

        [DescriptionAttribute("Event fires when the activity execution starts.")]
        [CategoryAttribute("Handlers")]
        [MergableProperty(false)]
        public event System.EventHandler CommandExecuting
        {
            add
            {
                base.AddHandler(CommandExecutingEvent, value);
            }
            remove
            {
                base.RemoveHandler(CommandExecutingEvent, value);
            }
        }

        public static DependencyProperty CommandExecutedEvent = DependencyProperty.Register("CommandExecuted", typeof(System.EventHandler), typeof(FileSystemActivity.FileSystem));

        [DescriptionAttribute("Event fires when the activity execution ends.")]
        [CategoryAttribute("Handlers")]
        [MergablePropertyAttribute(false)]
        public event System.EventHandler CommandExecuted
        {
            add
            {
                base.AddHandler(CommandExecutedEvent, value);
            }
            remove
            {
                base.RemoveHandler(CommandExecutedEvent, value);
            }
        }
    }
}
