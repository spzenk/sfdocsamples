using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Allus.Cnn.Common.BE;
using Allus.Cnn.ISVC.CreateDomains;
using Allus.Cnn.ISVC.GetColaboratorDataByParams;
using Allus.Cnn.ISVC.SearchRelatedDomainsByUser;
using Allus.Cnn.ISVC.CreateMessage;
using Allus.Cnn.ISVC.CreateReceivedMessages;
using Allus.Cnn.ISVC.SearchColaboratorsByParams;
using Allus.Cnn.ISVC.GetAllRelatedDomains;
using Allus.Cnn.ISVC.UpdateReceivedMessages;
using Allus.Cnn.ISVC.SearchMessageByParams;
using Allus.Cnn.ISVC.SearchRpt_ReadConfirmed;
using Allus.Cnn.ISVC.SearchMessagesReadConfirmed;

namespace Allus.Cnn.Common
{
    public class Controller
    {
        public static List<Colaborator> ColaboratorList = null;
        static Fwk.Bases.ClientServiceBase _ClientServiceBase;
        public static DomainList Dominios;
        public static DomainList Cuentas;
        public static DomainList SubAreas;
        public static DomainList Cargos;
        public static DomainList Sucursales;
        public static DomainList RelatedDomains;
        /// <summary>
        /// Es el usuario logueado a la aplicacion
        /// </summary>
        static ColaboratorData _LoggedColaboratorData;
        static Colaborator _LoggedColaborator;

        public static Colaborator LoggedColaborator
        {
            get { return Controller._LoggedColaborator; }
            set { Controller._LoggedColaborator = value; }
        }
        static Fwk.HelperFunctions.Caching.FwkCache cache;

        /// <summary>
        /// Obtiene la instancia estatica del <see cref="ColaboratorData"/>
        /// </summary>
        /// <returns></returns>
        public static ColaboratorData GetColaboratorDataInstance()
        {
            if (_LoggedColaboratorData == null)
                _LoggedColaboratorData = Controller.GetColaboratorDataByParams(Environment.UserName);

            return _LoggedColaboratorData;
        }

        /// <summary>
        /// Vuelve a llamar el metodo del controller para llenar el actual colaborador logueado en el sistema
        /// Este metodo vuelve a cargar la instancia estatica del <see cref="ColaboratorData"/>
        /// </summary>
        public static void ReloadColaboratorDataInstance()
        {
            _LoggedColaboratorData = Controller.GetColaboratorDataByParams(Environment.UserName);
        }

        static Controller()
        {
            ColaboratorList = new List<Colaborator>();
            cache = new Fwk.HelperFunctions.Caching.FwkCache();
            _ClientServiceBase = new Fwk.Bases.ClientServiceBase();
            DomainList pAllDomains = null;
            try
            {
                Controller.GetAllRelatedDomains(out RelatedDomains, out pAllDomains);

            }
            catch (Fwk.Exceptions.TechnicalException ex)
            {
                ex.Source = "Origen de datos";
                throw ex;
            }

            Domain wNullDomain = new Domain();
            wNullDomain.Name = "Todos";
            wNullDomain.DomainId = -1;


            Cuentas = new DomainList();
            Dominios = new DomainList();
            SubAreas = new DomainList();
            Cargos = new DomainList();
            Sucursales = new DomainList();

            Cuentas.Add(wNullDomain);
            Dominios.Add(wNullDomain);
            SubAreas.Add(wNullDomain);
            Cargos.Add(wNullDomain);
            Sucursales.Add(wNullDomain);

            var x = from c in pAllDomains where c.Hierarchy.Value == 0 select c;
            Cuentas.AddRange(x.ToArray<Domain>());

            x = from c in pAllDomains where c.Hierarchy.Value == 1 select c;
            SubAreas.AddRange(x.ToArray<Domain>());

            x = from c in pAllDomains where c.Hierarchy.Value == 2 select c;
            Cargos.AddRange(x.ToArray<Domain>());

            x = from c in pAllDomains where c.Hierarchy.Value == 3 select c;
            Sucursales.AddRange(x.ToArray<Domain>());

            x = from c in pAllDomains where c.Hierarchy.Value == 4 select c;
            Dominios.AddRange(x.ToArray<Domain>());

        }

