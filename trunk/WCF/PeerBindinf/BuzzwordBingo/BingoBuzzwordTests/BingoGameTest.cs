using BuzzwordBingo.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using BuzzwordBingo.Interfaces;

namespace BingoBuzzwordTests
{
    
    
    /// <summary>
    ///This is a test class for BingoGameTest and is intended
    ///to contain all BingoGameTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BingoPlayerTest
    {
        private Mock<IBingoEvaluator> mockBingoEvaluator;
        private Mock<IBingoCard> mockBingoCard;
        private BingoPlayer target;

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
            target = new BingoPlayer(mockBingoEvaluator.Object,mockBingoCard.Object);
        }
        //
        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            mockBingoEvaluator = null;
            mockBingoCard = null;
            target = null;
        }
        //
        #endregion


        /// <summary>
        ///A test for BingoCard
        ///</summary>
        [TestMethod()]
        public void BingoCardProperty_IsNotNull()
        {
            Assert.IsNotNull(target.BingoCard);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BingoCardProperty_CannotBeSet_Null()
        {
            target.BingoCard = null;
        }

        [TestMethod]
        public void BingoCardProperty_CanBeSet()
        {
            Mock<IBingoCard> mockCard = new Mock<IBingoCard>();
            target.BingoCard = mockCard.Object;
            Assert.AreEqual<IBingoCard>(mockCard.Object, target.BingoCard);
        }

        [TestMethod]
        public void BingoCardProperty_Update_Throws_PropertyChangedEvent()
        {
            bool result = false;
            Mock<IBingoCard> mockCard = new Mock<IBingoCard>();
            target.PropertyChanged += ((o, e) => { if (e.PropertyName == "BingoCard") result = true; });
            target.BingoCard = mockCard.Object;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void BingoCardProperty_DoesNotThrow_PropertyChangedEvent_Without_Change()
        {
            bool result = false;
            var bingoCard = target.BingoCard;
            target.PropertyChanged += ((o, e) => { if (e.PropertyName == "BingoCard") result = true; });
            target.BingoCard = bingoCard;
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void BingoCardCheckedEvent_Causes_BingoEvaluator_CheckBingo_To_Be_Called()
        {
            mockBingoCard.Raise(mock => mock.SquareChecked += null, new SquareCheckedEventArgs(0, true));
            mockBingoEvaluator.Verify(mock => mock.CheckForBingo(mockBingoCard.Object));
        }

        [TestMethod]
        public void BingoEvent_Raised_When_BingoEvaluator_Returns_True()
        {
            bool result = false;
            target.Bingo += ((o, e) => { result = true; });
            mockBingoEvaluator.Setup(mock => mock.CheckForBingo(target.BingoCard)).Returns(true);
            mockBingoCard.Raise(mock => mock.SquareChecked += null, new SquareCheckedEventArgs(0, true));
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void BingoEvent_NotRaised_When_BingoEvaluator_Returns_False()
        {
            bool result = false;
            target.Bingo += ((o, e) => { result = true; });
            mockBingoEvaluator.Setup(mock => mock.CheckForBingo(target.BingoCard)).Returns(false);
            mockBingoCard.Raise(mock => mock.SquareChecked += null, new SquareCheckedEventArgs(0, true));
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void BingoEvent_Returns_BingoEvaluator_Buzzwords()
        {
            //string[] buzzwords = new string[] { "One", "Two", "Three", "Four", "Five" };
            //BingoEventArgs args = null;
            //target.Bingo += ((o, e) => { args = e; });
            //mockBingoEvaluator.Setup(mock => mock.CheckForBingo(target.BingoCard)).Returns(true);
            //mockBingoEvaluator.Setup(mock => mock.BingoBuzzwords).Returns(buzzwords);
            //mockBingoCard.Raise(mock => mock.SquareChecked += null, new SquareCheckedEventArgs(0, true));
            //Assert.AreEqual<string[]>(buzzwords, args.Buzzwords);
        }
    }
}
