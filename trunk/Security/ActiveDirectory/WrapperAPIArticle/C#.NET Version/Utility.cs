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
using System.IO;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;
using System.Globalization;
using System.DirectoryServices;
using System.Data.SqlClient;
using System.Security.Principal;

namespace ActiveDirectory
{
	public class Utility
	{
		
		#region "public Constant Variables"
public readonly static DateTime DefaultDate = DateTime.Parse("12/30/1899");

		public static string ADPath =System.Configuration.ConfigurationSettings.AppSettings.Get("ADPAth");
		public static string ADUser = System.Configuration.ConfigurationSettings.AppSettings.Get("ADUser");
		public static string ADPassword = System.Configuration.ConfigurationSettings.AppSettings.Get("ADPassword");
		public static string ADUsersPath = System.Configuration.ConfigurationSettings.AppSettings.Get("ADUsersPath");
		#endregion
			
		#region "private functions"
		internal static DirectoryEntry GetDirectoryObject(string UserName, string Password)
		{
			DirectoryEntry oDE;
			oDE = new DirectoryEntry(ADPath, UserName, Password, AuthenticationTypes.Secure);
			return oDE;
		}
		#endregion
		
		#region "public Enums"
		public enum LoginResult
		{
			LOGIN_OK = 0,
			LOGIN_USER_DOESNT_EXIST,
			LOGIN_USER_ACCOUNT_INACTIVE
		}
		internal enum UserStatus
		{
			Enable = 544,
			Disable = 546
		}
		internal enum GroupScope
		{
			ADS_GROUP_TYPE_DOMAIN_LOCAL_GROUP = - 2147483644,
			ADS_GROUP_TYPE_GLOBAL_GROUP = - 2147483646,
			ADS_GROUP_TYPE_UNIVERSAL_GROUP = - 2147483640
		}
		internal enum ADAccountOptions
		{
			UF_TEMP_DUPLICATE_ACCOUNT = 256,
			UF_NORMAL_ACCOUNT = 512,
			UF_INTERDOMAIN_TRUST_ACCOUNT = 2048,
			UF_WORKSTATION_TRUST_ACCOUNT = 4096,
			UF_SERVER_TRUST_ACCOUNT = 8192,
			UF_DONT_EXPIRE_PASSWD = 65536,
			UF_SCRIPT = 1,
			UF_ACCOUNTDISABLE = 2,
			UF_HOMEDIR_REQUIRED = 8,
			UF_LOCKOUT = 16,
			UF_PASSWD_NOTREQD = 32,
			UF_PASSWD_CANT_CHANGE = 64,
			UF_ACCOUNT_LOCKOUT = 16,
			UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED = 128
		}
		
		#endregion
		
		#region "Functions"
		internal static DirectoryEntry GetUser(string UserName, string Password)
		{
			DirectoryEntry de = GetDirectoryObject(UserName, Password);
			DirectorySearcher deSearch = new DirectorySearcher();
			deSearch.SearchRoot = de;
			deSearch.Filter = "(&(objectClass=user)(sAMAccountName=" + UserName + "))";
			deSearch.SearchScope = SearchScope.Subtree;
			SearchResult results = deSearch.FindOne();
			if (!(results == null))
			{
				de = new DirectoryEntry(results.Path, ADUser, ADPassword, AuthenticationTypes.Secure);
				return de;
			}
			else
			{
				return null;
			}
		}
		internal static void EnableUserAccount (DirectoryEntry oDE)
		{
			oDE.Properties["userAccountControl"].Value = UserStatus.Enable;
			oDE.CommitChanges();
			oDE.Close();
		}
		internal static DirectoryEntry GetGroup(string Name)
		{
			DirectoryEntry de = Utility.GetDirectoryObject();
			DirectorySearcher deSearch = new DirectorySearcher();
			deSearch.SearchRoot = de;
			deSearch.Filter = "(&(objectClass=group)(cn=" + Name + "))";
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
		
		internal static void DisableUserAccount (DirectoryEntry oDE)
		{
			oDE.Properties["userAccountControl"].Value = UserStatus.Disable;
			oDE.CommitChanges();
			oDE.Close();
		}
		internal static DirectoryEntry GetDirectoryObject(string DomainReference)
		{
			DirectoryEntry oDE;
			oDE = new DirectoryEntry(Utility.ADPath + DomainReference, Utility.ADUser, Utility.ADPassword, AuthenticationTypes.Secure);
			return oDE;
		}
		
		internal static void SetUserPassword (DirectoryEntry oDE, string Password)
		{
			oDE.Invoke("SetPassword", new object[] {Password});
		}
		
		internal static bool IsAccountActive(int userAccountControl)
		{
			int userAccountControl_Disabled = Convert.ToInt32(ADAccountOptions.UF_ACCOUNTDISABLE);
			int flagExists = userAccountControl & userAccountControl_Disabled;
			if (flagExists > 0)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
		
		internal static string GetLDAPDomain()
		{
			StringBuilder LDAPDomain = new StringBuilder();
			string serverName = "k2mega.local";
			string[] LDAPDC = serverName.Split(System.Convert.ToChar("."));
			int i = 0;
			while (i < LDAPDC.GetUpperBound(0) + 1)
			{
				LDAPDomain.Append("DC=" + LDAPDC[i]);
				if (i < LDAPDC.GetUpperBound(0))
				{
					LDAPDomain.Append(",");
				}
				i += 1;
			}
			return LDAPDomain.ToString();
		}
		internal static DirectoryEntry GetDirectoryObjectByDistinguishedName(string ObjectPath)
		{
			DirectoryEntry oDE;
			oDE = new DirectoryEntry(ObjectPath, Utility.ADUser, Utility.ADPassword, AuthenticationTypes.Secure);
			return oDE;
		}
		internal static void SetProperty (DirectoryEntry oDE, string PropertyName, string PropertyValue)
		{
			if ((PropertyValue != string.Empty) && (PropertyValue != null))
			{
				if (oDE.Properties.Contains(PropertyName))
				{
					oDE.Properties[PropertyName][0] = PropertyValue;
				}
				else
				{
					oDE.Properties[PropertyName].Add(PropertyValue);
				}
			}
		}
		internal static DirectoryEntry GetDirectoryObject()
		{
			DirectoryEntry oDE;
			oDE = new DirectoryEntry(Utility.ADPath, Utility.ADUser, Utility.ADPassword, AuthenticationTypes.Secure);
			return oDE;
		}
		internal static string GetProperty(DirectoryEntry oDE, string PropertyName)
		{
			if (oDE.Properties.Contains(PropertyName))
			{
				return oDE.Properties[PropertyName][0].ToString();
			}
			else
			{
				return string.Empty;
			}
		}
		#endregion
		
	}
}