        private static void GetAllRelatedDomains(out DomainList pRelatedDomains, out DomainList pAllDomains)
        {
            pRelatedDomains = null;
            pAllDomains = null;

            GetAllRelatedDomainsRequest req = new GetAllRelatedDomainsRequest();

            GetAllRelatedDomainsResponse res = _ClientServiceBase.ExecuteService<GetAllRelatedDomainsRequest, GetAllRelatedDomainsResponse>(req);
            if (res.Error != null)
            {
                throw Common.ProcessException(res.Error);
            }

            pAllDomains = res.BusinessData.AllDomains;
            pRelatedDomains = res.BusinessData.RelatedDomains;
        }



        public static void CreateDomainsToAdmin(string puserName, DomainList domainList)
        {
            CreateDomainsRequest req = new CreateDomainsRequest();
            req.BusinessData.UserName = puserName;
            req.BusinessData.DomainList = domainList;

            CreateDomainsResponse res = _ClientServiceBase.ExecuteService<CreateDomainsRequest, CreateDomainsResponse>(req);

            if (res.Error != null)
            {
                throw Common.ProcessException(res.Error);
            }



        }

        /// <summary>
        /// busca los dominios relacionados al usuario
        /// </summary>
        /// <param name="puserName"></param>
        /// <param name="userId"></param>
        /// <param name="pCache">Determina si se implementa cacheo de datos</param>
        /// <param name="pRefreshData">Determina si se decea eliminar la data del cache</param>
        /// <returns></returns>
        public static DomainList SearchRelatedDomainsByUser(string puserName,
            int? userId,
            bool pCache,
            bool pRefreshData)
        {


            SearchRelatedDomainsByUserReq req = new SearchRelatedDomainsByUserReq();

            if (userId == null)
            {
                req.BusinessData.ColaboratorData.UserId = -1;

            }
            else
            {
                req.BusinessData.ColaboratorData.UserId = userId.Value;
            }

            if (pCache)
            {
                if (pRefreshData)
                {
                    cache.RemoveItem(string.Concat(req.ServiceName + puserName));
                }
                req.CacheSettings.CacheManagerName = Common.ServiceCacheName;
                req.CacheSettings.ExpirationTime = 30;
                req.CacheSettings.CacheOnClientSide = true;
                req.CacheSettings.RefreshOnExpired = false;
                req.CacheSettings.ResponseCacheId = string.Concat(req.ServiceName + puserName);
            }

            req.BusinessData.ColaboratorData.Username = puserName;

            SearchRelatedDomainsByUserRes res = _ClientServiceBase.ExecuteService<SearchRelatedDomainsByUserReq, SearchRelatedDomainsByUserRes>(req);
            if (res.Error != null)
            {
                throw Common.ProcessException(res.Error);
            }


            ///Esto es para asignar las cantidades de elementos por dominio que provienen de la coleccion Controller.RelatedDomains
            foreach (Domain d in res.BusinessData)
            {
                if (Controller.RelatedDomains.Exists(x => x.Id.Equals(d.Id)))
                {
                    d.Count = Controller.RelatedDomains.First<Domain>(x => x.Id.Equals(d.Id) &&
                        x.Hierarchy.Equals(d.Hierarchy)).Count;
                }
            }


            return res.BusinessData;
        }


