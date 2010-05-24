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
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace WorkflowConsoleApplication1
{
	public sealed partial class Workflow1
	{
		#region Designer generated code
		
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.CanModifyActivities = true;
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            this.CreateFile = new FileSystemActivity.FileSystem();
            this.Write = new System.Workflow.Activities.CodeActivity();
            this.CloseFile = new FileSystemActivity.FileSystem();
            this.ReadFile = new FileSystemActivity.FileSystem();
            this.Print = new System.Workflow.Activities.CodeActivity();
            this.CloseFile2 = new FileSystemActivity.FileSystem();
            this.FindFiles = new FileSystemActivity.FileSystem();
            // 
            // CreateFile
            // 
            this.CreateFile.FileAccess = System.IO.FileAccess.Write;
            this.CreateFile.FileMode = System.IO.FileMode.Create;
            this.CreateFile.Name = "CreateFile";
            this.CreateFile.Source = "HelloWorld.txt";
            // 
            // Write
            // 
            this.Write.Name = "Write";
            this.Write.ExecuteCode += new System.EventHandler(this.Write_ExecuteCode);
            // 
            // CloseFile
            // 
            this.CloseFile.Command = FileSystemActivity.CommandType.CloseFile;
            this.CloseFile.Name = "CloseFile";
            this.CloseFile.StreamReader = null;
            // 
            // ReadFile
            // 
            this.ReadFile.Command = FileSystemActivity.CommandType.OpenTextFile;
            this.ReadFile.Name = "ReadFile";
            this.ReadFile.Source = "HelloWorld.txt";
            this.ReadFile.StreamReader = null;
            // 
            // Print
            // 
            this.Print.Name = "Print";
            this.Print.ExecuteCode += new System.EventHandler(this.Print_ExecuteCode);
            // 
            // CloseFile2
            // 
            this.CloseFile2.Command = FileSystemActivity.CommandType.CloseFile;
            this.CloseFile2.Name = "CloseFile2";
            activitybind1.Name = "ReadFile";
            activitybind1.Path = "StreamReader";
            this.CloseFile2.SetBinding(FileSystemActivity.FileSystem.StreamReaderProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            // 
            // FindFiles
            // 
            this.FindFiles.Command = FileSystemActivity.CommandType.FindFiles;
            this.FindFiles.Name = "FindFiles";
            this.FindFiles.Recursive = false;
            this.FindFiles.SearchPattern = "*.txt";
            this.FindFiles.Source = "C:\\Temp";
            this.FindFiles.CommandExecuted += new System.EventHandler(this.OnFilesFound);
            // 
            // Workflow1
            // 
            this.Activities.Add(this.CreateFile);
            this.Activities.Add(this.Write);
            this.Activities.Add(this.CloseFile);
            this.Activities.Add(this.ReadFile);
            this.Activities.Add(this.Print);
            this.Activities.Add(this.CloseFile2);
            this.Activities.Add(this.FindFiles);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

		}

		#endregion

        private FileSystemActivity.FileSystem CloseFile;
        private CodeActivity Write;
        private FileSystemActivity.FileSystem ReadFile;
        private CodeActivity Print;
        private FileSystemActivity.FileSystem CloseFile2;
        private FileSystemActivity.FileSystem FindFiles;
        private FileSystemActivity.FileSystem CreateFile;










    }
}
