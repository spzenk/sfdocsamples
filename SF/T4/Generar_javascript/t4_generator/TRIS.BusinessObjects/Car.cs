using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRIS.BusinessObjects
{
    public class Car : BaseBO
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public int CO2 { get; set; }

        public DateTime ImportDate { get; set; }

        public List<Option> Options { get; set; }

        public List<int> AvailableYears { get; set; }

        public List<string> AvailableCountries { get; set; }

        public Car()
        {
            this.Options = new List<Option>();
        }
    }
}
