using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;



namespace  Epiron.Front.Bases.Controls
{
    [ToolboxItem(true)]
    public partial class ComboDomain : Xtra_UC_Base
    {
        private DataTable dtDominio;
        //Variable para carga de combo una sola vez al comienzo
        //dps pasa a false para asi habilitar el evento ActiveFlagCheckedChanged_1(activos o no activos )
        private Boolean bFirstLoad = true;

        public ComboDomain()
        {
            InitializeComponent();

            // Se setea propiedad para que cuando no haya valores, se muestre vacio
            cmbDominios.Properties.NullText = "";
        }

        //DomainName
        //DomainGUID
        Boolean? active = null;
        public override void Populate(object obj)
        {
            dtDominio = (DataTable)obj;
            try
            {
                

                cmbDominios.Properties.DisplayMember = "DomainName";
                cmbDominios.Properties.ValueMember = "DomainGUID";


                //if (cmbDominios._ShowActiveFlag && cmbDominios._ActiveFlagChecked)
                //    active = true;

                if (dtDominio != null)
                {
                    //AccountList _List = AccountController.AccountGet(null, active);
                    //System.Data.DataRowCollection _Rows = _DtAuthenticationType.Rows;


                    DomainList wDomainList = new DomainList();

                    foreach (DataRow dr in dtDominio.Rows)
                    {
                        Domain wDomain = new Domain();

                        //wDomain.DomainId = Convert.ToInt32( dr.Table.Rows[0]["DomainId"]);
                        wDomain.DomainName = dr.Table.Rows[0]["DomainName"].ToString();
                        wDomain.DomainGUID = dr.Table.Rows[0]["DomainGUID"].ToString();

                        wDomainList.Add(wDomain);
                    }


                    #region[Agregado de Item a lista de acuerdo a propiedad _WithTextSelection]

                    //if (_WithTextSelection == true)
                    //{
                    //    DataRow wAccountBE_Seleccione = new AccountBE();
                    //    wAccountBE_Seleccione.AccountId = -1;
                    //    wAccountBE_Seleccione.AccountName = "Seleccione";
                    //    _List.Insert(0, wAccountBE_Seleccione);
                    //}

                    #endregion
                    cmbDominios.Properties.DataSource = wDomainList;
                    cmbDominios.Refresh();
                    cmbDominios.EditValue = cmbDominios.Properties.GetDataSourceValue(cmbDominios.Properties.ValueMember, 0);
                    //cmbDominios.Properties.PopulateColumns();

                    foreach (DevExpress.XtraEditors.Controls.LookUpColumnInfo col in cmbDominios.Properties.Columns)
                    {
                        if (col.FieldName != "DomainName")
                        {
                            col.Visible = false;
                        }
                    }

                    bFirstLoad = false;


                }
            }
            catch (Exception)
            {

                throw;
            }

        }



        //public String _DomainGUID
        //{
        //    get
        //    {
        //        DevExpress.XtraEditors.LookUpEdit cmbDominios = new LookUpEdit();
        //        cmbDominios = baseComboCheck1.baseCombo1.cmbDominios;
        //        if (!baseComboCheck1._Checked && baseComboCheck1._ShowCheck)
        //            return null;
        //        else
        //            return cmbDominios.EditValue.ToString();
        //    }
        //    set
        //    {

        //        cmbDominios = baseComboCheck1.baseCombo1.cmbDominios;
        //        cmbDominios.EditValue = value;
        //    }
        //}


        public String GetDomainGUID()
        {
            try
            {
                DevExpress.XtraEditors.LookUpEdit cmbDominios = new LookUpEdit();

                if (cmbDominios.ItemIndex != -1)
                {
                    return (cmbDominios.EditValue.ToString());
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        //public Boolean _ShowCheck
        //{
        //    get { return cmbDominios._ShowCheck; }
        //    set { cmbDominios._ShowCheck = value; }
        //}

        //public Boolean _Checked
        //{
        //    get { return cmbDominios._Checked; }
        //    set { cmbDominios._Checked = value; }
        //}





        private Boolean TextSelection;
        [Category("Components"), Description("Agrega texto 'Seleccione' al los item del combo ")]
        public Boolean WithTextSelection
        {
            get { return TextSelection; }
            set { TextSelection = value; }
        }

        public Boolean ContainDomains
        {
            get
            {
                if (dtDominio == null) return false;
                return dtDominio.Rows.Count > 0;
            }
        }
    }


    public class Domain
    {
        private String domainName;
        private String domainGUID;
        private Int32? domainId;

        public String DomainName
        {
            get { return domainName; }
            set { domainName = value; }
        }

        public String DomainGUID
        {
            get { return domainGUID; }
            set { domainGUID = value; }
        }

        public Int32? DomainId
        {
            get { return domainId; }
            set { domainId = value; }
        }

    }

    public class DomainList : List<Domain>
    {
 
    }
}
