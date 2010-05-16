using WCFDirectClient.Presenters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using WCFDirectClient.Services;
using WCFDirectHost.Services;
namespace WCFDirectClientTest
{
    
    
    /// <summary>
    ///This is a test class for IntelDataPresenterTest and is intended
    ///to contain all IntelDataPresenterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IntelDataPresenterTest
    {

        private IntelDataPresenter target;
        private Moq.Mock<IIntelClient> mockIntelClient;

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
            target = new IntelDataPresenter(mockIntelClient.Object);
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


        [TestMethod()]
        public void Caption_Default_IsNull()
        {
            Assert.IsNull(target.Caption);
        }

        [TestMethod()]
        public void Caption_Can_Be_Set()
        {
            string caption = "caption";
            target.Caption = caption;
            Assert.AreEqual<string>(caption, target.Caption);
        }

        [TestMethod()]
        public void Image_Can_Be_Set()
        {
            Bitmap image = new Bitmap(100, 100);
            target.RawImage = image;
            Assert.AreEqual<Bitmap>(image, target.RawImage);
        }

        [TestMethod]
        public void OnAgentChanged_Sets_AgentProperty()
        {
            string agent = "agent";
            target.OnAgentChanged(null, new AgentChangedEventArgs() { Agent = agent });
            Assert.AreEqual<string>(agent, target.Agent);
        }


        [TestMethod]
        public void SendCommand_CanExecute_IsFalse_When_IntelClientConnnected_IsFalse()
        {
            mockIntelClient.Setup(mock => mock.IsConnected).Returns(false);
            Assert.IsFalse(target.SendCommand.CanExecute(null));
        }

        [TestMethod]
        public void SendCommand_CanExecute_IsTrue_When_IntelClientConnected()
        {
            mockIntelClient.Setup(mock => mock.IsConnected).Returns(true);
            Assert.IsTrue(target.SendCommand.CanExecute(null));
        }

        [TestMethod]
        public void SendCommand_Execute_Calls_IntelClient_SendIntel()
        {
         
            target.SendCommand.Execute(null);
            mockIntelClient.Verify(mock => mock.SendIntel(Moq.It.IsAny<IntelData>()));
        }
    }
}
