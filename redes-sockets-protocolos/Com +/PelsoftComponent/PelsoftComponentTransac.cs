using System;
using System.Data;
using System.Xml.Serialization;
using System.Data.SqlClient;
using System.EnterpriseServices;
namespace PelsoftComponent
{
	/// <summary>
	/// Summary description for PelsoftComponentTransac.
	/// </summary>
	[System.EnterpriseServices.TransactionAttribute(System.EnterpriseServices.TransactionOption.Required)]
	public class PelsoftComponentTransac :System.EnterpriseServices.ServicedComponent	

	{
		#region --[Constructor]--
		public PelsoftComponentTransac()
		{

		}
		#endregion

		[System.EnterpriseServices.AutoComplete()]
		public void CrearEmpleado(string pstrEmpleado)
		{
			SqlConnection Cnn = new SqlConnection ("Persist Security Info=False;User ID=sa;Initial Catalog=test;Data Source=127.0.0.1;Password=");
			SqlCommand Cmd = new SqlCommand ();
			SqlParameter Param = null;
			Cmd.CommandType = CommandType.StoredProcedure;
			try
			{
				Employee pEmpleado =  DeserializeEmpleado( pstrEmpleado);
			
				Cnn.Open();
			
				Cmd.CommandText = "Employee_i";
				Cmd.Connection = Cnn;
			
				Param = Cmd.Parameters.Add("@LastName",SqlDbType.NVarChar,50);
				Param.Value = pEmpleado.LastName;

				Param = Cmd.Parameters.Add("@FirstName",SqlDbType.NVarChar,50);
				Param.Value = pEmpleado.FirstName;

				Param = Cmd.Parameters.Add("@Title",SqlDbType.NVarChar,50);
				Param.Value = pEmpleado.Title;

				Cmd.ExecuteNonQuery();
				Cnn.Close();
				

			}
			catch(SqlException er)
			{
				
				throw er;

			}

		}
		public  Employee  DeserializeEmpleado(string XmlData)
		{
			System.Text.UTF8Encoding wEncoder = new System.Text.UTF8Encoding();
			XmlSerializer serializer = new XmlSerializer(typeof(Employee));

			System.IO.MemoryStream mStream = new System.IO.MemoryStream(wEncoder.GetBytes(XmlData));
			Employee Emp = (Employee)serializer.Deserialize(mStream);
			return Emp;

		}
		

	}
}
