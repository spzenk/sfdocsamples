using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Epiron.Front.Bases;

namespace Epiron.Front.Bases.Controls
{
    public partial class ComboAuthenticationType : Xtra_UC_Base, IEpironControl
    {
       
        //Variable para carga de combo una sola vez al comienzo
        //dps pasa a false para asi habilitar el evento ActiveFlagCheckedChanged_1(activos o no activos )
        private Boolean bFirstLoad = true;
        bool active = false;
        [Browsable(true)]
        [Category("Epiron")]
        public string TextUICode { get; set; }

        [Browsable(true)]
        [Category("Epiron")]
        public Boolean CheckEditingABMValue { get; set; }

        [Browsable(true)]
        [Category("Epiron")]
        public Boolean CheckEditingABM { get; set; }

      
        private DataTable dtAuthenticationType;

        public DataTable DtAuthenticationType
        {
            get { return dtAuthenticationType; }
            set { dtAuthenticationType = value; }
        }
        public ComboAuthenticationType()
        {
            InitializeComponent();
           
        }

        #region [ComboEditValueChanged]
        public event EventHandler OnComboEditValueChanged;
        
      


        #endregion


        public override void Populate(object dtt)
        {
            dtAuthenticationType = (DataTable)dtt;
            try
            {




                //TODO: Ver que es esto
                //if (cmbAuthenticationType._ShowActiveFlag && cmbAuthenticationType._ActiveFlagChecked)
                //    active = true;

                if (dtAuthenticationType != null)
                {
                    //AccountList _List = AccountController.AccountGet(null, active);
                    //System.Data.DataRowCollection _Rows = dtAuthenticationType.Rows;


                    AuthenticationTypeList wAuthenticationTypeList = new AuthenticationTypeList();

                    Int32 CountRows = dtAuthenticationType.Rows.Count;
                    String strEventText;
                    if (Common.CheckIfExistEventResponseId(dtAuthenticationType, out strEventText))
                    {
                        this.MessageViewer.Show(strEventText);
                        return;
                    }
                    AuthenticationType wAuthenticationType = null;

                    foreach (DataRow dr in dtAuthenticationType.Rows)
                    {
                        wAuthenticationType = new AuthenticationType();

                        wAuthenticationType.AuthenticationTypeName = dr["AuthenticationTypeName"].ToString();
                        wAuthenticationType.AuthenticationTypeTag = dr["AuthenticationTypeTag"].ToString();
                        wAuthenticationType.AuthenticationTypeGUID = Guid.Parse(dr["AuthenticationTypeGUID"].ToString());
                        wAuthenticationType.Guid = Guid.Parse(dr["Guid"].ToString());

                        wAuthenticationTypeList.Add(wAuthenticationType);
                    }


                    #region[Agregado de Item a lista de acuerdo a propiedad _WithTextSelection]

                    //if (WithTextSelection == true)
                    //{
                    //    wAuthenticationType = new AuthenticationType();
                    //    wAuthenticationType.AuthenticationTypeTag = "-1";
                    //    wAuthenticationType.AuthenticationTypeName = "Seleccione";
                    //    wAuthenticationTypeList.Add(wAuthenticationType);
                    //}

                    #endregion
                    cmbAuthenticationType.Properties.DataSource = wAuthenticationTypeList;
                    cmbAuthenticationType.Refresh();
                    Int32 wIndexWindows = cmbAuthenticationType.Properties.GetDataSourceRowIndex("AuthenticationTypeTag", "WINDOWS");



                    foreach (DevExpress.XtraEditors.Controls.LookUpColumnInfo col in cmbAuthenticationType.Properties.Columns)
                    {
                        if (col.FieldName != "AuthenticationTypeName")
                        {
                            col.Visible = false;
                        }
                    }

                    bFirstLoad = false;
                }
            }
            catch (Exception ex)
            {
                this.ExceptionViewer.Show(ex);

            }

        }

