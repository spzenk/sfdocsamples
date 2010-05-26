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

// Static Model
namespace ActiveDirectory
{
	public class ADManager
	{
		private static ADManager _instance;
		
		private ADManager() {
		}
		
		public static ADManager Instance
		{
			get{
				if (_instance == null)
				{
					_instance = new ADManager();
				}
				return _instance;
			}
		}
		
		#region "private Properties"
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
		private ArrayList Load(SearchResultCollection seCollection)
		{
			ArrayList list = new ArrayList();
			ADUser adUser;
			foreach ( SearchResult se in seCollection)
			{
			adUser= Load(new DirectoryEntry(se.Path, Utility.ADUser, Utility.ADPassword, AuthenticationTypes.Secure));
				list.Add(adUser);
			}
			return list;
		}
		private ArrayList LoadGroup(SearchResultCollection seCollection)
		{
			ArrayList list = new ArrayList();
			SearchResult se;
			foreach (SearchResult tempLoopVar_se in seCollection)
			{
				se = tempLoopVar_se;
				list.Add(LoadGroup(new DirectoryEntry(se.Path, Utility.ADUser, Utility.ADPassword, AuthenticationTypes.Secure)));
			}
			return list;
		}
		private ADGroup LoadGroup(DirectoryEntry de)
		{
			ADGroup _ADGroup = new ADGroup();
			_ADGroup.Name = Utility.GetProperty(de, "cn");
			_ADGroup.DisplayName = Utility.GetProperty(de, "DisplayName");
			_ADGroup.DistinguishedName = Utility.ADPath + "/" + Utility.GetProperty(de, "DistinguishedName");
			_ADGroup.Description = Utility.GetProperty(de, "Description");
			return _ADGroup;
		}
		private static SearchResultCollection GetUsers()
		{
			DirectoryEntry de = Utility.GetDirectoryObject();
			DirectorySearcher deSearch = new DirectorySearcher();
			deSearch.SearchRoot = de;
			deSearch.Filter = "(&(objectClass=user)(objectCategory=person))";
			deSearch.SearchScope = SearchScope.Subtree;
			return deSearch.FindAll();
		}
		private static SearchResultCollection GetGroups()
		{
			DataSet dsGroup = new DataSet();
			DirectoryEntry de = Utility.GetDirectoryObject();
			DirectorySearcher deSearch = new DirectorySearcher();
			deSearch.SearchRoot = de;
			deSearch.Filter = "(&(objectClass=group))";
			return deSearch.FindAll();
			
		}
		private static DirectoryEntry GetUser(string UserName)
		{
			DirectoryEntry de = Utility.GetDirectoryObject();
			DirectorySearcher deSearch = new DirectorySearcher();
			deSearch.SearchRoot = de;
			deSearch.Filter = "(&(objectClass=user)(CN=" + UserName + "))";
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
		
		
		private ADUser Load(DirectoryEntry de)
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
			ADUser.UserName  = Utility.GetProperty(de, "sAMAccountName");
			ADUser.DistinguishedName = Utility.ADPath + "/" + Utility.GetProperty(de, "DistinguishedName");
			ADUser.IsAccountActive = Utility.IsAccountActive(Convert.ToInt32(Utility.GetProperty(de, "userAccountControl")));
			return ADUser;
		}
		private DirectoryEntry AddGroup(string Name, string DisplayName, string DistinguishedName, string Description)
		{
			
			string RootDSE;
			System.DirectoryServices.DirectorySearcher DSESearcher = new System.DirectoryServices.DirectorySearcher();
			try
			{
				RootDSE = DSESearcher.SearchRoot.Path;
				RootDSE = RootDSE.Insert(7, Utility.ADUsersPath);
				System.DirectoryServices.DirectoryEntry myDE = new DirectoryEntry(RootDSE);
				DirectoryEntries myEntries = myDE.Children;
				System.DirectoryServices.DirectoryEntry myDirectoryEntry = myEntries.Add("CN=" + Name, "Group");
				Utility.SetProperty(myDirectoryEntry, "cn", Name);
				Utility.SetProperty(myDirectoryEntry, "DisplayName", DisplayName);
				Utility.SetProperty(myDirectoryEntry, "Description", Description);
				Utility.SetProperty(myDirectoryEntry, "sAMAccountName", Name);
				Utility.SetProperty(myDirectoryEntry, "groupType", System.Convert.ToString(Utility.GroupScope.ADS_GROUP_TYPE_GLOBAL_GROUP));
				
				myDirectoryEntry.CommitChanges();
				myDirectoryEntry = Utility.GetGroup(Name);
				return myDirectoryEntry;
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}
		
		private DirectoryEntry Add(string FirstName, string MiddleInitial, string LastName, string UserPrincipalName, string PostalAddress, string MailingAddress, string ResidentialAddress, string Title, string HomePhone, string OfficePhone, string Mobile, string Fax, string Email, string Url, string UserName, string Password, string DistinguishedName, bool IsAccountActive)
		{
			
			string RootDSE;
			System.DirectoryServices.DirectorySearcher DSESearcher = new System.DirectoryServices.DirectorySearcher();
			try
			{
				RootDSE = DSESearcher.SearchRoot.Path;
				RootDSE = RootDSE.Insert(7, Utility.ADUsersPath);
				System.DirectoryServices.DirectoryEntry myDE = new DirectoryEntry(RootDSE);
				DirectoryEntries myEntries = myDE.Children;
				System.DirectoryServices.DirectoryEntry myDirectoryEntry = myEntries.Add("CN=" + UserName, "user");
				Utility.SetProperty(myDirectoryEntry, "givenName", FirstName);
				Utility.SetProperty(myDirectoryEntry, "initials", MiddleInitial);
				Utility.SetProperty(myDirectoryEntry, "sn", LastName);
				if ( UserPrincipalName !=  null)
				{
					Utility.SetProperty(myDirectoryEntry, "UserPrincipalName", UserPrincipalName);
				}
				else
				{
					Utility.SetProperty(myDirectoryEntry, "UserPrincipalName", UserName);
				}
				Utility.SetProperty(myDirectoryEntry, "PostalAddress", PostalAddress );
				Utility.SetProperty(myDirectoryEntry, "StreetAddress", MailingAddress);
				Utility.SetProperty(myDirectoryEntry, "HomePostalAddress", ResidentialAddress);
				Utility.SetProperty(myDirectoryEntry, "Title", Title);
				Utility.SetProperty(myDirectoryEntry, "HomePhone", HomePhone);
				Utility.SetProperty(myDirectoryEntry, "TelephoneNumber", OfficePhone);
				Utility.SetProperty(myDirectoryEntry, "Mobile", Mobile);
				Utility.SetProperty(myDirectoryEntry, "FacsimileTelephoneNumber", Fax);
				Utility.SetProperty(myDirectoryEntry, "mail", Email);
				Utility.SetProperty(myDirectoryEntry, "Url", Url);
				Utility.SetProperty(myDirectoryEntry, "sAMAccountName", UserName);
				Utility.SetProperty(myDirectoryEntry, "UserPassword", Password);
				myDirectoryEntry.Properties["userAccountControl"].Value = Utility.UserStatus.Enable;
				myDirectoryEntry.CommitChanges();
				myDirectoryEntry = GetUser(UserName);
				Utility.SetUserPassword(myDirectoryEntry, Password);
				return myDirectoryEntry;
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}
		
		#endregion
		
		#region "public Properties"
		public ADUser LoadUser(string userName)
		{
			return Load(GetUser(userName));
		}
		public ADGroup LoadGroup(string GroupName)
		{
			return LoadGroup(Utility.GetGroup(GroupName));
		}
		public ArrayList LoadAllUsers()
		{
			return Load(GetUsers());
		}
		public ArrayList LoadAllGroups()
		{
			
			return Load(GetGroups());
		}
		public ADUser CreateADUser(ActiveDirectory.ADUser  ADUser)
		{
			return Load(Add(ADUser.FirstName, ADUser.MiddleInitial, ADUser.LastName, ADUser.UserPrincipalName, ADUser.PostalAddress, ADUser.MailingAddress, ADUser.ResidentialAddress, ADUser.Title, ADUser.HomePhone, ADUser.OfficePhone, ADUser.Mobile, ADUser.Fax, ADUser.Email, ADUser.Url, ADUser.UserName, ADUser.Password, ADUser.DistinguishedName, ADUser.IsAccountActive));
		}
		public ADGroup CreateADGroup(ActiveDirectory.ADGroup  ADGroup)
		{
			return LoadGroup(AddGroup(ADGroup.Name, ADGroup.DisplayName, ADGroup.DistinguishedName,  ADGroup.Description ));
		}
		public static void AddUserToGroup (string UserDistinguishedName, string GroupDistinguishedName)
		{
			DirectoryEntry oGroup = Utility.GetDirectoryObjectByDistinguishedName(GroupDistinguishedName);
			oGroup.Invoke("Add", new object[] {UserDistinguishedName});
			oGroup.Close();
		}
		public static void RemoveUserFromGroup (string UserDistinguishedName, string GroupDistinguishedName)
		{
			DirectoryEntry oGroup = Utility.GetDirectoryObjectByDistinguishedName(GroupDistinguishedName);
			oGroup.Invoke("Remove", new object[] {UserDistinguishedName});
			oGroup.Close();
		}
		public static void DisableUserAccount (string UserName)
		{
			ActiveDirectory.Utility.DisableUserAccount(GetUser(UserName));
		}
		public static void EnableUserAccount (string UserName)
		{
			ActiveDirectory.Utility.EnableUserAccount(GetUser(UserName));
		}
		public static void DeleteUserAccount (string UserName)
		{
			
			DirectoryEntry de = GetUser(UserName);
			de.DeleteTree();
			de.CommitChanges();
		}
		public static void DeleteGroupAccount (string GroupName)
		{
			DirectoryEntry de = Utility.GetGroup(GroupName);
			de.DeleteTree();
			de.CommitChanges();
		}
		public static bool IsUserValid(string UserName, string Password)
		{
			try
			{
				DirectoryEntry deUser = Utility.GetUser(UserName, Password);
				deUser.Close();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		public static bool UserExists(string UserName)
		{
			DirectoryEntry de = Utility.GetDirectoryObject();
			DirectorySearcher deSearch = new DirectorySearcher();
			deSearch.SearchRoot = de;
			deSearch.Filter = "(&(objectClass=user) (cn=" + UserName + "))";
			SearchResultCollection results = deSearch.FindAll();
			if (results.Count == 0)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
		
		public static bool GroupExists(string GroupName)
		{
			DirectoryEntry de = Utility.GetDirectoryObject();
			DirectorySearcher deSearch = new DirectorySearcher();
			deSearch.SearchRoot = de;
			deSearch.Filter = "(&(objectClass=group) (cn=" + GroupName + "))";
			SearchResultCollection results = deSearch.FindAll();
			if (results.Count == 0)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
		public static Utility.LoginResult Login(string UserName, string Password)
		{
			if (IsUserValid(UserName, Password))
			{
				DirectoryEntry de = GetUser(UserName);
				if (!(de == null))
				{
					if (Utility.UserStatus.Enable == (Utility.UserStatus)(de.Properties["userAccountControl"][0]))
					{
							de.Close();
						return Utility.LoginResult.LOGIN_OK;
					}
					else
					{
							de.Close();
						return Utility.LoginResult.LOGIN_USER_ACCOUNT_INACTIVE;
					}
				
				}
				else
				{
					return Utility.LoginResult.LOGIN_USER_DOESNT_EXIST;
				}
			}
			else
			{
				return Utility.LoginResult.LOGIN_USER_DOESNT_EXIST;
			}
		}
		
		#endregion
		
	}
	
}


