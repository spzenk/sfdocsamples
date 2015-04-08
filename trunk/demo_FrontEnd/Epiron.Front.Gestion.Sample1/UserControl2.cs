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
using Fwk.UI.Forms;
using DevExpress.XtraTreeList;

using Fwk.UI.Controls.Menu.Tree;


namespace Epiron.Front.Gestion.Sample1
{
    public partial class UserControl2 : Xtra_UC_Base
    {
        TreeMenu menu;
        public UserControl2()
        {
            InitializeComponent();
        }
        public override void Populate(object initialObject)
        {
            LoadMenuFile();
            this.treeList2.ExpandAll();
        }
       

        private void treeList2_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node == null) return;
            Fwk.UI.Controls.Menu.Tree.MenuItem item = (Fwk.UI.Controls.Menu.Tree.MenuItem)treeList2.GetDataRecordByNode(e.Node);
            if (!String.IsNullOrEmpty(item.AssemblyInfo))
            {
                //if (FormBase.CheckRule(item.AuthRule))
                //{
                    base.LunchUserControl(PanelEnum.RightPanel,item, null);
                //}
            }
        }
        private void treeList2_KeyDown(object sender, KeyEventArgs e)
        {
            DevExpress.XtraTreeList.TreeList tl = sender as DevExpress.XtraTreeList.TreeList;
            if (tl.FocusedNode != null)
            {
                if (e.KeyCode == Keys.Right)
                {
                    if (!tl.FocusedNode.Expanded && tl.FocusedNode.HasChildren)
                        tl.FocusedNode.Expanded = true;
                    else tl.MoveNextVisible();
                }
                if (e.KeyCode == Keys.Left)
                {
                    if (tl.FocusedNode.Expanded)
                        tl.FocusedNode.Expanded = false;
                    else tl.MovePrevVisible();
                }
            }
        }

        private void treeList2_MouseClick(object sender, MouseEventArgs e)
        {

            TreeList tl = sender as TreeList;
            if (tl.FocusedNode != null)
                if (tl.FocusedNode.HasChildren)
                    tl.FocusedNode.Expanded = !tl.FocusedNode.Expanded;
        }
        void LoadMenuFile()
        {
            try
            {
                treeList2.BeginUpdate();
                menu = Common.LoadMenuFromFile(@"m_patient.xml");
                this.treeMenuBindingSource.DataSource = menu.ItemList;


                treeList2.RefreshDataSource();
                treeList2.EndUpdate();


            }
            //catch (InvalidOperationException e)
            //{
            //    ExceptionViewer.Show(e);
            //}
            catch (Exception ex2)
            {
                
                ExceptionViewer.Show(ex2);
            }
        }
    }
}
