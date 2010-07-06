using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Fwk.Bases.Connector.SingleService;
using Fwk.Bases;



namespace Allus.Cnn.Common.BE
{

    #region Colaborator class
    /// <summary>
    /// Esta clase reprecenta un usuario e implementa INotifyPropertyChanged lo que le da soporte
    /// a bindings one-way and two-way
    /// 
    /// </summary>
    [DataContract]
    public class Colaborator : INotifyPropertyChanged
    {
        #region Instance Fields
        //private string _ImageURL;
        private string _Name;
        private string _HostName;
        string _MachineIp;

        private bool _IsAdmin;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #region Cosntructores
        /// <summary>
        /// Blank constructor
        /// </summary>
        public Colaborator()
        {
        }

       
        #endregion

        #region Public Properties
        /// <summary>
        /// direccion url de la imagen del colaborador
        /// </summary>
        //[DataMember]
        //public string ImageURL
        //{
        //    get { return _ImageURL; }
        //    set
        //    {
        //        _ImageURL = value;
        //        OnPropertyChanged("ImageURL");
        //    }
        //}

        /// <summary>
        /// nombre del colaborador
        /// </summary>
        [DataMember]
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                // llama al handler OnPropertyChanged  cuando la propiedad cambia
                OnPropertyChanged("Name");
            }
        }

        [DataMember]
        public string MachineIp
        {
            get { return _MachineIp; }
            set
            {
                _MachineIp = value;
            }
        }
        [DataMember]
        public string HostName
        {
            get { return _HostName; }
            set { _HostName = value; }
        }
        /// <summary>
        ///indica si el colaborador es administrador colaborador
        /// </summary>
        [DataMember]
        public bool IsAdmin
        {
            get { return _IsAdmin; }
            set
            {
                _IsAdmin = value;
            }
        }
        #endregion
        #region OnPropertyChanged (for correct well behaved databinding)
        /// <summary>
        /// Informa el combio de valor de una propiedad
        ///  y si el binding nececita ser actualizado
        /// </summary>
        /// <param name="propValue">La propiedad que cambia</param>
        protected void OnPropertyChanged(string propValue)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propValue));
            }
        }
        #endregion
    }
    #endregion


    /// <summary>
    /// Esta es la clase q representa un usuario o colaborardor en la base de datos.- Mantiene una relacion uno a uno con la clase Colaborator 
    /// Se diferencia de esta ya que esta es usada por los servicios de negocio y no para comunicacion p2p.-
    /// </summary>
    [XmlInclude(typeof(ColaboratorData)), Serializable]
    public class ColaboratorData : Entity
    {

        public ColaboratorData()
        {

        }


        public ColaboratorData(MeshBE mesh)
        {
            cuentaId = mesh.CuentaId;
            subAreaId = mesh.SubAreaId;
            cargoId = mesh.CargoId;
            sucursalId = mesh.SucursalId;
            domain = mesh.Domain;

        }
        public ColaboratorData(Colaborator pColaborator)
        {
            username = pColaborator.Name;
            _MachineIp = pColaborator.MachineIp;
        }


        DomainList _DomainList;

        public DomainList DomainList
        {
            get { return _DomainList; }
            set { _DomainList = value; }
        }

        bool connected;

        public bool Connected
        {
            get { return connected; }
            set { connected = value; }
        }
        bool _IsConsoleAdmin;

        public bool IsConsoleAdmin
        {
            get { return _IsConsoleAdmin; }
            set { _IsConsoleAdmin = value; }
        }
        int _UserId;

        public int UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }
        string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        string domain = Common.NULL;

        public string Domain
        {
            get { return domain; }
            set { domain = value; }
        }
        string firstname;

        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }
        string surname;

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        int? cuentaId;

        public int? CuentaId
        {
            get { return cuentaId; }
            set { cuentaId = value; }
        }
        int? subAreaId;

        public int? SubAreaId
        {
            get { return subAreaId; }
            set { subAreaId = value; }
        }
        int? sucursalId;

        public int? SucursalId
        {
            get { return sucursalId; }
            set { sucursalId = value; }
        }

        int? cargoId;

        public int? CargoId
        {
            get { return cargoId; }
            set { cargoId = value; }
        }
        string _MachineIp;

        public string MachineIp
        {
            get { return _MachineIp; }
            set
            {
                _MachineIp = value;
            }
        }
        private string _HostName;

        public string HostName
        {
            get { return _HostName; }
            set { _HostName = value; }
        }

        private String _MessageStatus;

        public String MessageStatus
        {
            get { return _MessageStatus; }
            set { _MessageStatus = value; }
        }

    }
}
