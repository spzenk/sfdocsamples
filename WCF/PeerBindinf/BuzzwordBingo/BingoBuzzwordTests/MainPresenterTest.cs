using BuzzwordBingo.Presenters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuzzwordBingo.Core;
using Moq;
using BuzzwordBingo.Interfaces;
using System;

namespace BingoBuzzwordTests
{
    
    
    /// <summary>
    ///This is a test class for MainPresenterTest and is intended
    ///to contain all MainPresenterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MainPresenterTest
    {
        Mock<IBingoService> mockBingoService;
        Mock<IBingoCard> mockBingoCard;
        Mock<IBingoEvaluator> mockBingoEvaluator;
        BingoGamePresenter bingoGame;
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
            mockBingoEvaluator = new Mock<IBingoEvaluator>();
            mockBingoCard = new Mock<IBingoCard>();
            mockBingoService = new Mock<IBingoService>();
            bingoGame = new BingoGamePresenter(mockBingoService.Object);
            target = new MainPresenter();
        }
        //
        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            mockBingoCard = null;
            mockBingoEvaluator = null;
            bingoGame = null;
            target = null;
        }
        //
        #endregion


        //[TestMethod()]
        //public void MainPresenterConstructorTest()
        //{
        //    Assert.AreEqual<BingoGame>(bingoGame, target.BingoGame);
        //}

        //[TestMethod()]
        //public void BingoGameProperty_CanBSet()
        //{
        //    BingoPlayer newGame = new BingoPlayer(mockBingoEvaluator.Object, mockBingoCard.Object);
        //    target.BingoPlayer = newGame;
        //    Assert.AreEqual<BingoPlayer>(newGame, target.BingoPlayer);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentException))]
        //public void BingoGameProperty_CannotBeSet_Null()
        //{
        //    target.BingoPlayer = null;
        //}
    }
}
