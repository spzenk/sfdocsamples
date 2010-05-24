using System;
using System.Xml.Serialization;
using System.Collections;

namespace PelsoftComponent
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
	
    public class Empleado : Employee
    {   
     
        
        private string _cellPhone = null;
        private Project _project = null;       

        public Empleado(int employeeID, string firstName, string lastName, string title) 
            : base(employeeID, firstName, lastName, title) {}

        public Empleado() : base() {}
        
        public Project Project
        {
            get {return _project;}
            set {_project = value;}
        }

        

        
        public string CellPhone
        {
            get {return _cellPhone;}
            set {_cellPhone = value;}
        }   
        
    }

}
