using WCFDirectHost.Presenters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WCFDirectHost.ViewModels;
using System.Windows.Controls;
using WCFDirectHost.Services;
using System.Drawing;
namespace WCFDirectHostTests
{
    
    
    /// <summary>
    ///This is a test class for ImageryPresenterTest and is intended
    ///to contain all ImageryPresenterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ImageryPresenterTest
    {
        private ImageryPresenter target;

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
            target =  new ImageryPresenter();
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
        ///A test for ImageryPresenter Constructor
        ///</summary>
        [TestMethod()]
        public void ImageryPresenterConstructorTest()
        {
            Assert.IsNotNull(target);
        }

        [TestMethod()]
        public void ImageryCollection_IsNotNull()
        {
            Assert.IsNotNull(target.Imagery);
        }

        [TestMethod()]
        public void OnImageryReceivedEvent_Adds_ImageryViewModel_To_ImageryCollection()
        {
            target.OnImageryReceived(null, new IntelEventArgs(new IntelData("agent", new Bitmap(100,100),"caption")));
            Assert.IsTrue(target.Imagery.Count == 1);
        }
    }
}
