using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Fwk.UI.Forms;
using Epiron.Front.Bases;



namespace Meucci.Front.Alerts
{
    public partial class MarqueeUC : Xtra_UC_Base
    {

        public MarqueeUC()
        {
            InitializeComponent();
        }
        public override void Populate(object initialObject)
        {
            marquee1.TextToShow = "Allus Global BPO Center es la compañía lider en America Latina en la provision de soluciones BPO inteligentes.";
            marquee1.TimeToShow = 2000;
            marquee1.Shape = DevExpress.XtraGauges.Core.Model.DigitalBackgroundShapeSetType.Style11;
            marquee1.Restart();
            marquee1.Start();
      
        }
       

    }
}
