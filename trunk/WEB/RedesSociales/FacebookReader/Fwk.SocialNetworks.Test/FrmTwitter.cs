using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fwk.SocialNetworks.Data
{
    public partial class FrmTwitter : Form
    {
        public FrmTwitter()
        {
            InitializeComponent();
        }

        private void btn_Twitterizer_GetAllUserMessages_Click(object sender, EventArgs e)
        {
            Fwk.SocialNetworks.Twitter.Twitterizer wTwitterizer = new Fwk.SocialNetworks.Twitter.Twitterizer();
            List<Twitterizer.TwitterDirectMessage> list = wTwitterizer.GetAllUserMessages(0, Constants.LogSince);

            List<Twitterizer.TwitterStatus> listMen = wTwitterizer.GetAllUserMentions(0, Constants.LogSince);
            Print(txtMentions, listMen);

            List<Twitterizer.TwitterStatus> listStatus = wTwitterizer.GetAllUserStatuses(2743256109, Constants.LogSince);
            Print(txtStatuses, listStatus);

            List<Twitterizer.TwitterSavedSearch> listTwitterSavedSearch= wTwitterizer.Get_SavedSearches();
            Print(txtSavedSearches, listTwitterSavedSearch);
        }


        void Print(TextBox t, List<Twitterizer.TwitterStatus> l)
        {
            StringBuilder str = new StringBuilder();
            foreach (Twitterizer.TwitterStatus s in l)
            {

                str.AppendLine(string.Concat("Id:  ", s.Id));
                str.AppendLine(string.Concat("CreatedDate:  ", s.CreatedDate));
                str.AppendLine(string.Concat("Source:   ", s.Source));
                str.AppendLine(s.Text);
                str.AppendLine("-------------------------------------------------------------");
            }

            t.Text = str.ToString();

        }
        void Print(TextBox t, List<Twitterizer.TwitterSavedSearch> l)
        {
            StringBuilder str = new StringBuilder();
            foreach (Twitterizer.TwitterSavedSearch s in l)
            {

                str.AppendLine(string.Concat("Id:  ", s.Id));
                str.AppendLine(string.Concat("CreatedAt:  ", s.CreatedAt));
                str.AppendLine(string.Concat("Name:   ", s.Name));
                str.AppendLine(string.Concat("Position:   ", s.Position));
                str.AppendLine(s.Query);
                str.AppendLine("-------------------------------------------------------------");
            }

            t.Text = str.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }



    }
}
