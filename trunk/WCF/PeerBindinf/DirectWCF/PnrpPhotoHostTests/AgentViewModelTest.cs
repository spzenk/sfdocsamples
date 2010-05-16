using WCFDirectHost.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WCFDirectHost.Services;
using System;

namespace WCFDirectHostTests
{
    
    
    /// <summary>
    ///This is a test class for AgentViewModelTest and is intended
    ///to contain all AgentViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AgentViewModelTest
    {

        
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
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for IsOnline
        ///</summary>
        ///
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Throw_Excpetion_With_NullAgentProfile()
        {
            AgentViewModel target = new AgentViewModel(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Throw_Exception_With_EmpyAgent_In_AgentProfile()
        {
            AgentProfile profile = new AgentProfile(string.Empty);
            AgentViewModel target = new AgentViewModel(profile);
        }

        [TestMethod()]
        public void IsOnline_IsFalse_At_Creation()
        {
            AgentProfile agentProfile = new AgentProfile("agent");
            AgentViewModel target = new AgentViewModel(agentProfile);
            Assert.IsFalse(target.IsOnline);
        }

        [TestMethod]
        public void Image_IsNotNull_When_AgentProfileImage_IsNull()
        {
            AgentProfile agentProfile = new AgentProfile("agent");
            AgentViewModel target = new AgentViewModel(agentProfile);
            Assert.IsNotNull(target.Image);
        }

        [TestMethod]
        public void IsOnline_Can_Be_Set()
        {
            AgentProfile agentProfile = new AgentProfile("agent");
            AgentViewModel target = new AgentViewModel(agentProfile);
            target.IsOnline = true;
            Assert.IsTrue(target.IsOnline);
        }

        [TestMethod]
        public void PropertyChangedEvent_When_IsOnline_Updated()
        {
            bool result = false;
            AgentProfile agentProfile = new AgentProfile("agent");
            AgentViewModel target = new AgentViewModel(agentProfile);
            target.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler((o,e) => { if (e.PropertyName.Equals("IsOnline")) result = true; });
            target.IsOnline = true;
            Assert.IsTrue(result);
        }

        
    }
}
