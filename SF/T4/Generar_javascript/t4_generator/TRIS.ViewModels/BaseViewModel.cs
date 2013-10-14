using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRIS.ViewModels
{
    public abstract class BaseViewModel
    {
        public Guid id { get; set; }

        public bool isactive { get; set; }
    }
}
