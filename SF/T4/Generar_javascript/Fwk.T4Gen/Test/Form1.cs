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
            List<Type> d = RetriveAllModels();

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
