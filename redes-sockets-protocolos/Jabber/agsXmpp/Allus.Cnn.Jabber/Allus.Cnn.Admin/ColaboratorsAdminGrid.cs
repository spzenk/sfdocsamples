using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Allus.Cnn.Common;
using Allus.Cnn.Common.DAC;
using DevExpress.XtraGrid.Views.Base;
using Allus.Cnn.Common.BE;
using System.Collections;

namespace Allus.Cnn.Admin
{
    [ToolboxItem(true)]
    [DefaultEvent("SelectColaboratorEvent")]
    public partial class ColaboratorsAdminGrid : UserControlBase
    {
        private List<ColaboratorData> _ColaboratorList = null;
        [Category("Allus.Libraries")]
        public event EventHandler SelectColaboratorEvent;
        [Category("Allus.Libraries")]
        public event EventHandler RefreshColaboratorEvent;

        [Browsable(false)]
        public int ColaboratorsCountInMesh
        {
            get
            {

                return _ColaboratorList.Count;
            }
        }

        public ColaboratorsAdminGrid()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                _ColaboratorList = new List<ColaboratorData>();
                colaboratorBindingSource.DataSource = _ColaboratorList;
            }
        }
        /// <summary>
        /// Carga la grilla con un MeshId proveniente como filtro
        /// </summary>
        /// <param name="meshId"></param>
        public void Populate(string meshId )
        {
            ColaboratorData pColaboratorDataInfo = Allus.Cnn.Common.Common.GetColaboratorDataFromMeshId(meshId);
            Populate(pColaboratorDataInfo);
        }

        /// <summary>
        /// Carga la grilla con los los usuarios de la base de datos por medio de un filtro
        /// Mapea los usuarios de la base de datos con los que estan conectados en P2P
        /// </summary>
        /// <param name="pColaboratorDataInfo">ColaboratorData utilizado como filtro</param>
        public void Populate(ColaboratorData pColaboratorDataInfo)
        {

            try
            {
                _ColaboratorList = Controller.SearchColaboratorsByParams(pColaboratorDataInfo);

                if (_ColaboratorList.Count == 0)
                    MessageViewer.Show("La busqueda no tuvo resultados");

                Controller.MapColaborators_ColaboratorsData(Controller.ColaboratorList, _ColaboratorList);
            }
            catch (Exception ex)
            {
                this.ExceptionViewer.Show(ex);
                return;
            }
            colaboratorBindingSource.DataSource = _ColaboratorList;
            grdColaboratos.RefreshDataSource();
        }

        /// <summary>
        /// Carga la grilla con los los usuarios de la base de datos <see cref="List<ColaboratorData>"/>
        /// </summary>
        /// <param name="list">Lista de ColaboratorData</param>
        public void Populate(List<ColaboratorData>  list)
        {
            _ColaboratorList = list;
            colaboratorBindingSource.DataSource = _ColaboratorList;
            Controller.MapColaborators_ColaboratorsData(Controller.ColaboratorList, _ColaboratorList);
            grdColaboratos.RefreshDataSource();

            //repositoryItemPictureEdit1.EditValue = gridView1.OptionsView.AnimationType;
        }

        /// <summary>
        /// Agrega un colaboratordata a través de un Colaborator.- 
        /// Este metodo no busca en BD, realiza la busqueda en la lista de ColaboratorData y le asigna la IP del pColaborator
        /// </summary>
        /// <param name="pColaborator"></param>
        public void Add(Colaborator pColaborator)
        {
            //Si el colaborador es un administrador no se agrega a la grilla
            if (pColaborator.IsAdmin) return;

            ColaboratorData wColaboratorData;
            //Solo se agrega el colaborador si no estaba agregado
            if (_ColaboratorList.Any<ColaboratorData>(col => col.Username.Equals(pColaborator.Name, StringComparison.OrdinalIgnoreCase)))
            {
                wColaboratorData = _ColaboratorList.First<ColaboratorData>(col => col.Username.Equals(pColaborator.Name, StringComparison.OrdinalIgnoreCase));
                wColaboratorData.MachineIp = pColaborator.MachineIp;
                wColaboratorData.Connected = true;
                grdColaboratos.RefreshDataSource();
            }
            //else
            //{
            //    wColaboratorData = new ColaboratorData(pColaborator);
            //    wColaboratorData.Connected = true;
            //    _ColaboratorList.Add(wColaboratorData);
                
            //}

           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pColaborator"></param>
        public void Remove(Colaborator pColaborator)
        {
            if (_ColaboratorList.Any<ColaboratorData>(col => col.Username.Equals(pColaborator.Name, StringComparison.OrdinalIgnoreCase)))
            {
                ColaboratorData wColaboratorData = _ColaboratorList.First<ColaboratorData>(col => col.Username.Equals(pColaborator.Name,StringComparison.OrdinalIgnoreCase));
                wColaboratorData.MachineIp = "";
                wColaboratorData.Connected = false;
           
                grdColaboratos.RefreshDataSource();

            }
        }

        private void barBtnItem_Cards_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdColaboratos.MainView = this.layoutView1;
        }

        private void barBtnItem_Grid_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdColaboratos.MainView = this.gridView1;
        }
        public ColaboratorData CurrentColaborator;
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            CurrentColaborator = (ColaboratorData)((System.Windows.Forms.BindingSource)gridView1.DataSource).Current;
            OnSelectColaboratorEvent();


        }

        private void btnRereshColaborators_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (RefreshColaboratorEvent != null)
                RefreshColaboratorEvent(this, new EventArgs());

        }



       

        private void layoutView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {

            CurrentColaborator = (ColaboratorData)((System.Windows.Forms.BindingSource)(grdColaboratos.MainView.DataSource)).Current;
            OnSelectColaboratorEvent();
           
        }

        void OnSelectColaboratorEvent()
        {
            if (SelectColaboratorEvent != null)
            {
                SelectColaboratorEvent(CurrentColaborator, new EventArgs());
                lblColaboratorData.Caption = CurrentColaborator.Username;
            }
        }
        //Dictionary<int, Image> ht = new Dictionary<int, Image>();
        private void gridView1_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                DataRow row = gridView1.GetDataRow(e.RowHandle);
                if (row == null) return;
                bool key = (bool)row["Connected"];
                if (key)

                    //if (!ht.ContainsKey(key))
                    //    ht.Add(key, GetImage(key));
                    e.Value = Allus.Cnn.Admin.Properties.Resources.ball_green;
                else
                    e.Value = Allus.Cnn.Admin.Properties.Resources.ball_yellow;

            }
        }

       
    }
}
