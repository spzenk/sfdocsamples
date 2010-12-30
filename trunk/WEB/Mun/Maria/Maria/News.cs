using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maria
{
    public class NewsList:List<News>
    { }
    public class News
    {
        string _Id;

        public string Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        DateTime _CreateDate;

        public DateTime CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }
        string _CreateUser;

        public string CreateUser
        {
            get { return _CreateUser; }
            set { _CreateUser = value; }
        }
        string _Text;

        public string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }
        string _Title;

        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
    }
}
