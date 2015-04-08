using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraSplashScreen;
using Fwk.Exceptions;
using Fwk.Security.Cryptography;
using System.Data;

namespace Epiron.Front.Bases
{
    public enum PanelEnum
    {
        LeftPanel_0,
        LeftPanel_1,
        RightPanel, FootherPanel
    }
    public enum TypeText
    {
        Todos = 0,
        SoloNumeros = 1,
        SoloLetras = 2,
        Alfanumerico = 3,
        AlfanumericoSinEspacio = 34

    }
    public class Common
    {



        public static void ShowWaitForm()
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(frmWait));
            }
            catch
            {
                SplashScreenManager.CloseForm();
            }
        }
        public static void CloseWaitForm()
        {

            try
            {
                SplashScreenManager.CloseForm();
            }
            catch
            {
                //Puede lanzar error si no se estaba mostrando
            }
        }

        public static Fwk.UI.Controls.Menu.Tree.TreeMenu LoadMenuFromFile(String pFullFileName)
        {
            //Application.StartupPath
            if (String.IsNullOrEmpty(pFullFileName))
                return null;
            if (!System.IO.File.Exists(pFullFileName))
                return null;

            String wXml = Fwk.HelperFunctions.FileFunctions.OpenTextFile(pFullFileName);
            return Fwk.UI.Controls.Menu.Tree.TreeMenu.GetFromXml<Fwk.UI.Controls.Menu.Tree.TreeMenu>(wXml);

        }

        /// <summary>
        /// Busca la existencia de una col "EventResponseId" lo cual indica que el Wservice retorna un error
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static  bool CheckIfExistEventResponseId(DataTable dt,out String  pEventResponseText ) 
        {
            pEventResponseText = String.Empty;
            if (dt.Columns.Contains("EventResponseId"))
            {
                DataRow row = dt.Rows[0];
                Int32 sEventResponseId = Convert.ToInt32(row["EventResponseId"]);

                String sEventResponseText = row["EventResponseText"].ToString();
                Int32 sEventResponseInternalCode = Convert.ToInt32(row["EventResponseInternalCode"].ToString());
                //Guid sGuid = Guid.Parse(dr.Table.Rows[i]["Guid"].ToString());

                pEventResponseText = String.Concat("Error: \r\nEventResponseId = ", sEventResponseId, "\r\nEventResponseText =", sEventResponseText, "\r\nEventResponseInternalCode = " + sEventResponseInternalCode);
                return true;
            }
            return false;
        }



    }
}
