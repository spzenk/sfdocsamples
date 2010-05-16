using WCFDirectHost.Presenters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace WCFDirectHostTests
{
    
    
    /// <summary>
    ///This is a test class for MainPresenterTest and is intended
    ///to contain all MainPresenterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MainPresenterTest
    {
        private MainPresenter target;

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
            target = new MainPresenter(null);
        }
        //
        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            target.Close();
        }
        //
        #endregion


        /// <summary>
        ///A test for MainPresenter Constructor
        ///</summary>
        [TestMethod()]
        public void MainPresenterConstructorTest()
        {
            Assert.IsNotNull(target);
        }

        [TestMethod()]
        public void ServiceProperty_IsNotNull()
        {
            Assert.IsNotNull(target.Service);
        }

        [TestMethod()]
        public void AgentStatusProperty_IsNotNull()
        {
            Assert.IsNotNull(target.AgentStatus);
        }

        [TestMethod()]
        public void ImageryProperty_IsNotNull()
        {
            Assert.IsNotNull(target.Imagery);
        }
    }
}
