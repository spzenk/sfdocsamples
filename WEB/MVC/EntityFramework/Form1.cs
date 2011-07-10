using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.Entity;

namespace EntityFramework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdventureWorksEntities dc = new AdventureWorksEntities();
            
            var list = from a in dc.Address   where a.City.StartsWith("b") select a;


            List<Address> list2 = list.ToList<Address>();
            //contexto dc2 = new contexto("AdventureWorksEntities");
            //Address dire = dc2.Addresses.Find(2);


            var query = (System.Data.Objects.ObjectQuery<Address>)list;

            textBox1.Text = query.ToTraceString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Product p = new Product();

            try
            {
                p.Name = "";
            }
            catch (Exception ex)
            {
             
                MessageBox.Show(Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex));
            }

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<string> s = new List<string>();
            AdventureWorksEntities dc = new AdventureWorksEntities();

            Product product = dc.Product.First<Product>(p => p.ProductID.Equals(Convert.ToInt32(txtId.Text)));

            s.Add(string.Concat("Name ",product.Name));
            s.Add(string.Concat("ProductModel ", product.ProductModel.Name));
        }


    }

    public class contexto : DbContext
    {
        public contexto(string cnnStringNAme) : base(cnnStringNAme) { }

        public DbSet<Address> Addresses { get; set; }
    }
}
