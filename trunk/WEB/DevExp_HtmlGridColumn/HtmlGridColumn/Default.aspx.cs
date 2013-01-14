using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxGridView;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        string i1 = "<div style=\"color:#1F1F1D\">  <h3>Muestra de texto codificado</h3>  <p style=\"font-size:14px;color:#760B26\">Debes poner  EncodeHtml.</p></div>";
        protected void Page_Load(object sender, EventArgs e)
        {
            ASPxGridView1.DataBound += new EventHandler(ASPxGridView1_DataBound);
            BuildData();
           
        }

        void ASPxGridView1_DataBound(object sender, EventArgs e)
        {
            ((GridViewDataTextColumn)ASPxGridView1.Columns[0]).PropertiesTextEdit.EncodeHtml = false;
            
        }

        public void BuildData()
        {
            System.Data.DataTable dtt = new System.Data.DataTable();
            dtt.Columns.Add("col1");
            System.Data.DataRow r = dtt.NewRow();
            r[0] ="<div style=\"color: #585858;font-size: 19px;\"> Hola mundo </div>";
            dtt.Rows.Add(r);

            r = dtt.NewRow();
            r[0] = i1;
            dtt.Rows.Add(r);

            ASPxGridView1.DataSource= dtt;

            ASPxGridView1.DataBind();

        }
    }
}
