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

#endregion

/// <summary>
/// Task Class
/// </summary>
public class Task : IComparable<Task>
{
    #region Constructors

	public Task()
	{
	}

    public Task(int id, string description, string assignedTo, string status)
	{
        _id = id;
        _description = description;
        _assignedTo = assignedTo;
        _status = status;
	}

    #endregion

    #region Sorting

    #region IComparable<Task> Members

    public int CompareTo(Task other)
    {
        return Id.CompareTo(other.Id);
    }

    #endregion

    public static Comparison<Task> DescriptionComparison = delegate(Task t1, Task t2) 
    {
        return t1.Description.CompareTo(t2.Description); 
    };

    public static Comparison<Task> AssignedToComparison = delegate(Task t1, Task t2)
    {
        return t1.AssignedTo.CompareTo(t2.AssignedTo);
    };

    public static Comparison<Task> StatusComparison = delegate(Task t1, Task t2)
    {
        return t1.Status.CompareTo(t2.Status);
    };

    #endregion

    #region Properties & Fields

    private int _id;
    public int Id
    {
        get
        {
            return _id;
        }
        set
        {
            if (_id < 0)
                throw new ArgumentException(@"Id must be greater than or equal to zero.");
            else
                _id = value;
        }
    }

    private string _description;
    public string Description
    {
        get
        {
            return _description;
        }
        set
        {
            _description = value;
        }
    }

    private string _assignedTo;
    public string AssignedTo
    {
        get
        {
            return _assignedTo;
        }
        set
        {
            _assignedTo = value;
        }
    }

    private string _status;
    public string Status
    {
        get
        {
            return _status;
        }
        set
        {
            _status = value;
        }
    }

    #endregion
}