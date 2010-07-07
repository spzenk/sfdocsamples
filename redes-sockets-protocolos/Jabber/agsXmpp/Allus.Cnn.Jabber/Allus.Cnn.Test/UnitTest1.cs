using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Allus.Cnn.ISVC.CreateMessage;
using Allus.Cnn.ISVC.CreateReceivedMessages;
using Fwk.Bases.FrontEnd;
using Fwk.Bases;
using Allus.Cnn.ISVC.SearchMessageByParams;
using Allus.Cnn.Common.BE;
using Allus.Cnn.ISVC.SearchRpt_ReadConfirmed;
using Allus.Cnn.ISVC.SearchMessagesReadConfirmed;
using Fwk.Transaction;
using SVC = Allus.Cnn.SVC;
using ISVC = Allus.Cnn.ISVC;
using Allus.Cnn.Common;
using Allus.Cnn.Common.BE;


namespace Allus.Cnn.Test
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        ClientServiceBase _ClientServiceBase = new ClientServiceBase();
        ColaboratorData _colaborator;
        String _strErrorResult = String.Empty;
        TransactionScopeHandler _Tx;

        public UnitTest1()
        {
          
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void CreateMessage()
        {
            string strErrorResult = String.Empty;
            CreateMessagesRequest wRequest = new CreateMessagesRequest();
            wRequest.BusinessData.MessageId = Guid.NewGuid();
            wRequest.BusinessData.MessageText = "No confirmeís";
            wRequest.BusinessData.Sender = Environment.UserName.ToString();
            wRequest.BusinessData.MeshName = "1";
            wRequest.BusinessData.Date = System.DateTime.Now;
            wRequest.BusinessData.RequireConfirm = false;
            wRequest.BusinessData.Priority = 1;
            wRequest.BusinessData.MachineIp = "100.11..1";
            wRequest.BusinessData.MessageType = Allus.Cnn.Common.MessageType.SimpleText;
            wRequest.BusinessData.Title = "No requiere confirmación" ;
            wRequest.BusinessData.Url = "www.hola.com";

            
            CreateMessagesResponse wResponse = new CreateMessagesResponse();
            wResponse = _ClientServiceBase.ExecuteService<CreateMessagesRequest, CreateMessagesResponse>(wRequest);
            

            if (wResponse.Error != null)
            {
                strErrorResult = wResponse.Error.Message;
            }

            Assert.AreEqual<Fwk.Exceptions.ServiceError>(wResponse.Error, null, strErrorResult);
        }

        [TestMethod]
        public void CreateReceivedMessage()
        {
            Guid wGuid = new Guid("f3d79b4f-2303-41ef-9bfe-20d8950dac45");
            string strErrorResult = String.Empty;
            CreateReceivedMessagesRequest wRequest = new CreateReceivedMessagesRequest();
            wRequest.BusinessData.MessageId = wGuid; // LEER: debe ser igual que el de CreateMessage porque en la BD es FK y por eso salta error de TEST.
            wRequest.BusinessData.Receptor = Environment.UserName.ToString();
            wRequest.BusinessData.Date = System.DateTime.Now;
            wRequest.BusinessData.Confirmed = null;

            CreateReceivedMessagesResponse wResponse = new CreateReceivedMessagesResponse();
            wResponse = _ClientServiceBase.ExecuteService<CreateReceivedMessagesRequest, CreateReceivedMessagesResponse>(wRequest);


            if (wResponse.Error != null)
            {
                strErrorResult = wResponse.Error.Message;
            }

            Assert.AreEqual<Fwk.Exceptions.ServiceError>(wResponse.Error, null, strErrorResult);
        }

        [TestMethod]
        public void SearchMessageByParam()
        {
            // SP: MessagesB_s_ByParams
            MessagesBE wMessage = new MessagesBE();
            wMessage.Sender = "aaguirre";
            MeshBE wMeshBe = new MeshBE();
            String strErrorResult = String.Empty;

            DateTime? startDate = null;
            DateTime? startEnd = null;
           
            //if (chkUseDate.Checked)
            //{
            //    startDate = dtpDateStart.Value;
            //    startEnd = dtpDateEnd.Value;
            //}

            wMessage.Title = "hola";

            SearchMessageByParamsReq req = new SearchMessageByParamsReq();
            req.BusinessData.MessageParams = wMessage;
            
            req.BusinessData.DateEnd = startEnd;
            req.BusinessData.DateStart = startDate;
            req.BusinessData.Mesh = new MeshBE();
            req.BusinessData.Mesh.CuentaId = 1;
            req.BusinessData.Mesh.CargoId = 1;
            req.BusinessData.Mesh.SubAreaId = 1;
            req.BusinessData.Mesh.SucursalId = 1;
            req.BusinessData.Mesh.Domain = "";
            req.BusinessData.Mesh.Name = "tecnologia";


            SearchMessageByParamsRes res = _ClientServiceBase.ExecuteService<SearchMessageByParamsReq, SearchMessageByParamsRes>(req);
            
            if (res.Error != null)
            {
                strErrorResult = res.Error.Message;
            }
        
           // Assert.AreEqual<Fwk.Exceptions.ServiceError>(res.Error, null, strErrorResult);
        }

        [TestMethod]
        public void SearchRpt_ReadConfirmed()
        {
            string strErrorResult = String.Empty;
            Guid wMessageId = new Guid("fc09124b-d5bb-4782-93ce-c32f4d62feb9");
            SearchRpt_ReadConfirmedRequest wRequest = new SearchRpt_ReadConfirmedRequest();
            wRequest.BusinessData.MessageId = wMessageId; 
            SearchRpt_ReadConfirmedResponse wResponse = new SearchRpt_ReadConfirmedResponse();
            wResponse = _ClientServiceBase.ExecuteService<SearchRpt_ReadConfirmedRequest, SearchRpt_ReadConfirmedResponse>(wRequest);


            if (wResponse.Error != null)
            {
                strErrorResult = wResponse.Error.Message;
            }

            Assert.AreEqual<Fwk.Exceptions.ServiceError>(wResponse.Error, null, strErrorResult);
        }

        [TestMethod]
        public void SearchMessageReadConfirmed()
        {
            string strErrorResult = String.Empty;
            Guid wMessageId = new Guid("c6f3d5e4-b35f-497f-91c6-5531d7201e07");
            SearchMessagesReadConfirmedRequest wRequest = new SearchMessagesReadConfirmedRequest();
            SearchMessagesReadConfirmedResponse wResponse = new SearchMessagesReadConfirmedResponse();
            
            wRequest.BusinessData.ColaboratorData = new ColaboratorData();
            wRequest.BusinessData.ColaboratorData.CuentaId = 78;
            wRequest.BusinessData.MessageId = wMessageId;

            wResponse = _ClientServiceBase.ExecuteService<SearchMessagesReadConfirmedRequest, SearchMessagesReadConfirmedResponse>(wRequest);

            if (wResponse.Error != null)
            {
                strErrorResult = wResponse.Error.Message;
            }
            Assert.AreEqual<Fwk.Exceptions.ServiceError>(wResponse.Error, null, strErrorResult);
        }

        [TestMethod]
        public void SearchColaboratorsByParams()
        {
            SVC.SearchColaboratorsByParamsService wService = new SVC.SearchColaboratorsByParamsService();
            ISVC.SearchColaboratorsByParams.SearchColaboratorsByParamsRequest wReq = new Allus.Cnn.ISVC.SearchColaboratorsByParams.SearchColaboratorsByParamsRequest();
            ISVC.SearchColaboratorsByParams.SearchColaboratorsByParamsResponse wRes = new Allus.Cnn.ISVC.SearchColaboratorsByParams.SearchColaboratorsByParamsResponse();
            ColaboratorData wCol = new ColaboratorData(); ;

            wCol.Username = "moviedo";
            wReq.BusinessData.ColaboratorData = wCol;

            try
            {
                wRes = wService.Execute(wReq);
            }
            catch (Exception ex)
            {
                _strErrorResult = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }

            Assert.AreEqual<String>(_strErrorResult, String.Empty, _strErrorResult);
        }

        [TestMethod]
        public void GetColaboratorDataByParams()
        {
            SVC.GetColaboratorDataByParamsService wService = new SVC.GetColaboratorDataByParamsService();
            ISVC.GetColaboratorDataByParams.GetColaboratorDataByParamsRequest wReq = new Allus.Cnn.ISVC.GetColaboratorDataByParams.GetColaboratorDataByParamsRequest();
            ISVC.GetColaboratorDataByParams.GetColaboratorDataByParamsResponse wRes = new Allus.Cnn.ISVC.GetColaboratorDataByParams.GetColaboratorDataByParamsResponse();

            wReq.BusinessData.UserName = "moviedo";

            try
            {
                wRes = wService.Execute(wReq);
            }
            catch (Exception ex)
            {
                _strErrorResult = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }

            Assert.AreEqual<String>(_strErrorResult, String.Empty, _strErrorResult);
        }

        [TestMethod]
        public void GetAllRelatedDomains()
        {
            SVC.GetAllRelatedDomainsService wService = new SVC.GetAllRelatedDomainsService();
            ISVC.GetAllRelatedDomains.GetAllRelatedDomainsRequest wReq = new Allus.Cnn.ISVC.GetAllRelatedDomains.GetAllRelatedDomainsRequest();
            ISVC.GetAllRelatedDomains.GetAllRelatedDomainsResponse wRes = new Allus.Cnn.ISVC.GetAllRelatedDomains.GetAllRelatedDomainsResponse();

            wReq.BusinessData.Dummy = string.Empty;

            try
            {
                wRes = wService.Execute(wReq);
            }
            catch (Exception ex)
            {
                _strErrorResult = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }

            Assert.AreEqual<String>(_strErrorResult, String.Empty, _strErrorResult);
        }

        [TestMethod]
        public void DeleteRelatedDomains()
        {
            SVC.DeleteRelatedDomainsService wService = new SVC.DeleteRelatedDomainsService();
            ISVC.DeleteRelatedDomains.DeleteRelatedDomainsRequest wReq = new Allus.Cnn.ISVC.DeleteRelatedDomains.DeleteRelatedDomainsRequest();
            ISVC.DeleteRelatedDomains.DeleteRelatedDomainsResponse wRes = new Allus.Cnn.ISVC.DeleteRelatedDomains.DeleteRelatedDomainsResponse();

            wReq.BusinessData.UserId = 1;

            _Tx = new TransactionScopeHandler(TransactionalBehaviour.RequiresNew, IsolationLevel.ReadCommitted, new TimeSpan(0, 0, 15));

            try
            {
                _Tx.InitScope();

                wRes = wService.Execute(wReq);

                _Tx.Abort();
            }
            catch (Exception ex)
            {
                _strErrorResult = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }

            Assert.AreEqual<String>(_strErrorResult, String.Empty, _strErrorResult);
        }

        [TestMethod]
        public void CreateDomains()
        {
            SVC.CreateDomainsService wService = new SVC.CreateDomainsService();
            ISVC.CreateDomains.CreateDomainsRequest wReq = new Allus.Cnn.ISVC.CreateDomains.CreateDomainsRequest();
            ISVC.CreateDomains.CreateDomainsResponse wRes = new Allus.Cnn.ISVC.CreateDomains.CreateDomainsResponse();
            DomainList wDomainList = new DomainList();
            Domain wDomain = new Domain();

            wDomain.Count = 1;
            wDomain.DomainId = 1;
            wDomain.Hierarchy = 1;
            wDomain.Id = "1";
            wDomain.Name = "moviedo";
            wDomain.ParentID = "0";

            wDomainList.Add(wDomain);

            wReq.BusinessData.UserName = "moviedo";
            wReq.BusinessData.DomainList = wDomainList;

            _Tx = new TransactionScopeHandler(TransactionalBehaviour.RequiresNew, IsolationLevel.ReadCommitted, new TimeSpan(0, 0, 15));

            try
            {
                _Tx.InitScope();

                wRes = wService.Execute(wReq);

                _Tx.Abort();
            }
            catch (Exception ex)
            {
                _strErrorResult = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }

            Assert.AreEqual<String>(_strErrorResult, String.Empty, _strErrorResult);
        }

    }


}
