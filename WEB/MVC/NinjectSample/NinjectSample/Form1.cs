using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Windows.Forms;
using Ninject;
using NinjectSample.Clases;

namespace NinjectSample
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //IKernel kernel = new StandardKernel();
            //kernel.Bind<IPaisRepository>().To<PaisRepository>();
            //System.Web.Http.Dependencies.IDependencyResolver resolver = new NinjectResolver(kernel);
            //GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NinjectWebCommon.Start();
            var service = NinjectWebCommon.Get_Service<UserData>();

        }
    }
}
