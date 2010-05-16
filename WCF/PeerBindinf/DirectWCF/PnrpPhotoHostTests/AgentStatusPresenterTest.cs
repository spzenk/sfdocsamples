using WCFDirectHost.Presenters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WCFDirectHost.Services;
using WCFDirectHost.ViewModels;

namespace WCFDirectHostTests
{
    
    
    /// <summary>
    ///This is a test class for AgentStatusPresenterTest and is intended
    ///to contain all AgentStatusPresenterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AgentStatusPresenterTest
    {
        AgentStatusPresenter target = null;

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
            target = new AgentStatusPresenter();
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
        public void AgentStatusPresenterConstructorTest()
        {
            Assert.IsNotNull(target);
        }

        [TestMethod]
        public void AgentEnters_Adds_AgentViewModel_To_AgentCollectionProperty()
        {
            target.OnAgentStatusChanged(null, new IntelEventArgs(new AgentProfile("agent")));
            Assert.IsTrue(target.Agents.Count == 1);
        }

        [TestMethod]
        public void AgentEnters_Adds_AgentViewModel_To_AgentCollectionProperty_With_IsOnline_True()
        {
            target.OnAgentStatusChanged(null, new IntelEventArgs(new AgentProfile("agent")));
            Assert.IsTrue(target.Agents[0].IsOnline);
        }

        [TestMethod]
        public void AgentLeave_Sets_IsOnline_False()
        {
            target.OnAgentStatusChanged(null, new IntelEventArgs(new AgentProfile("agent")));
            target.OnAgentStatusChanged(null, new IntelEventArgs("agent"));
            Assert.IsFalse(target.Agents[0].IsOnline);
        }

        [TestMethod]
        public void OfflineAgents_Removed_When_AgentEnters()
        {
            target.OnAgentStatusChanged(null, new IntelEventArgs(new AgentProfile("agent")));
            target.OnAgentStatusChanged(null, new IntelEventArgs("agent"));
            target.OnAgentStatusChanged(null, new IntelEventArgs(new AgentProfile("newagent")));
            Assert.IsTrue(target.Agents.Count == 1);
        }


    }
}
