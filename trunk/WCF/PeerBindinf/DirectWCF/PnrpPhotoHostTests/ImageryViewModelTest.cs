using WCFDirectHost.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Controls;
using System;
using System.Drawing;

namespace WCFDirectHostTests
{
    
    
    /// <summary>
    ///This is a test class for ImageryViewModelTest and is intended
    ///to contain all ImageryViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ImageryViewModelTest
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
        ///A test for ImageryViewModel Constructor
        ///</summary>
        [TestMethod()]
        public void ImageryViewModelConstructor()
        {
            string agent = "agent";
            Bitmap image = new Bitmap(100,100);
            string caption = "caption";
            ImageryViewModel target = new ImageryViewModel(agent, image, caption);
            Assert.IsNotNull(target.TimeStamp);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ImageryViewModel_Cannot_Have_NullImage()
        {
            string agent = "agent";
            Bitmap image = null;
            string caption = "caption";
            ImageryViewModel target = new ImageryViewModel(agent, image, caption);
        }
    }
}
