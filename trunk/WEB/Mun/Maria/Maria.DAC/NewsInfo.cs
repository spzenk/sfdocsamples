using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;

namespace Maria.BE
{
    public class NewsList : List<NewsInfo>
    { }
    public class NewsInfo
    {

        public NewsInfo()
        {
            _Id = Guid.NewGuid();
        }

        public NewsInfo(Guid pGuid)
        {
            _Id = pGuid;
        }

        Guid _Id;

        public Guid Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        DateTime _CreateionDate;

        public DateTime CreationDate
        {
            get { return _CreateionDate; }
            set { _CreateionDate = value; }
        }
        DateTime? _ExpitationDate;

        public DateTime? ExpitationDate
        {
            get { return _ExpitationDate; }
            set { _ExpitationDate = value.Value; }
        }
        string _CreationUser;

        public string CreationUser
        {
            get { return _CreationUser; }
            set { _CreationUser = value; }
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
        byte[] _Img = null  ;

        public byte[] Img
        {
            get { return _Img; }
            set { _Img = value; }
        }
        
    }
}
