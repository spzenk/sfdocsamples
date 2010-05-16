using WCFDirectHost.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace WCFDirectHostTests
{
    
    
    /// <summary>
    ///This is a test class for PeerRegistrationServiceTest and is intended
    ///to contain all PeerRegistrationServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PeerRegistrationServiceTest {

        private string peerClassifier = "peerClassifier";
        private int port = 8080;
        private PeerRegistrationService target = null;

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
        public void MyTestInitialize() {
            target = new PeerRegistrationService();
        }
        //
        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup() {
            target.Stop();
            target = null;
        }
        //
        #endregion


        /// <summary>
        ///A test for PeerUri
        ///</summary>
        [TestMethod()]
        public void PeerUri_Returns_Empty_When_Stopped() {
            Assert.AreEqual<string>(string.Empty, target.PeerUri);
        }

        [TestMethod()]
        public void PeerUri_Returns_Uri_When_Started() {
            target.Start(peerClassifier, port);
            Assert.IsNotNull(target.PeerUri);
        }

        [TestMethod]
        public void IsRegistered_Is_False_At_Creation(){
            Assert.IsFalse(target.IsRegistered);
        }

        [TestMethod]
        public void IsRegistered_Is_True_After_Start() {
            target.Start(peerClassifier,port);
            Assert.IsTrue(target.IsRegistered);
        }

        [TestMethod]
        public void IsRegistered_Is_False_After_Stop() {
            target.Start(peerClassifier, port);
            target.Stop();
            Assert.IsFalse(target.IsRegistered);
        }
    }
}
