using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Allus.Cnn.Common.BE;

namespace Allus.Cnn.Common
{
    [ToolboxItem(true)]
    public partial class DomainCombosFilters : Allus.Cnn.Common.UserControlBase
    {

        MeshBE _MeshBE ;
        [Category("Allus.Libraries")]
        public event EventHandler OnClick;

        [Browsable(false)]
        public MeshBE Mesh
        {
            get { return _MeshBE; }
            set { _MeshBE = value; }
        }



        public DomainCombosFilters()
        {
            InitializeComponent();
        }

        void FillMesh()
        {
            _MeshBE.CuentaId = GetValueFromCombo(cmdCuenta);

            _MeshBE.Cuenta = (_MeshBE.CuentaId == null) ? Common.NULL : cmdCuenta.Text; 

            _MeshBE.SubAreaId = GetValueFromCombo(cmdSubarea);
            _MeshBE.Subarea = (_MeshBE.SubAreaId == null)? Common.NULL:cmdSubarea.Text;
          
            _MeshBE.CargoId = GetValueFromCombo(cmdCargo);
            _MeshBE.Cargo = (_MeshBE.CargoId == null) ? Common.NULL : cmdCargo.Text; 

            _MeshBE.SucursalId = GetValueFromCombo(cmbSucursal);
            _MeshBE.Sucursal = (_MeshBE.SucursalId == null) ? Common.NULL : cmbSucursal.Text;  

            if (cmbDominio.EditValue != null)
                if ((int)cmbDominio.EditValue != -1)
                    _MeshBE.Domain = cmbDominio.Text;

        }

        public void Populate()
        {
            cuentaBindingSource.DataSource = Controller.Cuentas;
            SubareabindingSource.DataSource = Controller.SubAreas;
            cargobindingSource.DataSource = Controller.Cargos;
            dominiobindingSource.DataSource = Controller.Dominios;
            sucursalbindingSource.DataSource = Controller.Sucursales;
            cmdCuenta.ItemIndex = 0;
            cmdSubarea.ItemIndex = 0;
            cmdCargo.ItemIndex = 0;
            cmbDominio.ItemIndex = 0;
            cmbSucursal.ItemIndex = 0;
        }

        int? GetValueFromCombo(DevExpress.XtraEditors.LookUpEdit cmd)
        {
            int? id = null;
            if (cmd.EditValue != null)
                if ((int)cmd.EditValue > 0)
                    id = (int)cmd.EditValue;
            return id;
        }

        private void cmdCuenta_EditValueChanged(object sender, EventArgs e)
        {
            FillMesh();
        }

        private void cmdSubarea_EditValueChanged(object sender, EventArgs e)
        {
            FillMesh();
        }

        private void cmdCargo_EditValueChanged(object sender, EventArgs e)
        {
            FillMesh();
        }

        private void cmbDominio_EditValueChanged(object sender, EventArgs e)
        {
            FillMesh();
        }

        private void cmbSucursal_EditValueChanged(object sender, EventArgs e)
        {
            FillMesh();
        }

        private void DomainCombosFilters_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
                _MeshBE = new MeshBE();
        }


    }
}
