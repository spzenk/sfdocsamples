using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Data.SqlXml;
using System.Collections;

namespace ObjectStorePart1
{
	public class ObjectRepository
	{    
        private String _SqlXmlconnectionString;

		public ObjectRepository(String connectionString)
		{_SqlXmlconnectionString = connectionString;}

        public Employee[] GetEmployee(string lastName) 
        {
            SqlXmlCommand command = new SqlXmlCommand(_SqlXmlconnectionString);
            command.CommandType = SqlXmlCommandType.Sql;
            command.CommandText = "exec FetchEmployee ?";
            SqlXmlParameter param = command.CreateParameter();
            param.Value = lastName;
            return DeserializeEmployee(command.ExecuteXmlReader());
        }

        public void PersistEmployee(Employee employee) 
        {
            PersistChanges(SerializeEmployee(employee), false);
        }

        public void PersistEmployees(Employee[] employee)
        {
            PersistChanges(SerializeEmployeeArray(employee), false);       
        }

        public void RemoveEmployee(Employee employee) 
        {
            PersistChanges(SerializeEmployee(employee), true);
        }

        private void PersistChanges(string serializedEmployees, bool delete)
        {
            SqlXmlCommand command = new SqlXmlCommand(_SqlXmlconnectionString);
            command.CommandType = SqlXmlCommandType.Sql;
            command.CommandText = "exec PersistEmployees ?, ?";
            SqlXmlParameter param = command.CreateParameter();
            param.Value = serializedEmployees;            
            SqlXmlParameter param2 = command.CreateParameter();
            param2.Value = delete ? 1 : 0;  
            command.ExecuteNonQuery();
        }

        private string SerializeEmployee(Employee employee)
        {
            Employee[] emps = new Employee[1];
            emps[0] = employee;
            return SerializeEmployeeArray(emps);
        }

        private string SerializeEmployeeArray(Employee[] employees)
        {
            MemoryStream stream = new MemoryStream();
            XmlRootAttribute xmlRoot = new XmlRootAttribute();
            xmlRoot.ElementName = "EmployeeList";
            Type type = employees.GetType();
            XmlSerializer serializer = new XmlSerializer(type, xmlRoot);
            serializer.Serialize(stream, (object) employees);
            stream.Position = 0;
            return new StreamReader(stream).ReadToEnd(); 
        }

        private Employee[] DeserializeEmployee(XmlReader reader)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute();
            xmlRoot.ElementName = "EmployeeList";
            XmlSerializer serializer = new XmlSerializer(typeof(Employee[]),xmlRoot);
            Employee[] emps = (Employee[]) serializer.Deserialize(reader);
            reader.Close();
            return emps;
        }

        public void CleanDatabase()
        {
            SqlXmlCommand command = new SqlXmlCommand(_SqlXmlconnectionString);
            command.CommandType = SqlXmlCommandType.Sql;
            command.CommandText = "delete address;delete Employee";
            SqlXmlParameter param = command.CreateParameter();
            command.ExecuteNonQuery();
        }


	}
}
