#region Directives

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

#endregion

/// <summary>
/// Task Data Access Layer
/// </summary>
public class TaskDataAccess
{
    #region Constructors
    
    public TaskDataAccess()
	{
    }

    #endregion

    #region GetTasks

    public static List<Task> GetTasks(string sortExpression)
    {
        string sql = @"SELECT Id, Description, AssignedTo, Status FROM Tasks";
        using (SqlConnection myConnection = 
            new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
        {
            SqlCommand myCommand = new SqlCommand(sql, myConnection);
            myConnection.Open();
            SqlDataReader reader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

            List<Task> results = new List<Task>();
            while (reader.Read())
            {
                Task task = new Task();

                task.Id = int.Parse(reader["Id"].ToString());
                task.Description = reader["Description"].ToString();
                task.AssignedTo = reader["AssignedTo"].ToString();
                task.Status = reader["Status"].ToString();

                results.Add(task);             
            }

            // Sort the collection
            switch (sortExpression)
            {
                case ("Id"):
                    results.Sort();
                    break;
                case ("Description"):
                    results.Sort(Task.DescriptionComparison);
                    break;
                case ("AssignedTo"):
                    results.Sort(Task.AssignedToComparison);
                    break;
                case ("Status"):
                    results.Sort(Task.StatusComparison);
                    break;
            }   

            reader.Close();
            myConnection.Close();
            return results;
        }
    }

    #endregion

    #region UpdateTask

    public static void UpdateTask(int id, string description, string assignedTo, string status)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("UPDATE [Tasks] SET [Description] = '");
        sb.Append(description);
        sb.Append("', [AssignedTo] = '");
        sb.Append(assignedTo);
        sb.Append("', [Status] = '");
        sb.Append(status);
        sb.Append("' WHERE [Id] = ");
        sb.Append(id);
        string sql = sb.ToString();

        using (SqlConnection myConnection =
            new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
        {
            SqlCommand myCommand = new SqlCommand(sql, myConnection);
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }
    }

    #endregion
}
