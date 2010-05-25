using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
namespace DynamicControls_NoAutopostBack
{
    /// <summary>
    /// Summary description for CheckObjet
    /// </summary>
    public class CheckObjet
    {
        string _Title;

        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        bool _chk1;

        public bool Chk1
        {
            get { return _chk1; }
            set { _chk1 = value; }
        }
        bool _chk2;

        public bool Chk2
        {
            get { return _chk2; }
            set { _chk2 = value; }
        }
        bool _chk3;

        public bool Chk3
        {
            get { return _chk3; }
            set { _chk3 = value; }
        }

        public CheckObjet(bool chk1,bool chk2,bool chk3,string title)
        {
            _Title = title;
            _chk1 = chk1;
            _chk2 = chk2;
            _chk3 = chk3;
        }
    }
}