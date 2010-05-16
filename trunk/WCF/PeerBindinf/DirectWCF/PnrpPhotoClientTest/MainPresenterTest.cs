using WCFDirectClient.Presenters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WCFDirectClient.Services;

namespace WCFDirectClientTest
{
    
    
    /// <summary>
    ///This is a test class for MainPresenterTest and is intended
    ///to contain all MainPresenterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MainPresenterTest
    {
        Moq.Mock<IIntelClient> mockIntelClient;
        MainPresenter target;
        

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
            target = new MainPresenter(mockIntelClient.Object);
        }
        //
        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            mockIntelClient = null;
            target = null;
        }
        //
        #endregion


        /// <summary>
        ///A test for MainPresenter Constructor
        ///</summary>
        [TestMethod()]
        public void MainPresenter_Service_IsNotNull()
        {
            Assert.IsNotNull(target.Service);
        }

        [TestMethod()]
        public void MainPresenter_IntelData_IsNotNull()
        {
            Assert.IsNotNull(target.IntelData);
        }
    }
}
