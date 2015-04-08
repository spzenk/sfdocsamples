using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Epiron.Front.Bases;

namespace Epiron.Front.Gestion.Sample1
{
    public partial class UserControl1 : Xtra_UC_Base
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Fwk.UI.Controls.Menu.Tree.MenuItem m = new Fwk.UI.Controls.Menu.Tree.MenuItem();
            m.AssemblyInfo = "Epiron.Front.Gestion.Facebook.History,Epiron.Front.Gestion.Facebook";

            this.LunchUserControl(PanelEnum.RightPanel, m, 10);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Fwk.UI.Controls.Menu.Tree.MenuItem m = new Fwk.UI.Controls.Menu.Tree.MenuItem();
            m.AssemblyInfo = "Epiron.Front.Gestion.Facebook.statistics,Epiron.Front.Gestion.Facebook";

            this.LunchUserControl(PanelEnum.RightPanel, m, 10);
        }
    }
}
