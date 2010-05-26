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
using ActiveDirectory;
using System.DirectoryServices;


using System.Data.SqlClient;
using System.Text;
using System.Security.Principal;
using System.Xml.Serialization;
using System.Reflection;

namespace ActiveDirectory
{
	
	[Serializable()]public class ADUser
	{
		
		#region "private property variables"
		private string _FirstName; //givenName
		private string _MiddleInitial; //initials
		private string _LastName; //sn
		private string _DisplayName; //Name
		private string _UserPrincipalName; //userPrincipalName (e.g. user@domain.local)
		private string _PostalAddress;
		private string _MailingAddress; //StreetAddress
		private string _ResidentialAddress; //HomePostalAddress
		private string _Title;
		private string _HomePhone;
		private string _OfficePhone; //TelephoneNumber
		private string _Mobile;
		private string _Fax; //FacsimileTelephoneNumber
		private string _Email; //mail
		private string _Url;
		private string _UserName; //sAMAccountName
		private string _Password;
		private string _DistinguishedName;
		private bool _IsAccountActive; //userAccountControl
		private ArrayList _Groups;
		#endregion
		
		#region "public Properties"
		public string FirstName
		{
			get{
				return _FirstName;
			}
			set
			{
				_FirstName = value;
			}
		}
		
		public string MiddleInitial
		{
			get{
				return _MiddleInitial;
			}
			set
			{
				if (value.Length > 6)
				{
					throw (new Exception("MiddleInitial cannot be more than six characters"));
				}
				else
				{
					_MiddleInitial = value;
				}
			}
		}
		public string LastName
		{
			get{
				return _LastName;
			}
			set
			{
				_LastName = value;
			}
		}
		
		public string DisplayName
		{
			get{
				_DisplayName = _FirstName + _MiddleInitial + "." + _LastName;
				return _DisplayName;
			}
			
		}
		
		public string UserPrincipalName
		{
			get{
				return _UserPrincipalName;
			}
			set
			{
				_UserPrincipalName = value;
			}
		}
		
		public string PostalAddress
		{
			get{
				return _PostalAddress;
			}
			set
			{
				_PostalAddress = value;
			}
		}
		public string MailingAddress
		{
			get{
				return _MailingAddress;
			}
			set
			{
				_MailingAddress = value;
			}
		}
		
		public string ResidentialAddress
		{
			get{
				return _ResidentialAddress;
			}
			set
			{
				_ResidentialAddress = value;
			}
		}
		
		public string Title
		{
			get{
				return _Title;
			}
			set
			{
				_Title = value;
			}
		}
		public string HomePhone
		{
			get{
				return _HomePhone;
			}
			set
			{
				_HomePhone = value;
			}
		}
		
		public string OfficePhone
		{
			get{
				return _OfficePhone;
			}
			set
			{
				_OfficePhone = value;
			}
		}
		public string Mobile
		{
			get{
				return _Mobile;
			}
			set
			{
				_Mobile = value;
			}
		}
		public string Fax
		{
			get{
				return _Fax;
			}
			set
			{
				_Fax = value;
			}
		}
		public string Email
		{
			get{
				return _Email;
			}
			set
			{
				_Email = value;
			}
		}
		public string Url
		{
			get{
				return _Url;
			}
			set
			{
				_Url = value;
			}
		}
		public string UserName
		{
			get{
				return _UserName;
			}
			set
			{
				_UserName = value;
			}
		}
		public string Password
		{
			get{
				return _Password;
			}
			set
			{
				_Password = value;
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
		public bool IsAccountActive
		{
			get{
				return _IsAccountActive;
			}
			set
			{
				_IsAccountActive = value;
			}
		}
		public ArrayList Groups
		{
			get{
				if (_Groups == null)
				{
					_Groups = ADGroup.LoadByUser(DistinguishedName);
				}
				return _Groups;
			}
			set
			{
				_Groups = value;
			}
		}
		#endregion
		
		#region "static Functions"
		internal static ArrayList LoadByGroup(string DistinguishedName)
		{
			return GetUsers(DistinguishedName);
		}
		#endregion
		
		#region "public Functions"
		public void Update ()
		{
			try
			{
				DirectoryEntry de = GetDirectoyrObject(UserName);
				Utility.SetProperty(de, "givenName", FirstName);
				Utility.SetProperty(de, "initials", MiddleInitial);
				Utility.SetProperty(de, "sn", LastName);
				Utility.SetProperty(de, "UserPrincipalName", UserPrincipalName);
				Utility.SetProperty(de, "PostalAddress", PostalAddress);
				Utility.SetProperty(de, "StreetAddress", MailingAddress);
				Utility.SetProperty(de, "HomePostalAddress", ResidentialAddress);
				Utility.SetProperty(de, "Title", Title);
				Utility.SetProperty(de, "HomePhone", HomePhone);
				Utility.SetProperty(de, "TelephoneNumber", OfficePhone);
				Utility.SetProperty(de, "Mobile", Mobile);
				Utility.SetProperty(de, "FacsimileTelephoneNumber", Fax);
				Utility.SetProperty(de, "mail", Email);
				ActiveDirectory.Utility.SetProperty(de, "Url", Url);
				if (IsAccountActive == true)
				{
					de.Properties["userAccountControl"][0] = Utility.UserStatus.Enable;
				}
				else
				{
					de.Properties["userAccountControl"][0] = Utility.UserStatus.Disable;
				}
				de.CommitChanges();
			}
			catch (Exception ex)
			{
				throw (new Exception("User cannot be updated" + ex.Message));
			}
		}
		public void SetPassword (string newPassword)
		{
			try
			{
				DirectoryEntry de = GetDirectoyrObject(UserName);
				Utility.SetUserPassword(de, newPassword);
				de.CommitChanges();
			}
			catch (Exception ex)
			{
				throw (new Exception("User Password cannot be set" + ex.Message));
			}
		}
		#endregion
		
		#region "private Functions"
		private DirectoryEntry GetDirectoyrObject(string UserName)
		{
			DirectoryEntry de = Utility.GetDirectoryObject();
			DirectorySearcher deSearch = new DirectorySearcher();
			deSearch.SearchRoot = de;
			deSearch.Filter = "(&(objectClass=user)(sAMAccountName=" + UserName + "))";
			deSearch.SearchScope = SearchScope.Subtree;
			SearchResult results = deSearch.FindOne();
			if (!(results == null))
			{
				de = new DirectoryEntry(results.Path, Utility.ADUser, Utility.ADPassword, AuthenticationTypes.Secure);
				return de;
			}
			else
			{
				return null;
			}
		}
		private static ArrayList GetUsers(string DistinguishedName)
		{
			DirectoryEntry _de = Utility.GetDirectoryObjectByDistinguishedName(DistinguishedName);
			int index;
			ArrayList list = new ArrayList();
			for (index = 0; index <= _de.Properties["member"].Count - 1; index++)
			{
				list.Add(Load(Utility.GetDirectoryObjectByDistinguishedName(Utility.ADPath + "/" + _de.Properties["member"][index].ToString())));
			}
			return list;
		}
		private static ADUser Load(DirectoryEntry de)
		{
			ADUser ADUser = new ADUser();
			ADUser.FirstName = Utility.GetProperty(de, "givenName");
			ADUser.MiddleInitial = Utility.GetProperty(de, "initials");
			ADUser.LastName = Utility.GetProperty(de, "sn");
			ADUser.UserPrincipalName = Utility.GetProperty(de, "UserPrincipalName");
			ADUser.PostalAddress = Utility.GetProperty(de, "PostalAddress");
			ADUser.MailingAddress = Utility.GetProperty(de, "StreetAddress");
			ADUser.ResidentialAddress = Utility.GetProperty(de, "HomePostalAddress");
			ADUser.Title = Utility.GetProperty(de, "Title");
			ADUser.HomePhone = Utility.GetProperty(de, "HomePhone");
			ADUser.OfficePhone = Utility.GetProperty(de, "TelephoneNumber");
			ADUser.Mobile = Utility.GetProperty(de, "Mobile");
			ADUser.Fax = Utility.GetProperty(de, "FacsimileTelephoneNumber");
			ADUser.Email = Utility.GetProperty(de, "mail");
			ADUser.Url = Utility.GetProperty(de, "Url");
			ADUser.UserName = Utility.GetProperty(de, "sAMAccountName");
			ADUser.DistinguishedName = Utility.ADPath + "/" + Utility.GetProperty(de, "DistinguishedName");
			ADUser.IsAccountActive = Utility.IsAccountActive(Convert.ToInt32(Utility.GetProperty(de, "userAccountControl")));
			return ADUser;
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


