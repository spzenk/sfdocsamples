using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Allus.Cnn.Common;
using Allus.Cnn.Common.BE;
using DevExpress.XtraEditors.Filtering;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraBars;
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace Allus.Cnn.Admin
{
    [ToolboxItem(true)]
    [DefaultEvent("SelectColaboratorEvent")]
    public partial class AdminDomainGrid : UserControlBase
    {
        #region Events & Members
        [Category("Allus.Libraries")]
        public event FinalizeMeshHandler FinalizeMeshEvent;
        [Category("Allus.Libraries")]
        public event EventHandler SendMessageEvent;
        [Category("Allus.Libraries")]
        public event EventHandler RefreshColaboratorEvent;
        [Category("Allus.Libraries")]
        public event EventHandler OnMeshChangedEvent;
        [Category("Allus.Libraries")]
        public event EventHandler<Allus.Cnn.Common.ExceptionEventArgs> ExceptionEvent;
        DomainList _RelatedDomains;
        /// <summary>
        /// Determina si se hiso click en el botonde refrescar
        /// </summary>
        bool _RefreshDomains = false;
        bool _IsOnLine = false;
        [Category("Allus.Libraries")]
        public bool IsOnLine
        {
            get { return _IsOnLine; }
            set { _IsOnLine = value; }
        }
        bool _OnInitLoad = true;
        Domain _SelectedDomain;
        string _currentMeshId;
        string _currentMeshName;
        string _userName;
        
        public Colaborator Admin;
        #endregion

        #region Properties

        public bool SFCheckDomainVisible
        {
            get { return this.treeList2.OptionsView.ShowCheckBoxes; }
            set {this.treeList2.OptionsView.ShowCheckBoxes = value;}
        }

        public bool SFColInMeshVisible
        {
            get { return colInMesh.Visible; }
            set {colInMesh.Visible = value;}
        }

        public DevExpress.XtraBars.BarItemVisibility SFButtonRefreshVisible
        {
            get { return btnRereshDomains.Visibility; }
            set{btnRereshDomains.Visibility = value;}
        }

        public DevExpress.XtraBars.BarItemVisibility SFButtonMeshVisible
        {
            get { return btnNewMesh.Visibility; }
            set{btnNewMesh.Visibility = value;}
        }

        public DevExpress.XtraBars.BarItemVisibility SFButtonUncheckAllVisible
        {
            get { return btnCheck.Visibility; }
            set{btnCheck.Visibility = value;}
        }

        [Browsable(false)]
        public DomainList RelatedDomains
        {
            get { return _RelatedDomains; }
            set { _RelatedDomains = value; }
        }
        
        [Browsable(false)]
        public int ColaboratorsCountInMesh
        {
            get {return _RelatedDomains.Sum(p => p.Count);}
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        #endregion

        public AdminDomainGrid()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Carga de manera asincrona los Dominios relacionados entre si en la grilla.-
        /// </summary>
        public void PopulateAsync()
        {
            Exception ex = null;
            Allus.Cnn.Common.DelegateWithOutAndRefParameters s = new Allus.Cnn.Common.DelegateWithOutAndRefParameters(Populate);

            s.BeginInvoke(out ex, new AsyncCallback(EndPopulate), null);
        }

        /// <summary>
        /// Fin de el metodo populate que fue llamado de forma asincrona
        /// </summary>
        /// <param name="res"></param>
        void EndPopulate(IAsyncResult res)
        {
            Exception ex;
            if (this.InvokeRequired)
            {
                AsyncCallback d = new AsyncCallback(EndPopulate);
                this.Invoke(d, new object[] { res });

            }
            else
            {
                AsyncResult result = (AsyncResult)res;
                Allus.Cnn.Common.DelegateWithOutAndRefParameters del = (Allus.Cnn.Common.DelegateWithOutAndRefParameters)result.AsyncDelegate;
                del.EndInvoke(out ex, res);
                if (ex != null)
                {
                    
                    if (ExceptionEvent != null)
                        ExceptionEvent(this, new ExceptionEventArgs(ex));
                    return;
                }
                
                this.domainListBindingSource.DataSource = _RelatedDomains;
                treeList2.RefreshDataSource();
            }
        }

        /// <summary>
        /// Carga Dominios relacionados entre al objeto _RelatedDomains que esta bindiado a la grilla
        /// </summary>
        void Populate(out Exception ex)
        {
            ex = null;

            try
            {
                if (_userName == null)
                {
                    _RelatedDomains = Controller.RelatedDomains;
                }
                else
                {
                    _RelatedDomains = Controller.SearchRelatedDomainsByUser(_userName,null,true,_RefreshDomains);
                    ///Reseteo la varieble por si la llamada a la linea anterior proviene de otro lugar distinto de refrescar.-
                    _RefreshDomains = false;
                }
            }
            catch (Exception err)
            {
                err.Source = "Origen de datos";
                ex = err;
            }
        }

        public void Populate(DomainList pRelatedDomains)
        {
            _RelatedDomains = pRelatedDomains;
            this.domainListBindingSource.DataSource = _RelatedDomains;
            treeList2.RefreshDataSource();
        }

        public DomainList GetCheckedDomains()
        {
            DomainList list = new DomainList();
            CalcCheckedNodesOperation operation = new CalcCheckedNodesOperation();

            treeList2.NodesIterator.DoOperation(operation);

            foreach (TreeListNode node in operation.CheckedIndeterminateNodes)
            {
                list.Add((Domain)treeList2.GetDataRecordByNode(node));
            }

            return list;
        }


        private void treeList2_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (_OnInitLoad)
               return;
            
            if (e.Node == null)
                return;
            
            if (e.Node.TreeList.FocusedColumn == null)
                return;
            
            _SelectedDomain = (Domain)treeList2.GetDataRecordByNode(e.Node);

            if (_SelectedDomain != null)
            {
                btnNewMesh.SuperTip.Items.Clear();
                if (_SelectedDomain.InMesh)
                {
                    btnNewMesh.Glyph = Properties.Resources.chat_22x22;
                    btnNewMesh.SuperTip.Items.Add("Ver sala");
                }
                else
                { //Crear sala
                    btnNewMesh.Glyph = Properties.Resources.chat_new_22x22;
                    btnNewMesh.SuperTip.Items.Add("Crear sala");
                }
                GetMeshName(e.Node, out _currentMeshId, out _currentMeshName);

            }
    
        }
        /// <summary>
        /// Arma el Id del Mesh desde el arbol TreeList
        /// </summary>
        /// <param name="node"></param>
        /// <param name="subMesId"></param>
        /// <param name="subMesName"></param>
        void GetMeshName(TreeListNode node, out string subMesId, out string subMesName)
        {
            Stack<string> stackId = new Stack<string>();
            Stack<string> stackName = new Stack<string>();
            subMesName = string.Empty;
            subMesId = string.Empty;
            int count = 0;
            while (node != null)
            {
                stackId.Push(((Domain)treeList2.GetDataRecordByNode(node)).DomainId.ToString());
                stackName.Push(((Domain)treeList2.GetDataRecordByNode(node)).Name.Trim());

                node = node.ParentNode;
                count++;
            }
            string[] hhh = stackId.ToArray<string>();
            for (int i = 1; i <= count; i++)
            {
                subMesId = string.Concat(subMesId, stackId.Pop());
                subMesName = string.Concat(subMesName, stackName.Pop());
                if (i != count)
                {
                    subMesName = string.Concat(subMesName, Common.Common.DOMAIN_SEPARATOR);
                    subMesId = string.Concat(subMesId, Common.Common.DOMAIN_SEPARATOR);
                }

            }
        }
        private void AdminDomainGrid_Load(object sender, EventArgs e)
        {
            _OnInitLoad = false;
        }


        /// <summary>
        /// Crea un nuevo mesh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewMesh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!_IsOnLine) return;
            
            if (string.IsNullOrEmpty(_currentMeshName)) return;
            //Indica que este nodo pertenece a un mesh creado (cambia el icono del nodo en el tree)
            ((Domain)treeList2.GetDataRecordByNode(treeList2.FocusedNode)).InMesh = true;
            bool isNew = false;
            Mesh wMesh = MeshFactory.GetMeshForm( _currentMeshId, _currentMeshName, treeList2.FocusedNode, out isNew);
            if (isNew)
            {
                wMesh.FinalizeMeshEvent += new FinalizeMeshHandler(Mesh_FinalizeMeshEvent);
                wMesh.SendMessageEvent += new EventHandler(Mesh_SendMessageEvent);
                ///Envia un evento comunicando q se modifico 
                if (OnMeshChangedEvent != null)
                    OnMeshChangedEvent(sender, null);
            }
            wMesh.Show();

            btnNewMesh.SuperTip.Items.Clear();
            btnNewMesh.Glyph = Properties.Resources.chat_22x22;
            btnNewMesh.SuperTip.Items.Add("Ver sala");

        }

        void Mesh_SendMessageEvent(object sender, EventArgs e)
        {
            if (SendMessageEvent != null)
                SendMessageEvent(sender, new EventArgs());
        }


        /// <summary>
        /// Se produce cuando el FormMesh avisa la Finalizacion del mesh.-
        /// Elimina los handlers: FinalizeMeshEvent y SendMessageEvent
        /// Lanza los eventos: OnMeshChangedEvent y FinalizeMeshEvent
        /// </summary>
        /// <param name="meshId"></param>
        void Mesh_FinalizeMeshEvent(string meshId)
        {
            Mesh wMesh = MeshFactory.GetById(meshId);
            if (wMesh != null)
            {
                //Indica que este nodo NO pertenece a un mesh creado (cambia el icono del nodo en el tree)
                ((Domain)treeList2.GetDataRecordByNode(wMesh.Node)).InMesh = false;
                wMesh.FinalizeMeshEvent -= new FinalizeMeshHandler(Mesh_FinalizeMeshEvent);
                wMesh.SendMessageEvent -= new EventHandler(Mesh_SendMessageEvent); 
                if (OnMeshChangedEvent != null) // Anuncia de un cambio en la coleccion de meshes
                    OnMeshChangedEvent(wMesh.MeshBE.Id, null);
                if (FinalizeMeshEvent != null)// Anuncia de una finalizqacion en la coleccion de meshes (al formColaborator)
                    FinalizeMeshEvent(wMesh.MeshBE.Id);

                MeshFactory.RemoveMeshForm(meshId);
            }
        }

        private void btnRereshColaborators_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _RefreshDomains = true;
            PopulateAsync();
            if (RefreshColaboratorEvent != null) RefreshColaboratorEvent(this, new EventArgs());
        }

        private void treeList2_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            SetCheckedChildNodes(e.Node, e.Node.CheckState);
            SetCheckedParentNodes(e.Node, e.Node.CheckState);
        }

        private void treeList2_BeforeCheckNode(object sender, DevExpress.XtraTreeList.CheckNodeEventArgs e)
        {
            e.State = (e.PrevState == CheckState.Checked ? CheckState.Unchecked : CheckState.Checked);
        }

        private void SetCheckedChildNodes(TreeListNode node, CheckState check)
        {

            foreach (TreeListNode childNode in node.Nodes)
            {
                childNode.CheckState = check;
                SetCheckedChildNodes(childNode, check);

            }
        }
        /// <summary>
        /// Establece el estado del padre: Si algun nodo hijo no esta chequeado lo pone 
        /// en estado : Indeterminate
        /// </summary>
        /// <param name="node"></param>
        /// <param name="check"></param>
        private void SetCheckedParentNodes(TreeListNode node, CheckState check)
        {
            if (node.ParentNode != null)
            {
                bool b = false;

                foreach (TreeListNode childNode in node.ParentNode.Nodes)
                {
                    if (!check.Equals(childNode.CheckState))
                    {
                        b = !b;
                        break;
                    }
                }
                node.ParentNode.CheckState = b ? CheckState.Indeterminate : check;
                SetCheckedParentNodes(node.ParentNode, check);
            }
        }


        private void btnCheck_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            CheckState wCheckState = (((DevExpress.XtraBars.BarCheckItem)(sender)).Checked ? CheckState.Checked : CheckState.Unchecked);

            if (wCheckState == CheckState.Checked)
            {
                this.btnCheck.Caption = "Quitar selección";
                this.btnCheck.Glyph = global::Allus.Cnn.Admin.Properties.Resources.control_stop_16;
            }
            else
            {
                this.btnCheck.Caption = "Seleccionar";
                this.btnCheck.Glyph = global::Allus.Cnn.Admin.Properties.Resources.confirm_16;
            }

            foreach (TreeListNode node in treeList2.Nodes)
            {
                node.CheckState = wCheckState;
                SetCheckedChildNodes(node, wCheckState);
            }
        }


        public void CheckThisDomains(DomainList list)
        {
            if (list == null) return;
            if (list.Count == 0) return;
            CheckThisDomains(treeList2.Nodes, list);
        }
        /// <summary>
        /// Recursividad para chequear los nodes
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="list"></param>
        void CheckThisDomains(TreeListNodes nodes, DomainList list)
        {
            Domain d;
            foreach (TreeListNode node in nodes)
            {
                d = ((Domain)treeList2.GetDataRecordByNode(node));
                if (list.Any<Domain>(p =>
                    p.DomainId.Equals(d.DomainId) && p.Hierarchy.Equals(d.Hierarchy)
                    && p.ParentID.Equals(d.ParentID)
                    ))
                {
                    node.CheckState = CheckState.Checked;
                }

                CheckThisDomains(node.Nodes, list);
            }
        }

        /// <summary>
        /// Genera un nuevo mesh desde la grilla de meshes cachados .- Este metodo se usa cuando el mesh no fue creado
        /// desde el tree de dominios
        /// </summary>
        /// <param name="pMeshBE">MeshBE</param>
        public void GenerateAndShowMesh(MeshBE pMeshBE)
        {

            TreeListNode selNode = null;
            //Cuenta
            if (pMeshBE.CuentaId != null)
                selNode = GetNodeByDomainId(this.treeList2.Nodes, pMeshBE.CuentaId);
            //SubArea
            if (pMeshBE.SubAreaId != null)
                selNode = GetNodeByDomainId(selNode.Nodes, pMeshBE.SubAreaId);
            //Cargo
            if (pMeshBE.CargoId != null)
                selNode = GetNodeByDomainId(selNode.Nodes, pMeshBE.CargoId);

            //Si el nodo es nulu significa que este administrador ya no es administrador de este dominio
            if (selNode == null)
            {
                this.MessageViewer.Show("Ya no tiene permiso para utilizar esta sala.");
                return ;
            }
            Mesh  wMesh = MeshFactory.GetMeshForm(pMeshBE, selNode);

            wMesh.FinalizeMeshEvent += new FinalizeMeshHandler(Mesh_FinalizeMeshEvent);
            wMesh.SendMessageEvent += new EventHandler(Mesh_SendMessageEvent);

            //Indica que este nodo pertenece a un mesh creado (cambia el icono del nodo en el tree)
            ((Domain)treeList2.GetDataRecordByNode(selNode)).InMesh = true;
            treeList2.RefreshDataSource();
            wMesh.Show();

        }

        /// <summary>
        /// Busca un nodo en el arbol por el Id de dominio
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="domainId"></param>
        /// <returns></returns>
        TreeListNode GetNodeByDomainId(TreeListNodes nodes, int? domainId)
        {
            Domain d ;
            foreach (TreeListNode node in nodes)
            {
                d = ((Domain)treeList2.GetDataRecordByNode(node));
                if (d.DomainId == domainId)
                    return node;
                
            }
            return null;
        }
    }
}
