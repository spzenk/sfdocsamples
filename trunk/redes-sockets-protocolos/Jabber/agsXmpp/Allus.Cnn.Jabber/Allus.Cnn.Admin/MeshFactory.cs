using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Allus.Cnn.Common;
using DevExpress.XtraTreeList.Nodes;
using Allus.Cnn.Common.BE;

namespace Allus.Cnn.Admin
{
    class MeshFactory
    {
        
        static Dictionary<string, Mesh> _MeshFormList = new Dictionary<string, Mesh>();
        public static AlertService GlobalWrapper;
        internal static List<MeshBE> GetList()
        {
            var x = from c in _MeshFormList select c.Value.MeshBE;
        
            return x.ToList<MeshBE>();
        }
        static MeshFactory()
        {
       
        }
        internal static String[] GetList_MeshId()
        {
            return _MeshFormList.Keys.ToArray<string>();
        }

        /// <summary>
        /// Obtiene el correspondiente mesh, si no existe lo crea.-
        /// </summary>
        /// <param name="meshBE"></param>
        /// <param name="node"></param>
        /// <returns>Formulario Mesh</returns>
        internal static Mesh GetMeshForm(MeshBE meshBE, TreeListNode node)
        {
            bool isNew;
            return GetMeshForm(meshBE.Id, meshBE.Name, node, out isNew);
        }
        /// <summary>
        /// Obtiene el correspondiente mesh, si no existe lo crea
        /// </summary>
        /// <param name="meshId"></param>
        /// <param name="meshName"></param>
        /// <param name="node"></param>
        /// <param name="isNew">Parametro tipo out que determina si el Mesh existia o fue creado.-</param>
        /// <returns>Formulario Mesh</returns>
        internal static Mesh GetMeshForm(string meshId, string meshName,TreeListNode node,out bool isNew)
        {
         

            isNew = false;
            meshId = MeshBE.GetCompleteIdOrName(meshId);
            meshName = MeshBE.GetCompleteIdOrName(meshName);
            Mesh wMesh;
            if (_MeshFormList.ContainsKey(meshId))
            {
                wMesh = (Mesh)_MeshFormList[meshId];
                isNew = false;
            }
            else
            {
                wMesh = new Mesh(Controller.LoggedColaborator, meshId, meshName);
                wMesh.Node = node;
                _MeshFormList.Add(meshId, wMesh);
                isNew = true;
                //Actualizo esta lista para q los colaboradores q recien ingresen al mesh global 
                //Sepan que submesh se an creado desde el administrador.-
                GlobalWrapper.MeshIdList = _MeshFormList.Keys.ToList<String>();
                //Agrego al storage el mesh en el caso de que se trate de un nuevo mesh q no estaba en la cache
                if(!SettingStorage.Storage.MeshBEList.Exists(m => m.Id == wMesh.MeshBE.Id))
                    SettingStorage.Storage.MeshBEList.Add(wMesh.MeshBE);
            }
            return wMesh;
        }
        internal static Mesh GetById(string meshId)
        {
            
            Mesh wMesh=null;
            if (_MeshFormList.ContainsKey(meshId))
                wMesh = (Mesh)_MeshFormList[meshId];

           
            return wMesh;
        }
        /// <summary>
        /// Remueve el form mesh de la lista de meshes (_MeshFormList y SettingStorage.Storage.MeshBEList.)
        /// </summary>
        /// <param name="meshId">Id ej: 123$12$</param>
        internal static void RemoveMeshForm(string meshId)
        {
            Mesh wMesh;
            if (_MeshFormList.ContainsKey(meshId))
            {
                

                wMesh = (Mesh)_MeshFormList[meshId];
                //Busco el mesh BE en la cache para eliminarlo si es que existe
                MeshBE wMeshBE = SettingStorage.Storage.MeshBEList.First<MeshBE>(m => m.Id.Equals(wMesh.MeshBE.Id));
                if (wMeshBE!= null)
                    SettingStorage.Storage.MeshBEList.Remove(wMeshBE);
                wMesh.Close();
                wMesh.Dispose();
                //Elimino el formulario del mesh del diccionario
                _MeshFormList.Remove(meshId);
            }
           
            

        }

        internal static void ShowMesh(MeshBE pMesh,out bool isNew)
        {
            isNew = true;
            Mesh wMesh = GetById(pMesh.Id);
            if (wMesh != null)
            {
                wMesh.Show();
                wMesh.Focus();
                isNew = false;
            }
            
        }

        internal static void CloseAllMesh()
        {
            foreach (Mesh m in _MeshFormList.Values)
            {
                m.DisconnectMesh();

            }
            _MeshFormList.Clear();
        }

        /// <summary>
        /// Recorre todos los meshs creados y avisa que ingreso un nuevo colaborador a la sala
        /// </summary>
        /// <param name="pColaborator"></param>
        internal static void UserJoin(Colaborator pColaborator)
        {
            //Primero lo agrego a la lista si se trata de un colaborador no agregado
            if (!Controller.ColaboratorList.Any<Colaborator>(col => col.Name.Equals(pColaborator.Name, StringComparison.OrdinalIgnoreCase)))
                Controller.ColaboratorList.Add(pColaborator);
            foreach(Mesh m in _MeshFormList.Values)
            {
                m.UserJoin(pColaborator);
            }
        }
        /// <summary>
        /// Recorre todos los meshs creados y avisa que salio un  colaborador a la sala
        /// </summary>
        /// <param name="pColaborator"></param>
        internal static void UserLeave(Colaborator pColaborator)
        {
            //Si no existe el colaborador q anuncia Leave
            if (!Controller.ColaboratorList.Any<Colaborator>(
                col => col.Name.Equals(pColaborator.Name, 
                    StringComparison.OrdinalIgnoreCase))) return;

               Colaborator wColaborator  = Controller.ColaboratorList.First<Colaborator>(col => col.Name.Equals(pColaborator.Name, StringComparison.OrdinalIgnoreCase));
           
            if (wColaborator != null)
            {
                foreach (Mesh m in _MeshFormList.Values)
                {
                    m.UserLeave(pColaborator);
                }

                //Despues de avisar a todos los meshes q salio un colaborador del Mesh global
                //elimino el colaborador de la lista
                Controller.ColaboratorList.Remove(wColaborator);
            }
        }

    }
}
