using System;
using System.Xml.Serialization;
using System.Collections;

namespace ObjectStorePart1
{

    public class Project
    {
        [XmlElement(ElementName = "ProjectName")]
        public string _projectName = null;
        [XmlElement(ElementName = "Manager")]
        public int _manager = -1;
        
        public Project(){}
        public Project(string projectName, int manager)
        {
            _projectName = projectName;
            _manager = manager;
        }
            
    }
	
    public class Employee2 : Employee
    {   
        private string _workPhone = null;
        private string _homePhone = null;
        private string _cellPhone = null;
        private Project _project = null;       

        public Employee2(int employeeID, string firstName, string lastName, string title) 
            : base(employeeID, firstName, lastName, title) {}

        public Employee2() : base() {}
        
        public Project Project
        {
            get {return _project;}
            set {_project = value;}
        }

        public string WorkPhone
        {
            get {return _workPhone;}
            set {_workPhone = value;}
        }
        
        public string HomePhone
        {
            get {return _homePhone;}
            set {_homePhone = value;}
        }
        
        public string CellPhone
        {
            get {return _cellPhone;}
            set {_cellPhone = value;}
        }   
        
    }

}
