using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using DotNetNuke.Framework.Providers;
using Microsoft.ApplicationBlocks.Data;

namespace WroxModules.GuestbookCS
{
    public class SqlDataProvider //:DataProvider
    {


        #region vars
        private const string providerType = "data";
        private const string moduleQualifier = "DNNModuleProgramming_CS_";
        private ProviderConfiguration providerConfiguration = ProviderConfiguration.GetProviderConfiguration(providerType);
        private string connectionString;
        private string providerPath;
        private string objectQualifier;
        private string databaseOwner;
        #endregion

        #region cstor


        /// < summary >
        /// cstor used to create the sqlProvider with required parameters from
        /// the configuration
        /// section of web.config file
        /// < /summary >
        public SqlDataProvider()
        {
            Provider provider = (Provider)providerConfiguration.Providers[providerConfiguration.DefaultProvider];
            connectionString = DotNetNuke.Common.Utilities.Config.GetConnectionString();
            if (connectionString == string.Empty)
                connectionString = provider.Attributes["connectionString"];
            providerPath = provider.Attributes["providerPath"];
            objectQualifier = provider.Attributes["objectQualifier"];
            if (objectQualifier != string.Empty && !objectQualifier.EndsWith("_")) objectQualifier += "_";
            databaseOwner = provider.Attributes["databaseOwner"];
            if (databaseOwner != string.Empty && !databaseOwner.EndsWith(".")) databaseOwner += ".";
        }
        #endregion



        #region private methods
        private string GetFullyQualifiedName(string name)
        {
            return databaseOwner + objectQualifier + moduleQualifier + name;
        }
        private object GetNull(object field)
        {
            return DotNetNuke.Common.Utilities.Null.GetNull(field, DBNull.Value);
        }
        #endregion


        public void InsertGuestbookEntry(int moduleId, string submitterName, string submitterWebsite, string submitterComment, DateTime submissionDate, bool isApproved)
        {
            SqlHelper.ExecuteNonQuery(connectionString, GetFullyQualifiedName("InsertGuestbookEntry"), moduleId,
            submitterName, submitterWebsite, submitterComment,
            submissionDate, isApproved);
        }
        public void ApproveGuestbookEntry(int moduleId, int entryId)
        {
            SqlHelper.ExecuteNonQuery(connectionString,
            GetFullyQualifiedName("AproveGuestbookEntry"),
            moduleId, entryId);
        }

        public void DeleteGuestbookEntry(int moduleId, int entryId)
        {
            SqlHelper.ExecuteNonQuery(connectionString, GetFullyQualifiedName("DeleteGuestbookEntry"), moduleId, entryId);
        }


        public IDataReader GetApprovedEntries(int moduleId)
        {
            return (IDataReader)SqlHelper.ExecuteReader(connectionString,
            GetFullyQualifiedName("GetApprovedEntries"), moduleId);
        }
        public IDataReader GetAllEntries(int moduleId)
        {
            return (IDataReader)SqlHelper.ExecuteReader(connectionString,
            GetFullyQualifiedName("GetAllEntries"), moduleId);
        }



    }
}


//// 
//// DotNetNuke® - http://www.dotnetnuke.com 
//// Copyright (c) 2002-2010 
//// by DotNetNuke Corporation 
//// 
//// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
//// documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
//// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
//// to permit persons to whom the Software is furnished to do so, subject to the following conditions: 
//// 
//// The above copyright notice and this permission notice shall be included in all copies or substantial portions 
//// of the Software. 
//// 
//// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
//// TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
//// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
//// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
//// DEALINGS IN THE SOFTWARE. 
//// 

//using System;
//using System.Data;
//using System.Data.SqlClient;
//using Microsoft.ApplicationBlocks.Data;

//using DotNetNuke.Common.Utilities;
//using DotNetNuke.Framework.Providers;

//namespace YourCompany.Modules.GuestbookCS
//{

//    /// ----------------------------------------------------------------------------- 
//    /// <summary> 
//    /// SQL Server implementation of the abstract DataProvider class 
//    /// </summary> 
//    /// <remarks> 
//    /// </remarks> 
//    /// <history> 
//    /// </history> 
//    /// ----------------------------------------------------------------------------- 
//    public class SqlDataProvider : DataProvider
//    {


//        #region "Private Members"

//        private const string ProviderType = "data";
//        private const string ModuleQualifier = "YourCompany_";

//        private ProviderConfiguration _providerConfiguration = ProviderConfiguration.GetProviderConfiguration(ProviderType);
//        private string _connectionString;
//        private string _providerPath;
//        private string _objectQualifier;
//        private string _databaseOwner;

//        #endregion

//        #region "Constructors"

//        public SqlDataProvider()
//        {

//            // Read the configuration specific information for this provider 
//            Provider objProvider = (Provider)_providerConfiguration.Providers[_providerConfiguration.DefaultProvider];

//            // Read the attributes for this provider 

//            //Get Connection string from web.config 
//            _connectionString = Config.GetConnectionString();

//            if (_connectionString == "")
//            {
//                // Use connection string specified in provider 
//                _connectionString = objProvider.Attributes["connectionString"];
//            }

//            _providerPath = objProvider.Attributes["providerPath"];

//            _objectQualifier = objProvider.Attributes["objectQualifier"];
//            if (_objectQualifier != "" & _objectQualifier.EndsWith("_") == false)
//            {
//                _objectQualifier += "_";
//            }

//            _databaseOwner = objProvider.Attributes["databaseOwner"];
//            if (_databaseOwner != "" & _databaseOwner.EndsWith(".") == false)
//            {
//                _databaseOwner += ".";
//            }

//        }

//        #endregion

//        #region "Properties"

//        public string ConnectionString
//        {
//            get { return _connectionString; }
//        }

//        public string ProviderPath
//        {
//            get { return _providerPath; }
//        }

//        public string ObjectQualifier
//        {
//            get { return _objectQualifier; }
//        }

//        public string DatabaseOwner
//        {
//            get { return _databaseOwner; }
//        }

//        #endregion

//        #region "Private Methods"

//        private string GetFullyQualifiedName(string name)
//        {
//            return DatabaseOwner + ObjectQualifier + ModuleQualifier + name;
//        }

//        private object GetNull(object Field)
//        {
//            return DotNetNuke.Common.Utilities.Null.GetNull(Field, DBNull.Value);
//        }

//        #endregion

//        #region "Public Methods"

//        public override IDataReader GetGuestbookCSs(int ModuleId)
//        {
//            return (IDataReader)SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("GetGuestbookCSs"), ModuleId);
//        }

//        public override IDataReader GetGuestbookCS(int ModuleId, int ItemId)
//        {
//            return (IDataReader)SqlHelper.ExecuteReader(ConnectionString, GetFullyQualifiedName("GetGuestbookCS"), ModuleId, ItemId);
//        }

//        public override void AddGuestbookCS(int ModuleId, string Content, int UserId)
//        {
//            SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("AddGuestbookCS"), ModuleId, Content, UserId);
//        }

//        public override void UpdateGuestbookCS(int ModuleId, int ItemId, string Content, int UserId)
//        {
//            SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("UpdateGuestbookCS"), ModuleId, ItemId, Content, UserId);
//        }

//        public override void DeleteGuestbookCS(int ModuleId, int ItemId)
//        {
//            SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("DeleteGuestbookCS"), ModuleId, ItemId);
//        }

//        #endregion

//    }
//}