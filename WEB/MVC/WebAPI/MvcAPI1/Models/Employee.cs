using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcAPI1.Controllers
{
    internal class EmpList : List<Employee>
    { 
    
    }
    internal class Employee
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String Desc { get; set; }
        public long Nro { get; set; }

        public Employee(int p1, string p2, string p3, long p4)
        {
            // TODO: Complete member initialization
            this.Id = p1;
            this.Name = p2;
            this.Desc = p3;
            this.Nro = p4;
        }
   
    }
}
