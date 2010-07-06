using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Allus.Cnn.Common
{
    interface IReport
    {
        void Populate(Guid pMessageId, string pMessageTitle);

    }
}
