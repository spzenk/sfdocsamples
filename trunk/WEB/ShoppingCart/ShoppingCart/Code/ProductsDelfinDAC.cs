using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capote.Code;



namespace ShoppingCart
{
    public class ProductsDelfinDAC
    {

        public static List<ProductBE> Retrive_Produts(int subCategoryId)
        {
            ProductBE wProductBE = null;
            List<ProductBE> wCatalogo = new List<ProductBE>();
            using (DelfinDataDataContext dc = new DelfinDataDataContext())
            {

                var productsdb = dc.shopcart_products_views.Where(p => p.idcate.Equals(subCategoryId));
                if (productsdb != null)
                    foreach (shopcart_products_view p_db in productsdb)
                    {
                        wProductBE = new ProductBE();
                        wProductBE.Id = p_db.idart;
                        wProductBE.IdCate = subCategoryId.ToString();
                        wProductBE.Price = p_db.prevta;
                        wProductBE.Description = p_db.denom;
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
            using (DelfinDataDataContext dc = new DelfinDataDataContext())
            {

                var categoryList = dc.categorias.ToList<categoria>();

                ProductCategotyBE be = null;
                foreach (categoria item in categoryList.Where(p => p.idnivel != null && string.IsNullOrEmpty(p.idnivel.Trim())==false))
                {
                    be = new ProductCategotyBE();
                    be.Id = item.idcate.ToString();//+ "." + item.ProductCategoryID.ToString();
                    be.Text = item.denom.Trim();
                    be.Catego = item.denom.Trim();
                    be.ParentId = item.idparent.ToString().Trim();
                    be.IdNivel = item.idnivel;
                    wProductCategotyBEList.Add(be);
                }

                //foreach (ProductCategory item in category)
                //{
                //    be = new ProductCategotyBE();
                //    be.Id = item.ProductCategoryID.ToString();
                //    be.Text = item.Name;
                //    be.ParentId = "0";
                //    wProductCategotyBEList.Add(be);
                //}
            }

            return wProductCategotyBEList;
        }


    }
}