        /// <summary>
        /// Obtiene los datos que están siendo utilizados por el combo
        /// </summary>
        /// <returns></returns>
        //public  AuthenticationType GetDataSelectedCombo()
        //{
        //    try
        //    {
        //*** Utilizando llamada a la BD ***
        //LookUpEdit1.EditValue = LookUpEdit1.Properties.GetDataSourceValue(LookUpEdit1.Properties.ValueMember, 0);
        //Boolean? active = null;
        //if (baseComboCheck1._ShowActiveFlag && baseComboCheck1._ActiveFlagChecked)
        //    active = true;
        //AccountList _List = AccountController.AccountGet(Convert.ToInt32(LookUpEdit1.EditValue), active);
        //**********************************


        //Lista completa
        //AuthenticationTypeList _AuthenticationTypeList = (AuthenticationTypeList)baseComboCheck1.baseCombo1.bindingSource1.List;
        //Se declara variable tipo entidad
        //AuthenticationType _AuthenticationType = null;
        //Se filtra por el id
        //foreach (AuthenticationType _acc in _AuthenticationTypeList)
        //{
        //    if (_acc.AuthenticationTypeGUID == Guid.Parse (LookUpEdit1.EditValue.ToString()))
        //    {
        //        _account = _acc;
        //        break;
        //    }
        //}

        //return _account;

        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //        throw;

        //    }
        //}
        /// <summary>
        /// Obtiene listado de todos los registros
        /// </summary>
        /// <returns></returns>
        //public AccountList GetDataAllCombo()
        //{
        //    try
        //    {

        //        AccountList _accountList = (AccountList)baseComboCheck1.baseCombo1.bindingSource1.List;
        //        return _accountList;

        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //        throw;

        //    }
        //}
        public String GetAuthenticationTypeGUID()
        {
            //try
        


                if (this.cmbAuthenticationType.ItemIndex != -1)
                {
                    return (this.cmbAuthenticationType.GetColumnValue("AuthenticationTypeGUID").ToString());
                }
                else
                {
                    return null;
                }

           
        }


        //public String _AuthenticationType
        //{
        //    get
        //    {
        //        DevExpress.XtraEditors.LookUpEdit LookUpEdit1 = baseComboCheck1.baseCombo1.lookUpEdit1;
        //        if (!baseComboCheck1._Checked && baseComboCheck1._ShowCheck)
        //            return null;
        //        else
        //            return (LookUpEdit1.EditValue.ToString());
        //    }
        //    set
        //    {

        //        LookUpEdit1 = baseComboCheck1.baseCombo1.lookUpEdit1;
        //        LookUpEdit1.EditValue = value;
        //    }
        //}

        public String GetAuthenticationType()
        {
          
                if (this.cmbAuthenticationType.ItemIndex != -1)
                {
                    return (this.cmbAuthenticationType.GetColumnValue("AuthenticationTypeTag").ToString());
                }
                else
                {
                    return null;
                }
     
        }


        private void cmbAuthenticationType_ComboEditValueChanged(object sender, System.EventArgs e)
        {

            if (OnComboEditValueChanged != null)
            {
                OnComboEditValueChanged(GetAuthenticationType(), new EventArgs());
            }



          
        }








    }
    public class AuthenticationType
    {
        private String authenticationTypeName;
        private String authenticationTypeTag;
        private Guid authenticationTypeGUID;
        private Guid guid;


        public String AuthenticationTypeName
        {
            get { return authenticationTypeName; }
            set { authenticationTypeName = value; }
        }

        public String AuthenticationTypeTag
        {
            get { return authenticationTypeTag; }
            set { authenticationTypeTag = value; }
        }

        public Guid AuthenticationTypeGUID
        {
            get { return authenticationTypeGUID; }
            set { authenticationTypeGUID = value; }
        }

        public Guid Guid
        {
            get { return guid; }
            set { guid = value; }
        }

    }

    public class AuthenticationTypeList : List<AuthenticationType>
    {

    }
}
