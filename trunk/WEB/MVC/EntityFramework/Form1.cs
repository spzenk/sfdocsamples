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
            Clear();
            StringBuilder s= new StringBuilder();
            //EntityFramework.Entities.Prod.AdventureWorksProducts j = new Entities.Prod.AdventureWorksProducts();


            AdventureWorksEntities dc = new AdventureWorksEntities();

            int ID = Convert.ToInt32(txtId.Text);

            //Lamda
            _Product_EF = dc.Product.First<Product>(p => p.ProductID.Equals(ID));


            //Lamda
           // var x = j.ProductDescriptions.First<EntityFramework.Entities.Prod.ProductDescription>(p => p.ProductDescriptionID.Equals(ID));

            //LinQ
            var wProduct = from a in dc.Product where a.ProductID.Equals(ID) select a;

            var prod2 = wProduct.First();

            s.AppendLine(string.Concat("Name ", _Product_EF.Name));

            if (_Product_EF.ProductModel != null)
                s.AppendLine(string.Concat("ProductModel ", _Product_EF.ProductModel.Name));


            txtProduct_EDM.Text = s.ToString();
        }

        private void btnGetXml_Click(object sender, EventArgs e)
        {
            Clear();
            AdventureWorksEntities dc = new AdventureWorksEntities();

            int ID = Convert.ToInt32(txtId.Text);
            Product product = dc.Product.First<Product>(p => p.ProductID.Equals(ID));

            
            _Product_Fwk.MakeFlag = product.MakeFlag;
            _Product_Fwk.Name = product.Name;
            _Product_Fwk.ProductID = product.ProductID;

            _Product_Fwk.SellStartDate = product.SellStartDate;


            JsonString_Fwk(true);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clear();
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
            Clear();
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
            Clear();
           
            int id = Convert.ToInt32(txtId.Text);
           

            try
            {
                AdventureWorksEntities dc = new AdventureWorksEntities();
                _Product_EF = dc.Product.First<Product>(p => p.ProductID.Equals(id));
                string xml = Fwk.HelperFunctions.SerializationFunctions.SerializeToXml(_Product_EF);
                
                
                _Product_Fwk.SetXml(xml);


                txtProduct_Fwk.Text = xml;


            }
            catch (Exception ex)
            {

                MessageBox.Show(Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex));
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {


            Clear();
            int id = Convert.ToInt32(txtId.Text);
   

            try
            {
                AdventureWorksEntities dc = new AdventureWorksEntities();
                
                _Product_EF = dc.Product.First<Product>(p => p.ProductID.Equals(id));
                JsonSerializerSettings s = new JsonSerializerSettings ();
                s.PreserveReferencesHandling =  PreserveReferencesHandling.None;
    
                //string json = JsonConvert.SerializeObject(_Product_EF, Formatting.None);
                string json = JsonHelper.Serialize(_Product_EF);
                _Product_Fwk = (Fwk.Entities.Common.BE.ProductBE)JsonConvert.DeserializeObject(json, typeof(Fwk.Entities.Common.BE.ProductBE));

                txtProduct_EDM.Text = json;

            }
            catch (Exception ex)
            {

                MessageBox.Show(Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex));
            }

        }
        Fwk.Entities.Common.BE.ProductBE _Product_Fwk;
        Product _Product_EF;

       
        /// <summary>
        /// using mapping overload
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click_1(object sender, EventArgs e)
        {
            Clear();
            int id = Convert.ToInt32(txtId.Text);
            

            try
            {
                AdventureWorksEntities dc = new AdventureWorksEntities();
               
                 _Product_EF = dc.Product.First<Product>(p => p.ProductID.Equals(id));

                 _Product_Fwk = (Fwk.Entities.Common.BE.ProductBE)_Product_EF;

                JsonString_Fwk(true);


            }
            catch (Exception ex)
            {

                MessageBox.Show(Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex));
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            JsonString_Edm(true);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            JsonString_Fwk(true);

        }
        void JsonString_Fwk(bool indented)
        {

            if (indented)
                txtProduct_Fwk.Text = JsonConvert.SerializeObject(_Product_Fwk, Formatting.Indented);
            else
                txtProduct_Fwk.Text = JsonConvert.SerializeObject(_Product_Fwk, Formatting.None);

        }

        void JsonString_Edm(bool indented)
        {
           

            if (indented)
                txtProduct_EDM.Text = JsonConvert.SerializeObject(_Product_EF, Formatting.Indented);
            else
                txtProduct_EDM.Text = JsonConvert.SerializeObject(_Product_EF, Formatting.None);


        }
        void Clear()
        {
            _Product_Fwk = new Fwk.Entities.Common.BE.ProductBE();

            txtProduct_EDM.Clear();
            txtProduct_Fwk.Clear();
        }


    }

 
}
