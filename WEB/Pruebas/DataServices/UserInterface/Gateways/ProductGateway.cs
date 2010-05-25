using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Configuration;
using NorthwindModel;
using System.Data.Services.Client;

namespace UserInterface.Gateways
{
   
    public class ProductGateway : IProductGateway
    {
        
        NorthwindEntities context;
        Uri serviceUri;
        public ProductGateway()
        {
            serviceUri = new Uri("http://localhost:25115/NorthwindService.svc");
            context = new NorthwindEntities(serviceUri);
            context.MergeOption = MergeOption.AppendOnly;            
        }

        public IList<Products> GetProducts(string productName, Categories category)
        {
                       
            int categoryId = category.CategoryID;
            string uri = serviceUri + "/Categories(" + categoryId + ")/Products?";
            if (!String.IsNullOrEmpty(productName)) 
            {
                uri = uri + "$filter=ProductName eq '" + productName + "'&";
            }
            uri = uri + "$expand=Categories";
            Uri queryUri = new Uri(uri);
            try
            {
                IEnumerable<Products> products = context.Execute<Products>(queryUri);
          
                return products.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        } 


        public IList<Categories> GetCategories()
        {
            var ProductCategories = from c in context.Categories
                                    select c;

            return ProductCategories.ToList();
        }


        public string DeleteProduct(Products product)
        {
            context.AttachTo("Products", product);
            context.DeleteObject(product);

            try
            {
                DataServiceResponse r = context.SaveChanges();
                return null;
            }
            catch (DataServiceRequestException)
            {   
                return "Product Cannot be Deleted";
            }
            
        }


        public void UpdateProduct(Products product)
        {
            Categories newCategory = product.Categories;
            context.AttachTo("Products", product);
            context.AttachTo("Categories", newCategory);
            context.UpdateObject(product);
            context.SetLink(product, "Categories", newCategory);

            context.SaveChanges();
        }

        public void AddProduct(Products product)
        {
            context.AddObject("Products", product);
            context.AttachTo("Categories", product.Categories);
            context.SetLink(product, "Categories", product.Categories);
            try
            {
                DataServiceResponse r = context.SaveChanges();
            }
            catch (DataServiceRequestException e)
            {
                // see e.Response for error details
            }
        }

    }        
}
