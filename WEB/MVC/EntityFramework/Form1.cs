using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Entity;
using Fwk.Exceptions;
using Newtonsoft.Json;
using System.Data.Common;
using System.Transactions;
using EntityFramework.Entities;

namespace EntityFramework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


         
        }

      



        private void button3_Click(object sender, EventArgs e)
        {
            StringBuilder s= new StringBuilder();
            //EntityFramework.Entities.Prod.AdventureWorksProducts j = new Entities.Prod.AdventureWorksProducts();


            AdventureWorksEntities dc = new AdventureWorksEntities();

            int ID = Convert.ToInt32(txtId.Text);

            //Lamda
            Product product = dc.Product.First<Product>(p => p.ProductID.Equals(ID));


            //Lamda
           // var x = j.ProductDescriptions.First<EntityFramework.Entities.Prod.ProductDescription>(p => p.ProductDescriptionID.Equals(ID));

            //LinQ
            var wProduct = from a in dc.Product where a.ProductID.Equals(ID) select a;

            var prod2 = wProduct.First();

            s.AppendLine(string.Concat("Name ", product.Name));

            if (product.ProductModel != null)
                s.AppendLine(string.Concat("ProductModel ", product.ProductModel.Name));


            textBox1.Text = s.ToString();
        }

        private void btnGetXml_Click(object sender, EventArgs e)
        {
            AdventureWorksEntities dc = new AdventureWorksEntities();

            int ID = Convert.ToInt32(txtId.Text);
            Product product = dc.Product.First<Product>(p => p.ProductID.Equals(ID));

            ProductMapp wProductMapp = new ProductMapp();
            wProductMapp.MakeFlag = product.MakeFlag;
            wProductMapp.Name = product.Name;
            wProductMapp.ProductID = product.ProductID;

            wProductMapp.SellStartDate = product.SellStartDate;

            string json = JsonConvert.SerializeObject(wProductMapp, Formatting.Indented);

            //            {
            //  "ProductID": 680,
            //  "Name": "HL Road Frame - Black, 57",
            //  "ProductNumber": null,
            //  "MakeFlag": true,
            //  "SellStartDate": "\/Date(896670000000-0300)\/"
            //}

            textBox1.Text = json;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(txtId.Text);

            AdventureWorksEntities dc = new AdventureWorksEntities();
            Product product = dc.Product.First<Product>(p => p.ProductID.Equals(ID));

            try
            {

                product.Name = txtName.Text;
                dc.SaveChanges();
                MessageBox.Show("Changes saved to the database.");
            }
            catch (FunctionalException fx)
            {
                if(fx.ErrorId.Equals("1000"))
                    MessageBox.Show(fx.Message);
                else
                    MessageBox.Show("Fue un moco desconocido");
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (AdventureWorksEntities dc = new AdventureWorksEntities())
            {

                dc.Connection.Open();
                DbTransaction tr = dc.Connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                var products = from p in dc.Product where p.Class.Equals("M") select p;
                Int16 level = 1;


                UpdateProducts(products.ToList<Product>(), level);
                dc.SaveChanges(System.Data.Objects.SaveOptions.DetectChangesBeforeSave);

                // throw new Exception();
                tr.Commit();
                //tr.Rollback();

            }

        }

        void UpdateProducts(List<Product> products,Int16 level)
        {
            foreach (Product p in products)
            {
                p.SafetyStockLevel = Convert.ToInt16( p.SafetyStockLevel + level);
            }
         
        }

        private void btnTransactions_2_Click(object sender, EventArgs e)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                using (AdventureWorksEntities dc = new AdventureWorksEntities())
                {

                    dc.Connection.Open();

                    var products = from p in dc.Product where p.Class.Equals("M") select p;
                    Int16 level = 1;


                    UpdateProducts(products.ToList<Product>(), level);
                    dc.SaveChanges(System.Data.Objects.SaveOptions.DetectChangesBeforeSave);

                    //throw new Exception();
                }
                transaction.Complete();
            }
          

        }



        private void button2_Click(object sender, EventArgs e)
        {
            Product Product_EF = null;
            int id = Convert.ToInt32(txtId.Text);
            Fwk.Entities.Common.BE.ProductBE Product_Fwk = new Fwk.Entities.Common.BE.ProductBE();

            try
            {
                AdventureWorksEntities dc = new AdventureWorksEntities();
                Product_EF = dc.Product.First<Product>(p => p.ProductID.Equals(id));
                string xml = Fwk.HelperFunctions.SerializationFunctions.SerializeToXml(Product_EF);
                
                
                Product_Fwk.SetXml(xml);


                textBox1.Text = xml;


            }
            catch (Exception ex)
            {

                MessageBox.Show(Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex));
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product Product_EF = null;
            int id = Convert.ToInt32(txtId.Text);
            Fwk.Entities.Common.BE.ProductBE Product_Fwk = new Fwk.Entities.Common.BE.ProductBE();

            try
            {
                AdventureWorksEntities dc = new AdventureWorksEntities();
                Product_EF = dc.Product.First<Product>(p => p.ProductID.Equals(id));
                
                string json = JsonConvert.SerializeObject(Product_EF, Formatting.Indented);
                textBox1.Text = json;


            }
            catch (Exception ex)
            {

                MessageBox.Show(Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex));
            }

        }


        private void button5_Click_1(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(txtId.Text);
            Fwk.Entities.Common.BE.ProductBE Product_Fwk = new Fwk.Entities.Common.BE.ProductBE();

            try
            {
                AdventureWorksEntities dc = new AdventureWorksEntities();
               
                Product Product_EF = dc.Product.First<Product>(p => p.ProductID.Equals(id));

                //Product_Fwk = prod.First<Fwk.Entities.Common.BE.ProductBE>();
                Product_Fwk = (Fwk.Entities.Common.BE.ProductBE)Product_EF;

                textBox1.Text = JsonConvert.SerializeObject(Product_Fwk, Formatting.Indented); 


            }
            catch (Exception ex)
            {

                MessageBox.Show(Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex));
            }

        }
    }

 
}
