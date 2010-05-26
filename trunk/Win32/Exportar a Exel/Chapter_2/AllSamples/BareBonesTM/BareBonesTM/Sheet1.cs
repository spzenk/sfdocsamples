using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;

namespace BareBonesTM
{
    public partial class Sheet1
    {
        string filePath =@"C:\Documents and Settings\All Users\Documents\My Pictures\Sample Pictures\blue hills.jpg";
        /// <summary>
        /// This routine formats the worksheet
        /// </summary>
        private void FormatSheet()
        {
            //take care of some aesthetic issues
            Application.DisplayFormulaBar = false;
            Application.DisplayFunctionToolTips = false;
            Application.DisplayScrollBars = false;
            Application.DisplayStatusBar = false;

            //take care of some sizing issues

            //make some customizations
            Application.Rows.Worksheet.SetBackgroundPicture(filePath);

            //remove worksheet 2 and worksheet 3
            Application.DisplayAlerts = false;
            ((Excel.Worksheet)this.Application.ActiveWorkbook.Sheets[2]).Delete();
            ((Excel.Worksheet)this.Application.ActiveWorkbook.Sheets[2]).Delete();
            ((Excel.Worksheet)this.Application.ActiveWorkbook.Sheets[1]).Name =
            "Bare Bones Time";
            Application.DisplayAlerts = true;

            //hide column and row headers
            Application.ActiveWindow.DisplayGridlines = false;
            Application.ActiveWindow.DisplayHeadings = false;
        }
        /// <summary>
        /// This routine customizes the worksheet with prefetched data
        /// </summary>
        private void CustomizedData()
        {
            //set a namedrange
            Microsoft.Office.Tools.Excel.NamedRange formattedRange =
            this.Controls.AddNamedRange(this.Range["A1", "D10"], "formattedRange");

            //note range names
            Microsoft.Office.Tools.Excel.NamedRange preFilledRange =
            this.Controls.AddNamedRange(this.Range["A2", "A9"], "PreFilledRange");

            //formattedRange.ShrinkToFit = true;
            formattedRange.ShowErrors();

            //auto fill days of the week
            Microsoft.Office.Tools.Excel.NamedRange firstCell =
            this.Controls.AddNamedRange(this.Range["A2", missing], "FirstCell");

            //note must seed the value
            firstCell.Select();
            firstCell.Value2 = "Monday";
            //note must use the firstcell range that points to A1 for the autofill to work
            firstCell.AutoFill(Application.get_Range("A2:A6", missing), Excel.XlAutoFillType.xlFillWeekdays);

            preFilledRange.BorderAround(missing, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, missing);
            preFilledRange.AutoFormat(Excel.XlRangeAutoFormat.xlRangeAutoFormat3DEffects1, true, false, true, false, true, true);

            //get a reference to the header cell
            Microsoft.Office.Tools.Excel.NamedRange MergeRange = this.Controls.AddNamedRange(this.Range["A1", "D1"], "MergeRange");

            //format the header cell
            MergeRange.EntireRow.Font.Bold = true;
            MergeRange.Value2 = "Time Sheet [Week - " + DateTime.Now.ToString("hh/MM/yyyy") + "]";
            MergeRange.EntireRow.Font.Background = Excel.XlBackground.xlBackgroundTransparent;

            //turn off merged prompt dialog and then merge
            Application.DisplayAlerts = false;
            MergeRange.Merge(true);
            Application.DisplayAlerts = true;

            //setup the range for data entry
            Microsoft.Office.Tools.Excel.NamedRange valueRange =
            this.Controls.AddNamedRange(this.Range["B2", "B6"], "ValueRange");
            valueRange.NumberFormat = "#,###.00";
            valueRange.Font.Bold = true;
            valueRange.BorderAround(missing, Excel.XlBorderWeight.xlHairline, Excel.XlColorIndex.xlColorIndexAutomatic, missing);
            valueRange.AutoFormat(Excel.XlRangeAutoFormat.xlRangeAutoFormatColor2, true, false, true, false, true, true);

            Microsoft.Office.Tools.Excel.NamedRange commentRange = this.Controls.AddNamedRange(this.Range["B2", missing], "CommentRange");
            //add the comment
            commentRange.AddComment("Enter your hours worked here.");

        }
        private void Sheet1_Startup(object sender, System.EventArgs e)
        {
            //customize the worksheet during start up
            FormatSheet();

            //add the customized data
            CustomizedData();
        }
        private void CalculateTotal()
        {
            Microsoft.Office.Tools.Excel.NamedRange totalRange =
                this.Controls.AddNamedRange(this.Range["B2", "B6"], "TotalRange");

            int[] fields = new int[] { 1, 2, 3, 4, 5 };
            totalRange.Subtotal(1, Excel.XlConsolidationFunction.xlSum, fields, missing, missing, Excel.XlSummaryRow.xlSummaryBelow);
        }
        private void EmailDocument()
        {
            //calculate the hours worked
            CalculateTotal();

            if (MessageBox.Show("Are you sure you want to submit  ?", "Time sheet submission", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //email the document to management
                this.Application.ActiveWorkbook.SendMail("someone@example.com", DateTime.Now.ToString("hh/MM/yyyy"), missing);
            }

        }
        private void Sheet1_Shutdown(object sender, System.EventArgs e)
        {
            //The user is thru so email the document to recipient
            EmailDocument();
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
