using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DevExp_CloudTag
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string sql = "select * from country";
            //if (ddlFilter.SelectedItem.Value.ToString() != "")
            //    sql += " where " + ddlFilter.SelectedItem.Value.ToString();
            //AccessDataSource1.SelectCommand = sql;
            //ASPxCloudControl1.ValueField = ddlValueField.SelectedItem.Value.ToString();
        }

        protected void ASPxCloudControl1_ItemDataBound(object source, DevExpress.Web.ASPxCloudControl.CloudControlItemEventArgs e)
        {
            e.Item.Text = e.Item.Text.ToUpper();

        }

        protected void ASPxCloudControl1_ItemClick(object source, DevExpress.Web.ASPxCloudControl.CloudControlItemEventArgs e)
        {

        }
    }

    public class DAC
    {

        public static List<Elemento> RetriveTags()
        {
            List<Elemento> list = new List<Elemento>();

            Elemento t = new Elemento();
            t.Text = "Allus";
            t.Url = "www.allus.com.ar";
            t.Priority = 7;
            list.Add(t);
            t = new Elemento();
            t.Text = "DevExpress";
            t.Url = "www.devexpress.com";
            t.Priority = 12;
            list.Add(t);
            t = new Elemento();
            t.Text = "Honda";
            t.Url = "www.Honda.com";
            t.Priority = 4;
            list.Add(t);

            t = new Elemento();
            t.Text = "MOTOROLA";
            t.Url = "www.motorola.com";
            t.Priority = 12;
            list.Add(t);

            t = new Elemento();
            t.Text = "Sony";
            t.Url = "www.Sony.com";
            t.Priority = 7;
            list.Add(t);

            t = new Elemento();
            t.Text = "samsung";
            t.Url = "www.samsung.com";
            t.Priority = 4;
            list.Add(t);

            t = new Elemento();
            t.Text = "IBM - Argentina";
            t.Url = "www.ibm.com/ar/es";
            t.Priority = 23;
            list.Add(t);

            t = new Elemento();
            t.Text = "facebook";
            t.Url = "https://www.facebook.com/";
            t.Priority = 19;
            list.Add(t);
            return list;

        }

    }

    public class Elemento
    {
       public String Text{ get;set;}
       public int Priority { get; set; }
       public String Url { get; set; }
    }

}
