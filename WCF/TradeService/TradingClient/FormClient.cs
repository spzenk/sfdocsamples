using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fabrikam;
using System.ServiceModel.Channels;
using System.ServiceModel;


namespace TradingClient
{
    public partial class FormClient : Form
    {
        public FormClient()
        {
            InitializeComponent();
        }

        private void btnCallService_Click(object sender, EventArgs e)
        {
            ///------------------------------------------------------------<endpoint name="TradingServiceConfiguration"
            ITradingService dealProxy = new ChannelFactory<ITradingService>("TradingServiceConfiguration").CreateChannel();

            dealProxy.BeginDeal();

            Trade trade = new Trade();
            trade.Count = 10;
            trade.Symbol = "MSFT";
            trade.Date = DateTime.Now.AddMonths(2);
            dealProxy.AddTrade(trade);

            dealProxy.AddFunction("InterestRateEstimation");
            dealProxy.AddFunction("TechnologyStockEstimation");

            decimal dealValue = dealProxy.Calculate();
            textBox1.Text= "Deal value estimated at ${0}" + dealValue;

            dealProxy.Purchase();

            dealProxy.EndDeal();

            ((IChannel)dealProxy).Close();

        }
    }
}
