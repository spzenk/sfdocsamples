using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases.ViewModels;

namespace Test.ViewModels
{
    public class SimpleCarViewModel : BaseViewModel
    {
        public string Brand { get; set; }

        public string Model { get; set; }
    }
}
