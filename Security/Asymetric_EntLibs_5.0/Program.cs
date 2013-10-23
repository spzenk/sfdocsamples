using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Symetric_EntLibs_5._0;

namespace Asymetric_EntLibs_5_0
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_ConArchivo());
        }
    }
}
