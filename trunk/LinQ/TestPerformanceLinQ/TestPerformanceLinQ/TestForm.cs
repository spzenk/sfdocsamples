using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TestPerformanceLinQ.BackEnd;

namespace TestPerformanceLinQ
{
    public partial class TestForm : Form
    {
        List<MuestrasTime> _Muestras = new List<MuestrasTime>();
        public TestForm()
        {
            InitializeComponent();
            muestrasTimeBindingSource.DataSource = _Muestras;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            DateTime inicio = DateTime.Now;
            int count = 0;

            for (int i = 0; i <= (int)numericUpDown1.Value; i++)
            {
                dataGridView1.DataSource = SalesDAC.BuscarDetallesIEnumerableTodos(out count);
            }

            TimeSpan duracion = DateTime.Now - inicio;
            lblDuracion.Text = duracion.TotalMilliseconds.ToString();
            _Muestras.Add(new MuestrasTime { TotalMilliseconds = duracion.TotalMilliseconds });


            dataGridViewMuestras.DataSource = null;
            dataGridViewMuestras.DataSource = muestrasTimeBindingSource;
            lblRecordsCount.Text = count.ToString(); ;
        }

        public  class MuestrasTime
        {
            public double TotalMilliseconds { get; set; }
        }
    }
}
