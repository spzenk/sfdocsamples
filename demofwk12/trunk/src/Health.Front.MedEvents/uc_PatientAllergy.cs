using System;
using System.Linq;

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Health.Back.BE;
using Health.Entities;
using DevExpress.XtraEditors.Controls;
using Fwk.UI.Common;
using Health.BE;
using Health.BE.Enums;
using Health.Front;
namespace Health.Front.Patients
{
    public partial class uc_PatientAllergy : Xtra_UC_Base
    {
        PatientAllergyBE _PatientAllergy_Aux;
        //ParametroList _CurrentAllergiesItemTypesList = null;
        internal PatientAllergyBE _PatientAllergy { get; set; }

        public uc_PatientAllergy()
        {
            InitializeComponent();
            this.ShowClose = true;
            this.ShowSave = true;
        }


        public void Init()
        {
            if (ServiceCalls.IsInDesignMode()) return;

     
            InitializeComboBoxDatasource(TipoAlergia.AnimalAllergy);
            InitializeComboBoxDatasource(TipoAlergia.ChemicalAllergy);
            InitializeComboBoxDatasource(TipoAlergia.FoodAllergy);
            InitializeComboBoxDatasource(TipoAlergia.InsectAllergy);
            InitializeComboBoxDatasource(TipoAlergia.MedicamentsAllergy);
            //InitializeComboBoxDatasource(TipoAlergia.MiteAllergy);
            InitializeComboBoxDatasource(TipoAlergia.PollenAllergy);
            //InitializeComboBoxDatasource(TipoAlergia.SunAllergy);

            _PatientAllergy = frmPatientAtencion.GetInstance(this)._PatientAllergy;
            if (_PatientAllergy.AllergyId == -1)
            {
                _PatientAllergy = new PatientAllergyBE();
                _PatientAllergy.PatientId = ServiceCalls.CurrentPatient.PatientId;
                _PatientAllergy.EntityState = Fwk.Bases.EntityState.Added;
            }
            else
            {
                _PatientAllergy.EntityState = Fwk.Bases.EntityState.Unchanged;
            }

            _PatientAllergy_Aux = _PatientAllergy.Clone<PatientAllergyBE>();
            PopulateControls();
        }

        public override void Refresh()
        {
            Init();
            base.Refresh();
        }

        void PopulateControls()
        {
            chkPetAllergy.Checked = _PatientAllergy.AnimalAllergy;
            chkChemicalAllergy.Checked = _PatientAllergy.ChemicalAllergy;
            chkFoodAllergy.Checked = _PatientAllergy.FoodAllergy;
            chkInsectAllergy.Checked = _PatientAllergy.InsectAllergy;
            chkMiteAllergy.Checked = _PatientAllergy.MiteAllergy;
            chkPollen.Checked = _PatientAllergy.PollenAllergy;
            chkSol.Checked = _PatientAllergy.SunAllergy;

            if (!String.IsNullOrEmpty(_PatientAllergy.OtherAllergy))
            {

                SetCombo(checkedCombo_ChemicalAllergy);
                SetCombo(checkedCombo_FoodAllergy);
                SetCombo(checkedCombo_InsectAllergy);
                SetCombo(checkedCombo_MedicamentsAllergy);
                //SetCombo(checkedCombo_MiteAllergies);
                SetCombo(checkedCombo_PetAllergy);
                SetCombo(checkedCombo_Pollen);
                //SetCombo(checkedCombo_Sun);
            }

            textEdit1.Text = GetComboValues();
        }

        /// <summary>
        /// Recorre el los items del combo y chekea aquellos q pertenescan a items del paciente
        /// </summary>
        /// <param name="cmd"></param>
        void SetCombo(CheckedComboBoxEdit cmd)
        {
            foreach (CheckedListBoxItem item in cmd.Properties.Items)
            {
                if (_PatientAllergy.OtherAllergy.Contains(item.Value.ToString()))
                    item.CheckState = CheckState.Checked;
            }
        }

