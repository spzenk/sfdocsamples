using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Fwk.Bases.ViewModels;

namespace Test
{
    public class CarViewModel : BaseViewModel
    {
        public int Co2 { get; set; }

        public DateTime Importdate { get; set; }

        public List<OptionViewModel> Options { get; set; }

        public List<int> Availableyears { get; set; }

        public List<string> Availablecountries { get; set; }
    }
}
