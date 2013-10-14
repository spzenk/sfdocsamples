using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRIS.BusinessObjects
{
    public abstract class BaseBO
    {
        public Guid Id { get; set; }

        public bool IsActive { get; set; }
    }
}
