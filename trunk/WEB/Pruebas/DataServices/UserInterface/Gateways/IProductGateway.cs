using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthwindModel;

namespace UserInterface.Gateways
{
    public interface IProductGateway
    {
        IList<Products> GetProducts(string productName, Categories category);
        IList<Categories> GetCategories();
        string DeleteProduct(Products product);
        void UpdateProduct(Products product);
        void AddProduct(Products product);
    }
}
