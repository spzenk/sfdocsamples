using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxTreeList;

namespace UsoTreeList
{
    public partial class UC_MainTreeView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void treeList_CustomCallback(object sender, DevExpress.Web.ASPxTreeList.TreeListCustomCallbackEventArgs e)
        {
          
        }
        protected void treeList_CustomDataCallback(object sender, TreeListCustomDataCallbackEventArgs e)
        {
            string key = e.Argument.ToString();
            TreeListNode node = treeList.FindNodeByKeyValue(key);
            e.Result = GetEntryText(node);
            
        }
        protected string GetEntryText(TreeListNode node)
        {
            if (node != null)
            {
                string text = node["Url"].ToString();
                return text.Trim().Replace("\r\n", "<br />");
            }
            return string.Empty;
        }
        //TODO:para escribir con JS en un elemento de la pagina
        //document.getElementById('messageText').innerHTML = e.result;
    }
}