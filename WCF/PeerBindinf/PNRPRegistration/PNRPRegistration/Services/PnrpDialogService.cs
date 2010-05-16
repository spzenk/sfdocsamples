using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Slickthought.MVP.Services;
using PNRPRegistration.Views;

namespace PNRPRegistration.Services
{
    public class PnrpDialogService : BaseDialogService
    {
        protected override void RegisterKnownWindows()
        {
            this.Register("LookUpRegistration", typeof(LookupResultDialog));
        }
    }
}
