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
using System.Data.SqlClient;

namespace Default
{
	/// <summary>
	/// Summary description for WebForm2.
	/// </summary>
	public class WebForm2 : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			string strSQLQuery;
			SqlConnection adoSqlConn =new SqlConnection("data source=blr-ec-112844;initial catalog=master;password=sa;persist security info=True;user id=sa;");
			SqlCommand sqlcmdCommand = new SqlCommand("SELECT count(*) FROM testlang WHERE userfname=N'" + Request.Form["txtFName"] + "' AND userlname=N'" + Request.Form["txtLName"] + "'", adoSqlConn);
			SqlDataReader adosqlDataReader;
	        adoSqlConn.Open();
			sqlcmdCommand.CommandText = "SELECT count(*) FROM testlang WHERE userfname=N'" + Request.Form["txtFName"] + "' AND userlname=N'" + Request.Form["txtLName"] + "'";
			adosqlDataReader = sqlcmdCommand.ExecuteReader();
			adosqlDataReader.Read();

			if (adosqlDataReader.Read()==false)
			{
				adosqlDataReader.Close();
				Response.Write("<B>Thank You for Registering</B>");
				//Format the SQL Query to Insert Data.
				strSQLQuery = "INSERT INTO testlang (userfname, userlname, userlangid,useraddress) VALUES(N'" + Request.Form["txtFName"] + "', N'" + Request.Form["txtLName"] + "','" + Request.QueryString["lang"] + "', N'" + Request.Form["txtAddress"] + "')";
					//Insert the New Record.
					sqlcmdCommand.CommandText = strSQLQuery;
				sqlcmdCommand.ExecuteNonQuery();
			}
			else
				Response.Write("<B>You have already registered</B>");

        adosqlDataReader.Close();

        //Format the SQL Query to Get Data.
        strSQLQuery = "SELECT UID, userfname, userlname, userlangid,useraddress FROM testlang WHERE userlangid='" + Request.QueryString["lang"] + "'";
        //Response.Write(strSQLQuery)

        //Get All the records satisfying the LangID.
        sqlcmdCommand.CommandText = strSQLQuery;
        adosqlDataReader = sqlcmdCommand.ExecuteReader();
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
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
