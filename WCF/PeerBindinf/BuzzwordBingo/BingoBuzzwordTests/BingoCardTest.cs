using BuzzwordBingo.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Moq;
using System;
namespace BingoBuzzwordTests
{
    
    
    /// <summary>
    ///This is a test class for BingoCardTest and is intended
    ///to contain all BingoCardTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BingoCardTest
    {
        string[] buzzwords = new string[24] {"One","Two","Three","Four","Five",
                                                 "Six","Seven","Eight","Nine","Ten",
                                                 "Eleven","Twelve","Thirteen", "Fourteen","Fifteen",
                                                 "Sixteen","Seventeen","Eighteen","Nineteen","Twenty",
                                                 "TwentyOne","TwentyTwo","TwentyThree","TwentyFour"};

        //private Mock<IBingoEvaluator> mockEvaluator;
        private BingoCard target;

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
            //mockEvaluator = new Mock<IBingoEvaluator>();
            //target = new BuzzwordBingoCard(mockEvaluator.Object);
            target = new BingoCard();
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
        ///A test for BingoCard Constructor
        ///</summary>
        [TestMethod()]
        public void BingoCardConstructor_Succesful()
        {
            Assert.IsNotNull(target);
        }

        [TestMethod]
        public void SquaresProperty_IsNotNull()
        {
            Assert.IsNotNull(target.Squares);
        }

        [TestMethod]
        public void SquaresProperty_CenterSquareText_Equals_Bingo()
        {
            Assert.AreEqual<string>("BINGO", target.Squares[12].Buzzword.ToUpper());
        }

        //[TestMethod]
        //public void IsBingoProperty_Initally_IsFalse()
        //{
        //    Assert.IsFalse(target.IsBingo);
        //}

        //[TestMethod]
        //public void BingoEvaluatorProperty_IsNotNull()
        //{
        //    Assert.IsNotNull(target.BingoEvaluator);
        //}

        //[TestMethod]
        //public void ChangeBingoSquare_IsChecked_Runs_Evaluator()
        //{
        //    target.Squares[0].IsChecked = true;
        //    mockEvaluator.Verify(mock => mock.CheckForBingo(target));
        //}

        //[TestMethod]
        //public void IsBingo_SetTrue_When_BingoEvaluator_Returns_True()
        //{
        //    mockEvaluator.Setup<bool>(mock => mock.CheckForBingo(target)).Returns(true);
        //    target.Squares[0].IsChecked = true;
        //    Assert.IsTrue(target.IsBingo);
        //}

        //[TestMethod]
        //public void IsBingo_SetTrue_Fires_BingoEvent()
        //{
        //    bool result = false;
        //    mockEvaluator.Setup<bool>(mock => mock.CheckForBingo(target)).Returns(true);
        //    target.Bingo +=new EventHandler<BingoEventArgs>((o,e) => { result = true; });
        //    target.Squares[0].IsChecked = true;
        //    Assert.IsTrue(result);
        //}

        //[TestMethod]
        //public void BingoEvent_Contains_CorrectBuzzwords()
        //{
        //    bool result = false;
        //    string[] buzzwords = new string[] { "One", "Two", "Three", "Four", "Five" };
        //    mockEvaluator.Setup<bool>(mock => mock.CheckForBingo(target)).Returns(true);
        //    mockEvaluator.Setup<string[]>(mock => mock.BingoBuzzwords).Returns(buzzwords);
        //    target.Bingo += new EventHandler<BingoEventArgs>((o, e) => { if (buzzwords.Equals(e.Buzzwords)) result = true; });
            
        //    target.Squares[0].IsChecked = true;
        //    Assert.IsTrue(result);
        //}

        //[TestMethod]
        //public void BingoEvent_Contains_CorrectPattern()
        //{
        //    bool result = false;
        //    bool[] pattern = new bool[] { true, true, false, true };
        //    mockEvaluator.Setup<bool>(mock => mock.CheckForBingo(target)).Returns(true);
        //    mockEvaluator.Setup<bool[]>(mock => mock.Pattern).Returns(pattern);
        //    target.Bingo += new EventHandler<BingoEventArgs>((o, e) => { if (pattern.Equals(e.Pattern)) result = true; });

        //    target.Squares[0].IsChecked = true;
        //    Assert.IsTrue(result);
        //}

        //[TestMethod]
        //public void BingoEvalutor_Returns_True_IsBingo_Fires_PropertyChanged()
        //{
        //    bool result = false;
        //    mockEvaluator.Setup<bool>(mock => mock.CheckForBingo(target)).Returns(true);
        //    target.PropertyChanged += ((o, e) => { if (e.PropertyName == "IsBingo") result = true; });
        //    target.Squares[0].IsChecked = true;
        //    Assert.IsTrue(result);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentException))]
        //public void BingoEvaluator_CannotBe_Set_Null()
        //{
        //    target.BingoEvaluator = null;
        //}

        [TestMethod]
        public void BuildCard_Updates_BingoSquares_Buzzword()
        {
            
            target.BuildCard(buzzwords);

            int emptySquares = (from square in target.Squares where string.IsNullOrEmpty(square.Buzzword) select square).Count();

            Assert.IsFalse(emptySquares > 0);
        }

        [TestMethod]
        public void BuildCard_Updates_BingoSquares_Position()
        {

            target.BuildCard(buzzwords);

            int emptySquares = (from square in target.Squares where square.Position == -1 select square).Count();

            Assert.IsFalse(emptySquares > 0);
        }

        [TestMethod]
        public void BuildCard_DoesNot_Update_BingoSquare()
        {
           
            target.BuildCard(buzzwords);
            Assert.AreEqual<string>("BINGO", target.Squares[12].Buzzword.ToUpper());
        }

        [TestMethod]
        public void BuildCard_Sets_All_SquaresIsChecked_False()
        {
            target.Squares[0].IsChecked = true;
            target.BuildCard(buzzwords);
            int checkedSquares = (from square in target.Squares where (bool)square.IsChecked select square).Count();

            Assert.IsTrue(checkedSquares == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BuildCard_Throws_Exception_OnNull_Argument()
        {
            target.BuildCard(null);
        }

        [TestMethod]
        public void Clear_Sets_All_Squares_IsChecked_False()
        {
            Random rnd = new Random();
            target.Squares[rnd.Next(24)].IsChecked = true;
            target.Clear();
            int checkedSquares = (from square in target.Squares where (bool) square.IsChecked select square).Count();

            Assert.IsTrue(checkedSquares == 0);
        }

        [TestMethod]
        public void ToggleSquareMethod_Toggles_SquareIsChecked()
        {
            bool oldState = (bool) target.Squares[0].IsChecked;
            target.ToggleSquare(0);
            Assert.AreEqual<bool?>(!oldState, target.Squares[0].IsChecked);
        }

        [TestMethod]
        public void CheckSquareMethod_Sets_Square_IsChecked()
        {
            int square = 0;
            target.CheckSquare(square,false);
            Assert.IsFalse((bool)target.Squares[square].IsChecked);
        }

        [TestMethod]
        public void SquareCheckChangedEvent_Fires_Card_SquareCheckedEvent()
        {
            bool result = false;
            target.SquareChecked += ((o, e) => { result = true; });
            target.Squares[0].IsChecked = !target.Squares[0].IsChecked;
            Assert.IsTrue(result);
        }

    }
}
