using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Allus.Cnn.Common
{
    public class ReadConfirmedMessagesBEFront
    {
        #region [Fields]

        private int _Leidos;
        private int? _Confirmados;
        private int? _NoConfirmados;
        private int _NoLeidos;

        #endregion

        #region [Properties]

        public int Leidos
        {
            get { return _Leidos; }
            set { _Leidos = value; }
        }

        public int? Confirmados
        {
            get { return _Confirmados; }
            set { _Confirmados = value; }
        }

        public int? NoConfirmados
        {
            get { return _NoConfirmados; }
            set { _NoConfirmados = value; }
        }

        public int NoLeidos
        {
            get { return _NoLeidos; }
            set { _NoLeidos = value; }
        }
        #endregion
    }
}
