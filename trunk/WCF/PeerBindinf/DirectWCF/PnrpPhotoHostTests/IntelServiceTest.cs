using WCFDirectHost.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Controls;
using System.Drawing;
namespace WCFDirectHostTests
{
    
    
    /// <summary>
    ///This is a test class for IntelServiceTest and is intended
    ///to contain all IntelServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IntelServiceTest
    {
        private IntelService _target;

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
            _target = new IntelService();
        }
        
        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            _target = null;
        }
        //
        #endregion


        /// <summary>
        ///A test for Enter
        ///</summary>
        [TestMethod()]
        public void Enter_Fires_AgentStatusChangeEvent()
        {
            string agent = "agent";
            bool result = false;
            _target.AgentStatusChanged += new System.EventHandler<IntelEventArgs>((o, e) => { result = true; });
            _target.Enter(new AgentProfile(agent));
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void Enter_AgentStatusChangeEvent_Returns_Correct_IntelEventArg()
        {
            string agent = "agent";
            IntelEventArgs args = null;
            _target.AgentStatusChanged += new System.EventHandler<IntelEventArgs>((o, e) => { args = e; });
            _target.Enter(new AgentProfile(agent));

            Assert.AreEqual<string>(agent, args.AgentProfile.Agent);
            Assert.AreEqual<IntelEventType>(IntelEventType.AgentEnter, args.EventType);
        }

        [TestMethod]
        public void Enter_AgentStatusChangeEvent_DoesNotFire_On_NullAgentProfile() {
            bool result = false;
            _target.AgentStatusChanged += new System.EventHandler<IntelEventArgs>((o, e) => { result = true; });
            _target.Enter(null);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Enter_AgentStatusChangeEvent_DoesNotFire_On_EmptyAgentString() {
            bool result = false;
            _target.AgentStatusChanged += new System.EventHandler<IntelEventArgs>((o, e) => { result = true; });
            _target.Enter(new AgentProfile(string.Empty));
            Assert.IsFalse(result);
        }
       

        [TestMethod()]
        public void SendItel_Fires_IntelReceivedEvent()
        {
            string agent = "agent";
            string caption = "caption";
            Bitmap image = new Bitmap(100, 100);

            bool result = false;
            _target.IntelReceived += new System.EventHandler<IntelEventArgs>((o, e) => { result = true; });
            IntelData data = new IntelData(agent,image,caption);
            _target.SendIntel(data);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void SendItel_IntelReceivedEvent_Returns_Correct_IntelEventArg()
        {

            string agent = "agent";
            string caption = "caption";
            Bitmap image = new Bitmap(100, 100);

            IntelEventArgs args = null;
            _target.IntelReceived += new System.EventHandler<IntelEventArgs>((o, e) => { args = e; });
            IntelData data = new IntelData(agent, image, caption);
            _target.SendIntel(data);

            Assert.AreEqual<string>(agent, args.AgentProfile.Agent);
            Assert.AreEqual<Bitmap>(image, args.Image);
            Assert.AreEqual<string>(caption, args.Caption);
            Assert.AreEqual<IntelEventType>(IntelEventType.IntelReceived, args.EventType);
        }

        [TestMethod()]
        public void Leave_Fires_AgentStatusChangeEvent()
        {
            bool result = false;
            _target.AgentStatusChanged += new System.EventHandler<IntelEventArgs>((o, e) => { result = true; });
            _target.Leave("agent");
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void Leave_AgentStatusChangeEvent_Returns_Correct_IntelEventArg()
        {
            string agent = "agent";
            IntelEventArgs args = null;
            _target.AgentStatusChanged += new System.EventHandler<IntelEventArgs>((o, e) => { args = e; });
            _target.Leave(agent);

            Assert.AreEqual<string>(agent, args.AgentProfile.Agent);
            Assert.AreEqual<IntelEventType>(IntelEventType.AgentLeave, args.EventType);
        }

        [TestMethod]
        public void Leave_With_EmptyAgent_Does_Not_Fire_AgentStatusChangeEvent() {
            string agent = string.Empty;
            bool result = false;
            _target.AgentStatusChanged += new System.EventHandler<IntelEventArgs>((o, e) => { result = true; });
            _target.Leave(agent);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Leave_With_NullAgent_Does_Not_Fire_AgentStatusChangeEvent() {
            string agent = null;
            bool result = false;
            _target.AgentStatusChanged += new System.EventHandler<IntelEventArgs>((o, e) => { result = true; });
            _target.Leave(agent);
            Assert.IsFalse(result);
        }
    }
}
