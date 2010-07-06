using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Allus.Cnn.Common.BE
{
    [Serializable]
    public class MeshBE
    {
        string _FriendlyName = Common.NULL;


        string _Name = Common.NULL;
        string _Id;
        string _Domain = Common.NULL;
        string _Cuenta = Common.NULL;
        int? _CuentaId;
        string _Subarea = Common.NULL;
        int? _SubAreaId;
        string _Sexo = Common.NULL;
        string _Cargo = Common.NULL;
        int? _CargoId;
        string _Sucursal = Common.NULL;
        int? _SucursalId;

        public MeshBE()
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">Concatenacion de los dominios de filtrado expresado como {Cuenta_Subarea_Cargo_Sucursal_Domain}</param>
        /// <param name="id">Concatenacion de los Ids dominios de filtrado expresado como {Cuenta_Subarea_Cargo_Sucursal_Domain}</param>
        public MeshBE(string name, string id)
        {



            if (!string.IsNullOrEmpty(id))
            {

                String[] meshIdArray = id.Split(Common.DOMAIN_SEPARATOR);
                ///Valida si la cuenta coincide Cuentas
                if (meshIdArray.Length >= 1)
                    if (string.Compare(meshIdArray[0], Common.NULL) != 0)
                        _CuentaId = Convert.ToInt32(meshIdArray[0]);
                ///Valida si la Subarea coincide Subarea 
                if (meshIdArray.Length >= 2)
                    if (string.Compare(meshIdArray[1], Common.NULL) != 0)
                        _SubAreaId = Convert.ToInt32(meshIdArray[1]);

                ///Valida si el cargo coincide Cargo
                if (meshIdArray.Length >= 3)
                    if (string.Compare(meshIdArray[2], Common.NULL) != 0)
                        _CargoId = Convert.ToInt32(meshIdArray[2]);

                ///Valida si el cargo coincide Sucursal
                if (meshIdArray.Length >= 4)
                    if (string.Compare(meshIdArray[3], Common.NULL) != 0)
                        _SucursalId = Convert.ToInt32(meshIdArray[3]);
                ///Valida si el cargo coincide de active directory
                if (meshIdArray.Length >= 5)
                    if (string.Compare(meshIdArray[4], Common.NULL) != 0)
                        _Domain = meshIdArray[4].ToString();
            }

            if (!string.IsNullOrEmpty(name))
            {
                String[] meshNameArray = name.Split(Common.DOMAIN_SEPARATOR);
                ///Valida si la cuenta coincide Cuentas
                if (meshNameArray.Length >= 1)
                    if (string.Compare(meshNameArray[0], Common.NULL) != 0)
                        _Cuenta = meshNameArray[0].ToString();
                ///Valida si la Subarea coincide Subarea 
                if (meshNameArray.Length >= 2)
                    if (string.Compare(meshNameArray[1], Common.NULL) != 0)
                        _Subarea = meshNameArray[1].ToString();

                ///Valida si el cargo coincide Cargo
                if (meshNameArray.Length >= 3)
                    if (string.Compare(meshNameArray[2], Common.NULL) != 0)
                        _Cargo = meshNameArray[2].ToString();

                ///Valida si el cargo coincide Sucursal
                if (meshNameArray.Length >= 4)
                    if (string.Compare(meshNameArray[3], Common.NULL) != 0)
                        _Sucursal = meshNameArray[3].ToString();

                ///Valida si el cargo coincide Dominio de active directory
                if (meshNameArray.Length >= 5)
                    if (string.Compare(meshNameArray[4], Common.NULL) != 0)
                        _Domain = meshNameArray[4].ToString();
            }
            _FriendlyName = name.Replace(string.Concat(Common.DOMAIN_SEPARATOR.ToString(), Common.NULL), string.Empty);
            _FriendlyName = _FriendlyName.Replace(Common.DOMAIN_SEPARATOR.ToString(), "-->");

        }

        public string FriendlyName
        {
            get { return _FriendlyName; }
            set { _FriendlyName = value; }
        }

        public string Id
        {
            get
            {
                GenerateId();
                return _Id;
            }
            set { _Id = value; }
        }


        public string Name
        {
            get
            {
                GenerateName();
                return _Name;
            }
            set { _Name = value; }
        }


        public string Domain
        {
            get { return _Domain; }
            set { _Domain = value; }
        }

        public string Sexo
        {
            get { return _Sexo; }
            set { _Sexo = value; }
        }

        #region gerarquicos del menu


        public string Cuenta
        {
            get { return _Cuenta; }
            set { _Cuenta = value; }
        }

        public int? CuentaId
        {
            get { return _CuentaId; }
            set { _CuentaId = value; }
        }



        public string Subarea
        {
            get { return _Subarea; }
            set { _Subarea = value; }
        }


        public int? SubAreaId
        {
            get { return _SubAreaId; }
            set { _SubAreaId = value; }
        }


        public string Cargo
        {
            get { return _Cargo; }
            set { _Cargo = value; }
        }

        public int? CargoId
        {
            get { return _CargoId; }
            set { _CargoId = value; }
        }



        public string Sucursal
        {
            get { return _Sucursal; }
            set { _Sucursal = value; }
        }




        public int? SucursalId
        {
            get { return _SucursalId; }
            set { _SucursalId = value; }
        }


        #endregion


        /// <summary>
        /// Retorna la concatenacion de los dominios de filtrado o armado de meshes
        /// 0:_Cuenta
        /// 1:_Subarea
        /// 2:_Cargo
        /// 3:_Sucursal
        /// 4:_Domain
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            GenerateName();
            return _Name;
        }

        void GenerateId()
        {
            List<string> list = new List<string>();

            if (_CuentaId != null)
                list.Add(_CuentaId.ToString());
            else
                list.Add(Common.NULL);

            if (_SubAreaId != null)
                list.Add(_SubAreaId.ToString());
            else
                list.Add(Common.NULL);

            if (_CargoId != null)
                list.Add(_CargoId.ToString());
            else
                list.Add(Common.NULL);

            if (!string.IsNullOrEmpty(_Sucursal))
                list.Add(_Sucursal);
            else
                list.Add(Common.NULL);

            list.Add(_Domain);


            _Id = string.Join(Common.DOMAIN_SEPARATOR.ToString(), list.ToArray());
            list = null;
        }

        void GenerateName()
        {
            List<string> list = new List<string>();
            list.Add(_Cuenta);
            list.Add(_Subarea);
            list.Add(_Cargo);
            list.Add(_Sucursal);
            list.Add(_Domain);
            _Name = string.Join(Common.DOMAIN_SEPARATOR.ToString(), list.ToArray());
            list = null;

        }


        internal bool CanParticipeToMesh(ColaboratorData pColaboratorData)
        {

            bool participe = false;
            ///Valida si la cuenta coincide 
            if (_CuentaId != null)
                participe = (_CuentaId == pColaboratorData.CuentaId);
            ///Valida si la Subarea coincide  
            if (_SubAreaId != null)
                participe = (_SubAreaId == pColaboratorData.SubAreaId);
            ///Valida si el cargo coincide 
            if (_CargoId != null)
                participe = (_CargoId == pColaboratorData.CargoId);

            ///Valida si  Sucursal coincide 
            if (_SucursalId != null)
                participe = (_SucursalId == pColaboratorData.SucursalId);

            ///Valida si el dominio coincide 
            if (_Domain.CompareTo(Common.NULL) != 0)
                participe = (_Domain.CompareTo(pColaboratorData.Domain) == 0);


            return participe;
        }


        /// <summary>
        /// Completa el MeshId
        /// Retorna un Id de mesh completo a partir de un Id de mesh Incompleto
        /// EJ: 
        /// de 12$3 a 12$3$ALL$ALL$ALL$$ALL
        /// </summary>
        /// <param name="meshId"></param>
        /// <returns></returns>
        public static string GetCompleteIdOrName(string meshNameOrId)
        {
            List<string> list = new List<string>();
            String[] meshIdArray = meshNameOrId.Split(Common.DOMAIN_SEPARATOR);
            ///Valida si la cuenta coincide Cuentas
            if (meshIdArray.Length >= 1)
                list.Add(meshIdArray[0]);
            else
                list.Add(Common.NULL);


            ///Valida si la Subarea coincide Subarea 
            if (meshIdArray.Length >= 2)
                list.Add(meshIdArray[1]);
            else
                list.Add(Common.NULL);



            ///Valida si el cargo coincide Cargo
            if (meshIdArray.Length >= 3)
                list.Add(meshIdArray[2]);
            else
                list.Add(Common.NULL);


            ///Valida si el cargo coincide Sucursal
            if (meshIdArray.Length >= 4)
                list.Add(meshIdArray[3]);
            else
                list.Add(Common.NULL);

            ///Valida si el cargo coincide de active directory
            if (meshIdArray.Length >= 5)
                list.Add(meshIdArray[4]);
            else
                list.Add(Common.NULL);

            return string.Join(Common.DOMAIN_SEPARATOR.ToString(), list.ToArray());
        }

        public static string GetDatabaseMeshNameOrId(string pMeshNameOrId)
        {
            if (string.IsNullOrEmpty(pMeshNameOrId)) return string.Empty;
            String[] meshIArray =pMeshNameOrId.Split(Common.DOMAIN_SEPARATOR);
            var filter = from s in meshIArray where !s.Equals(Common.NULL) select s;
            return string.Join(Common.DOMAIN_SEPARATOR.ToString(), filter.ToArray<String>());
        }

        //public static string GetDatabaseMeshId(string pMeshNameOrId)
        //{
        //    if (string.IsNullOrEmpty(pMeshNameOrId)) return string.Empty;
        //    String[] meshIArray = pMeshNameOrId.Split(Common.DOMAIN_SEPARATOR);
        //    var filter = from s in meshIArray where !s.Equals(Common.NULL) select s;
        //    return string.Join(Common.DOMAIN_SEPARATOR.ToString(), filter.ToArray<String>());
        //}

    }
}
