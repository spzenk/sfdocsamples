using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capote.Code;

using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;



namespace ShoppingCart
{
    public class ProductsDelfinDAC
    {
        public static string connectionString;
        static ProductsDelfinDAC()
        {
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DelfinSAConnectionString"].ConnectionString;
        }
        public static List<ProductBE> Retrive_Produts(int? subCategoryId)
        {
            ProductBE wProductBE = null;
            List<ProductBE> wCatalogoList = new List<ProductBE>();
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
                        wProductBE.Marca = p_db.Marca;
                        wProductBE.Count = 0;
                        wCatalogoList.Add(wProductBE);
                    }
            }

            //Database dataBase = null;
            //DbCommand cmd = null;


            //dataBase = new Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(ProductsDelfinDAC.connectionString);
            //cmd = dataBase.GetStoredProcCommand("Articulos_s_categoria");
            //dataBase.AddInParameter(cmd, "idcate", System.Data.DbType.Int32, subCategoryId);
            //using (IDataReader reader = dataBase.ExecuteReader(cmd))
            //{
            //    while (reader.Read())
            //    {
            //        wProductBE = new ProductBE();
            //        wProductBE.Id = Convert.ToDecimal(reader["idart"]);
            //        wProductBE.IdCate = subCategoryId.ToString();
            //        wProductBE.Price = Convert.ToDecimal(reader["precio"]);
            //        wProductBE.Description = reader["denom"].ToString();
            //        wProductBE.Count = 0;
            //        wCatalogoList.Add(wProductBE);

            //    }
            //}

            return wCatalogoList;
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

                var categoryList = dc.categorias.OrderBy(d => d.denom).ToList<categoria>();

                ProductCategotyBE be = null;
                foreach (categoria item in categoryList.Where(p => p.idnivel != null && string.IsNullOrEmpty(p.idnivel.Trim())==false))
                {
                    be = new ProductCategotyBE();
                    be.Id = item.idcate.ToString();//+ "." + item.ProductCategoryID.ToString();
                    be.Text = item.denom.Trim();
                    be.Catego = item.denom.Trim();
                    be.ParentId = item.idparent.ToString().Trim();
                    be.IdNivel = item.idnivel;
                    be.Level= item.idnivel.Split('.').Count();
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