        public static List<ColaboratorData> SearchColaboratorsByParams(ColaboratorData pColaboratorData)
        {
            SearchColaboratorsByParamsRequest req = new SearchColaboratorsByParamsRequest();
            req.BusinessData.ColaboratorData = pColaboratorData;
            SearchColaboratorsByParamsResponse res = _ClientServiceBase.ExecuteService<SearchColaboratorsByParamsRequest, SearchColaboratorsByParamsResponse>(req);
            if (res.Error != null)
            {
                throw Common.ProcessException(res.Error);
            }

            return res.BusinessData.ColaboratorDataList;
        }
        public static ColaboratorData GetColaboratorDataByParams(string puserName)
        {
            GetColaboratorDataByParamsRequest req = new GetColaboratorDataByParamsRequest();
            req.BusinessData.UserName = puserName;
            req.CacheSettings.CacheManagerName = Common.ServiceCacheName;
            req.CacheSettings.CacheOnClientSide = true;
            req.CacheSettings.RefreshOnExpired = false;
            req.CacheSettings.ResponseCacheId = string.Concat(req.ServiceName + puserName);
            GetColaboratorDataByParamsResponse res = _ClientServiceBase.ExecuteService<GetColaboratorDataByParamsRequest, GetColaboratorDataByParamsResponse>(req);

            req.CacheSettings.ExpirationTime = 30;
            if (res.Error != null)
            {
                throw Common.ProcessException(res.Error);
            }

            return res.BusinessData.ColaboratorData;
        }

        public static void CreateMessage(AlertMessage pAlert, Colaborator pColaborator, int pColaboratorsCountInMesh)
        {
            CreateMessagesRequest wRequest = new CreateMessagesRequest();
            CreateMessagesResponse wResponse = new CreateMessagesResponse();

            wRequest.BusinessData.MessageId = pAlert.MessageGuid;
            wRequest.BusinessData.Sender = pColaborator.Name;
            wRequest.BusinessData.Date = pAlert.Date;
            wRequest.BusinessData.MessageText = pAlert.Text;
            wRequest.BusinessData.Title = pAlert.Title;
            wRequest.BusinessData.Url = pAlert.Url;
            //TODO: Almacen del Mesh Name en Base de datos
            wRequest.BusinessData.MeshId = pAlert.MeshId;
            wRequest.BusinessData.MeshName = pAlert.MeshName;
            wRequest.BusinessData.RequireConfirm = pAlert.RequireConfirm;
            wRequest.BusinessData.MachineIp = pColaborator.MachineIp;
            wRequest.BusinessData.MachineName = pColaborator.HostName;
            wRequest.BusinessData.ColaboratorsCountInMesh = pColaboratorsCountInMesh;
            wRequest.BusinessData.Priority = pAlert.Priority;
            wRequest.BusinessData.MessageType = pAlert.MessageType;


            wResponse = _ClientServiceBase.ExecuteService<CreateMessagesRequest, CreateMessagesResponse>(wRequest);

            if (wResponse.Error != null)
            {
                throw Common.ProcessException(wResponse.Error);
            }
        }

        public static void CreateReceivedMessage(AlertMessage pMessage, string pReceiver)
        {
            CreateReceivedMessagesRequest wRequest = new CreateReceivedMessagesRequest();
            CreateReceivedMessagesResponse wResponse = new CreateReceivedMessagesResponse();

            wRequest.BusinessData.MessageId = pMessage.MessageGuid;
            wRequest.BusinessData.Receptor = pReceiver;
            wRequest.BusinessData.Date = pMessage.Date;
            wRequest.BusinessData.Confirmed = pMessage.Confirmed;

            wResponse = _ClientServiceBase.ExecuteService<CreateReceivedMessagesRequest, CreateReceivedMessagesResponse>(wRequest);

            if (wResponse.Error != null)
            {
                throw Common.ProcessException(wResponse.Error);
            }
        }

        public static void UpdateReceivedMessage(AlertMessage pMessage, string pReceiver)
        {
            UpdateReceivedMessagesRequest wRequest = new UpdateReceivedMessagesRequest();
            UpdateReceivedMessagesResponse wResponse = new UpdateReceivedMessagesResponse();

            wRequest.BusinessData.MessageId = pMessage.MessageGuid;
            wRequest.BusinessData.Receptor = pReceiver;
            wRequest.BusinessData.Confirmed = pMessage.Confirmed;

            wResponse = _ClientServiceBase.ExecuteService<UpdateReceivedMessagesRequest, UpdateReceivedMessagesResponse>(wRequest);

            if (wResponse.Error != null)
            {
                throw Common.ProcessException(wResponse.Error);
            }
        }

