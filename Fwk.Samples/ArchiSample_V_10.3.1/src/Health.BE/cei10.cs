using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Health.Back.BE;
using Health.Entities;


namespace Health.BE
{
    
    [XmlRoot("Array"), SerializableAttribute]
    public class CEI10ComboList : Fwk.Bases.BaseEntities<CEI10Combo> { }

    [XmlInclude(typeof(CEI10Combo)), Serializable]
    public partial class CEI10Combo : Fwk.Bases.BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// 
        /// </summary>
        public global::System.String Code
        {
            get
            {
                return _Code;
            }
            set
            {
                _Code = value;
            }
        }

        private global::System.String _Code;



        /// <summary>
        /// 
        /// </summary>
        public global::System.String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }

        private global::System.String _Description;

      





        #endregion


        /// <summary>
        /// Empty Constructor
        /// </summary>
        public CEI10Combo() { }

        /// <summary>
        /// Constructor from Model Entity
        /// Framework BE --> Edm Entity Model 
        /// </summary>
        /// <param name="pCEI10">Edm Model BE</param>
        public CEI10Combo(CEI_10BE pCEI10)
        {
            _Code = pCEI10.Code.Trim();
            _Description = pCEI10.Description;

          
        }


        
    }


    [XmlRoot("Array"), SerializableAttribute]
    public class CEI10GridList : Fwk.Bases.BaseEntities<CEI10Grid> { }

    [XmlInclude(typeof(CEI10Grid)), Serializable]
    public partial class CEI10Grid : Fwk.Bases.BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// 
        /// </summary>
        public global::System.String Code
        {
            get
            {
                return _Code;
            }
            set
            {
                _Code = value;
            }
        }

        private global::System.String _Code;



        /// <summary>
        /// 
        /// </summary>
        public global::System.String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }

        private global::System.String _Description;

        //public global::System.String Name
        //{
        //    get
        //    {
        //        return string.Concat(_Code, " ", _Description);
        //    }
        //    set
        //    {
        //        _Description = value;
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        public global::System.String Group1
        {
            get
            {
                return _Group1;
            }
            set
            {
                _Group1 = value;
            }
        }

        public global::System.String Group2
        {
            get
            {
                return _Group2;
            }
            set
            {
                _Group2 = value;
            }
        }

        public global::System.String Capitulo
        {
            get
            {
                return _Capitulo;
            }
            set
            {
                _Capitulo = value;
            }
        }


        private global::System.String _Group1;
        private global::System.String _Group2;
        private global::System.String _Capitulo;






        #endregion


        /// <summary>
        /// Empty Constructor
        /// </summary>
        public CEI10Grid() { }

        /// <summary>
        /// Constructor from Model Entity
        /// Framework BE --> Edm Entity Model 
        /// </summary>
        /// <param name="pCEI10">Edm Model BE</param>
        public CEI10Grid(cei10_view pCEI10)
        {
            _Code = pCEI10.Code.Trim();
            _Description = pCEI10.Description;

            _Group1 = pCEI10.Grupo1.Trim();
            _Group2 = pCEI10.Grupo2.Trim();
            _Capitulo = pCEI10.Capitulo;
        }


        /// <summary>
        /// Overload equal operator
        /// Framework BE = Edm Entity Model 
        /// </summary>
        /// <param name="pCEI10">Edm Model BE</param>
        public static explicit operator CEI10Grid(cei10_view pCEI10)
        {
            return new CEI10Grid(pCEI10);
        }
    }

}
