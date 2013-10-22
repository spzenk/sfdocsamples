using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.T4Gen;
using Fwk.Bases.ViewModels;
using System.Reflection;
using System.IO;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CarViewModel m = new CarViewModel();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DirectoryInfo d2 = new DirectoryInfo(@"C:\Projects\sfdocsamples\SF\T4\Generar_javascript\Fwk.T4Gen\Test\bin\Debug");
            var set = new HashSet<string> { ".dll", ".exe" };
            FileInfo[] files = d2.GetFiles(".dll", SearchOption.TopDirectoryOnly);
       
            List<Type> d = RetriveAllModels();
            d = Properties();
            //jsObservables t4 = new jsObservables();
            //String s = t4.TransformText();


        }

        public static List<Type> Properties()
        {
            var list = new List<Type>();


            foreach (Type type in System.Reflection.Assembly.GetAssembly(typeof(BaseViewModel)).GetTypes())
            {
                if (type.IsAbstract) continue;
                if (type.Name == typeof(BaseViewModel).Name) continue;
                list.Add(type);
            }
            return list;
        }
        public List<Type> RetriveAllModels()
        {
            var list = new List<Type>();
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {

                Type[] types = assembly.GetTypes();

                foreach (Type type in types)
                {

                    if (type.BaseType == typeof(BaseViewModel))
                    {
                        list.Add(type);

                    }

                }

            }
            return list;
        }
    }
}
