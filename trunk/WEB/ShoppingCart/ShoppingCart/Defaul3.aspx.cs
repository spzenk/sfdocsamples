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
        public List<ProductBE> _Catalogo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Page.Session["CARRO"] == null)
                    this.Page.Session["CARRO"] = new List<ProductBE>();
                int? idSubcategoria = null;

                if (Request.QueryString["id"] != null)
                    idSubcategoria = Convert.ToInt32(Request.QueryString["id"].ToString());

                //FillGrid(idSubcategoria);
            }

            //ShoppingCart.Code.siteMap site = ProductsDelfinDAC.Retrive_SiteMap();
            //String ss = ProductsDelfinDAC.Retrive_Categories().GetXml();
         
            //XmlDataSource1.DataBind();
            //String ss = site.GetXml();
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
                txtQuantity.ReadOnly = true;

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
                    wItem.Marca + "','" +
                    e.Row.DataItemIndex +
                    "');");

                //Set up javascript array
                //JSArray += "myArray[" + counter.ToString() + "] = document.getElementById('" + hfTotal.ClientID + "').value;" + Environment.NewLine;

                //counter to maintain the js array index
                //counter += 1;

            }
        }
        void FillGrid(int? idCategoria)
        {
            if (idCategoria.HasValue == false) return;
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

        protected void trvCategories_SelectedNodeChanged(object sender, EventArgs e)
        {
           string idSubcategoria = trvCategories.SelectedNode.Value;
                //idSubcategoria = Convert.ToInt32(Request.QueryString["id"].ToString());
        }

        protected void trvCategories_TreeNodeDataBound(object sender, TreeNodeEventArgs e)
        {
            foreach (TreeNode node in trvCategories.Nodes)
            {
               
                //SetAction(node);
                PrintNodesRecursive(node);
            }
        }
        public void PrintNodesRecursive(TreeNode oParentNode)
        {
            if (oParentNode.Text.Trim() == "Bebidas")
            {
            }
           // Start recursion on all subnodes.
            foreach (TreeNode oSubNode in oParentNode.ChildNodes)
            {
                SetAction(oSubNode);
                if (oSubNode.ChildNodes.Count!=0)
                 PrintNodesRecursive(oSubNode);
            }
        }

      


        void SetAction(TreeNode node)
        {
            //if (node.Text.Contains("Rotisería") || node.Text.Contains("Carne"))
            //{
            //    node.SelectAction = TreeNodeSelectAction.Expand;
            //}
            if (node.NavigateUrl.Equals(""))
                node.SelectAction = TreeNodeSelectAction.Expand;
            else
                node.SelectAction = TreeNodeSelectAction.Select;
        }

        protected void trvCategories_TreeNodeExpanded(object sender, TreeNodeEventArgs e)
        {

        }

       
    }
}