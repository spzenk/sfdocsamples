using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class GridViewSpreadsheet : System.Web.UI.Page
{
    /// <summary>
    /// There are 2 ButtonField's and the row labels column
    /// therefore first edit cell index is 3
    /// </summary>
    private const int _firstEditCellIndex = 3;

    /// <summary>
    /// Set the number of columns in the spreadsheet
    /// An asp:TemplateField must be added for each column
    /// </summary>
    private const int _columnCount = 6;

    /// <summary>
    /// Set the number of rows in the spreadsheet
    /// </summary>
    private const int _rowCount = 8;

    #region Page Load

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _sampleData = null;
            this.GridView1.DataSource = _sampleData;
            this.GridView1.DataBind();
        }

        if (this.GridView1.SelectedIndex > -1)
        {
            // Call UpdateRow on every postback
            this.GridView1.UpdateRow(this.GridView1.SelectedIndex, false);
        }      
    }

    #endregion

    #region GridView1

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Get the LinkButton control in the first cell
            LinkButton _singleClickButton = (LinkButton)e.Row.Cells[0].Controls[0];
            // Get the javascript which is assigned to this LinkButton
            string _jsSingle = ClientScript.GetPostBackClientHyperlink(_singleClickButton, "");

            // If the page contains validator controls then call 
            // Page_ClientValidate before allowing a cell to be edited
            if (Page.Validators.Count > 0)
                _jsSingle = _jsSingle.Insert(11, "if(Page_ClientValidate())");

            // Add events to each editable cell
            for (int columnIndex = _firstEditCellIndex; columnIndex < e.Row.Cells.Count; columnIndex++)
            {
                // Add the column index as the event argument parameter
                string js = _jsSingle.Insert(_jsSingle.Length - 2, columnIndex.ToString());
                // Add this javascript to the onclick Attribute of the cell
                e.Row.Cells[columnIndex].Attributes["onclick"] = js;
                // Add a cursor style to the cells
                e.Row.Cells[columnIndex].Attributes["style"] += "cursor:pointer;cursor:hand;";
            }
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridView _gridView = (GridView)sender;

        switch (e.CommandName)
        {
            case ("SingleClick"):
                // Get the row index
                int _rowIndex = int.Parse(e.CommandArgument.ToString());     
                // Parse the event argument (added in RowDataBound) to get the selected column index
                int _columnIndex = int.Parse(Request.Form["__EVENTARGUMENT"]);
                // Set the Gridview selected index
                _gridView.SelectedIndex = _rowIndex;
                // Bind the Gridview
                _gridView.DataSource = _sampleData;
                _gridView.DataBind();

                // Get the display control for the selected cell and make it invisible
                Control _displayControl = _gridView.Rows[_rowIndex].Cells[_columnIndex].Controls[1];
                _displayControl.Visible = false;
                // Get the edit control for the selected cell and make it visible
                Control _editControl = _gridView.Rows[_rowIndex].Cells[_columnIndex].Controls[3];
                _editControl.Visible = true;
                // Clear the attributes from the selected cell to remove the click event
                _gridView.Rows[_rowIndex].Cells[_columnIndex].Attributes.Clear();
                // Change the styles on the selected cell, column and row label
                _gridView.Rows[_rowIndex].Cells[_columnIndex].CssClass = "ssCellSelected";
                _gridView.Rows[_rowIndex].Cells[2].CssClass = "ssRowLabelSelected";
                _gridView.HeaderRow.Cells[_columnIndex].CssClass = "ssHeaderSelected";

                // Set focus on the selected edit control
                ScriptManager.RegisterStartupScript(this, GetType(), "SetFocus",
                    "document.getElementById('" + _editControl.ClientID + "').focus();", true);
                // If the edit control is a dropdownlist set the
                // SelectedValue to the value of the display control
                if (_editControl is DropDownList && _displayControl is Label)
                {
                    ((DropDownList)_editControl).SelectedValue = ((Label)_displayControl).Text;
                }
                // If the edit control is a textbox then select the text
                if (_editControl is TextBox)
                {
                   ((TextBox)_editControl).Attributes.Add("onfocus", "this.select()");
                }
                      
                break;
        }
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridView _gridView = (GridView)sender;

        if (e.RowIndex > -1)
        {
            // Loop though the columns to find a cell in edit mode
            for (int i = _firstEditCellIndex; i < _gridView.Columns.Count; i++)
            {
                // Get the editing control for the cell
                Control _editControl = _gridView.Rows[e.RowIndex].Cells[i].Controls[3];
                if (_editControl.Visible)
                {
                    int _dataTableColumnIndex = i - 2;

                    try
                    {
                        // Get the id of the row
                        Label idLabel = (Label)_gridView.Rows[e.RowIndex].FindControl("RowLabelsLabel");
                        int id = int.Parse(idLabel.Text); 
                        // Get the value of the edit control and update the DataTable
                        DataTable dt = _sampleData;
                        DataRow dr = dt.Rows.Find(id);
                        dr.BeginEdit();
                        if (_editControl is TextBox)
                        {
                            dr[_dataTableColumnIndex] = ((TextBox)_editControl).Text;
                        }
                        else if (_editControl is DropDownList)
                        {
                            dr[_dataTableColumnIndex] = ((DropDownList)_editControl).SelectedValue;
                        }
                        dr.EndEdit();

                        // Save the updated DataTable
                        _sampleData = dt;

                        // Repopulate the GridView
                        _gridView.DataSource = dt;
                        _gridView.DataBind();
                    }
                    catch (ArgumentException)
                    {
                        this.Message.Text += "Error updating GridView row at index " 
                            + e.RowIndex + "<br />";

                        // Repopulate the GridView
                        _gridView.DataSource = _sampleData;
                        _gridView.DataBind();
                    }   
                }
            }
            // Clear the selected index to prevent 
            // another update on the next postback
            _gridView.SelectedIndex = -1;
        }
    }

    #endregion

    #region Render Override

    // Register the dynamically created client scripts
    protected override void Render(HtmlTextWriter writer)
    {
        // The client events for GridView1 were created in GridView1_RowDataBound
        foreach (GridViewRow r in GridView1.Rows)
        {
            if (r.RowType == DataControlRowType.DataRow)
            {
                for (int columnIndex = _firstEditCellIndex; columnIndex < r.Cells.Count; columnIndex++)
                {
                    Page.ClientScript.RegisterForEventValidation(r.UniqueID + "$ctl00", columnIndex.ToString());
                }
            }
        }
      
        base.Render(writer);
    }

    #endregion

    #region Sample Data

    /// <summary>
    /// Property to manage data
    /// </summary>
    private DataTable _sampleData
    {
        get
        {
            DataTable dt = (DataTable)Session["SpreadsheetData"];

            if (dt == null)
            {
                // Create a DataTable and save it to session
                dt = new DataTable();
                
                object[] emptyRow = new object[_columnCount];
                char letter = 'A';

                // Add Row Labels column
                dt.Columns.Add(new DataColumn("Id", typeof(string)));
                // Add columns
                for (int i = 0; i < _columnCount; i++)
                {
                    dt.Columns.Add(new DataColumn(letter.ToString(), typeof(string)));
                    letter = (char)((int)letter + 1);
                }
                // Add empty rows
                for (int i = 1; i < _rowCount + 1; i++)
                {
                    emptyRow[0] = i.ToString();
                    dt.Rows.Add(emptyRow);
                }

                // Add the id column as a primary key
                DataColumn[] keys = new DataColumn[1];
                keys[0] = dt.Columns["id"];
                dt.PrimaryKey = keys;

                _sampleData = dt;
            }

            return dt;
        }
        set
        {
            Session["SpreadsheetData"] = value;
        }
    }

    #endregion
}
