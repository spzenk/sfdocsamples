/*HOWTO:
The examples in this file are adapted for use from the
Professional VSTO 2005 edition published by Wiley
Each method illustrates a code listing in the chapter.
The solution represents a chapter.

To execute the examples, simply uncomment the relevant example
and run the solution from the Visual Studio Environment. Since
binaries are not included, you must compile the solution.

In some cases, there may be multiple handlers for one event. 
The additional handlers are commented out. You will need to 
uncomment the relevant handler to cause the code to work correctly.

For file loads, the actual file data is added as a file to the
solution. You will need to provide the fully qualified file path
to cause the application to run without error. The file path must 
point to the file on disk. By default, the file is found in
the working folder directory. A sample file, data.txt is part of the project.

Where necessary, the excel spreadsheet contains data to cause 
some examples to execute correctly. Additionally, controls may
already be present on the design surface as well.

A more detailed explanation of the code is already presented in the
chapter. 
*/

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using System.IO;
using System.Text;

namespace AllSamples
{
    public partial class Sheet1
    {
        string filePath = string.Empty;
        string httpFilePath = string.Empty;
        private void FileProcessor(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);

            fs.Close();
        }
        //to run this example, update the file path to point to the data.txt file in the solution
        private void Listing_2_1()
        {            
            FileProcessor(filePath);
        }
        private void Listing_2_2()
        {
            Application.ScreenUpdating = false;
            Application.Workbooks.Open(filePath, System.Type.Missing, false, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, ",", true, System.Type.Missing, System.Type.Missing, true, System.Type.Missing, System.Type.Missing);
            Application.ScreenUpdating = true;
        }
        //to run this example, the file pointed to by the variable httpFilePath needs to
        //reside in a virtual directory. For help on setting up a virtual directory
        //consult the MSDN documentation
        private void Listing_2_3()
        {
            this.Application.Workbooks.OpenText(httpFilePath, Excel.XlPlatform.xlMacintosh, 3, Excel.XlTextParsingType.xlDelimited, Excel.XlTextQualifier.xlTextQualifierNone, missing, missing, missing, false, missing, missing, missing, missing, missing, missing, missing, missing, missing);
        }
        //to run this example, the local machine must have internet access
        private void Listing_2_4()
        {
            object async = false;
            Excel.Range rngDestination = this.Application.get_Range("A1", missing);
            object connection = "URL;http://edition.cnn.com/WORLD/";
            Excel.QueryTable tblQuery = this.QueryTables.Add(connection, rngDestination, missing);
            tblQuery.BackgroundQuery = true;
            tblQuery.TablesOnlyFromHTML = true;
            tblQuery.Refresh(async);
            tblQuery.SaveData = true;
        }
        //to run this example, make sure filePath points to a valid XML document
        private void Listing_2_5()
        {
            this.Application.Workbooks.OpenXML(filePath, missing, missing); 
        }
        private void Listing_2_6()
        {
            DataSet ds = GetDataSet();
            int count = 1;
            foreach (DataRow dt in ds.Tables[0].Rows)
            {
                Excel.Range rng = this.Application.get_Range("A" + count++, missing);
                rng.Value2 = dt.ItemArray;
            }	    
        }
        private System.Data.DataSet GetDataSet()
        {
            DataSet ds = new DataSet("MyDataSet");
            DataTable myDataTable = new DataTable("My DataTable");
            ds.Tables.Add(myDataTable);
            DataColumn myDataColumn;
            DataRow myDataRow;

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.String");
            myDataColumn.ColumnName = "Count";
            myDataColumn.Caption = "Count";
            // Add the Columns
            myDataTable.Columns.Add(myDataColumn);

            // Create second column
            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.String");
            myDataColumn.ColumnName = "Item";
            myDataColumn.Caption = "Item";

            // Add the column to the table.
            myDataTable.Columns.Add(myDataColumn);

            // Create three new DataRow objects and add them to the DataTable
            for (int i = 0; i <= 2; i++)
            {
                myDataRow = myDataTable.NewRow();
                myDataRow["Count"] = i.ToString();
                myDataRow["Item"] = i.ToString();
                myDataTable.Rows.Add(myDataRow);
            }
            return ds;
        }
        private void Listing_2_7()
        {
            DataSet ds = GetDataSet();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ds.WriteXml(filePath);
                Application.Workbooks.Open(filePath, System.Type.Missing, false, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, ",", true, System.Type.Missing, System.Type.Missing, true, System.Type.Missing, System.Type.Missing);
            }
        }
        //In some cases, the sheets tab may be hidden. To unhide the sheets tab
        //select Tools | Options | View tab. The check the sheet tab
        private void Listing_2_8()
        {
            Application.DisplayAlerts = false;
            ((Excel.Worksheet)this.Application.ActiveWorkbook.Sheets[2]).Delete();
            Application.DisplayAlerts = true;
            Application.Quit();
        }
        private void Listing_2_9()
        {
            Excel.Workbook nWorkbook = this.Application.Workbooks.Add(missing);
            this.Application.Workbooks.Open(filePath, System.Type.Missing, false, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, ",", true, System.Type.Missing, System.Type.Missing, true, System.Type.Missing, System.Type.Missing);
            ((Microsoft.Office.Interop.Excel._Workbook)this.Application.Workbooks[1]).Activate();

            if (!nWorkbook.Saved)
                nWorkbook.SaveAs(@"CSVData.txt", Excel.XlFileFormat.xlXMLSpreadsheet, missing, missing, missing, missing, Excel.XlSaveAsAccessMode.xlNoChange, missing, missing, missing,missing,missing);
            else
                nWorkbook.Close(false, missing, missing);
        }
        //while running this example, the end-user will be prompted to delete the 
        //worksheet, choose yes to proceed, no to cancel
        private void Listing_2_10()
        {
            ((Excel.Worksheet)this.Application.ActiveWorkbook.Sheets[2]).Delete();
        }
        //by default, new worksheets are added before the default sheet1
        private void Listing_2_11()
        {
            Excel.Worksheet newWorksheet;
            newWorksheet = (Excel.Worksheet)Globals.ThisWorkbook.Worksheets.Add(missing, missing, missing, missing);
        }
        private void Listing_2_12()
        {
            Globals.Sheet1.Copy(missing, Globals.ThisWorkbook.Sheets[1]);
        }
        private void Listing_2_13()
        {
            ((Excel.Worksheet)Globals.ThisWorkbook.Sheets[1]).Visible = Excel.XlSheetVisibility.xlSheetHidden;
        }
        private void Listing_2_14()
        {
            Excel.Range rng = Globals.Sheet1.Range["a1", "g12"] as Excel.Range;
            rng.AutoFormat(Excel.XlRangeAutoFormat.xlRangeAutoFormat3DEffects2,true, false, true, false, true, true);
        }
        private void Listing_2_15()
        {
            Microsoft.Office.Tools.Excel.NamedRange namedRange1 =
Controls.AddNamedRange(this.Range["A1", "A10"], "namedRange1");

            Microsoft.Office.Tools.Excel.NamedRange namedRange2 =
            Controls.AddNamedRange(this.Range["A1", missing], "namedRange2");

            namedRange1.Merge(false);
            namedRange2.Merge(false);

            namedRange1.BorderAround(missing, Excel.XlBorderWeight.xlThin,
            Excel.XlColorIndex.xlColorIndexAutomatic, missing);
            namedRange1.AutoFormat(Excel.XlRangeAutoFormat.xlRangeAutoFormat3DEffects1,
                true, false, true, false, true, true);
        }
        private void Listing_2_16()
        {
            object row = 1, column = 2;
            Excel.Range rng = Globals.Sheet1.Cells[row, column] as Excel.Range;
            rng.Value2 = "123456";
            rng.NumberFormat = "$#,###.0";
        }
        private void Listing_2_17()
        {
            Excel.Range rng = Globals.Sheet1.Range["B3", "B3"] as Excel.Range;
            rng.Value2 = "123456";
            rng.NumberFormat = "$#,###.0";
            rng = rng.Cells[3, 3] as Excel.Range;
            rng.Value2 = "new";
        }
        private void Listing_2_18()
        {
            Excel.Range rngA = Globals.Sheet1.Range["a2", "B3"] as Excel.Range;
            rngA.Value2 = "Mortgage";
            Excel.Range rngB = Globals.Sheet1.Range["a5", "B6"] as Excel.Range;
            rngB.Value2 = "Interest";

            Excel.Range unionRange = Application.Union(rngA, rngB, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing) as Excel.Range;
            unionRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
        }
        private void Listing_2_19()
        {
            Excel.Range rngA = Globals.Sheet1.Range["a2", "B3"] as Excel.Range;
            Excel.Range rngB = Globals.Sheet1.Range["a5", "B6"] as Excel.Range;

            Excel.Range intersection = Application.Intersect(rngA, rngB, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing) as Excel.Range;
            if (intersection == null)
            {
                //add code here
            }
        }
        private void Listing_2_20()
        {
            object row = 3, column = 5;
            Excel.Range off = Globals.Sheet1.Range["a1", "a1"] as Excel.Range;
            off.Value2 = "Initial Position";
            off = off.get_Offset(row, column) as Excel.Range;
            off.Value2 = "Final Position";
        }
        //to run this example, add data to range b2, f6 before running this code
        private void Listing_2_21()
        {
            Microsoft.Office.Tools.Excel.NamedRange valueRange = this.Controls.AddNamedRange(this.Range["B2", "F6"], "ValueRange");
            valueRange.NumberFormat = "#,###.00";
            //add some processing code here

            //reset the range B2, F6 to its default format
            valueRange.NumberFormat = "General";
            //This line throws an exception because the currency keyword is not supported
            //valueRange.NumberFormat = "Currency";
        }
        //the following start up event handler is designed to call the code for each
        //example in chapter 2. To run these examples, uncomment the appropriate function
        private void Sheet1_Startup(object sender, System.EventArgs e)
        {
            //Listing_2_1();
            //Listing_2_2();
            //Listing_2_3();
            //Listing_2_4();
            //Listing_2_5();
            //Listing_2_6();
            //Listing_2_7();
            //Listing_2_8();
            //Listing_2_9();
            //Listing_2_10();
            //Listing_2_11();
            //Listing_2_12();
            //Listing_2_13();
            //Listing_2_14();
            //Listing_2_15();
            //Listing_2_16();
            //Listing_2_17();
            //Listing_2_18();
            //Listing_2_19();
            //Listing_2_20();
            //Listing_2_21();
        }
        


        private void Sheet1_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(Sheet1_Startup);
            this.Shutdown += new System.EventHandler(Sheet1_Shutdown);
        }

        #endregion

    }
}
