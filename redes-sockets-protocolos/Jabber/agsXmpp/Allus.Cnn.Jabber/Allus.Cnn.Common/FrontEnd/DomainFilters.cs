using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Allus.Cnn.Common;
using Allus.Cnn.Common.BE;

namespace Allus.Cnn.Common
{
    public delegate void AceptDomainFilterHandler(ColaboratorData filter);
    [ToolboxItem(true)]
    [DefaultEvent("AceptDomainFilterEvent")]
    public partial class DomainFilters : Allus.Cnn.Common.UserControlBase
    {
        [Category("Allus.Libraries")]
        public event AceptDomainFilterHandler AceptDomainFilterEvent;
        ColaboratorData _Selected;
        public DomainFilters()
        {
            InitializeComponent();
  
        }

        public void Populate()
        {
            domainCombosFilters1.Populate();

      
    
        }

        private void btnAcept_Click(object sender, EventArgs e)
        {
            _Selected = new ColaboratorData(domainCombosFilters1.Mesh);
           // _Selected.Username = txtUserName.Text;

            if (AceptDomainFilterEvent != null)
                AceptDomainFilterEvent(_Selected);
        }

        public ColaboratorData GetFilter()
        {
            if (domainCombosFilters1.Mesh == null)
                return null;
            _Selected = new ColaboratorData(domainCombosFilters1.Mesh);
            return _Selected;
        }
        
    }
}
