// 
// DotNetNukeŽ - http://www.dotnetnuke.com 
// Copyright (c) 2002-2010 
// by DotNetNuke Corporation 
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
// to permit persons to whom the Software is furnished to do so, subject to the following conditions: 
// 
// The above copyright notice and this permission notice shall be included in all copies or substantial portions 
// of the Software. 
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
// TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE. 
// 

using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

using DotNetNuke;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;

namespace Pelsoft.Modules.GuestbookCS
{

    /// ----------------------------------------------------------------------------- 
    /// <summary> 
    /// The ViewGuestbookCS class displays the content 
    /// </summary> 
    /// <remarks> 
    /// </remarks> 
    /// <history> 
    /// </history> 
    /// ----------------------------------------------------------------------------- 
    partial class ViewGuestbookCS : PortalModuleBase, IActionable
    {

        #region "Event Handlers"

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Page_Load runs when the control is loaded 
        /// </summary> 
        /// ----------------------------------------------------------------------------- 
        protected void Page_Load(object sender, System.EventArgs e)
        {
            try
            {
                GuestbookCSController objGuestbookCSs = new GuestbookCSController();
                List<GuestbookEntryInfo> colGuestbookCSs;

                // get the content from the GuestbookCS table 
                colGuestbookCSs = objGuestbookCSs.GetAllEntries(ModuleId);

                if (colGuestbookCSs.Count == 0)
                {
                    // add the content to the GuestbookCS table 
                    GuestbookEntryInfo objGuestbookCS = new GuestbookEntryInfo();
                    objGuestbookCS.ModuleId = ModuleId;
                    objGuestbookCS.SubmitterComment = Localization.GetString("DefaultContent", LocalResourceFile);
                    objGuestbookCS.SubmitterName  = this.UserId.ToString();
                    objGuestbookCSs.InsertGuestbookEntry(objGuestbookCS);
                    // get the content from the GuestbookCS table 
                    //colGuestbookCSs = objGuestbookCSs.GetGuestbookCSs(ModuleId);
                }

                // bind the content to the repeater 
                lstContent.DataSource = colGuestbookCSs;
                lstContent.DataBind();
            }

            catch (Exception exc)
            {
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        /// ----------------------------------------------------------------------------- 
        /// <summary>
        /// lstContent_ItemDataBound runs when items are bound. Here the 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// ----------------------------------------------------------------------------- 
        protected void lstContent_ItemDataBound(object sender, System.Web.UI.WebControls.DataListItemEventArgs e)
        {
            string strContent = "";

            // add content to template 
            if (!string.IsNullOrEmpty((string)Settings["template"]))
            {
                strContent = (string)Settings["template"];
                ArrayList objProperties = CBO.GetPropertyInfo(typeof(GuestbookEntryInfo));
                foreach (PropertyInfo objPropertyInfo in objProperties)
                {
                    strContent = strContent.Replace("[" + objPropertyInfo.Name.ToUpper() + "]", Server.HtmlDecode(DataBinder.Eval(e.Item.DataItem, objPropertyInfo.Name).ToString()));
                }
            }
            else
            {
                strContent = DataBinder.Eval(e.Item.DataItem, "Content").ToString();
            }

            // assign the content 
            Label lblContent = (Label)e.Item.FindControl("lblContent");
            lblContent.Text = strContent;
        }

        #endregion

        #region "Optional Interfaces"

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Registers the module actions required for interfacing with the portal framework 
        /// </summary> 
        /// <value></value> 
        /// <returns></returns> 
        /// <remarks></remarks> 
        /// <history> 
        /// </history> 
        /// ----------------------------------------------------------------------------- 
        public ModuleActionCollection ModuleActions
        {
            get
            {
                ModuleActionCollection Actions = new ModuleActionCollection();
                Actions.Add(GetNextActionID(), Localization.GetString(ModuleActionType.AddContent, this.LocalResourceFile),
                   ModuleActionType.AddContent, "", "add.gif", EditUrl(), false, DotNetNuke.Security.SecurityAccessLevel.Edit,
                    true, false);
                return Actions;
            }
        }

        #endregion

    }

}