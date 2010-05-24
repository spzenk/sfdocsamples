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
using System.IO;
using System.Collections.Generic;
using System.Globalization;

namespace FileSystemActivity
{
    /// <summary>
    /// Provides the file system functionality.
    /// </summary>
	internal static class IOHelper
	{
        /// <summary>
        /// Deletes the specified file.
        /// </summary>
        /// <param name="source"></param>
        internal static void DeleteFile(string source)
        {
            File.Delete(source);
        }

        /// <summary>
        /// Copies an existing file to a new file.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="fileMode"></param>
        internal static void CopyFile(string source, string destination, bool overwrite)
        {
            File.Copy(source, destination, overwrite);
        }

        /// <summary>
        /// Moves a specified file to a new location.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="fileMode"></param>
        internal static void MoveFile(string source, string destination, bool overwrite)
        {
            if (!overwrite && source != destination && File.Exists(destination))
                throw new IOException(string.Format(CultureInfo.InvariantCulture, "The destination file '{0}' already exists.", source));
            if (overwrite && File.Exists(destination))
                File.Delete(destination);
            File.Move(source, destination);
        }

        /// <summary>
        /// Creates all the directories in a specified source.
        /// </summary>
        /// <param name="source"></param>
        internal static void CreateDirectory(string source)
        {
            Directory.CreateDirectory(source);
        }

        /// <summary>
        /// Deletes a specified directory.
        /// </summary>
        /// <param name="source"></param>
        internal static void DeleteDirectory(string source, bool recursive)
        {
            Directory.Delete(source, recursive);
        }

        /// <summary>
        /// Moves a directory and its contents to a new location.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="recursive"></param>
        internal static void MoveDirectory(string source, string destination)
        {
            Directory.Move(source, destination);            
        }

        /// <summary>
        /// Encrypts a file so that only the account used to encrypt the file can decrypt it.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        internal static void EncryptFile(string source)
        {
            File.Encrypt(source);
        }

        /// <summary>
        /// Decrypts a file that was encrypted by the current account using the Encrypt method.
        /// </summary>
        /// <param name="source"></param>
        internal static void DecryptFile(string source)
        {
            File.Decrypt(source);
        }

        /// <summary>
        /// Opens an existing text file for reading.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        internal static StreamReader OpenTextFile(string source)
        {
            return File.OpenText(source);
        }

        /// <summary>
        /// Opens a FileStream on the specified path.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="fileMode"></param>
        /// <returns></returns>
        internal static FileStream OpenFile(string source, FileMode fileMode, FileAccess fileAccess)
        {
            return File.Open(source, fileMode, fileAccess);
        }

        /// <summary>
        /// Closes the current stream.
        /// </summary>
        /// <param name="fileStream"></param>
        internal static void CloseFile(IDisposable stream)
        {
            if (stream != null)
                stream.Dispose();
        }

        /// <summary>
        /// Returns a file list from the current directory and subdirectories matching the given searchPattern.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="searchPattern"></param>
        /// <param name="recursive"></param>
        /// <returns></returns>
        internal static FileInfo[] FindFiles(string source, string searchPattern, bool recursive)
        {
            if (recursive)
                return new DirectoryInfo(source).GetFiles(searchPattern, SearchOption.AllDirectories);
            else
                return new DirectoryInfo(source).GetFiles(searchPattern, SearchOption.TopDirectoryOnly);
        }
	}
}
