using Fwk.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epiron.Back.Bases
{
    public class UILanguageValues : Entities<UILanguageValue> 
    { }
    public class UILanguageValue:Entity
    {
        public string key { get; set; }
        public string TextValue { get; set; }
        public string TooltipValue { get; set; }

    }
}
