using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using System.Xml;

namespace ShoppingCart
{
    public partial class _Default : System.Web.UI.Page
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
                    String idCategoria = Request.QueryString["id"].ToString();

                    idSubcategoria = Convert.ToInt32(idCategoria.Split('.')[0]);
                    FillGrid(idSubcategoria);
                }


                //FillCat(idSubcategoria);

               

            }
            if (this.IsCallback)
            {

            }

        }


            [System.Web.Services.WebMethod]
        public void ClearGrid()
        {
            FillGrid(null);
        }
       

        void FillGrid(int? idCategoria)
        {
            _Catalogo = ProductsDelfinDAC.Retrive_Produts(idCategoria.Value);
         
            if (this.Page.Session["CARRO"] != null)
            {
                foreach (ProductBE i in (List<ProductBE>)this.Page.Session["CARRO"])
                {
                    var itemCatalogo = _Catalogo.Where(p => p.Id.Equals(i.Id)).FirstOrDefault();
                    if (itemCatalogo!=null)
                        itemCatalogo.Count = i.Count;
                }
            }

            GridView_Prod.DataSource = _Catalogo;
            GridView_Prod.DataBind();
        }
        void Fill_Catalogo()
        {
            _Catalogo = new List<ProductBE>();


            TableRow row = null;
            TableCell tCell;
            AjaxControlToolkit.NumericUpDownExtender nSpin = null;
            
            System.Web.UI.WebControls.TextBox txt;
            foreach (ProductBE h in _Catalogo)
            {
                row = new TableRow();
                row.Height = 60;


                tCell = new TableCell();
                txt = new TextBox();
                nSpin = new AjaxControlToolkit.NumericUpDownExtender();

                tCell.Width = 60;
                

                nSpin.Width = 60;


                txt.ID = String.Concat("txt_", h.Id.ToString());
                txt.Width = 60;
                
                nSpin.TargetControlID = txt.ID;
                nSpin.Minimum = 0;
                nSpin.Maximum = 100;

                tCell.Controls.Add(nSpin);
                tCell.Controls.Add(txt);

                row.Cells.Add(tCell);



                tCell = new TableCell();
                tCell.Text = h.Description;




                row.Cells.Add(tCell);
                //ProductsTable.Rows.Add(row);
            }
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

       // #region Tree vie


       // private void FillCat(int? idSubcategoria)
       // {
       //     ProductCategotyBEList categories = ProductsDelfinDAC.Retrive_Categories();
       //     TreeViewBind(this.trvCategories, categories, null);
       //     this.trvCategories.CollapseAll();
       //     if (idSubcategoria.HasValue)
       //     {
       //         ExpandCategory(this.trvCategories.Nodes, idSubcategoria.Value);
       //     }
       //     this.trvCategories.DataBind();




       // }

       // void ExpandCategory(TreeNodeCollection nodes, int idSubcategoria)
       // {
           
       //     foreach (TreeNode node in nodes)
       //     {
                
       //         if (node.Value.Equals(idSubcategoria.ToString()))
       //         //if (Convert.ToInt32(node.Value.Split('.')[0]).Equals(idSubcategoria) && node.Parent != null)
       //         {
       //             //node.Parent.Expand();
       //             TryExpandParents(node);
       //             return;
       //         }

       //         if (node.ChildNodes.Count > 0)
       //         {
       //             ExpandCategory(node.ChildNodes, idSubcategoria);
       //         }

       //     }
       // }
       // void TryExpandParents(TreeNode node)
       // {

       //     if (node.Parent != null)
       //     {
       //         node.Parent.Expand();
       //         TryExpandParents(node.Parent);
       //     }

       // }

       //     /// <summary>
       ///// TreeViewBind() method, is use to load an XML string via XmlDocument
       ///// object, and convert it to XML Object. Binding object to TreeView
       ///// data source.
       ///// </summary>
       //private void TreeViewBind(TreeView trv , ProductCategotyBEList categories,ProductCategotyBEList subcategorias)
       //{
       //    try
       //    {
       //        TreeNode nodeTree = null;
       //        foreach (ProductCategotyBE cat in categories.Where(p=>p.ParentId.Equals("0")))
       //        {
       //            nodeTree = new TreeNode(cat.Text.Trim(), cat.Id);
       //            nodeTree.SelectAction = TreeNodeSelectAction.Expand;
       //            nodeTree.Target = "Default.aspx";
       //            AddSubcategories(nodeTree, cat.Id, categories);
       //            trv.Nodes.Add(nodeTree);
       //        }
       //    }
           
       //    catch (Exception ex)
       //    {
       //        Response.Write(ex.Message);
       //        trv.Nodes.Clear();
       //    }
       //}
      
       // /// <summary>
       // /// 
       // /// </summary>
       // /// <param name="parent"></param>
       // /// <param name="parentId"></param>
       // /// <param name="categories"></param>
       //private void AddSubcategories(TreeNode parent, string parentId, ProductCategotyBEList categories)
       //{

       //    List<ProductCategotyBE> childsBE = categories.Where(p => p.ParentId.Equals(parentId)).ToList();
       //    TreeNode nodeTree_Child = null;
       //    foreach (ProductCategotyBE childCatatBE in childsBE)
       //    {
       //        if (childCatatBE.Id == "102")
       //        {
       //            int i=0;
       //        }
       //        nodeTree_Child = new TreeNode(childCatatBE.Text, childCatatBE.Id);
       //        if (childCatatBE.Level == 3)
       //            nodeTree_Child.NavigateUrl = "Default.aspx?id=" + childCatatBE.Id + "";
       //        else
       //            nodeTree_Child.SelectAction = TreeNodeSelectAction.Expand;

       //        parent.ChildNodes.Add(nodeTree_Child);
       //        if (categories.Any(p => p.ParentId.Equals(childCatatBE.Id)) == true)
       //        {

       //            AddSubcategories(nodeTree_Child, childCatatBE.Id, categories);
       //        }

       //    }
       //}
    
       // #endregion

       protected void trvCategories_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
       {
           if (e.Node.Parent.Value !="0" )
               return;
       }

      
    }
}
