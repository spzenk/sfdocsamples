using WCFDirectHost.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace WCFDirectHostTests
{
    
    
    /// <summary>
    ///This is a test class for IntelServiceHostTest and is intended
    ///to contain all IntelServiceHostTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IntelServiceHostTest {

        private IntelServiceHost target = null;


        static Moq.Mock<IIntelService> mockIntelService = new Moq.Mock<IIntelService>();
        static Moq.Mock<IPeerRegistration> mockPeerService = new Moq.Mock<IPeerRegistration>();

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext {
            get {
                return testContextInstance;
            }
            set {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            mockPeerService.Setup(mock => mock.PeerUri).Returns("localhost");
        }
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize() {
            target = new IntelServiceHost(mockPeerService.Object);
        }
        //
        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup() {
            target.Close();
            target = null;
        }
        //
        #endregion


        /// <summary>
        ///A test for IntelServiceHost Constructor
        ///</summary>
        [TestMethod()]
        public void IntelServiceHostConstructorTest() {
            Assert.IsNotNull(target);
        }

        [TestMethod]
        public void IsOpen_False_Initially() {
            Assert.IsFalse(target.IsOpen);
        }

        [TestMethod]
        public void IsOpen_True_After_Open() {
            target.Open(new IntelService(), "localhost", 8080);
            Assert.IsTrue(target.IsOpen);
        }

        [TestMethod]
        public void Can_Call_Close_Without_Opening() {
            bool result = false;
            target.Closed += new System.EventHandler((o,e) => { result = true; });
            target.Close();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsOpen_False_After_Close() {
            target.Open(new IntelService(), "localhost", 8080);
            target.Close();
            Assert.IsFalse(target.IsOpen);
        }

        /// <summary>
        ///A test for Open
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void Open_Throws_Exception_If_PeerRegistrationService_IsNull()
        {
            target.PeerRegistration = null;
        }

        [TestMethod]
        public void OpenedEvent_Fired_When_OpenMethod_Called()
        {
            bool result =false;
            target.Opened +=new EventHandler((o,e) => { result = true; });
            target.Open(new IntelService(), "peerClassifier", 8080);
            target.Close();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ClosedEvent_Fired_When_CloseMethod_Called()
        {
            bool result = false;
            target.Closed += new EventHandler((o, e) => { result = true; });
            target.Open(new IntelService(), "peerClassifier", 8080);
            target.Close();
            Assert.IsTrue(result);
        }
    }
}