        void Set_PatientAllergy(PatientAllergyBE patientAllergyBE)
        {
            patientAllergyBE.AnimalAllergy = chkPetAllergy.Checked;
            patientAllergyBE.ChemicalAllergy = chkChemicalAllergy.Checked;
            patientAllergyBE.FoodAllergy = chkFoodAllergy.Checked;
            patientAllergyBE.InsectAllergy = chkInsectAllergy.Checked;
            patientAllergyBE.MedicamentsAllergy = chkMedicamentsAllergy.Checked;
            patientAllergyBE.MiteAllergy = chkMiteAllergy.Checked;
            patientAllergyBE.PollenAllergy = chkPollen.Checked;
            patientAllergyBE.SunAllergy = chkSol.Checked;
            patientAllergyBE.MedicalEventId = frmPatientAtencion.GetInstance(this).MedicalEvent.MedicalEventId;
            patientAllergyBE.OtherAllergy = GetComboIds();
            patientAllergyBE.Observation = txtObservacion.Text;


        }

        bool CheckChanges()
        {
            bool hasChanges = false;
            if (!_PatientAllergy.FoodAllergy.Equals(_PatientAllergy_Aux.FoodAllergy)) hasChanges = true;
            if (hasChanges == false && !_PatientAllergy.AnimalAllergy.Equals(_PatientAllergy_Aux.AnimalAllergy)) hasChanges = true;
            if (hasChanges == false && !_PatientAllergy.ChemicalAllergy.Equals(_PatientAllergy_Aux.ChemicalAllergy)) hasChanges = true;

            if (hasChanges == false && !_PatientAllergy.InsectAllergy.Equals(_PatientAllergy_Aux.InsectAllergy)) hasChanges = true;
            if (hasChanges == false && !_PatientAllergy.MedicamentsAllergy.Equals(_PatientAllergy_Aux.MedicamentsAllergy)) hasChanges = true;
            if (hasChanges == false && !_PatientAllergy.MiteAllergy.Equals(_PatientAllergy_Aux.MiteAllergy)) hasChanges = true;
            if (hasChanges == false && !_PatientAllergy.PollenAllergy.Equals(_PatientAllergy_Aux.PollenAllergy)) hasChanges = true;
            if (hasChanges == false && !_PatientAllergy.SunAllergy.Equals(_PatientAllergy_Aux.SunAllergy)) hasChanges = true;
            if (hasChanges == false && !_PatientAllergy.Observation.Equals(_PatientAllergy_Aux.Observation)) hasChanges = true;

            if (hasChanges == false && !_PatientAllergy.OtherAllergy.Equals(_PatientAllergy_Aux.OtherAllergy)) hasChanges = true;


            if (hasChanges)
                _PatientAllergy.EntityState = Fwk.Bases.EntityState.Changed;

            return hasChanges;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //String str = cmbTherAllergies.Properties.GetCheckedItems().ToString();
            //textEdit1.Text = cmbTherAllergies.Text;
            String str = "10105, 10110, 10109";

            foreach (CheckedListBoxItem item in checkedCombo_Pollen.Properties.Items)
            {
                if (str.Contains(item.Value.ToString()))
                    item.CheckState = CheckState.Checked;
            }
        }

        private void cmb_EditValueChanged(object sender, EventArgs e)
        {

            textEdit1.Text = GetComboValues();
        }

