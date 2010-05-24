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
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using System.Collections.Generic;

namespace WorkflowConsoleApplication1
{
	public partial class Workflow1 : SequentialWorkflowActivity
	{

        // This function initializes the Items property.  Here we're using an ArrayList
        // object as our collection.  Any type that implements IEnumerable can be used here.
        private void InitializeCollection(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            list.Add("value1");
            list.Add("value2");
            list.Add("value3");
            this.forEach1.Items = list;
        }

        // This function prints out the current item as the collection is iterated through.
        private void OnEachHandler(object sender, EventArgs e)
        {
            string s = this.forEach1.CurrentItem as string;
            Console.WriteLine("Current collection item is: " + s);
        }

        // The DynamicActivity (the child activity of ForEach) is a new activity instance 
        // instantiated for every iteration.
        private void code1_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("Executing child activity " + this.forEach1.DynamicActivity.QualifiedName);
            string s = this.forEach1.CurrentItem as string;
            Console.WriteLine(s);
        }
	}
}
