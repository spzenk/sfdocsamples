using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.DirectoryServices;
using System.Configuration;
using System.Collections.Generic;

// LDAP Web Service
// Thomas B. Holland
// 03/13/08

// Modified On 10/16/2008 to add searching features

namespace LDAPWebService
{
    /// <summary>
    /// LDAP Web Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/", Description = "The userName can be passed in with or without the domain prefix." +
        "  When developing Win Forms, username should be obtained by instantiating a new System.Security.Prinicpal.WindowsIdentity" +
        " object and calling the GetCurrent() method (i.e. WindowsIdentity id = WindowsIdentity.GetCurrent()).  " +
        "When developing ASP.NET applications, username should be obtained by using Context.User.Identity.Name")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class User : System.Web.Services.WebService
    {
        private DirectoryEntry entry = new DirectoryEntry(ConfigurationManager.AppSettings["LDAPServer"].ToString(), ConfigurationManager.AppSettings["BindUser"].ToString(), ConfigurationManager.AppSettings["BindPass"].ToString());

        public enum ADProperties
        {
            distinguishedName,
            displayName,
            telephoneNumber,
            samAccountName,
            manager,
            title,
            department,
            givenName,
            sn
        }

        #region WebMethods

        /// <summary>
        /// Returns the full name of a user from Active Directory.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [WebMethod(Description="Returns the full name of a user from Active Directory.")]
        public string GetFullName(string userName)
        {
            try
            {
                SearchResult result = DirectorySearch("cn", userName.Trim());

                if (result != null)
                    return result.GetDirectoryEntry().Properties["cn"].Value.ToString();
                else return "User Not Found In Active Directory";
            }

            catch (Exception ex)
            {
                return "An error was thrown by the LDAP Web Service.  The Error was \r\n" + ex.Message.ToString();
            }
        }

        /// <summary>
        /// Returns a generic list of the Active Directory security groups that a user is a member of. 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [WebMethod(Description="Returns a generic list of the Active Directory security groups that a user is a member of.")]
        public List<string> GetGroupMembership(string userName)
        {
            List<string> lstResult = new List<string>();

            try
            {
                SearchResult result = DirectorySearch("memberof", userName.Trim());

                if (result != null)
                {
                    ResultPropertyValueCollection c = result.Properties["memberof"];

                    for (int i = 0; i < c.Count; i++)
                    {
                        int SlashSpot = c[i].ToString().IndexOf(",");
                        lstResult.Add(c[i].ToString().Substring(3, SlashSpot - 3));
                    }
                }
                else
                {
                    lstResult.Add("User Not Found In Active Directory");
                }

            }
            catch (Exception ex)
            {
                lstResult.Add("An error was thrown by the LDAP Web Service.  The Error was \r\n" + ex.Message.ToString());
            }

            return lstResult;
        }

        /// <summary>
        /// Authenticates a user to Active Directory based on their username and password.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [WebMethod(Description="Authenticates a user to Active Directory based on their username and password.")]
        public bool AuthenticateUser(string userName, string password)
        {
            bool bolResult = false;

            try
            {
                SearchResult result = DirectorySearch(userName, password, "cn");

                if (result != null) bolResult = true;
                else bolResult = false;
            }
            catch
            {
                bolResult = false;
            }

            return bolResult;
        }

        /// <summary>
        /// Checks to see if a user is in the specified security group.  Returns true if they are a member, and false if they are not.
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        [WebMethod(Description="Checks to see if a user is in the specified security group.  Returns true if they are a member, and false if they are not.")]
        public bool AuthenticateUserToGroup(string userName, string groupName)
        {
            bool bolResult = false;

            try
            {
                SearchResult result = DirectorySearch("memberof", userName.Trim());

                if (result != null)
                {
                    ResultPropertyValueCollection c = result.Properties["memberof"];

                    for (int i = 0; i < c.Count; i++)
                    {
                        int SlashSpot = c[i].ToString().IndexOf(",");
                        string group = c[i].ToString().Substring(3, SlashSpot - 3);
                        if (group == groupName.Trim()) bolResult = true;
                    }
                }
                else bolResult = false;
            }
            catch
            {
                bolResult = false;
            }

            return bolResult;
        }

        /// <summary>
        /// Web method for performing a search against Active Directory
        /// </summary>
        /// <param name="property"></param>
        /// <param name="propertyValue"></param>
        /// <returns></returns>
        [WebMethod(Description="Searches Active Directory For Users")]
        public List<LDAPSearchResult> Search(ADProperties property, String propertyValue)
        {
            List<LDAPSearchResult> lstSearchResults = new List<LDAPSearchResult>();

            try
            {
                DirectorySearcher search = new DirectorySearcher(entry);
                SearchResultCollection resultCollection;

                LoadProperties(ref search);

                search.Filter = "(" + property + "=*" + propertyValue + "*)";
                resultCollection = search.FindAll();

                if (resultCollection != null)
                {
                    foreach (SearchResult result in resultCollection)
                    {
                        LDAPSearchResult objSearchResult = new LDAPSearchResult();

                        MapToObject(result, ref objSearchResult);

                        lstSearchResults.Add(objSearchResult);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

            return lstSearchResults;
        }

        #endregion  

        #region InternalMethods

        /// <summary>
        /// Maps the active directory results with the LDAPSearchResult object
        /// </summary>
        /// <param name="result"></param>
        /// <param name="objUser"></param>
        private void MapToObject(SearchResult result, ref LDAPSearchResult objSearchResult)
        {
            try
            {

                if (result.Properties["title"].Count > 0)
                    objSearchResult.Title = result.Properties["title"][0].ToString();
                if (result.Properties["distinguishedName"].Count > 0)
                    objSearchResult.distinguishedName = result.Properties["distinguishedName"][0].ToString();
                if (result.Properties["displayName"].Count > 0)
                    objSearchResult.displayName = result.Properties["displayname"][0].ToString();
                if (result.Properties["telephoneNumber"].Count > 0)
                    objSearchResult.telephoneNumber = result.Properties["telephoneNumber"][0].ToString();
                if (result.Properties["samAccountName"].Count > 0)
                    objSearchResult.samAccountName = result.Properties["samAccountName"][0].ToString();
                if (result.Properties["manager"].Count > 0)
                    objSearchResult.manager = FindOneByProperty(ADProperties.distinguishedName,
                        result.Properties["manager"][0].ToString());
                if (result.Properties["department"].Count > 0)
                    objSearchResult.department = result.Properties["department"][0].ToString();
                if (result.Properties["givenName"].Count > 0)
                    objSearchResult.FirstName = result.Properties["givenName"][0].ToString();
                if (result.Properties["sn"].Count > 0)
                    objSearchResult.LastName = result.Properties["sn"][0].ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Performs a search for the passed in property in Active Directory based upon the passed in userName.
        /// </summary>
        /// <param name="property"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        private SearchResult DirectorySearch(string property, string userName)
        {
            DirectorySearcher search = new DirectorySearcher(entry);

            search.PropertiesToLoad.Add(property);
            search.Filter = "sAMAccountName=" + FilterOutDomain(userName);

            SearchResult result = search.FindOne();

            return result;
        }

        /// <summary>
        /// Directory Search Overload.  Allows authentication to AD with a specified username and password
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        private SearchResult DirectorySearch(string userName, string password, string property)
        {
            DirectoryEntry dEntry = new DirectoryEntry(ConfigurationManager.AppSettings["LDAPServer"].ToString(), FilterOutDomain(userName.Trim()), password);
            DirectorySearcher search = new DirectorySearcher(dEntry);

            search.PropertiesToLoad.Add(property);
            search.Filter = "sAMAccountName=" + FilterOutDomain(userName);

            SearchResult result = search.FindOne();

            return result;
        }

        /// <summary>
        /// Cleans up ad search by property and maps to user defined object
        /// </summary>
        /// <param name="property"></param>
        /// <param name="propertyValue"></param>
        /// <returns></returns>
        private LDAPSearchResult FindOneByProperty(ADProperties property, String propertyValue)
        {
            LDAPSearchResult objSearchResult = new LDAPSearchResult();

            try
            {
                SearchResult result = FindOne(property, propertyValue);

                if (result != null)
                {
                    MapToObject(result, ref objSearchResult);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

            return objSearchResult;
        }

        /// <summary>
        /// Performs the search against ad by property
        /// </summary>
        /// <param name="property"></param>
        /// <param name="propertyValue"></param>
        /// <returns></returns>
        private SearchResult FindOne(ADProperties property, string propertyValue)
        {
            SearchResult result;

            try
            {
                DirectorySearcher search = new DirectorySearcher(entry);

                LoadProperties(ref search);

                search.Filter = "(" + property + "=" + propertyValue + ")";
                result = search.FindOne();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

            return result;
        }

        /// <summary>
        /// Filters out the domain if one is passed in
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        private string FilterOutDomain(string userName)
        {
            string result = string.Empty;

            if (userName.IndexOf("\\") > 0)
            {
                string UserName = string.Empty;
                int SlashSpot = 0;
                int NameLen = 0;

                SlashSpot = userName.IndexOf(@"\") + 1;

                NameLen = userName.Length - SlashSpot;

                UserName = userName.Substring(SlashSpot, NameLen);

                result = UserName;
            }
            else
            {
                result = userName;
            }

            return result;
        }

        /// <summary>
        /// Loads up the properties to bring back in a search result
        /// </summary>
        /// <param name="search"></param>
        private void LoadProperties(ref DirectorySearcher search)
        {
            try
            {
                // load up the properties we want to expose
                search.PropertiesToLoad.Add("title");
                search.PropertiesToLoad.Add("distinguishedName");
                search.PropertiesToLoad.Add("samAccountName");
                search.PropertiesToLoad.Add("displayName");
                search.PropertiesToLoad.Add("telephoneNumber");
                search.PropertiesToLoad.Add("manager");
                search.PropertiesToLoad.Add("department");
                search.PropertiesToLoad.Add("givenName");
                search.PropertiesToLoad.Add("sn");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        #endregion
    }
}
