using WCFDirectHost.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.PeerToPeer;
using System;
using WCFDirectHost.Presenters;

namespace WCFDirectHostTests
{
    
    
    /// <summary>
    ///This is a test class for IntelServiceHostTest and is intended
    ///to contain all IntelServiceHostTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ServicePresenterTest
    {
        ServicePresenter target;
        Moq.Mock<IIntelService> mockIntel;
        Moq.Mock<IPeerRegistration> mockPeer;
        Moq.Mock<IServiceHost> mockServiceHost;

        string peerClassifier = "peerClassifier";

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
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        ////Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            mockIntel = new Moq.Mock<IIntelService>();
            mockPeer = new Moq.Mock<IPeerRegistration>();
            mockServiceHost = new Moq.Mock<IServiceHost>();
            mockServiceHost.Setup(mock => mock.PeerRegistration).Returns(mockPeer.Object);
            target = new ServicePresenter(mockIntel.Object,  mockServiceHost.Object);
        }
        //
        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            target = null;
            mockPeer = null;
            mockIntel = null;
        }
        //
        #endregion


        /// <summary>
        ///A test for IntelServiceHost Constructor
        ///</summary>
        [TestMethod()]
        public void IntelServiceHostConstructorTest()
        {
            Assert.IsNotNull(target);
        }

        [TestMethod]
        public void Port_Property_Returns_Open_Port()
        {
  
            Assert.IsTrue(target.Port > 0);
        }

        /// <summary>
        ///A test for Open
        ///</summary>
        [TestMethod()]
        public void StartService_Opens_ServiceHost()
        {          
            target.StartService(peerClassifier);
            mockServiceHost.Verify(mock => mock.Open(Moq.It.IsAny<IIntelService>(),Moq.It.IsAny<string>(),Moq.It.IsAny<int>()));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StartService_With_EmptyPeerClassifier()
        {
            target.StartService(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StartService_With_NullPeerClassifier()
        {
            target.StartService(null);
        }

        [TestMethod]
        public void StartService_Sets_IsOpen_On_OpenEvent()
        {

            target.StartService(peerClassifier);
            mockServiceHost.Raise(mock => mock.Opened += null, new EventArgs());
            Assert.IsTrue(target.IsOpen);
        }

        [TestMethod()]
        public void StopService_Closes_ServiceHost()
        {
            target.StartService(peerClassifier);
            target.StopService();
            mockServiceHost.Verify(mock => mock.Close());
        }

        [TestMethod()]
        public void StopService_Sets_IsOpen_False_OnCloseEvent() {
            mockServiceHost.Raise(mock => mock.Closed += null, new EventArgs());
            target.StartService(peerClassifier);
            target.StopService();
            Assert.IsFalse(target.IsOpen);
        }

        [TestMethod]
        public void Uri_IsEmpty_When_Service_Stopped()
        {
             Assert.IsTrue(string.IsNullOrEmpty(target.Uri));
        }

        [TestMethod()]
        public void Has_Uri_When_Service_Running()
        {
            mockPeer.Setup(mock => mock.PeerUri).Returns("localhost");      
            target.StartService(peerClassifier);
            mockServiceHost.Setup(mock => mock.PeerRegistration.PeerUri).Returns("localhost");
            mockServiceHost.Raise(mock => mock.Opened += null, new EventArgs());
            Assert.AreEqual<string>("localhost", target.Uri);
        }

        /// <summary>
        ///A test for Close
        ///</summary>
        [TestMethod()]
        public void Closeing_SessionPresenter_Closes_ServiceHost()
        {
            target.Close();
            mockServiceHost.Verify(mock => mock.Close());
        }

        [TestMethod]
        public void StartCommand_CanExecute_IsFalse_When_HostClassifier_IsNull()
        {
            target.HostClassifier = null;
            Assert.IsFalse(target.StartCommand.CanExecute(null));
        }

        [TestMethod]
        public void StartCommand_CanExecute_IsTrue_When_HostClassifier_IsNotNull()
        {
            target.HostClassifier = "test";
            Assert.IsTrue(target.StartCommand.CanExecute(null));
        }
    }
}
