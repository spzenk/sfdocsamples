using WCFDirectHost.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Controls;
using System;
using System.Drawing;
namespace WCFDirectHostTests
{
    
    
    /// <summary>
    ///This is a test class for IntelEventArgsTest and is intended
    ///to contain all IntelEventArgsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IntelEventArgsTest
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
        ///A test for IntelEventArgs Constructor
        ///</summary>
        [TestMethod()]
        public void ConstructorTest_With_ValidAgent_and_EventType()
        {
            string agent = "agent";
            IntelEventType eventType = IntelEventType.AgentEnter;
            IntelEventArgs target = new IntelEventArgs(new AgentProfile(agent));
            Assert.AreEqual<string>(agent, target.AgentProfile.Agent);
            Assert.AreEqual<IntelEventType>(eventType, target.EventType);
        }

        /// <summary>
        ///A test for IntelEventArgs Constructor
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorTest_With_EmptyAgent_and_EventType()
        {
            string agent = string.Empty;
            IntelEventArgs target = new IntelEventArgs(new AgentProfile(agent));
        }

        /// <summary>
        ///A test for IntelEventArgs Constructor
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorTest_With_NullAgent_and_EventType()
        {
            string agent = null;
            IntelEventArgs target = new IntelEventArgs(new AgentProfile (agent ));
        }

        [TestMethod()]
        public void ConstructorTest_With_ValidAgent_and_Image()
        {
            string agent = "agent";
            Bitmap image = new Bitmap(100, 100);
            string caption = "caption";
            IntelEventArgs target = new IntelEventArgs(new IntelData(agent,image,caption));
            Assert.AreEqual<string>(agent, target.AgentProfile.Agent);
            Assert.AreEqual<Bitmap>(image, target.Image);
            Assert.AreEqual<string>(caption, target.Caption);
            Assert.AreEqual<IntelEventType>(IntelEventType.IntelReceived, target.EventType);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorTest_With_EmptyAgent_and_Image()
        {
            string agent = string.Empty;
            Bitmap image = new Bitmap(100, 100);
            string caption = "caption";
            IntelEventArgs target = new IntelEventArgs(new IntelData(agent, image, caption));     
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorTest_With_NullAgent_and_Image()
        {
            string agent = null ;
            Bitmap image = new Bitmap(100, 100);
            string caption = "caption";
            IntelEventArgs target = new IntelEventArgs(new IntelData(agent, image, caption));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorTest_With_ValidAgent_and_NullImage()
        {
            string agent = "agent";
            Bitmap image = null;
            string caption = "caption";
            IntelEventArgs target = new IntelEventArgs(new IntelData(agent, image, caption));
        }
    }
}
