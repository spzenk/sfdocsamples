using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShoppingCart;

namespace ShoppingCart
{
    public partial class buycart : System.Web.UI.Page
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
                    Msg.Visible = true;
                else Msg.Visible = false;
                Decimal total = 0;
                GridView_Prod.DataSource = (List<ProductBE>)this.Page.Session["CARRO"];
                
                foreach (ProductBE p in list)
                {
                    total += p.Price;
                }
                txtTotal.Value = total.ToString();
                GridView_Prod.DataBind();

            }
            else
                Msg.Visible = true;


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