using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingCart
{
    public partial class Defaul3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Page.Session["CARRO"] == null)
                    this.Page.Session["CARRO"] = new List<ProductBE>();
                int? idSubcategoria = null;

                if (Request.QueryString["id"] != null)
                    idSubcategoria = Convert.ToInt32(Request.QueryString["id"].ToString());

                //FillCat(idSubcategoria);
            }
        }
        
    }
}