        /// <summary>
        /// Retorna los valores selecionados separados por coma
        /// </summary>
        /// <returns></returns>
        String GetComboIds()
        {
            StringBuilder str = new StringBuilder();

            if (!String.IsNullOrEmpty(checkedCombo_ChemicalAllergy.Properties.GetCheckedItems().ToString()))
            {
                str.Append(checkedCombo_ChemicalAllergy.Properties.GetCheckedItems().ToString().Replace(" ", ""));
                str.Append(",");
            }
            if (!String.IsNullOrEmpty(checkedCombo_FoodAllergy.Properties.GetCheckedItems().ToString()))
            {
                str.Append(checkedCombo_FoodAllergy.Properties.GetCheckedItems().ToString().Replace(" ", ""));
                str.Append(",");
            }

            if (!String.IsNullOrEmpty(checkedCombo_InsectAllergy.Properties.GetCheckedItems().ToString()))
            {
                str.Append(checkedCombo_InsectAllergy.Properties.GetCheckedItems().ToString().Replace(" ", ""));
                str.Append(",");
            }

            if (!String.IsNullOrEmpty(checkedCombo_MedicamentsAllergy.Properties.GetCheckedItems().ToString()))
            {
                str.Append(checkedCombo_MedicamentsAllergy.Properties.GetCheckedItems().ToString().Replace(" ", ""));
                str.Append(",");
            }


            if (!String.IsNullOrEmpty(checkedCombo_PetAllergy.Properties.GetCheckedItems().ToString()))
            {
                str.Append(checkedCombo_PetAllergy.Properties.GetCheckedItems().ToString().Replace(" ", ""));
                str.Append(",");
            }

            if (!String.IsNullOrEmpty(checkedCombo_Pollen.Properties.GetCheckedItems().ToString()))
            {
                str.Append(checkedCombo_Pollen.Properties.GetCheckedItems().ToString().Replace(" ", ""));
                str.Append(",");
            }

            if (str.Length > 0)
                str.Remove(str.Length - 1, 1);

            return str.ToString();
        }

