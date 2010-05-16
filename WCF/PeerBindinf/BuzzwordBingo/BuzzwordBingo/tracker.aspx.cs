using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class tracker : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string target = Request.QueryString["file"];
        string via = Request.QueryString["via"];
        string[] tokens = target.Split(new char[] {'\\'});
        string file = tokens[tokens.Length-1];

        DateTime now = DateTime.Now;
        string filename = now.Month.ToString() + now.Day.ToString() + now.Year.ToString();

        //string writePath = Server.MapPath("download\\downloadtracker.txt");
        string writePath = Server.MapPath("download\\" + filename + ".txt");

        try
        {
            StreamWriter writer = new StreamWriter(writePath , true);
            writer.WriteLine("{0}, {1}, {2}", DateTime.Now.ToString(), file, via);
            writer.Dispose();
            Response.Redirect(target);
        }
        catch
        {
            Response.Write(writePath);
        }

        
    }
}
