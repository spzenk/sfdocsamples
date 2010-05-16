using WCFDirectClient.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.PeerToPeer;
using System;
namespace WCFDirectClientTest
{
    
    
    /// <summary>
    ///This is a test class for PeerResolverServiceTest and is intended
    ///to contain all PeerResolverServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PeerResolverServiceTest
    {

        private PeerResolverService target; 

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
        //    //PeerName peerName = new PeerName("testpeer", PeerNameType.Unsecured);
        //    //registration = new PeerNameRegistration(peerName, 8080);
        //    //registration.Start();
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
            target = new PeerResolverService();
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

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Cannot_Pass_Null_HostPeerName()
        {
            target.ResolveHostName(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Cannot_Pass_Empty_HostPeerName()
        {
            target.ResolveHostName(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(PeerToPeerException))]
        public void Throw_Exception_When_No_HostPeerName_Found()
        {
            target.ResolveHostName("hostpeername");
        }

        // This method requires setting up a NETSH PNRP registration in the command window
        // C:\NETSH P2P PNRP PEER>add registration 0.hostpeername
        [TestMethod]
        public void HostPeerName_Found()
        {
            // This method requires setting up a NETSH PNRP registration in the command window
            // C:\NETSH P2P PNRP PEER>add registration 0.hostpeername
            PeerNameResult result = target.ResolveHostName("hostpeername");
            Assert.IsNotNull(result);
        }
        
    }
}
