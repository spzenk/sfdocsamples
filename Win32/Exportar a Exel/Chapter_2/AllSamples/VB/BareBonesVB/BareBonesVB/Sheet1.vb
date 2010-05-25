
Public Class Sheet1
    Dim filePath As String = "C:\Documents and Settings\All Users\Documents\My Pictures\Sample Pictures\blue hills.jpg"
    Private Sub FormatSheet()
        'take care of some aesthetic issues
        Application.DisplayFormulaBar = False
        Application.DisplayFunctionToolTips = False
        Application.DisplayScrollBars = False
        Application.DisplayStatusBar = False

        'make some customizations
        Application.Rows.Worksheet.SetBackgroundPicture(filePath)

        'remove worksheet 2 and worksheet 3
        Application.DisplayAlerts = False
        CType(Me.Application.ActiveWorkbook.Sheets(2), Excel.Worksheet).Delete()
        CType(Me.Application.ActiveWorkbook.Sheets(2), Excel.Worksheet).Delete()
        CType(Me.Application.ActiveWorkbook.Sheets(1), Excel.Worksheet).Name = "Bare Bones Time"
        Application.DisplayAlerts = True

        'hide column and row headers
        Application.ActiveWindow.DisplayGridlines = False
        Application.ActiveWindow.DisplayHeadings = False
    End Sub

    Private Sub CustomizedData()
        'set a namedrange
        Dim formattedRange As Microsoft.Office.Tools.Excel.NamedRange = _
        Me.Controls.AddNamedRange(Me.Range("A1", "D10"), "formattedRange")

        'note range names
        Dim preFilledRange As Microsoft.Office.Tools.Excel.NamedRange = _
        Me.Controls.AddNamedRange(Me.Range("A2", "A9"), "PreFilledRange")

        'formattedRange.ShrinkToFit = true;
        formattedRange.ShowErrors()

        'auto fill days of the week
        Dim firstCell As Microsoft.Office.Tools.Excel.NamedRange = _
        Me.Controls.AddNamedRange(Me.Range("A2"), "FirstCell")

        'note must seed the value
        firstCell.Select()
        firstCell.Value2 = "Monday"
        'note must use the firstcell range that points to A1 for the autofill to work
        firstCell.AutoFill(Application.Range("A2:A6"), Excel.XlAutoFillType.xlFillWeekdays)

        preFilledRange.BorderAround(, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, )
        preFilledRange.AutoFormat(Excel.XlRangeAutoFormat.xlRangeAutoFormat3DEffects1, True, False, True, False, True, True)

        'get a reference to the header cell
        Dim MergeRange As Microsoft.Office.Tools.Excel.NamedRange = Me.Controls.AddNamedRange(Me.Range("A1", "D1"), "MergeRange")

        'format the header cell
        MergeRange.EntireRow.Font.Bold = True
        MergeRange.Value2 = "Time Sheet [Week - " + DateTime.Now.ToString("hh/MM/yyyy") + "]"
        MergeRange.EntireRow.Font.Background = Excel.XlBackground.xlBackgroundTransparent

        'turn off merged prompt dialog and then merge
        Application.DisplayAlerts = False
        MergeRange.Merge(True)
        Application.DisplayAlerts = True

        'setup the range for data entry
        Dim valueRange As Microsoft.Office.Tools.Excel.NamedRange = _
        Me.Controls.AddNamedRange(Me.Range("B2", "B6"), "ValueRange")
        valueRange.NumberFormat = "#,###.00"
        valueRange.Font.Bold = True
        valueRange.BorderAround(, Excel.XlBorderWeight.xlHairline, Excel.XlColorIndex.xlColorIndexAutomatic)
        valueRange.AutoFormat(Excel.XlRangeAutoFormat.xlRangeAutoFormatColor2, True, False, True, False, True, True)

        Dim commentRange As Microsoft.Office.Tools.Excel.NamedRange = Me.Controls.AddNamedRange(Me.Range("B2"), "CommentRange")
        'add the comment
        commentRange.AddComment("Enter your hours worked here.")

    End Sub

    Private Sub Sheet1_Startup1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Startup
        'customize the worksheet during start up
        FormatSheet()

        'add the customized data
        CustomizedData()
    End Sub
    Private Sub CalculateTotal()
        Dim totalRange As Microsoft.Office.Tools.Excel.NamedRange = _
        Me.Controls.AddNamedRange(Me.Range("B2", "B6"), "TotalRange")

        Dim fields() As Integer = New Integer() {1, 2, 3, 4, 5}

        totalRange.Subtotal(1, Excel.XlConsolidationFunction.xlSum, fields, , , Excel.XlSummaryRow.xlSummaryBelow)
    End Sub
    Private Sub EmailDocument()
        'calculate the hours worked
        CalculateTotal()

        If MessageBox.Show("Are you sure you want to submit  ?", "Time sheet submission", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            'email the document to management
            Me.Application.ActiveWorkbook.SendMail("someone@example.com", DateTime.Now.ToString("hh/MM/yyyy"))
        End If

    End Sub
    Private Sub Sheet1_Shutdown1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown
        'The user is through so email the document to recipient
        EmailDocument()
    End Sub

End Class
