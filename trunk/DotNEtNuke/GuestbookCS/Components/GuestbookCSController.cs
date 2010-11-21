using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using DotNetNuke;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace Pelsoft.Modules.GuestbookCS
{
    /// <summary>
    /// 
    /// </summary>
    public class GuestbookCSController
    {
        SqlDataProvider _SqlDataProvider = null;

        public GuestbookCSController()
        {
            _SqlDataProvider = new SqlDataProvider();
        }
        #region Public Methods
        /// <summary>
        /// This method will insert a guestbook entry to the system
        /// </summary>
        /// < param name=”oInfo” > The hydrated information object < /param >
        public void InsertGuestbookEntry(GuestbookEntryInfo oInfo)
        {
            _SqlDataProvider.InsertGuestbookEntry(oInfo.ModuleId,
            oInfo.SubmitterName, oInfo.SubmitterWebsite,
            oInfo.SubmitterComment,
            oInfo.SubmissionDate, oInfo.IsApproved);
        }
        /// <summary>
        /// This method will approve a guestbook entry
        /// </summary>
        /// < param name=”moduleId” > The id of the module used to modify theentries < /param >
        /// < param name=”entryId” > The id of the entry < /param >
        public void ApproveGuestbookEntry(int moduleId, int entryId)
        {
            _SqlDataProvider.ApproveGuestbookEntry(moduleId, entryId);
        }
        /// <summary>
        /// This method will delete a guestbook entry
        /// </summary>
        /// < param name=”moduleId” > The id of the module used to delete theentries < /param >
        /// < param name=”entryId” > The id of the entry < /param >
        public void DeleteGuestbookEntry(int moduleId, int entryId)
        {
            _SqlDataProvider.DeleteGuestbookEntry(moduleId, entryId);
        }
        /// <summary>
        /// This method will get the listing of all approved entries
        /// </summary>
        /// /// < param name=”moduleId” > The instance to get entries for < /param >
        /// < returns > The hydrated collection of information objects < /returns >
        public List<GuestbookEntryInfo> GetApprovedEntries(int moduleId)
        {
            return CBO.FillCollection<GuestbookEntryInfo>(_SqlDataProvider.GetApprovedEntries(moduleId));
        }
        /// <summary>
        /// This method will get the listing of all entries
        /// </summary>
        /// < param name=”moduleId” > The instance to get entries for < /param >
        /// < returns > The hydrated collection of information objects < /returns >
        public List<GuestbookEntryInfo> GetAllEntries(int moduleId)
        {
            return CBO.FillCollection<GuestbookEntryInfo>(_SqlDataProvider.GetAllEntries(moduleId));
        }
        #endregion
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
//using System.Configuration;
//using System.Data;
//using System.Xml;
//using System.Web;
//using System.Collections.Generic;

//using DotNetNuke;
//using DotNetNuke.Common;
//using DotNetNuke.Common.Utilities;
//using DotNetNuke.Services.Search;
//using DotNetNuke.Entities.Modules;

//namespace Pelsoft.Modules.GuestbookCS
//{

//    /// ----------------------------------------------------------------------------- 
//    /// <summary> 
//    /// The Controller class for GuestbookCS 
//    /// </summary> 
//    /// <remarks> 
//    /// </remarks> 
//    /// <history> 
//    /// </history> 
//    /// ----------------------------------------------------------------------------- 
//    public class GuestbookCSController : ISearchable, IPortable
//    {

//        #region "Public Methods"

//        /// ----------------------------------------------------------------------------- 
//        /// <summary> 
//        /// gets an object from the database 
//        /// </summary> 
//        /// <remarks> 
//        /// </remarks> 
//        /// <param name="ModuleId">The Id of the module</param> 
//        /// <history> 
//        /// </history> 
//        /// ----------------------------------------------------------------------------- 
//        public List<GuestbookCSInfo> GetGuestbookCSs(int ModuleId)
//        {

//            return CBO.FillCollection<GuestbookCSInfo>(DataProvider.Instance().GetGuestbookCSs(ModuleId));

//        }

//        /// ----------------------------------------------------------------------------- 
//        /// <summary> 
//        /// gets an object from the database 
//        /// </summary> 
//        /// <remarks> 
//        /// </remarks> 
//        /// <param name="ModuleId">The Id of the module</param> 
//        /// <param name="ItemId">The Id of the item</param> 
//        /// <history> 
//        /// </history> 
//        /// ----------------------------------------------------------------------------- 
//        public GuestbookCSInfo GetGuestbookCS(int ModuleId, int ItemId)
//        {

//            return (GuestbookCSInfo)CBO.FillObject(DataProvider.Instance().GetGuestbookCS(ModuleId, ItemId), typeof(GuestbookCSInfo));

//        }

//        /// ----------------------------------------------------------------------------- 
//        /// <summary> 
//        /// adds an object to the database 
//        /// </summary> 
//        /// <remarks> 
//        /// </remarks> 
//        /// <param name="objGuestbookCS">The GuestbookCSInfo object</param> 
//        /// <history> 
//        /// </history> 
//        /// ----------------------------------------------------------------------------- 
//        public void AddGuestbookCS(GuestbookCSInfo objGuestbookCS)
//        {

//            if (objGuestbookCS.Content.Trim() != "")
//            {
//                DataProvider.Instance().AddGuestbookCS(objGuestbookCS.ModuleId, objGuestbookCS.Content, objGuestbookCS.CreatedByUser);
//            }

//        }

//        /// ----------------------------------------------------------------------------- 
//        /// <summary> 
//        /// saves an object to the database 
//        /// </summary> 
//        /// <remarks> 
//        /// </remarks> 
//        /// <param name="objGuestbookCS">The GuestbookCSInfo object</param> 
//        /// <history> 
//        /// </history> 
//        /// ----------------------------------------------------------------------------- 
//        public void UpdateGuestbookCS(GuestbookCSInfo objGuestbookCS)
//        {

//            if (objGuestbookCS.Content.Trim() != "")
//            {
//                DataProvider.Instance().UpdateGuestbookCS(objGuestbookCS.ModuleId, objGuestbookCS.ItemId, objGuestbookCS.Content, objGuestbookCS.CreatedByUser);
//            }

//        }

//        /// ----------------------------------------------------------------------------- 
//        /// <summary> 
//        /// deletes an object from the database 
//        /// </summary> 
//        /// <remarks> 
//        /// </remarks> 
//        /// <param name="ModuleId">The Id of the module</param> 
//        /// <param name="ItemId">The Id of the item</param> 
//        /// <history> 
//        /// </history> 
//        /// ----------------------------------------------------------------------------- 
//        public void DeleteGuestbookCS(int ModuleId, int ItemId)
//        {

//            DataProvider.Instance().DeleteGuestbookCS(ModuleId, ItemId);

//        }

//        #endregion

//        #region "Optional Interfaces"

//        /// ----------------------------------------------------------------------------- 
//        /// <summary> 
//        /// GetSearchItems implements the ISearchable Interface 
//        /// </summary> 
//        /// <remarks> 
//        /// </remarks> 
//        /// <param name="ModInfo">The ModuleInfo for the module to be Indexed</param> 
//        /// <history> 
//        /// </history> 
//        /// ----------------------------------------------------------------------------- 
//        public DotNetNuke.Services.Search.SearchItemInfoCollection GetSearchItems(ModuleInfo ModInfo)
//        {

//            SearchItemInfoCollection SearchItemCollection = new SearchItemInfoCollection();

//            List<GuestbookCSInfo> colGuestbookCSs = GetGuestbookCSs(ModInfo.ModuleID);
//            foreach (GuestbookCSInfo objGuestbookCS in colGuestbookCSs)
//            {
//                SearchItemInfo SearchItem = new SearchItemInfo(ModInfo.ModuleTitle, objGuestbookCS.Content, objGuestbookCS.CreatedByUser, objGuestbookCS.CreatedDate, ModInfo.ModuleID, objGuestbookCS.ItemId.ToString(), objGuestbookCS.Content, "ItemId=" + objGuestbookCS.ItemId.ToString());
//                SearchItemCollection.Add(SearchItem);
//            }

//            return SearchItemCollection;

//        }

//        /// ----------------------------------------------------------------------------- 
//        /// <summary> 
//        /// ExportModule implements the IPortable ExportModule Interface 
//        /// </summary> 
//        /// <remarks> 
//        /// </remarks> 
//        /// <param name="ModuleID">The Id of the module to be exported</param> 
//        /// <history> 
//        /// </history> 
//        /// ----------------------------------------------------------------------------- 
//        public string ExportModule(int ModuleID)
//        {

//            string strXML = "";

//            List<GuestbookCSInfo> colGuestbookCSs = GetGuestbookCSs(ModuleID);
//            if (colGuestbookCSs.Count != 0)
//            {
//                strXML += "<GuestbookCSs>";
//                foreach (GuestbookCSInfo objGuestbookCS in colGuestbookCSs)
//                {
//                    strXML += "<GuestbookCS>";
//                    strXML += "<content>" + XmlUtils.XMLEncode(objGuestbookCS.Content) + "</content>";
//                    strXML += "</GuestbookCS>";
//                }
//                strXML += "</GuestbookCSs>";
//            }

//            return strXML;

//        }

//        /// ----------------------------------------------------------------------------- 
//        /// <summary> 
//        /// ImportModule implements the IPortable ImportModule Interface 
//        /// </summary> 
//        /// <remarks> 
//        /// </remarks> 
//        /// <param name="ModuleID">The Id of the module to be imported</param> 
//        /// <param name="Content">The content to be imported</param> 
//        /// <param name="Version">The version of the module to be imported</param> 
//        /// <param name="UserId">The Id of the user performing the import</param> 
//        /// <history> 
//        /// </history> 
//        /// ----------------------------------------------------------------------------- 
//        public void ImportModule(int ModuleID, string Content, string Version, int UserId)
//        {

//            XmlNode xmlGuestbookCSs = Globals.GetContent(Content, "GuestbookCSs");
//            foreach (XmlNode xmlGuestbookCS in xmlGuestbookCSs.SelectNodes("GuestbookCS"))
//            {
//                GuestbookCSInfo objGuestbookCS = new GuestbookCSInfo();
//                objGuestbookCS.ModuleId = ModuleID;
//                objGuestbookCS.Content = xmlGuestbookCS.SelectSingleNode("content").InnerText;
//                objGuestbookCS.CreatedByUser = UserId;
//                AddGuestbookCS(objGuestbookCS);
//            }

//        }

//        #endregion

//    }
//}