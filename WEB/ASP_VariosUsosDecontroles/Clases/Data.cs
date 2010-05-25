using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Clases;

namespace WebApplication1
{
    public class Data
    {
        public static List<Empleado> SearchClients()
        {
            List<Empleado> wEmpleadoList = new List<Empleado>();
            Empleado wCli = new Empleado();

            EmployedDataContext dc = new EmployedDataContext();

            IEnumerable<Empleado> wLinqEmpleadoslist = from emp in dc.Employees 
                                                       select new Empleado {Nombre= emp.Contact.FirstName,Apellido = emp.Contact.LastName};


   


            return wEmpleadoList;
        }

         
    }

    public class Empleado
    {



        string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        string apellido;

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
    }
}
