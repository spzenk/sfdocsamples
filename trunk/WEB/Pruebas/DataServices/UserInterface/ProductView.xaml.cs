using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using NorthwindModel;
using UserInterface.Gateways;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class ProductView : Window
    {
        public ProductView()
        {
            InitializeComponent();
        }

        private bool _FormCreateMode = true;
        private bool FormCreateMode
        {
            get
            {
                return _FormCreateMode;
            }
            set
            {
                _FormCreateMode = value;
            }
        }

        private Products product { get; set; }

        public void UpdateProduct(Products product)
        {
            ProductGateway gateway = new ProductGateway();
            IList<Products> p = new List<Products>();
            p = gateway.GetProducts(product.ProductName, product.Categories);
            this.product = gateway.GetProducts(product.ProductName, product.Categories)[0];
            FormCreateMode = false;
            this.Title = "Edit " + product.ProductName;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BindCategories();
            if( FormCreateMode )
            {
                product = new Products();
            }
            BindProduct();
        }

        private void BindProduct()
        {
            txtProductNumber.DataContext = product;
            txtName.DataContext = product;
            txtListPrice.DataContext = product;
            txtColor.DataContext = product;
            CategoryComboBoxProductDetail.DataContext = product;
            txtModifiedDate.DataContext = product;
            txtSellStartDate.DataContext = product;
            
        }

        private void BindCategories()
        {
            ProductGateway gateway = new ProductGateway();
            CategoryComboBoxProductDetail.ItemsSource = gateway.GetCategories();
            CategoryComboBoxProductDetail.SelectedIndex = 0;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            ProductGateway gateway = new ProductGateway();
            if (FormCreateMode)
            {                               
                product.Categories = (Categories)CategoryComboBoxProductDetail.SelectedItem;
                gateway.AddProduct(product);
            }
            else 
            {
                product.Categories = (Categories)CategoryComboBoxProductDetail.SelectedItem;
                gateway.UpdateProduct(product);
            }         
            this.Close();
        }
    }
}
