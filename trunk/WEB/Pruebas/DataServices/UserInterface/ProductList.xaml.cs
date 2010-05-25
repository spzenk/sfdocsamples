using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using NorthwindModel;
using UserInterface.Gateways;

namespace UserInterface
{
    
    public partial class ProductList
	{
		public ProductList()
		{
			this.InitializeComponent();
            ProductsListView.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(ProductsListView_MouseDoubleClick);                		
		}

        private void BindCategories()
        {
            ProductGateway gateway = new ProductGateway();
            CategoryComboBox.ItemsSource = gateway.GetCategories();
            CategoryComboBox.SelectedIndex = 0;
        }

        private void BindProducts()
        {
            if (CategoryComboBox.SelectedIndex > -1)
            {
                ProductGateway gateway = new ProductGateway();                
                ProductsListView.ItemsSource = gateway.GetProducts(NameTextBox.Text, CategoryComboBox.SelectedItem as Categories);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BindCategories();            
        }

        private void ProductsListView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Products p = ProductsListView.SelectedItem as Products;
            ProductView window = new ProductView();            
            window.Closed += new EventHandler(window_Closed);
            window.UpdateProduct(p);
            window.Show();            
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            BindProducts();           
        }

        private void btnNewProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductView window = new ProductView();
            window.Closed += new EventHandler(window_Closed);
            window.Show();            
        }

        private void btnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {            
           Products p = ProductsListView.SelectedItem as Products;
           if (p != null)
           {
               ProductGateway gateway = new ProductGateway();
               string returned = gateway.DeleteProduct(p);
               if (returned != null)
                    MessageBox.Show(returned);
               BindProducts();
           }           
        }

        void window_Closed(object sender, EventArgs e)
        {            
            BindProducts();
        }        
	}
}