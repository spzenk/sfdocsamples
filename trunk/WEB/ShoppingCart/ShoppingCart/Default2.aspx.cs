using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShoppingCart;

namespace WebApplication1
{
    public partial class Default2 : System.Web.UI.Page
    {
        public List<ProductBE> _Catalogo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Page.Session["CARRO"] == null)
                    this.Page.Session["CARRO"] = new List<ProductBE>();
                int? idSubcategoria = null;

                if (Request.QueryString["id"] != null)
                {
                    idSubcategoria = Convert.ToInt32(Request.QueryString["id"].ToString());
                    FillGrid(idSubcategoria);
                }


                



            }
          
        }




        void FillGrid(int? idCategoria)
        {
            _Catalogo = ProductsDelfinDAC.Retrive_Produts(idCategoria.Value);

            if (this.Page.Session["CARRO"] != null)
            {
                foreach (ProductBE i in (List<ProductBE>)this.Page.Session["CARRO"])
                {
                    var itemCatalogo = _Catalogo.Where(p => p.Id.Equals(i.Id)).FirstOrDefault();
                    if (itemCatalogo != null)
                        itemCatalogo.Count = i.Count;
                }
            }

            GridView_Prod.DataSource = _Catalogo;
            GridView_Prod.DataBind();
        }

        protected void GridView_Prod_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GridView_Prod_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            TextBox txtNumberToBuy = (TextBox)e.Row.FindControl("txtNumberToBuy");
            if (txtNumberToBuy != null)
                txtNumberToBuy.Text = "0";

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Get values for calculation
                TextBox txtQuantity = null;//new TextBox();

                HiddenField hfPrice = new HiddenField();
                //NumericUpDownExtender spin = null;
                //HiddenField hfTotal = new HiddenField();
                ProductBE wItem = ((ProductBE)e.Row.DataItem);

                txtQuantity = (TextBox)e.Row.FindControl("txtNumberToBuy"); // quantity


                //string txtId = GridViewBoundFieldHelper.GetText(e.Row, "Id");
                //string wPrice = GridViewBoundFieldHelper.GetText(e.Row, "Price");
                //spin = (NumericUpDownExtender)e.Row.FindControl("txtNumberToBuy_NumericUpDownExtender"); // id
                txtQuantity.Text = wItem.Count.ToString();

                //hfMealPrice = (HiddenField)e.Row.FindControl("hfMealPrice"); // meal price
                //hfTotal = (HiddenField)e.Row.FindControl("hfTotal"); //total




                txtQuantity.Attributes.Add("onchange", "javascript:Add('" +
                    txtQuantity.ClientID + "','" +
                    wItem.Id.ToString() + "','" +
                    wItem.Price.ToString() + "','" +
                    wItem.Description + "','" +
                    e.Row.DataItemIndex +
                    "');");

                //Set up javascript array
                //JSArray += "myArray[" + counter.ToString() + "] = document.getElementById('" + hfTotal.ClientID + "').value;" + Environment.NewLine;

                //counter to maintain the js array index
                //counter += 1;

            }
        }

        



    }

}