using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Threading;
using System.Resources;


namespace Default
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		public ResourceManager rm;

		//public System.Resources.ResourceManager rm = new System.Resources.ResourceManager();
		private void Page_Load(object sender, System.EventArgs e)
		{
			 Thread.CurrentThread.CurrentCulture = new CultureInfo(Request.UserLanguages[0]);
			 Thread.CurrentThread.CurrentUICulture = new CultureInfo(Request.UserLanguages[0]);
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			rm = (ResourceManager)Application["RM"];
			base.OnInit(e);
			
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
