using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Fwk.Bases;
using Allus.Cnn.Common;
using Allus.Cnn.Common.BE;

namespace Allus.Cnn.ISVC.SearchRpt_ReadConfirmed
{
    public class SearchRpt_ReadConfirmedResponse : Response<Result>
    {

    }

    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Entity
    {
        #region [Fields]
        private List<ResultGraficos> _ResultGraficos = new List<ResultGraficos>();

        #endregion
        public List<ResultGraficos> ResultGraficos
        {
            get { return _ResultGraficos; }
            set { _ResultGraficos = value; }
        }

    }

    public class ResultGraficos
    {
        #region [Fields]
        private string _Descripcion;
        private int _Cantidad;
        #endregion

        #region [Properties]
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public int Cantidad
        {

            get { return _Cantidad; }
            set { _Cantidad = value; }
        }
        #endregion
    }
}