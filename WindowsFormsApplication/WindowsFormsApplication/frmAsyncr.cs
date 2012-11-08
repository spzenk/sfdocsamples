using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public partial class frmAsyncr : Form
    {
        public frmAsyncr()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        // -------------await.-------------------------
        //Esa palabre clave es la que permite que un método que ha llamado a otro método asíncrono se espere a
        //que dicho método asíncrono termine. 
        // desde el momento en quellamada al método asíncrono
        //hasta el momento en que decidimos que nos debemos esperar  hemos estado haciendo otras cosas 
        //    Eso, de nuevo trasladado a código fuente, significa que entre la llamada al método asíncrono y el uso de await habrá más líneas de código fuente.
        //  Por lo tanto no usamos await cuando llamamos al método asíncrono, lo hacemos más tarde cuando queremos esperarnos a que dicho método termine 
        //  (y recoger el resultado, es decir mi cerveza).
        //private async void button1_Click(object sender, EventArgs e)
        //{

        //    // sobre que aplicamos await? Sobre cualquier objeto Task o su equivalente genérico Task<T> (EN LA GERFGA LLAMADO AWAITABLE)
        //    BearEnjine wBearEnjine = new BearEnjine();

        //    textBox1.Text = "INICIANDO FABRICA DE BIRRAS " + System.DateTime.Now.ToShortTimeString() ;
        //   var bears = wBearEnjine.ManufactureBears_ASYNC("Quilmes", 10000);
        //    bears.Start();
        //    List<Bear> birras = await bears;

        //   textBox1.Text = "Fin manufactura BIRRAS " + System.DateTime.Now.ToShortTimeString();
        //}
    }

    public class BearEnjine
    {
        public  Task<List<Bear>>  ManufactureBears_ASYNC(String parameter1,int count)
        {
            return new Task<List<Bear>>(() =>
                {
                    return ManufactureBears(count);
                });

        }

        List<Bear> ManufactureBears(int count)
        {
            List<Bear> list = new List<Bear>();
            Bear b=null;
            for (int i = 0; i < count; i++)
            {
                b = new Bear();
                b.Index = 1;
                list.Add(b);
            }

            return list;
        }

    }

    public class Bear
    {
        public Bear()
        {}
        public Bear(int index,string tipo )
        {
            this.BearType = tipo;
            this.Index = index;
        }
        public string BearType { get; set; }
        public int Index { get; set; }
    }
}

