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
	/// Summary description for MyInfo.
	/// </summary>
	public class MyInfo : System.Web.UI.Page
	{
		public ResourceManager rm;
		private void Page_Load(object sender, System.EventArgs e)
		{
			string SelectedCulture;
			Response.Write("<P>Your Language as  = " + Request.QueryString["lang"] + "</P>");
				if (Request.QueryString["lang"] != "" )
				{
					SelectedCulture= Request.QueryString["lang"];
					Thread.CurrentThread.CurrentCulture = new CultureInfo(SelectedCulture);
					Thread.CurrentThread.CurrentUICulture = new CultureInfo(SelectedCulture);
																																	  }
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
