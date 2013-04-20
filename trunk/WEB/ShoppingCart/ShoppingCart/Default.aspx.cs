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
                if(Page.Session["CARRO"]==null)
                 this.Page.Session["CARRO"] = new List<ProductBE>(); 
                    //Fill_Catalogo();
                if(Request.QueryString["id"]!=null)
                {
                String idCategoria = Request.QueryString["id"].ToString();

                int id = Convert.ToInt32 (idCategoria.Split('.')[0]);
                FillGrid(id);
                }
                FillCat();

                
            }
            if (this.IsCallback)
            { 
                
            }

        }

       


        public void AddToCart(int numberToBuy, int id, decimal price, string description)
        {
            if (System.Web.HttpContext.Current.Session["CARRO"] != null)
            {
              var cart =  (List<ProductBE>)System.Web.HttpContext.Current.Session["CARRO"];
              
              var item = cart.Where(p => p.Id.Equals(id)).FirstOrDefault();
              if (item == null)
              {
                  item = new ProductBE();
                  item.Description = description;
                  item.Id = id;
                  item.Count = numberToBuy;
                  item.Price = price * numberToBuy;
                  cart.Add(item);
              }
              else
              {


                  item.Count = numberToBuy;
                  item.Price = price * numberToBuy;
              }
            }


        }

        void FillGrid(int idCategoria)
        {
            _Catalogo = ProductsDAC.Retrive_Produts(idCategoria);
         
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

        #region Tree vie


        private void FillCat()
        {
            ProductCategotyBEList categories = ProductsDAC.Retrive_Categories();

 
            TreeViewBind(this.trvCategories, categories, null);

            this.trvCategories.DataBind();
        }
            /// <summary>
       /// TreeViewBind() method, is use to load an XML string via XmlDocument
       /// object, and convert it to XML Object. Binding object to TreeView
       /// data source.
       /// </summary>
       private void TreeViewBind(TreeView trv , ProductCategotyBEList categories,ProductCategotyBEList subcategorias)
       {
           try
           {
               TreeNode nodeTree = null;
               foreach (ProductCategotyBE cat in categories.Where(p=>p.ParentId.Equals("0")))
               {
                   nodeTree = new TreeNode(cat.Text, cat.Id);
                   nodeTree.SelectAction = TreeNodeSelectAction.None;
                   nodeTree.Target = "Default.aspx";
                   AddSubcategories(nodeTree, cat.Id, categories);
                   trv.Nodes.Add(nodeTree);
               }
           }
           
           catch (Exception ex)
           {
               Response.Write(ex.Message);
               trv.Nodes.Clear();
           }
       }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="parentId"></param>
        /// <param name="categories"></param>
       private void AddSubcategories(TreeNode parent, string parentId, ProductCategotyBEList categories)
       {

           List<ProductCategotyBE> childsBE = categories.Where(p => p.ParentId.Equals(parentId)).ToList();
           TreeNode nodeTree_Child = null;
           foreach (ProductCategotyBE childCatatBE in childsBE)
           {
               nodeTree_Child = new TreeNode(childCatatBE.Text, childCatatBE.Id);
               nodeTree_Child.NavigateUrl = "Default.aspx?id=" + childCatatBE.Id + "";
               parent.ChildNodes.Add(nodeTree_Child);
               if (categories.Any(p => p.ParentId.Equals(childCatatBE.Id) ) == true)
               {
                  
                   AddSubcategories(nodeTree_Child, childCatatBE.Id, categories);
               }
              
           }
       }
    
        #endregion

      
    }
}
