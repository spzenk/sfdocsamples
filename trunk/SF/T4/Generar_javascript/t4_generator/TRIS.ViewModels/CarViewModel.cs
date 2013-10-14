using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRIS.ViewModels
{
    public class CarViewModel : SimpleCarViewModel
    {
        public int co2 { get; set; }

        public DateTime importdate { get; set; }

        public List<OptionViewModel> options { get; set; }

        public List<int> availableyears { get; set; }

        public List<string> availablecountries { get; set; }
    }
}