        public static MessagesBECollection SearchMessageByParams(MessagesBE pMessagesBE, DateTime? pDateStart, DateTime? pDateEnd)
        {
            SearchMessageByParamsReq req = new SearchMessageByParamsReq();
            req.BusinessData.MessageParams = pMessagesBE;
            req.BusinessData.DateEnd = pDateEnd;
            req.BusinessData.DateStart = pDateStart;
            SearchMessageByParamsRes res = _ClientServiceBase.ExecuteService<SearchMessageByParamsReq, SearchMessageByParamsRes>(req);
            if (res.Error != null)
            {
                throw Common.ProcessException(res.Error);
            }

            return res.BusinessData.MessagesBECollection;
        }

        public static Allus.Cnn.ISVC.SearchRpt_ReadConfirmed.Result SearchRpt_ReadConfirmed(Guid pMessageId)
        {
            SearchRpt_ReadConfirmedRequest wRequest = new SearchRpt_ReadConfirmedRequest();
            SearchRpt_ReadConfirmedResponse wResponse = new SearchRpt_ReadConfirmedResponse();

            wRequest.BusinessData.MessageId = pMessageId;
            wResponse = _ClientServiceBase.ExecuteService<SearchRpt_ReadConfirmedRequest, SearchRpt_ReadConfirmedResponse>(wRequest);

            if (wResponse.BusinessData.ResultGraficos.Count > 0)
            {
                if (wResponse.Error != null)
                {
                    throw Common.ProcessException(wResponse.Error);
                }

                return wResponse.BusinessData;
            }
            else
                return null;
        }

        public static void MapColaborators_ColaboratorsData(List<Colaborator> pColaboratorList, List<ColaboratorData> pColaboratorDataList)
        {
            //foreach (ColaboratorData colData in pColaboratorDataList)
            //{
            //    Colaborator col = pColaboratorList.First<Colaborator>(p => p.Name.Equals(colData.Username));
            //   colData.MachineIp = col.MachineIp;
            //}
            foreach (Colaborator col in pColaboratorList)
            {
                if (pColaboratorDataList.Any<ColaboratorData>(p => p.Username.Equals(col.Name, StringComparison.OrdinalIgnoreCase)))
                {
                    ColaboratorData colData = pColaboratorDataList.First<ColaboratorData>(p => p.Username.Equals(col.Name, StringComparison.OrdinalIgnoreCase));
                    colData.MachineIp = col.MachineIp;
                    colData.Connected = true;
                }
            }
        }

        public static List<ColaboratorData> SearchMessageReadConfirmed(Guid pMessageId, ColaboratorData pColaboratorData)
        {
            SearchMessagesReadConfirmedRequest wRequest = new SearchMessagesReadConfirmedRequest();
            SearchMessagesReadConfirmedResponse wResponse = new SearchMessagesReadConfirmedResponse();
            
            wRequest.BusinessData.MessageId = pMessageId;
            wRequest.BusinessData.ColaboratorData = new ColaboratorData();
            wRequest.BusinessData.ColaboratorData.CuentaId = pColaboratorData.CuentaId;
            wRequest.BusinessData.ColaboratorData.SubAreaId = pColaboratorData.SubAreaId;
            wRequest.BusinessData.ColaboratorData.SucursalId = pColaboratorData.SucursalId;
            wRequest.BusinessData.ColaboratorData.CargoId = pColaboratorData.CargoId;
            wRequest.BusinessData.ColaboratorData.Domain = pColaboratorData.Domain;
            
            wResponse = _ClientServiceBase.ExecuteService<SearchMessagesReadConfirmedRequest, SearchMessagesReadConfirmedResponse>(wRequest);

            if (wResponse.Error != null)
                throw Common.ProcessException(wResponse.Error);

            return wResponse.BusinessData.ColaboratorDataList;
        }


    }
}