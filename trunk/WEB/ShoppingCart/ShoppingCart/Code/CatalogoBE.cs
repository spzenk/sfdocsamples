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
        public int Id { get; set; }
        public String Description { get; set; }
        public int Count { get; set; }
        public Decimal Price { get; set; }
    }

    public class ProductCategotyBEList : Fwk.Bases.BaseEntities<ProductCategotyBE>
    {
          

    
    }
    public class ProductCategotyBE:Fwk.Bases.BaseEntity
    {
        public String Id { get; set; }
        public String Text { get; set; }
        public String ParentId { get; set; }
        public int Order { get; set; }
    }

}