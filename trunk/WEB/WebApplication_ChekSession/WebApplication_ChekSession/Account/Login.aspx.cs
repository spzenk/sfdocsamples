using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication_ChekSession.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {

        }

        protected void LoginUser_Authenticate(object sender, AuthenticateEventArgs e)
        {
//            Dictionary<string, DateTime> activeUsers = (Dictionary<string, DateTime>)Application["activeUsers"];


            
        }

        protected void LoginUser_LoggedIn(object sender, EventArgs e)
        {

            Dictionary<string, DateTime> activeUsers = (Dictionary<string, DateTime>)Application["activeUsers"];
            activeUsers.Add(LoginUser.UserName, System.DateTime.Now);
            
        }

        protected void LoginUser_LoggingIn(object sender, LoginCancelEventArgs e)
        {
            Dictionary<string, DateTime> activeUsers = (Dictionary<string, DateTime>)Application["activeUsers"];

            if (activeUsers.ContainsKey(LoginUser.UserName))
            {
                this.LoginUser.FailureText = "Ya ingresaste";
            }
        }

    }
}
