// Wrapper API for using Microsoft Active Directory Services version 1.0
// Copyright (c) 2004-2005
// by Syed Adnan Ahmed ( adnanahmed235@yahoo.com )
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
// the rights to use, copy, modify, merge, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions 
// of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
// TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.

using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using System.DirectoryServices;
using System.Data.SqlClient;
using System.Text;
using System.Security.Principal;
using System.Xml.Serialization;
using System.Reflection;
using ActiveDirectory;

namespace ActiveDirectory
{
	
	[Serializable()]public class ADGroup
	{
		
		#region "private property variables"
		private string _Name; //(cn ) in Active Directory
		private string _DisplayName;
		private string _DistinguishedName;
		private string _Description;
		private ArrayList _Users;
		#endregion
		
		#region "public Properties"
		public string Name
		{
			get{
				return _Name;
			}
			set
			{
				_Name = value;
			}
		}
		
		public string DisplayName
		{
			get{
				return _DisplayName;
			}
			set
			{
				_DisplayName = value;
			}
		}
		
		public string DistinguishedName
		{
			get{
				return _DistinguishedName;
			}
			set
			{
				_DistinguishedName = value;
			}
		}
		
		public string Description
		{
			get{
				return _Description;
			}
			set
			{
				_Description = value;
			}
		}
		public ArrayList Users
		{
			get{
				if (_Users == null)
				{
					_Users = ADUser.LoadByGroup(DistinguishedName);
				}
				return _Users;
			}
			set
			{
				_Users = value;
			}
		}
		#endregion
		
		#region "friend Functions"
		internal static ArrayList LoadByUser(string DistinguishedName)
		{
			return GetGroups(DistinguishedName);
		}
		#endregion
		#region "friend Functions"
		public void Update ()
		{
			try
			{
				DirectoryEntry de = Utility.GetGroup(Name);
				Utility.SetProperty(de, "DisplayName", DisplayName);
				Utility.SetProperty(de, "Description", Description);
				de.CommitChanges();
			}
			catch (Exception ex)
			{
				throw (new Exception("User cannot be updated" + ex.Message));
			}
		}
		#endregion
		#region "private Functions"
		private static ArrayList GetGroups(string DistinguishedName)
		{
			DirectoryEntry _de = Utility.GetDirectoryObjectByDistinguishedName(DistinguishedName);
			int index;
			ArrayList list = new ArrayList();
			for (index = 0; index <= _de.Properties["memberOf"].Count - 1; index++)
			{
				list.Add(Load(Utility.GetDirectoryObjectByDistinguishedName(Utility.ADPath + "/" + _de.Properties["memberOf"][index].ToString())));
			}
			return list;
		}
		private static ADGroup Load(DirectoryEntry de)
		{
			ADGroup _ADGroup = new ADGroup();
			_ADGroup.Name = Utility.GetProperty(de, "cn");
			_ADGroup.DisplayName = Utility.GetProperty(de, "DisplayName");
			_ADGroup.DistinguishedName = Utility.ADPath + "/" + Utility.GetProperty(de, "DistinguishedName");
			_ADGroup.Description = Utility.GetProperty(de, "Description");
			return _ADGroup;
		}
		private ArrayList Load(DirectoryEntries deCollection)
		{
			ArrayList list = new ArrayList();
			DirectoryEntry de;
			foreach (DirectoryEntry tempLoopVar_de in deCollection)
			{
				de = tempLoopVar_de;
				list.Add(Load(de));
			}
			return list;
		}
		#endregion
		
	}
}
