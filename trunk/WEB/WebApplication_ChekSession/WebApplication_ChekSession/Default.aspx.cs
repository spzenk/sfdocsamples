using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace WebApplication_ChekSession
{
    public partial class _Default : System.Web.UI.Page
    {
        public string strUsers;
        
        protected void Page_Load(object sender, EventArgs e)
        { 

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            Dictionary<string, DateTime> activeUsers = (Dictionary<string, DateTime>)Application["activeUsers"];
            if (activeUsers.ContainsKey(txtUserName.Text.Trim()))
            {
                Label1.Text = "Ya ingresaste";
                return;
            }
            Label1.Text = "";
            activeUsers.Add(txtUserName.Text.Trim(), System.DateTime.Now);


           
        }
    }
}
