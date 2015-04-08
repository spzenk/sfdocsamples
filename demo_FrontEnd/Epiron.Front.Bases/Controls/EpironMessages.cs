using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Epiron.Back.Bases.BE;
using Epiron.Bases.ServiceProxy;

namespace Epiron.Front.Bases
{
    public class EpironMessages
    {

        static EpironMessages()
        {
            try
            {

                //cargar todos los mensajes
                List<MsgDialogBoxBE> lista = Controller.MsgDialogBoxGet(1, null);
                foreach (MsgDialogBoxBE item in lista)
                {

                    switch (item.MsgDialogBoxName)
                    {
                        case "MsgYesNoConfirmaGuardar":
                            MsgYesNoConfirmaGuardarString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgDatosGuardadosCorrectamente":
                            MsgDatosGuardadosCorrectamenteString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgValidacionCompleteDatosRequeridos":
                            MsgValidacionCompleteDatosRequeridosString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgYesNoConfirmaEliminar":
                            MsgYesNoConfirmaEliminarString = item.MsgDialogBoxDescrip;
                            break;
                        case "StringValidNombreYaExiste":
                            StringValidNombreYaExisteString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgRegistroEliminadoCorrectamente":
                            MsgRegistroEliminadoCorrectamenteString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgYesNoConfirmaGuardarTitle":
                            MsgYesNoConfirmaGuardarTitleString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgDatosGuardadosCorrectamenteTitle":
                            MsgDatosGuardadosCorrectamenteTitleString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgErrorTitle":
                            MsgErrorTitleString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgExceptionTitle":
                            MsgExceptionTitleString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgValidacionTitle":
                            MsgValidacionTitleString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgYesNoConfirmaEliminarTitle":
                            MsgYesNoConfirmaEliminarTitleString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgRegistroEliminadoCorrectamenteTitle":
                            MsgRegistroEliminadoCorrectamenteTitleString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgSelectProcessType":
                            MsgSelectProcessTypeString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgSelectAProcess":
                            MsgSelectAProcessString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgSelectAServiceInstance":
                            MsgSelectAServiceInstanceString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgselectASourceDatabase":
                            MsgselectASourceDatabaseString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgSelectAProxyOrigin":
                            MsgSelectAProxyOriginString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgCompleteTheConnectionStringOrigin":
                            MsgCompleteTheConnectionStringOriginString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgSelectADestinationDatabase":
                            MsgSelectADestinationDatabaseString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgChooseADestinationProxy":
                            MsgChooseADestinationProxyString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgCompleteConnectStringDestination":
                            MsgCompleteConnectStringDestinationString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgSelectTheStateService":
                            MsgSelectTheStateServiceString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgCompleteInterval":
                            MsgCompleteIntervalString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgCancelChanges":
                            MsgCancelChangesString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgNoDataWereRecorded":
                            MsgNoDataWereRecordedString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgValidNameExists_MailSender":
                            MsgValidNameExists_MailSenderString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgValidDeleted_MailSender":
                            MsgValidDeleted_MailSenderString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgPasswordsAreNotEqual":
                            MsgPasswordsAreNotEqualString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgValidNameExists_ServiceInstance":
                            MsgValidNameExists_ServiceInstanceString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgValidDeleted_ServiceInstance":
                            MsgValidDeleted_ServiceInstanceString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgValidSIDefault_ServiceInstance":
                            MsgValidSIDefault_ServiceInstanceString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgValidExists_ServiceInstance":
                            MsgValidExists_ServiceInstanceString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgValidDeleted_SMTPServer":
                            MsgValidDeleted_SMTPServerString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgValidNameExists_SMTPServer":
                            MsgValidNameExists_SMTPServerString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgValidDeleted_Database":
                            MsgValidDeleted_DatabaseString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgValidNameExists_Database":
                            MsgValidNameExists_DatabaseString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgConnectionStringValid":
                            MsgConnectionStringValidString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgConnectionStringNotValid":
                            MsgConnectionStringNotValidString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgConnectionStringNotVerified":
                            MsgConnectionStringNotVerifiedString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgValidDeleted_Account":
                            MsgValidDeleted_AccountString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgValidDeleted_AccountDetail":
                            MsgValidDeleted_AccountDetailString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgValidDeleted_AccountType":
                            MsgValidDeleted_AccountTypeString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgValidDeleted_Proxy":
                            MsgValidDeleted_ProxyString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgCheckGuidOfConfigurationFile":
                            MsgCheckGuidOfConfigurationFileString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgYouMustSelectAnAccount":
                            MsgYouMustSelectAnAccountString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgYouMustSelectAGroup":
                            MsgYouMustSelectAGroupString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgFromTheDateMustBeLessOrEqual":
                            MsgFromTheDateMustBeLessOrEqualString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgPleasePressTheSearchButton":
                            MsgPleasePressTheSearchButtonString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgNoActiveConfigurationsApplicationUserFP":
                            MsgNoActiveConfigurationsApplicationUserFPString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgEndDateMustBeGreaterThanStartDate":
                            MsgEndDateMustBeGreaterThanStartDateString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgPleaseSelectADate":
                            MsgPleaseSelectADateString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgStartNewDateGreaterThanTheDateOfStartOfCurrentConfiguration":
                            MsgStartNewDateGreaterThanTheDateOfStartOfCurrentConfigurationString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgEndNewDateGreaterThanTheDateOfStartOfCurrentConfiguration":
                            MsgEndNewDateGreaterThanTheDateOfStartOfCurrentConfigurationString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgThereIsAlreadyAnActiveConfiguration":
                            MsgThereIsAlreadyAnActiveConfigurationString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgThereIsAProcessRunningWithThisAccount":
                            MsgThereIsAProcessRunningWithThisAccountString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgTheValueExceedsTheFieldLength":
                            MsgTheValueExceedsTheFieldLengthString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgConnectionStringNotVerifiedDest":
                            MsgConnectionStringNotVerifiedDestString = item.MsgDialogBoxDescrip;
                            break;

                        case "MsgNotExistOrIsNotActive":
                            MsgNotExistOrIsNotActiveString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgNotExistOrIsNotActiveType":
                            MsgNotExistOrIsNotActiveTypeString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgNoUsersForChannelAccount":
                            MsgNoUsersForChannelAccountString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgPleaseEnterAConnectionStringTarget":
                            MsgPleaseEnterAConnectionStringTargetString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgPleaseSelectAnApplicationUser":
                            MsgPleaseSelectAnApplicationUserString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgPleaseEnterDatesToCheck":
                            MsgPleaseEnterDatesToCheckString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgThisTypeOfProcessCanNotBeConfigured":
                            MsgThisTypeOfProcessCanNotBeConfiguredString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgThereIsAProcessRunningWithThisAccount_Edit":
                            MsgThereIsAProcessRunningWithThisAccount_EditString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgPleaseSelectYourConnectionType":
                            MsgPleaseSelectYourConnectionTypeString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgValidDeleted_MailSenderByServiceInstance":
                            MsgValidDeleted_MailSenderByServiceInstanceString = item.MsgDialogBoxDescrip;
                            break;
                        case "MsgPleaseEnterAConnectionStringTargetOrigin":
                            MsgPleaseEnterAConnectionStringTargetOriginString = item.MsgDialogBoxDescrip;
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }


        }


        #region StringsForMessagebox

        //mensajes principales
        private static string MsgYesNoConfirmaGuardarString = "Sin mensaje";
        private static string MsgDatosGuardadosCorrectamenteString = "Sin mensaje";
        private static string MsgValidacionCompleteDatosRequeridosString = "Sin mensaje";
        private static string MsgYesNoConfirmaEliminarString = "Sin mensaje";
        private static string StringValidNombreYaExisteString = "Sin mensaje";
        private static string MsgRegistroEliminadoCorrectamenteString = "Sin mensaje";
        //titulos de los mensajes
        private static string MsgYesNoConfirmaGuardarTitleString = "Sin mensaje";
        private static string MsgDatosGuardadosCorrectamenteTitleString = "Sin mensaje";
        private static string MsgErrorTitleString = "Sin mensaje";
        private static string MsgExceptionTitleString = "Sin mensaje";
        private static string MsgValidacionTitleString = "Sin mensaje";
        private static string MsgYesNoConfirmaEliminarTitleString = "Sin mensaje";
        private static string MsgRegistroEliminadoCorrectamenteTitleString = "Sin mensaje";

        public static string MsgSelectProcessTypeString = "Sin mensaje";
        public static string MsgSelectAProcessString = "Sin mensaje";
        public static string MsgSelectAServiceInstanceString = "Sin mensaje";
        public static string MsgselectASourceDatabaseString = "Sin mensaje";
        public static string MsgSelectAProxyOriginString = "Sin mensaje";
        public static string MsgCompleteTheConnectionStringOriginString = "Sin mensaje";
        public static string MsgSelectADestinationDatabaseString = "Sin mensaje";
        public static string MsgChooseADestinationProxyString = "Sin mensaje";
        public static string MsgCompleteConnectStringDestinationString = "Sin mensaje";
        public static string MsgSelectTheStateServiceString = "Sin mensaje";
        public static string MsgCompleteIntervalString = "Sin mensaje";
        public static string MsgCancelChangesString = "Sin mensaje";
        public static string MsgNoDataWereRecordedString = "Sin mensaje";
        public static string MsgValidNameExists_MailSenderString = "Sin mensaje";
        public static string MsgValidDeleted_MailSenderString = "Sin mensaje";
        public static string MsgPasswordsAreNotEqualString = "Sin mensaje";
        public static string MsgValidNameExists_ServiceInstanceString = "Sin mensaje";
        public static string MsgValidDeleted_ServiceInstanceString = "Sin mensaje";
        public static string MsgValidSIDefault_ServiceInstanceString = "Sin mensaje";
        public static string MsgValidExists_ServiceInstanceString = "Sin mensaje";
        public static string MsgValidDeleted_SMTPServerString = "Sin mensaje";
        public static string MsgValidNameExists_SMTPServerString = "Sin mensaje";
        public static string MsgValidDeleted_DatabaseString = "Sin mensaje";
        public static string MsgValidNameExists_DatabaseString = "Sin mensaje";
        public static string MsgConnectionStringValidString = "Sin mensaje";
        public static string MsgConnectionStringNotValidString = "Sin mensaje";
        public static string MsgConnectionStringNotVerifiedString = "Sin mensaje";
        public static string MsgValidDeleted_AccountString = "Sin mensaje";
        public static string MsgValidDeleted_AccountDetailString = "Sin mensaje";
        public static string MsgValidDeleted_AccountTypeString = "Sin mensaje";
        public static string MsgValidDeleted_ProxyString = "Sin mensaje";
        public static string MsgCheckGuidOfConfigurationFileString = "Sin mensaje";
        public static string MsgYouMustSelectAnAccountString = "Sin mensaje";
        public static string MsgYouMustSelectAGroupString = "Sin mensaje";
        public static string MsgFromTheDateMustBeLessOrEqualString = "Sin mensaje";
        public static string MsgPleasePressTheSearchButtonString = "Sin mensaje";
        public static string MsgNoActiveConfigurationsApplicationUserFPString = "Sin mensaje";
        public static string MsgEndDateMustBeGreaterThanStartDateString = "Sin mensaje";
        public static string MsgPleaseSelectADateString = "Sin mensaje";
        public static string MsgStartNewDateGreaterThanTheDateOfStartOfCurrentConfigurationString = "Sin mensaje";
        public static string MsgEndNewDateGreaterThanTheDateOfStartOfCurrentConfigurationString = "Sin mensaje";
        public static string MsgThereIsAlreadyAnActiveConfigurationString = "Sin mensaje";
        public static string MsgThereIsAProcessRunningWithThisAccountString = "Sin mensaje";
        public static string MsgTheValueExceedsTheFieldLengthString = "Sin mensaje";
        public static string MsgConnectionStringNotVerifiedDestString = "Sin mensaje";
        public static string MsgNotExistOrIsNotActiveString = "Sin mensaje";
        public static string MsgNotExistOrIsNotActiveTypeString = "Sin mensaje";
        public static string MsgNoUsersForChannelAccountString = "Sin mensaje";
        public static string MsgPleaseEnterAConnectionStringTargetString = "Sin mensaje";
        public static string MsgPleaseSelectAnApplicationUserString = "Sin mensaje";
        public static string MsgPleaseEnterDatesToCheckString = "Sin mensaje";
        public static string MsgThisTypeOfProcessCanNotBeConfiguredString = "Sin mensaje";
        public static string MsgThereIsAProcessRunningWithThisAccount_EditString = "Sin mensaje";
        public static string MsgPleaseSelectYourConnectionTypeString = "Sin mensaje";
        public static string MsgValidDeleted_MailSenderByServiceInstanceString = "Sin mensaje";
        public static string MsgPleaseEnterAConnectionStringTargetOriginString = "Sin mensaje";
        //

        #endregion

        #region MessageBox
        public static Boolean MsgYesNoConfirmaGuardar()
        {

            DialogResult res = XtraMessageBox.Show(MsgYesNoConfirmaGuardarString, MsgYesNoConfirmaGuardarTitleString, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == System.Windows.Forms.DialogResult.No)
            {
                return false;
            }
            return true;
        }
        public static Boolean MsgYesNoConfirmaGuardar(String Mensaje)
        {

            DialogResult res = XtraMessageBox.Show(Mensaje, MsgYesNoConfirmaGuardarTitleString, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == System.Windows.Forms.DialogResult.No)
            {
                return false;
            }
            return true;
        }
        public static void MsgDatosGuardadosCorrectamente()
        {
            XtraMessageBox.Show(MsgDatosGuardadosCorrectamenteString, MsgDatosGuardadosCorrectamenteTitleString, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static Boolean MsgYesNo(string Mensaje)
        {

            DialogResult res = XtraMessageBox.Show(Mensaje, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == System.Windows.Forms.DialogResult.No)
            {
                return false;
            }
            return true;
        }
        public static void MsgError(String mensaje)
        {
            XtraMessageBox.Show(mensaje, MsgErrorTitleString, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void MsgException(String mensaje)
        {
            XtraMessageBox.Show(mensaje, MsgExceptionTitleString, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void MsgValidacion(String Mensaje)
        {
            XtraMessageBox.Show(Mensaje, MsgValidacionTitleString, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void MsgValidacionCompleteDatosRequeridos()
        {
            XtraMessageBox.Show(MsgValidacionCompleteDatosRequeridosString, MsgValidacionTitleString, MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        public static void MsgValidacionCompleteDatosRequeridos(String pCamposRequeridos)
        {
            XtraMessageBox.Show(MsgValidacionCompleteDatosRequeridosString + pCamposRequeridos, MsgValidacionTitleString, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static Boolean MsgYesNoConfirmaEliminar(String Mensaje)
        {

            DialogResult res = XtraMessageBox.Show(Mensaje, MsgYesNoConfirmaEliminarTitleString, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == System.Windows.Forms.DialogResult.No)
            {
                return false;
            }
            return true;
        }
        public static Boolean MsgYesNoConfirmaEliminar()
        {

            DialogResult res = XtraMessageBox.Show(MsgYesNoConfirmaEliminarString, MsgYesNoConfirmaEliminarTitleString, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == System.Windows.Forms.DialogResult.No)
            {
                return false;
            }
            return true;
        }
        public static void MsgRegistroEliminadoCorrectamente()
        {
            XtraMessageBox.Show(MsgRegistroEliminadoCorrectamenteString, MsgRegistroEliminadoCorrectamenteTitleString, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Strings con mensajes
        public static string StringValidNombreYaExiste()
        {
            string Msg = StringValidNombreYaExisteString;
            return Msg;
        }

        #endregion






    }
}
