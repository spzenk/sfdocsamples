using System;
using System.Collections.Generic;
using System.Web;

namespace Pelsoft.Modules.GuestbookCS
{
    public class GuestbookEntryInfo
    {
        #region Private Data Members
        private int _entryId;
        private int _moduleId;
        private string _submitterName;
        private string _submitterWebsite;
        private string _submitterComment;
        private DateTime _submissionDate;
        private bool _isApproved;
        #endregion

        #region Public Properties
        /// <summary>
        /// The unique identifier for an entry
        /// </summary>
        public int EntryId
        {
            get { return _entryId; }
            set { _entryId = value; }
        }
        /// <summary>
        /// The id of the module in which it is located
        /// </summary>
        public int ModuleId
        {
            get { return _moduleId; }
            set { _moduleId = value; }
        }
        /// <summary>
        /// The name of the submitter, as entered via the website
        /// </summary>
        public string SubmitterName
        {
            get { return _submitterName; }
            set { _submitterName = value; }
        }
        /// <summary>
        /// The website of the submitter, as entered via the website
        /// </summary>
        public string SubmitterWebsite
        {
            get { return _submitterWebsite; }
            set { _submitterWebsite = value; }
        }
        /// <summary>
        /// The submitter comments as entered via the website
        /// </summary>
        public string SubmitterComment
        {
            get { return _submitterComment; }
            set { _submitterComment = value; }
        }
        /// <summary >
        /// The date submitted
        /// </summary>
        public DateTime SubmissionDate
        {
            get { return _submissionDate; }
            set { _submissionDate = value; }
        }
        /// <summary >
        /// Is this entry approved?
        /// </summary>
        public bool IsApproved
        {
            get { return _isApproved; }
            set { _isApproved = value; }
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

//namespace Pelsoft.Modules.GuestbookCS
//{

//    /// ----------------------------------------------------------------------------- 
//    /// <summary> 
//    /// The Info class for GuestbookCS 
//    /// </summary> 
//    /// <remarks> 
//    /// </remarks> 
//    /// <history> 
//    /// </history> 
//    /// ----------------------------------------------------------------------------- 
//    public class GuestbookCSInfo
//    {
//        // local property declarations 
//        private int _ModuleId;
//        private int _ItemId;
//        private string _Content;
//        private int _CreatedByUser;
//        private DateTime _CreatedDate;
//        private string _CreatedByUserName;

//        // initialization 
//        public GuestbookCSInfo()
//        {
//        }

//        // public properties 
//        public int ModuleId
//        {
//            get { return _ModuleId; }
//            set { _ModuleId = value; }
//        }

//        public int ItemId
//        {
//            get { return _ItemId; }
//            set { _ItemId = value; }
//        }

//        public string Content
//        {
//            get { return _Content; }
//            set { _Content = value; }
//        }

//        public int CreatedByUser
//        {
//            get { return _CreatedByUser; }
//            set { _CreatedByUser = value; }
//        }

//        public DateTime CreatedDate
//        {
//            get { return _CreatedDate; }
//            set { _CreatedDate = value; }
//        }

//        public string CreatedByUserName
//        {
//            get { return _CreatedByUserName; }
//            set { _CreatedByUserName = value; }
//        }
//    }

//}