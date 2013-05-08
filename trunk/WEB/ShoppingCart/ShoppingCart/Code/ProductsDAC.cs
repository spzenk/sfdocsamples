using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart
{
    public class ProductsDAC
    {

        public static List<ProductBE> Retrive_Produts(int subCategoryId)
        {
            ProductBE wProductBE = null;
            List<ProductBE> wCatalogo = new List<ProductBE>();
            using (DataClasses1DataContext dc = new DataClasses1DataContext())
            {
                var productsdb = dc.Products.Where(p => p.ProductSubcategoryID.Value.Equals(subCategoryId));
                if (productsdb != null)
                    foreach (Product p_db in productsdb)
                    {
                        wProductBE = new ProductBE();
                        wProductBE.Id = p_db.ProductID;
                        wProductBE.Price = p_db.ListPrice;
                        wProductBE.Description = p_db.Name;
                        
                        wProductBE.Count = 0;
                        wCatalogo.Add(wProductBE);
                    }

            }
            return wCatalogo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ProductCategotyBEList Retrive_Categories()
        {
            ProductCategotyBEList wProductCategotyBEList = new ProductCategotyBEList();
            using (DataClasses1DataContext dc = new DataClasses1DataContext())
            {
                var subCategory = dc.ProductSubcategories.ToList<ProductSubcategory>();
                var category = dc.ProductCategories.ToList<ProductCategory>();

                ProductCategotyBE be = null;
                foreach (ProductSubcategory item in subCategory)
                {
                    be = new ProductCategotyBE();
                    be.Id = item.ProductSubcategoryID.ToString() + "."+ item.ProductCategoryID.ToString();
                    be.Text = item.Name;
                    be.ParentId = item.ProductCategoryID.ToString();
                    wProductCategotyBEList.Add(be);
                }

                foreach (ProductCategory item in category)
                {
                    be = new ProductCategotyBE();
                    be.Id = item.ProductCategoryID.ToString();
                    be.Text = item.Name;
                    be.ParentId = "0";
                    wProductCategotyBEList.Add(be);
                }
            }

            return wProductCategotyBEList;
        }
        public static ProductCategotyBEList Retrive_Sub_Categories()
        {
            ProductCategotyBEList wProductCategotyBEList = new ProductCategotyBEList();
            using (DataClasses1DataContext dc = new DataClasses1DataContext())
            {
                var subCategory = dc.ProductSubcategories.ToList<ProductSubcategory>();


                ProductCategotyBE be = null;
                foreach (ProductSubcategory item in subCategory)
                {
                    be = new ProductCategotyBE();
                    be.Id = item.ProductSubcategoryID.ToString();
                    be.Text = item.Name;
                    be.ParentId = item.ProductCategoryID.ToString();
                    wProductCategotyBEList.Add(be);
                }

               
            }

            return wProductCategotyBEList;
        }
    }
}
