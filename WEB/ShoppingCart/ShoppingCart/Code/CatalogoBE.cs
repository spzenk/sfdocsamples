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
          

    

        public string Li_Category = "<li><a href='/{0}'>{0}</a><li>";
        public string Li_FinalCategory = "<li><a href='{1}'>{0}</a>";

        public string GetMenu()
        {
            StringBuilder ul = new StringBuilder("<ul> [BODY]</ul>");

            //int order = 0;

            var roots = this.Where(p => p.ParentId.Equals(0));

            foreach (ProductCategotyBE cat in roots)
            {
                if (this.Any(p => p.ParentId.Equals(cat.Id)))
                {
 
                }
            }
            return ul.ToString();
        }

        public void RetriveOrder(List<ProductCategotyBE> roots)
        {
            //this.Any(p => p.ParentId, Equals(pProductCategotyBE_Id));
        }
    
    }
    public class ProductCategotyBE:Fwk.Bases.BaseEntity
    {
        public String Id { get; set; }
        public String Text { get; set; }
        public String ParentId { get; set; }
        public int Order { get; set; }
    }

}