using WCFDirectClient.Presenters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WCFDirectClient.Services;
using System.ComponentModel;
using System;
using WCFDirectHost.Services;
using System.Drawing;

namespace WCFDirectClientTest
{
    
    
    /// <summary>
    ///This is a test class for ServicePresenterTest and is intended
    ///to contain all ServicePresenterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ServicePresenterTest
    {
        ServicePresenter target;
        Moq.Mock<IIntelClient> mockIntelClient;

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
        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            mockIntelClient = new Moq.Mock<IIntelClient>();
            target = new ServicePresenter(mockIntelClient.Object);
        }
        //
        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            target = null;
        }
        //
        #endregion


        /// <summary>
        ///A test for ServicePresenter Constructor
        ///</summary>
        [TestMethod()]
        public void ServicePresenter_Initialized()
        {
            Assert.IsNotNull(target);
        }

        [TestMethod]
        public void RawImageProperty_Returns_IntelClient_AgentImageProperty()
        {
            var image = target.RawImage;
            mockIntelClient.VerifyGet<Bitmap>(mock => mock.AgentImage);
        }

        [TestMethod]
        public void RawImageProperty_Sets_IntelClient_AgentImage_Property()
        {
            Bitmap image = new Bitmap(100, 100);
            target.RawImage = image;
            mockIntelClient.VerifySet(mock => mock.AgentImage = image);
        }

        [TestMethod]
        public void RawImageProperty_Set_Firest_IntelImagePropertyChangedEvent()
        {
            bool result = false;
            target.PropertyChanged += new PropertyChangedEventHandler((o, e) => { if (e.PropertyName == "IntelImage") result = true; });
            target.RawImage = new Bitmap(100, 100);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AgentProperty_Returns_IntelClient_AgentProperty()
        {
            var image = target.Agent;
            mockIntelClient.VerifyGet<string>(mock => mock.Agent);
        }

        [TestMethod]
        public void AgentProperty_Sets_IntelClient_AgentProperty()
        {
            string agent = "agent";
            target.Agent = agent;
            mockIntelClient.VerifySet(mock => mock.Agent = agent);
        }

        [TestMethod]
        public void AgentProperty_Set_Firest_IntelImagePropertyChangedEvent()
        {
            bool result = false;
            target.PropertyChanged += new PropertyChangedEventHandler((o, e) => { if (e.PropertyName == "Agent") result = true; });
            target.Agent = "agent";
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IntelImage_Returns_NonNull_When_RawImage_Set_Null()
        {
            target.RawImage = null;
            Assert.IsNotNull(target.IntelImage);
        }


        [TestMethod]
        public void HostClassifier_Can_Be_Set_Is_Null_By_Default()
        {
            Assert.IsNull(target.HostClassifier);
        }

        [TestMethod]
        public void HostClassifier_Can_Be_Set()
        {
            string name = "peerName";
            target.HostClassifier = name;
            Assert.AreEqual<string>(name, target.HostClassifier);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void HostClassifier_Can_Be_Set_Cannot_Be_Set_ToNull()
        {
            target.HostClassifier = null;
        }

        [TestMethod]
        public void IsConnectedProperty_Value_Comes_from_IIntelClient()
        {
            var result = target.IsConnected;
            mockIntelClient.VerifyGet<bool>(mock => mock.IsConnected);
        }

        [TestMethod]
        public void HostUriProperty_Value_Comes_from_IIntelClient()
        {
            var result = target.HostUri;
            mockIntelClient.VerifyGet<string>(mock => mock.HostUri);
        }

        [TestMethod]
        public void IsConnected_PropertyChangedEvent_Triggered_By_IntelClient_IsConnectedPropertyChangedEvent()
        {
            bool result = false;
            target.PropertyChanged += new PropertyChangedEventHandler((o, e) => { if (e.PropertyName == "IsConnected") result = true; });
            mockIntelClient.Raise(mock => mock.PropertyChanged += null, new PropertyChangedEventArgs("IsConnected"));         
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void HostUri_PropertyChangedEvent_Triggered_By_IntelClient_HostUriPropertyChangedEvent()
        {
            bool result = false;
            target.PropertyChanged += new PropertyChangedEventHandler((o, e) => { if (e.PropertyName == "HostUri") result = true; });
            mockIntelClient.Raise(mock => mock.PropertyChanged += null, new PropertyChangedEventArgs("HostUri"));
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void StartCommand_CanExecute_Returns_True_When_IIntelClient_IsConnected_IsFalse()
        {
            mockIntelClient.Setup(mock => mock.IsConnected).Returns(false);
            Assert.IsTrue(target.StartCommand.CanExecute(null));
        }

        [TestMethod]
        public void StartCommand_CanExecute_Returns_False_When_IIntelClient_IsConnected_IsTrue()
        {
            mockIntelClient.Setup(mock => mock.IsConnected).Returns(true);
            Assert.IsFalse(target.StartCommand.CanExecute(null));
        }

        [TestMethod]
        public void StopCommand_CanExecute_Returns_False_When_IIntelClient_IsConnected_IsFalse()
        {
            mockIntelClient.Setup(mock => mock.IsConnected).Returns(false);
            Assert.IsFalse(target.StopCommand.CanExecute(null));
        }

        [TestMethod]
        public void StopCommand_CanExecute_Returns_True_When_IIntelClient_IsConnected_IsTrue()
        {
            mockIntelClient.Setup(mock => mock.IsConnected).Returns(true);
            Assert.IsTrue(target.StopCommand.CanExecute(null));
        }

        [TestMethod]
        public void OpenImageCommand_CanExecute_Returns_True()
        {
            Assert.IsTrue(target.OpenImageCommand.CanExecute(null));
        }

    }
}
