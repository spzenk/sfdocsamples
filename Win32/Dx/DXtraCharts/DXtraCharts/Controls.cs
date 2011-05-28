using System.Windows.Forms;
using System.Drawing.Imaging;
using DevExpress.LookAndFeel;
using DevExpress.Utils.Menu;
using DevExpress.XtraCharts.Native;
using System.Drawing;
using System.Drawing.Text;
using DevExpress.XtraBars;
using DevExpress.Skins;
using DevExpress.DXperience.Demos;

namespace DevExpress.XtraCharts.Demos {
	public class TutorialControl : TutorialControlBase {
		IDXMenuManager menuManager;
		public IDXMenuManager MenuManager { get { return menuManager; } set { menuManager = value; } }
	}
}
