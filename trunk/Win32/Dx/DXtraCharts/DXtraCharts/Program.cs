using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DXtraCharts
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
            Application.Run(new FormChart());
        }
    }
}
