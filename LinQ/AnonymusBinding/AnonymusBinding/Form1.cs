using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace AnonymusBinding
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            PubsDataContext dc = new PubsDataContext();
                IEnumerable<author> autores = from autor in dc.authors select autor;// where autor.au_lname.StartsWith("B") select autor;
                authorBindingSource.DataSource = autores;
                gridControl1.RefreshDataSource();
            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            PubsDataContext dc = new PubsDataContext();
            var titulos = from t in dc.titleauthors select 
                              new { t.title_id,
                                  t.royaltyper, 
                                  t.au_ord, 
                                  au_fname = (t.author.au_fname + " " + t.author.au_lname), 
                                  t.author.state };

      


            gridControl3.DataSource = titulos;
            gridControl3.RefreshDataSource();
            dataGridView1.DataSource = titulos;
        }
    }
}
