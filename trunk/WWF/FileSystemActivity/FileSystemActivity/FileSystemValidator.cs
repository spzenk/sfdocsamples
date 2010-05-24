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

using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Compiler;

namespace FileSystemActivity
{
    /// <summary>
    /// Provides the validation logic for the activity component.
    /// </summary>
    public sealed class FileSystemValidator : ActivityValidator
    {
        /// <summary>
        /// Overridden to validate the activity properties and populate the error collection.
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override ValidationErrorCollection Validate(ValidationManager manager, object obj)
        {
   			ValidationErrorCollection validationErrorCollection = new ValidationErrorCollection(base.Validate(manager, obj));
            FileSystem activity = obj as FileSystem;


            if (activity.Parent != null)
            {
                if (IsPropertyRequired(activity.Command, FileSystem.SourceProperty.Name) && 
                    (activity.Source == null || activity.Source.Length == 0) && activity.GetBinding(FileSystem.SourceProperty) == null)
                    validationErrorCollection.Add(ValidationError.GetNotSetValidationError(FileSystem.SourceProperty.Name));

                if (IsPropertyRequired(activity.Command, FileSystem.DestinationProperty.Name) &&
                    (activity.Destination == null || activity.Destination.Length == 0) && activity.GetBinding(FileSystem.DestinationProperty) == null)
                    validationErrorCollection.Add(ValidationError.GetNotSetValidationError(FileSystem.DestinationProperty.Name));

                if (IsPropertyRequired(activity.Command, FileSystem.SearchPatternProperty.Name) &&
                    (activity.SearchPattern == null || activity.SearchPattern.Length == 0) && activity.GetBinding(FileSystem.SearchPatternProperty) == null)
                    validationErrorCollection.Add(ValidationError.GetNotSetValidationError(FileSystem.SearchPatternProperty.Name));
            }

			return validationErrorCollection;
        }

        /// <summary>
        /// Determines whether the specified property must be set.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        private static bool IsPropertyRequired(CommandType command, string propertyName)
        {
            if (propertyName == FileSystem.SourceProperty.Name && command != CommandType.CloseFile)
                return true;

            switch (command)
            {
                case CommandType.CopyFile:
                case CommandType.MoveFile:
                case CommandType.MoveDirectory:
                    if (propertyName == FileSystem.DestinationProperty.Name)
                        return true;
                    break;
                case CommandType.FindFiles:
                    if (propertyName == FileSystem.SearchPatternProperty.Name)
                        return true;
                    break;
            }
            return false;
       }
    }
}