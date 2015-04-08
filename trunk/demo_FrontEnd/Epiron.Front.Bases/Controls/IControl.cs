using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epiron.Front.Bases.Controls
{
    public interface IEpironControl
    {
        String TextUICode { get; set; }

        Boolean CheckEditingABMValue { get; set; }
        Boolean CheckEditingABM { get; set; }
        
    }
}
