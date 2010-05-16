using BuzzwordBingo.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace BingoBuzzwordTests
{
    
    
    /// <summary>
    ///This is a test class for BingoSquareTest and is intended
    ///to contain all BingoSquareTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BingoSquareTest
    {
        int squarePosition = 0;
        string buzzword = "buzzword";
        BingoSquare target;
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
            target = new BingoSquare(buzzword,squarePosition);
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
        ///A test for Buzzword
        ///</summary>
        [TestMethod()]
        public void BuzzwordConstructorTest()
        {
            Assert.IsNotNull(target);
        }

        [TestMethod]
        public void BuzzwordProperty_Set_Via_Constructor()
        {
            Assert.AreEqual<string>(buzzword, target.Buzzword);
        }

        [TestMethod]
        public void BuzzwordProperty_CanBe_Set()
        {
            target.Buzzword = "test";
            Assert.AreEqual<string>("test", target.Buzzword);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BuzzwordProperty_Throws_ArgumentException_OnEmpty()
        {
            target.Buzzword = string.Empty;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BuzzwordProperty_Throws_ArgumentException_OnNull()
        {
            target.Buzzword = null;
        }

        [TestMethod]
        public void BuzzwordPropertyChanged_Fires_PropertyChangedEvent()
        {
            bool result = false;
            target.PropertyChanged += ((o,e) => { if (e.PropertyName == "Buzzword") result = true; });
            target.Buzzword = "change";
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void BuzzwordPropertyNoChange_DoesNot_Fires_PropertyChangedEvent()
        {
            bool result = false;
            string text = target.Buzzword;
            target.PropertyChanged += ((o, e) => { if (e.PropertyName == "Buzzword") result = true; });
            target.Buzzword = text;
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void PositionProperty_Returns_ConstructorValue()
        {
            Assert.AreEqual<int>(squarePosition, target.Position);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PositionProperty_CannotBe_Set_Out_of_Range_LessThanZero()
        {
            target.Position = -1;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PositionProperty_CannotBe_Set_Out_of_Range_GreaterThanMax()
        {
            target.Position = 25;
        }

        [TestMethod]
        public void IsCheckedProperty_Initially_IsFalse()
        {
            Assert.IsFalse((bool)target.IsChecked);
        }

        [TestMethod]
        public void IsCheckedProperty_CanBe_Set()
        {
            target.IsChecked = true;
            Assert.IsTrue((bool)target.IsChecked);
        }

        [TestMethod]
        public void IsCheckedPropertyChanged_Fires_PropertyChangedEvent()
        {
            bool result = false;
            target.PropertyChanged += ((o, e) => { if (e.PropertyName == "IsChecked") result = true; });
            target.IsChecked = !target.IsChecked;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsCheckedPropertyNoChange_DoesNot_Fire_PropertyChangedEvent()
        {
            bool result = false;
            target.PropertyChanged += ((o, e) => { if (e.PropertyName == "IsChecked") result = true; });
            target.IsChecked = target.IsChecked;
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckChangedPropertyChange_Fires_CheckChangedEvent()
        {
            bool result = false;
            target.CheckChanged += ((o, e) => { result = true; });
            target.IsChecked = !target.IsChecked;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckChangedPropertyNoChange_DoesNot_Fire_CheckChangedEvent()
        {
            bool result = false;
            target.CheckChanged += ((o, e) => { result = true; });
            target.IsChecked = target.IsChecked;
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckChangedEvent_Contains_BingoSquare()
        {
            bool result = false;
            target.CheckChanged += ((o, e) => { if (o.Equals(target)) result = true; });
            target.IsChecked = !target.IsChecked;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckChangedEvent_Contains_BingoSquare_Position()
        {
            SquareCheckedEventArgs args = null;
            target.CheckChanged += ((o, e) => { args = e; });
            target.IsChecked = !target.IsChecked;
            Assert.AreEqual<int>(target.Position, args.Square);
        }

        [TestMethod]
        public void CheckChangedEvent_Contains_BingoSquare_State()
        {
            SquareCheckedEventArgs args = null;
            target.CheckChanged += ((o, e) => { args = e; });
            target.IsChecked = !target.IsChecked;
            Assert.AreEqual<bool?>(target.IsChecked, args.IsChecked);
        }
    }
}
