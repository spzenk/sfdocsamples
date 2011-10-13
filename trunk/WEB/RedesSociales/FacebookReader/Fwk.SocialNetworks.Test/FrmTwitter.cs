﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fwk.SocialNetworks
{
    public partial class FrmTwitter : Form
    {

        Fwk.SocialNetworks.Twitter.TwitterizerWrap _Twitterizer = null;

        public FrmTwitter()
        {
            InitializeComponent();
            _Twitterizer = new Fwk.SocialNetworks.Twitter.TwitterizerWrap();
        }

        private void btn_Twitterizer_GetAllUserMessages_Click(object sender, EventArgs e)
        {
            
            List<Twitterizer.TwitterDirectMessage> list = _Twitterizer.GetAllUserMessages(0, Constants.LogSince);

            List<Twitterizer.TwitterStatus> listMen = _Twitterizer.GetAllUserMentions(0, Constants.LogSince);
            Print(txtMentions, listMen);

            List<Twitterizer.TwitterStatus> listStatus = _Twitterizer.GetAllUserStatuses(2743256109, Constants.LogSince);
            Print(txtStatuses, listStatus);


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



        void Print(TextBox t, List<Twitterizer.TwitterSearchResult> l)
        {
            StringBuilder str = new StringBuilder();
            foreach (Twitterizer.TwitterSearchResult s in l)
            {

                str.AppendLine(string.Concat("Id:  ", s.Id));
                str.AppendLine(string.Concat("CreatedDate:  ", s.CreatedDate));
                str.AppendLine(string.Concat("Source:   ", s.Source));
                str.AppendLine(s.Text);
                str.AppendLine("-------------------------------------------------------------");
            }

            t.Text = str.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Twitterizer.TwitterSavedSearch> listTwitterSavedSearch = _Twitterizer.Get_SavedSearches();
            Print(txtSavedSearches, listTwitterSavedSearch);
        }



        private void button2_Click(object sender, EventArgs e)
        {
         
            //enjine1.Start_Twitter_WithoutTimer();
            enjine1.Start_Twitter();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Twitterizer.TwitterSearchResult> listTwitterSearchResult = _Twitterizer.Search(txtSearch.Text, 124444492202909696, null);
            Print(txtSearchs, listTwitterSearchResult);

        }


      
    }
}
