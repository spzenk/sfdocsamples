using System;
using System.Xml.Serialization;
using System.Collections;

namespace ObjectStorePart1
{
    [XmlInclude(typeof(Employee2))]
    public class Employee
    {
        private int _employeeID = -1;
        private string _lastName = null;
        private string _firstName = null;
        private string _title = null;
        
        [XmlArrayItem(ElementName= "Address", Type=typeof(EmployeeAddress))]
        [XmlArray("AddressList")]
        public ArrayList _addressList = new ArrayList();        

        public Employee() {}

        public Employee(int employeeID, string firstName, string lastName, string title)
        {
            _employeeID = employeeID;
            _firstName = firstName;
            _lastName = lastName;
            _title = title;
        }

        [XmlElement(ElementName = "FirstName")]
        public string FName
        {
            get { return _firstName;}
            set { _firstName = value;}
        }
        
        [XmlElement(ElementName = "LastName")]
        public string LName
        {
            get { return _lastName;}
            set { _lastName = value;}
        }  
 
        [XmlElement(ElementName = "EmployeeID")]
        public int ID
        {
            get { return _employeeID;}
            set { _employeeID = value;}
        }  
      
        public string Title
        {
            get { return _title;}
            set { _title = value;}
        }  

    }
}
