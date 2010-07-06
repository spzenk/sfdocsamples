using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Allus.Cnn.Common;
using Allus.Cnn;
using System.Net;

using Allus.Cnn.Common.Proxy;
using System.Threading;
using Allus.Cnn.Common.BE;


namespace Allus.Cnn.Admin
{
    public partial class AdminDomainsScope : frmBaseDialog
    {
        ColaboratorData _Filter;
        public AdminDomainsScope()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Normal;
            textFindPopUp1.Properties.CloseOnOuterMouseClick = false;
        }


        private void AdminDomainsScope_Load(object sender, EventArgs e)
        {
            InitControls();
        }

        void InitControls()
        {
            this.domainFilters1.Populate();
            this.adminDomainGrid_Source.PopulateAsync();
        }
        
        private void colaboratorsAdminGrid1_SelectColaboratorEvent(object sender, EventArgs e)
        {
            //Cargo los dominios del usuario en la grilla de abajo
            DomainList dom = Controller.SearchRelatedDomainsByUser(String.Empty, ((ColaboratorData)sender).UserId, false, false);
            adminDomainGrid_Dest.Populate(dom);
            //Una vez cargado macheo los check de la grilla de arriba con los dominios de la grilla de abajo.-
            adminDomainGrid_Source.CheckThisDomains(adminDomainGrid_Dest.RelatedDomains);
        }

        private void colaboratorsAdminGrid1_RefreshColaboratorEvent(object sender, EventArgs e)
        {
            if (_Filter != null)
                colaboratorsAdminGrid1.Populate(_Filter);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            adminDomainGrid_Dest.Populate(adminDomainGrid_Source.GetCheckedDomains());
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (this.colaboratorsAdminGrid1.CurrentColaborator == null)
            {
                this.MessageViewer.Show("Seleccione un usuario");
                return;
            }
            if (this.adminDomainGrid_Dest.RelatedDomains == null)
            {
                this.MessageViewer.Show("Seleccione uno o mas dominios permitidos para el usuario");
                return;
            }
            if (this.adminDomainGrid_Dest.RelatedDomains.Count == 0)
            {
                this.MessageViewer.Show("Seleccione uno o mas dominios permitidos para el usuario");
                return;
            }
            Controller.CreateDomainsToAdmin(this.colaboratorsAdminGrid1.CurrentColaborator.Username, this.adminDomainGrid_Dest.RelatedDomains);

            this.MessageViewer.Show("Los permisos para el usuario se almacenaron correctamente");

        }

        /// <summary>
        /// Busca por texto y filtros de dominio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textFindPopUp1_OnFindClick(object sender, EventArgs e)
        {
            _Filter = domainFilters1.GetFilter();
            if (_Filter == null) return;
            
            //Si no hay parametros de busqueda retornar
            if ((IsfilterNull(_Filter) && string.IsNullOrEmpty(textFindPopUp1.TextEditor.Text)))
                return;
            else
            {
                _Filter.Username = textFindPopUp1.TextEditor.Text;
                _Filter.Firstname = textFindPopUp1.TextEditor.Text;
                _Filter.Surname = textFindPopUp1.TextEditor.Text;
            }

            colaboratorsAdminGrid1.Populate(_Filter);

        }

        /// <summary>
        /// Retorna true si el contenido del filtro es nulo.- Es decir si no existen parametros por los cuales buscar.-
        /// No chequea user name
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        bool IsfilterNull(ColaboratorData filter)
        {
            return (_Filter.CuentaId == null) &&
                (_Filter.SubAreaId == null) &&
                (_Filter.SucursalId == null) &&
                (_Filter.CargoId == null) &&
                (_Filter.Domain.Equals(Common.Common.NULL));


        }
        
        /// <summary>
        /// Busca solo por texto del nombre del usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textFindPopUp1_OnFindTextBoxEnter(object sender, EventArgs e)
        {
            _Filter = new ColaboratorData();
            _Filter.Username = textFindPopUp1.TextEditor.Text;
            _Filter.Firstname = textFindPopUp1.TextEditor.Text;
            _Filter.Surname = textFindPopUp1.TextEditor.Text;
            colaboratorsAdminGrid1.Populate(_Filter);
        }

        /// <summary>
        /// Busca por texto y filtros de dominio
        /// </summary>
        /// <param name="filter"></param>
        private void domainFilters1_AceptDomainFilterEvent(ColaboratorData filter)
        {
            filter.Username = textFindPopUp1.TextEditor.Text;
            _Filter = filter;
            colaboratorsAdminGrid1.Populate(_Filter);

        }

       
    }
}
