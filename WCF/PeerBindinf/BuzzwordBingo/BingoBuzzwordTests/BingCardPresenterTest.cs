using BuzzwordBingo.Presenters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuzzwordBingo.Core;
using Moq;
using BuzzwordBingo.Interfaces;


namespace BingoBuzzwordTests
{
    
    
    /// <summary>
    ///This is a test class for BingCardPresenterTest and is intended
    ///to contain all BingCardPresenterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BingCardPresenterTest
    {
        private Mock<IBingoEvaluator> mockEvaluator;
        private Mock<IBingoCard> mockBingoCard;
        private BingoCardPresenter target;

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
            mockEvaluator = new Mock<IBingoEvaluator>();
            mockBingoCard = new Mock<IBingoCard>();
            //mockBingoCard.Setup<IBingoEvaluator>(mock => mock.BingoEvaluator).Returns(mockEvaluator.Object);
            target = new BingoCardPresenter(mockBingoCard.Object,null);
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
        ///A test for BingoCard
        ///</summary>
        [TestMethod()]
        public void BingoCardProperty_Is_Correct_BingCard()
        {
            Assert.AreEqual<IBingoCard>(mockBingoCard.Object, target.BingoCard);
        }

        [TestMethod]
        public void CheckSquareCommand_IsNotNull()
        {
            Assert.IsNotNull(target.CheckSquareCommand);
        }

        [TestMethod]
        public void CheckSquareCommand_CanExecute_Returns_True()
        {
            bool result = target.CheckSquareCommand.CanExecute(null);
        }

        [TestMethod]
        public void CheckSquareCommand_Execute_Toggles_BingoSquare_IsCheckedProperty()
        {
            BingoSquare square = new BingoSquare("Test",0);
            bool? checkedState = square.IsChecked;

            target.CheckSquareCommand.Execute(square);

            Assert.AreEqual<bool?>(!checkedState, square.IsChecked);
        }
    }
}
