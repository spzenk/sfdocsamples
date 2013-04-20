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
                Decimal total = 0;
                GridView_Prod.DataSource = (List<ProductBE>)this.Page.Session["CARRO"];
                GridView_Prod.DataBind();
                foreach (ProductBE p in list)
                {
                    total += p.Price;
                }
                txtTotal.Value = total.ToString();
            }


        }
         protected void GridView_Prod_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
        }

         protected void GridView_Prod_RowDataBound(object sender, GridViewRowEventArgs e)
         { }
    }
}