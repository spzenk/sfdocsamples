using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Nodes.Operations;
using System.Windows.Forms;
namespace Allus.Cnn.Common
{
    public class CalcCheckedNodesOperation : TreeListOperation
    {
        private List<TreeListNode> checkedNodes = new List<TreeListNode>();
        public List<TreeListNode> CheckedNodes { get { return checkedNodes; } }
        private List<TreeListNode> checkedIndeterminateNodes = new List<TreeListNode>();
        public List<TreeListNode> CheckedIndeterminateNodes { get { return checkedIndeterminateNodes; } }
        
        public override void Execute(TreeListNode node)
        {
            if (node.CheckState == CheckState.Checked)
                checkedNodes.Add(node);
            if (node.CheckState == CheckState.Checked || node.CheckState == CheckState.Indeterminate)
                checkedIndeterminateNodes.Add(node);
        }
    }

    public class CalcCheckedChildrenOperation : CalcCheckedNodesOperation
    {
        private TreeListNode parent;
        private bool isCalculationStart = false;
        public CalcCheckedChildrenOperation(TreeListNode parent) { this.parent = parent; }
        public override void Execute(TreeListNode node)
        {
            if (node.HasAsParent(parent)) base.Execute(node);
        }
        public override bool CanContinueIteration(TreeListNode node)
        {
            if (isCalculationStart && !node.HasAsParent(parent)) return false;
            if (node == parent) isCalculationStart = true;
            return true;
        }
        public override bool NeedsVisitChildren(TreeListNode node)
        {
            return node == parent || node.HasAsParent(parent) || parent.HasAsParent(node);
        }
    }
}
