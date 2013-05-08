using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingCart
{
    public partial class viewbuy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                FillGrid();
            }
        }


        void FillGrid()
        {
            List<ProductBE> list = (List<ProductBE>)this.Page.Session["CARRO"];
            if (list != null)
            {
                if (list.Count == 0)
                    msg.Visible = true;
                else msg.Visible = false;
                Decimal total = 0;
                GridView_Prod.DataSource = (List<ProductBE>)this.Page.Session["CARRO"];
                GridView_Prod.DataBind();
                foreach (ProductBE p in list)
                {
                    if (p.Price.HasValue)
                        total += p.Price.Value;
                }
                txtTotal.Value = total.ToString();
                
            }
            else
                msg.Visible = true;


        }
         protected void GridView_Prod_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "remove")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                List<ProductBE> list = (List<ProductBE>)this.Page.Session["CARRO"];
                if (list != null)
                {
                    ProductBE i = list.Where(p => p.Id.Equals(id)).FirstOrDefault();
                    if (i != null)
                    {
                        list.Remove(i);
                         FillGrid();
                    }
                }
            }
        }

         protected void GridView_Prod_RowDataBound(object sender, GridViewRowEventArgs e)
         { }
    }
}