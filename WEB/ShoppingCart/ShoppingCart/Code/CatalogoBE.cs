using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.UI;

namespace ShoppingCart
{
    public class ProductBE
    {
        public Decimal Id { get; set; }
        public String IdCate { get; set; }
        public String Description { get; set; }
        public int Count { get; set; }
        public Decimal? Price { get; set; }
        public String Marca { get; set; }
    }

    public class ProductCategotyBEList : Fwk.Bases.BaseEntities<ProductCategotyBE>
    {
          

    
    }
    public class ProductCategotyBE:Fwk.Bases.BaseEntity
    {
        public String Id { get; set; }
        public String Text { get; set; }
        public String Depto { get; set; }
        public String Catego { get; set; }
        public String ParentId { get; set; }
        public String IdNivel { get; set; }

        public int Level { get; set; }
    }

}