        /// <summary>
        /// Retorna los valores selecionados separados por coma
        /// </summary>
        /// <returns></returns>
        String GetComboValues()
        {
            StringBuilder str = new StringBuilder();

            //Acaros
            if (chkMiteAllergy.Checked)
            {
                str.AppendLine("Alergia a los Ácaros");
                str.AppendLine();

            }

            if (checkedCombo_FoodAllergy.Properties.Items.Count != 0 && chkFoodAllergy.Checked && !String.IsNullOrEmpty(checkedCombo_FoodAllergy.Text))
            {
                str.AppendLine(checkedCombo_FoodAllergy.Text.Replace(", ", "\r\n"));
                str.AppendLine();
            }
            //Animales
            if (checkedCombo_PetAllergy.Properties.Items.Count != 0 && chkPetAllergy.Checked && !String.IsNullOrEmpty(checkedCombo_PetAllergy.Text))
            {
                str.AppendLine(checkedCombo_PetAllergy.Text.Replace(", ", "\r\n"));
                str.AppendLine();
            }

            if (checkedCombo_MedicamentsAllergy.Properties.Items.Count != 0 && chkMedicamentsAllergy.Checked && !String.IsNullOrEmpty(checkedCombo_MedicamentsAllergy.Text))
            {
                str.AppendLine(checkedCombo_MedicamentsAllergy.Text.Replace(", ", "\r\n"));
                str.AppendLine();
            }

            //Insectos
            if (checkedCombo_InsectAllergy.Properties.Items.Count != 0 && chkInsectAllergy.Checked && !String.IsNullOrEmpty(checkedCombo_InsectAllergy.Text))
            {
                str.AppendLine(checkedCombo_InsectAllergy.Text.Replace(", ", "\r\n"));
                str.AppendLine();
            }

            //Polen
            if (checkedCombo_Pollen.Properties.Items.Count != 0 && chkPollen.Checked && !String.IsNullOrEmpty(checkedCombo_Pollen.Text))
            {
                str.AppendLine(checkedCombo_Pollen.Text.Replace(", ", "\r\n"));
                str.AppendLine();
            }

            //Prod Quimicos
            if (checkedCombo_ChemicalAllergy.Properties.Items.Count != 0 && chkChemicalAllergy.Checked && !String.IsNullOrEmpty(checkedCombo_ChemicalAllergy.Text))
            {
                str.AppendLine(checkedCombo_ChemicalAllergy.Text.Replace(", ", "\r\n"));
                str.AppendLine();
            }

            if (chkSol.Checked)
            {
                str.AppendLine("Alergia al Sol");
                str.AppendLine();
            }

            return str.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        public override void AceptChanges(bool this_will_close)
        {
            Set_PatientAllergy(_PatientAllergy_Aux);

            try
            {
                if (_PatientAllergy.EntityState == Fwk.Bases.EntityState.Added)
                {
                    Set_PatientAllergy(_PatientAllergy);
                    ServiceCalls.CreateUpdatePatientAllergy(_PatientAllergy);
                }
                else
                {
                    if (CheckChanges())
                    {
                        Set_PatientAllergy(_PatientAllergy);
                        ServiceCalls.CreateUpdatePatientAllergy(_PatientAllergy);
                    }
                }

                if (this_will_close == false)
                {
                    this.MessageViewer.Show("Las alergias se actualizaron con exito .-");


                    frmPatientAtencion.PopulateAsync(this);
                    _PatientAllergy.EntityState = Fwk.Bases.EntityState.Unchanged;
                    _PatientAllergy_Aux = null;
                    _PatientAllergy_Aux = _PatientAllergy.Clone<PatientAllergyBE>();
                }
               


            }
            catch (Exception ex)
            {
                this.ExceptionViewer.Show(ex);
            }
        }

    

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            
                CheckBox chk = (CheckBox)sender;
                DevExpress.XtraEditors.CheckedComboBoxEdit checkedCombo = null;
                TipoAlergia wTipoAlergia = (TipoAlergia)Enum.Parse(typeof(TipoAlergia), chk.Tag.ToString());

                checkedCombo = GetCheckedCombo(wTipoAlergia);
                if (checkedCombo != null)
                {
                    if (checkedCombo.Properties.Items.Count != 0)
                    {
                        checkedCombo.Enabled = chk.Checked;
                    }
                }
              textEdit1.Text = GetComboValues();
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pTipoAlergia"></param>
        void InitializeComboBoxDatasource(TipoAlergia pTipoAlergia)
        {
            DevExpress.XtraEditors.CheckedComboBoxEdit checkedCombo = GetCheckedCombo(pTipoAlergia);
            var list = ServiceCalls.AllergiesItemTypesList.Where(p => p.IdParametroRef.Equals((int)pTipoAlergia)).ToArray<ParametroBE>();

            checkedCombo.Properties.DataSource = list;
            checkedCombo.Refresh();
            checkedCombo.RefreshEditValue(); 
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pTipoAlergia"></param>
        /// <returns></returns>
        DevExpress.XtraEditors.CheckedComboBoxEdit GetCheckedCombo(TipoAlergia pTipoAlergia)
        {
            DevExpress.XtraEditors.CheckedComboBoxEdit checkedCombo = null;

            switch (pTipoAlergia)
            {
                case TipoAlergia.AnimalAllergy:
                    {
                        checkedCombo = checkedCombo_PetAllergy;
                        break;
                    }
                case TipoAlergia.ChemicalAllergy:
                    {
                        checkedCombo = checkedCombo_ChemicalAllergy;
                        break;
                    }
                case TipoAlergia.FoodAllergy:
                    {
                        checkedCombo = checkedCombo_FoodAllergy;
                        break;
                    }
                case TipoAlergia.InsectAllergy:
                    {
                        checkedCombo = checkedCombo_InsectAllergy;
                        break;
                    }
                case TipoAlergia.MedicamentsAllergy:
                    {
                        checkedCombo = checkedCombo_MedicamentsAllergy;
                        break;
                    }
                case TipoAlergia.MiteAllergy:
                    {
                        //checkedCombo = checkedCombo_MiteAllergies;
                        break;
                    }
                case TipoAlergia.PollenAllergy:
                    {
                        checkedCombo = checkedCombo_Pollen;
                        break;
                    }
                case TipoAlergia.SunAllergy:
                    {
                        //checkedCombo = checkedCombo_Sun;
                        break;
                    }

            }

            return checkedCombo;
        }
    }
}
