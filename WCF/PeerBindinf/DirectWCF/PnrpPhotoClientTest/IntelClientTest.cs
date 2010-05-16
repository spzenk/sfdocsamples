using WCFDirectClient.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.PeerToPeer;
using System;
using System.Drawing;
using WCFDirectHost.Services;
using Moq.Stub;

namespace WCFDirectClientTest
{
    
    
    /// <summary>
    ///This is a test class for IntelServiceTest and is intended
    ///to contain all IntelServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IntelClientTest
    {
        private IntelClient target;
        private Moq.Mock<IPeerResolver> mockPeerResolution;
        private Moq.Mock<IIntelService> mockIntelService;
        //private Moq.Mock<IIntelService> mockIntelService = new Moq.Mock<IIntelService>();

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
            mockPeerResolution = new Moq.Mock<IPeerResolver>();
            mockIntelService = new Moq.Mock<IIntelService>();
            target = new IntelClient(mockPeerResolution.Object, mockIntelService.Object);
            target.Agent = "agent";
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
        ///A test for IntelService Constructor
        ///</summary>
        [TestMethod()]
        public void IntelServiceConstructorTest()
        {
            Assert.IsNotNull(target);
        }

        [TestMethod]
        public void PeerResolutionProperty_IsNotNull()
        {
            Assert.IsNotNull(target.PeerResolution);
        }

        [TestMethod]
        public void CanSet_PeerResolutionProperty()
        {
            Moq.Mock<IPeerResolver> mockNewPeer = new Moq.Mock<IPeerResolver>();
            target.PeerResolution = mockNewPeer.Object;
            Assert.AreEqual<IPeerResolver>(mockNewPeer.Object, target.PeerResolution);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Cannot_Set_Agent_ToNull()
        {
            target.Agent = null;
        }

        [TestMethod]
        public void Set_Agent_Fires_OnPropertyChanged()
        {
            bool result = false;
            target.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler((o,e) => {if (e.PropertyName=="Agent") result = true;});
            target.Agent = "test";
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Set_AgentImage_Fires_OnPropertyChanged()
        {
            bool result = false;
            target.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler((o, e) => { if (e.PropertyName == "AgentImage") result = true; });
            target.AgentImage = new Bitmap(100, 100);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void HostUriProperty_Initially_Null()
        {
            Assert.AreEqual<string>(null, target.HostUri);
        }

        [TestMethod]
        public void IsConnectedProperty_Initially_False()
        {
            Assert.IsFalse(target.IsConnected);
        }

        [TestMethod]
        public void IsConnected_IsFalse_When_Calling_Start_and_PeerResolution_Fails()
        {                  
            mockPeerResolution.Setup(mock => mock.ResolveHostName(Moq.It.IsAny<string>())).Returns<PeerNameResult>(null);
            target.Start("peerName");
            Assert.IsFalse(target.IsConnected);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Cannot_Have_Null_HostPeerName_When_Calling_Start()
        {
            target.Start(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Cannot_Have_Empty_HostPeerName_When_Calling_Start()
        {
            target.Start(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Cannot_Call_Start_Twice_Without_Calling_Stop()
        {         
            mockPeerResolution.Setup(mock => mock.ResolveHostName(Moq.It.IsAny<string>())).Returns(new PeerNameResult("localhost", 8080));
            target.Start("peerName");
            target.Start("peerName");
        }

        [TestMethod]
        public void IsConnected_IsTrue_When_Calling_Start_and_PeerResolution_Successful()
        {
            mockPeerResolution.Setup(mock => mock.ResolveHostName(Moq.It.IsAny<string>())).Returns(new PeerNameResult("localhost", 8080));         
            target.Start("peerName");
            Assert.IsTrue(target.IsConnected);
        }

        [TestMethod]
        public void IsConnectedProperty_Fires_PropertyChanged_Event_When_Start_Successful()
        {
            bool result = false;         
            target.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler((o, e) => { if (e.PropertyName == "IsConnected") result = true; });
            mockPeerResolution.Setup(mock => mock.ResolveHostName(Moq.It.IsAny<string>())).Returns(new PeerNameResult("localhost", 8080));
            target.Start("peerName");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsConnected_IsFalse_When_Start_UnSuccessful()
        {
            mockPeerResolution.Setup(mock => mock.ResolveHostName(Moq.It.IsAny<string>())).Returns<PeerNameResult>(null);
            target.Start("peerName");
            Assert.IsFalse(target.IsConnected);
        }

        [TestMethod]
        public void HostUri_Set_When_Start_Successful()
        {
            mockPeerResolution.Setup(mock => mock.ResolveHostName(Moq.It.IsAny<string>())).Returns(new PeerNameResult("localhost", 8080));
            target.Start("peerName");
            Assert.AreEqual<string>("localhost", target.HostUri);
        }

        [TestMethod]
        public void HostUriProperty_Fires_PropertyChanged_Event_When_Start_Successful()
        {
            bool result = false;
            target.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler((o,e) => { if (e.PropertyName == "HostUri") result = true; });
            mockPeerResolution.Setup(mock => mock.ResolveHostName(Moq.It.IsAny<string>())).Returns(new PeerNameResult("localhost", 8080));
            target.Start("peerName");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void HostUri_IsNull_When_Start_UnSuccessful()
        {
            mockPeerResolution.Setup(mock => mock.ResolveHostName(Moq.It.IsAny<string>())).Returns<PeerNameResult>(null);
            target.Start("peerName");
            Assert.IsNull(target.HostUri);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void HostUri_IsNull_When_Calling_Start_Fails_After_Initial_Successful_Start_Call()
        {
            mockPeerResolution.Setup(mock => mock.ResolveHostName(Moq.It.IsAny<string>())).Returns(new PeerNameResult("localhost", 8080));
            target.Start("peerName");
            mockPeerResolution.Setup(mock => mock.ResolveHostName(Moq.It.IsAny<string>())).Returns(new PeerNameResult("localhost", 8080));
            target.Start("peerName");
        }

        [TestMethod]
        public void IsConnected_IsFalse_When_Calling_Stop()
        {
            mockPeerResolution.Setup(mock => mock.ResolveHostName(Moq.It.IsAny<string>())).Returns(new PeerNameResult("localhost", 8080));
            target.Start("peerName");
            target.Stop();
            Assert.IsFalse(target.IsConnected);
        }

        [TestMethod]
        public void Can_Call_Stop_Without_First_Calling_Start()
        {
            target.Stop();
        }

        [TestMethod]
        public void HostUriProperty_IsNull_After_Calling_Stop()
        {
            mockPeerResolution.Setup(mock => mock.ResolveHostName(Moq.It.IsAny<string>())).Returns(new PeerNameResult("localhost", 8080));
            target.Start("peerName");
            target.Stop();
            Assert.IsNull(target.HostUri);
        }

        [TestMethod]
        public void IsConnectedProperty_IsFalse_After_Calling_Stop()
        {
            mockPeerResolution.Setup(mock => mock.ResolveHostName(Moq.It.IsAny<string>())).Returns(new PeerNameResult("localhost", 8080));
            target.Start("peerName");
            target.Stop();
            Assert.IsFalse(target.IsConnected);
        }


        /*[TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void Enter_Throws_ArgumentException_if_AgentProfile_IsNull()
        {
            target.Enter(null);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void Enter_Throws_ArgumentException_if_AgentProfile_Agent_IsNull()
        {
            AgentProfile profile = new AgentProfile();
            target.Enter(profile);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void Enter_Throws_ArgumentException_if_AgentProfile_Agent_IsEmpty()
        {
            AgentProfile profile = new AgentProfile();
            profile.Agent = string.Empty;
            target.Enter(profile);
        }


        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void Leave_Throws_ArgumentException_if_Agent_IsNull()
        {
            target.Leave(null);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void Leave_Throws_ArgumentException_if_Agent_IsEmpty()
        {
            target.Leave(string.Empty);
        }
        */

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void SendIntel_Throws_ArgumentException_if_IntdelData_IsNull()
        {
            target.SendIntel(null);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void SendIntel_Throws_ArgumentException_if_IntdelDataAgent_IsEmpty()
        {
            IntelData data = new IntelData() { Agent= string.Empty};
            target.SendIntel(data);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void SendIntel_Throws_ArgumentException_if_IntdelDataAgent_IsNull()
        {
            IntelData data = new IntelData() { Agent = null };
            target.SendIntel(data);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void SendIntel_Throws_ArgumentException_if_IntdelDataImage_IsNull()
        {
            IntelData data = new IntelData() { Agent = "agent", Image= null };
            target.SendIntel(data);
        }


    }
}
