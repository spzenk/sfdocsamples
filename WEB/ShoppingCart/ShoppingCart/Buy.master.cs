using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShoppingCart;

namespace WebApplication1
{
    public partial class Buy : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                int? idSubcategoria = null;
                if (Request.QueryString["id"] != null)
                {
                    idSubcategoria = Convert.ToInt32(Request.QueryString["id"].ToString());
                }

               FillCat(idSubcategoria);
            }
        }

        #region Tree vie


        private void FillCat(int? idSubcategoria)
        {
            ProductCategotyBEList categories = ProductsDelfinDAC.Retrive_Categories();
            TreeViewBind(this.trvCategories, categories, null);
            this.trvCategories.CollapseAll();
            if (idSubcategoria.HasValue)
            {
                ExpandCategory(this.trvCategories.Nodes, idSubcategoria.Value);
            }
            this.trvCategories.DataBind();




        }

        void ExpandCategory(TreeNodeCollection nodes, int idSubcategoria)
        {
           
            foreach (TreeNode node in nodes)
            {

                if (node.Value.Equals(idSubcategoria.ToString()))
                //if (Convert.ToInt32(node.Value.Split('.')[0]).Equals(idSubcategoria) && node.Parent != null)
                {
                    //node.Parent.Expand();
                    TryExpandParents(node);
                    return;
                }

                if (node.ChildNodes.Count > 0)
                {
                    ExpandCategory(node.ChildNodes, idSubcategoria);
                }

            }
        }
        void TryExpandParents(TreeNode node)
        {

            if (node.Parent != null)
            {
                node.Parent.Expand();
                TryExpandParents(node.Parent);
            }

        }

        /// <summary>
        /// TreeViewBind() method, is use to load an XML string via XmlDocument
        /// object, and convert it to XML Object. Binding object to TreeView
        /// data source.
        /// </summary>
        private void TreeViewBind(TreeView trv, ProductCategotyBEList categories, ProductCategotyBEList subcategorias)
        {
            try
            {
                TreeNode nodeTree = null;
                foreach (ProductCategotyBE cat in categories.Where(p => p.ParentId.Equals("0")))
                {
                    nodeTree = new TreeNode(cat.Text.Trim(), cat.Id);
                    nodeTree.SelectAction = TreeNodeSelectAction.Expand;
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
                //if (childCatatBE.Id == "102")
                //{
                //    int i = 0;
                //}
                nodeTree_Child = new TreeNode(childCatatBE.Text, childCatatBE.Id);
                if (childCatatBE.Level == 3)
                    nodeTree_Child.NavigateUrl = "Default.aspx?id=" + childCatatBE.Id ;
                else
                    nodeTree_Child.SelectAction = TreeNodeSelectAction.Expand;

                parent.ChildNodes.Add(nodeTree_Child);
                if (categories.Any(p => p.ParentId.Equals(childCatatBE.Id)) == true)
                {

                    AddSubcategories(nodeTree_Child, childCatatBE.Id, categories);
                }

            }
        }
        protected void trvCategories_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
        {
            if (e.Node.Parent.Value != "0")
                return;
        }
        #endregion
    }
}