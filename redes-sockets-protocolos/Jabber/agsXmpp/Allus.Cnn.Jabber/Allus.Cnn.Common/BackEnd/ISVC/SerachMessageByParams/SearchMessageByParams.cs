using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Fwk.Bases;
using Allus.Cnn.Common;
using Allus.Cnn.Common.BE;

namespace Allus.Cnn.ISVC.SearchMessageByParams
{
    [Serializable]
    public class SearchMessageByParamsReq : Request<Param>
    {
        public SearchMessageByParamsReq()
        {
            this.ServiceName = "SearchMessageByParamsService";
        }
    }

    #region [BussinesData]

    [XmlInclude(typeof(Param)), Serializable]
    public class Param : Entity
    {
        DateTime? _DateStart;

        public DateTime? DateStart
        {
            get { return _DateStart; }
            set { _DateStart = value; }
        }
        DateTime? _DateEnd;

        public DateTime? DateEnd
        {
            get { return _DateEnd; }
            set { _DateEnd = value; }
        }
        MessagesBE _messageParams;
        MeshBE _MeshBE;

        public MeshBE Mesh
        {
            get { return _MeshBE; }
            set { _MeshBE = value; }
        }

        public MessagesBE MessageParams
        {
            get { return _messageParams; }
            set { _messageParams = value; }
        }
        

    }

    #endregion







    [Serializable]
    public class SearchMessageByParamsRes : Response<Result>
    {
    }

    #region [BussinesData]

    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Entity
    {
        #region [Private Members]
        private MessagesBECollection _MessagesBECollection;
        #endregion


        #region [Properties]

        #region [Dummy]
       
        public MessagesBECollection MessagesBECollection
        {
            get { return _MessagesBECollection; }
            set { _MessagesBECollection = value; }
        }
        #endregion

        #endregion
    }
    #endregion
}