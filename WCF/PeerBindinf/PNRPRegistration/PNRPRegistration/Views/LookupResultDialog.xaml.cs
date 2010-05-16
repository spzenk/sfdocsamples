using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Net.PeerToPeer;
using System.Diagnostics;

namespace PNRPRegistration.Views
{
    /// <summary>
    /// Interaction logic for LookupResultDialog.xaml
    /// </summary>
    public partial class LookupResultDialog : Window
    {
        public LookupResultDialog()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



       
    }
}
