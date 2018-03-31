using Microsoft.VisualStudio.TestTools.UnitTesting;
using _3_tests;
using System;

namespace test {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void IsSquare () {
            //arrange
            Program3.Rectangle rec = new Program3.Rectangle( new Program3.Point( 0, 0 ), new Program3.Point( 0, 1 ), new Program3.Point( 1, 1 ), new Program3.Point( 1, 0 ) );
            //act
            bool expected = true;
            bool actual = rec.IsASquare();
            //assert
            Assert.AreEqual( expected, actual );
        }
        [TestMethod]
        public void IsRectangle () {
            //arrange
            Program3.Rectangle rec = new Program3.Rectangle( new Program3.Point( 0, 0 ), new Program3.Point( 0, 6 ), new Program3.Point( 2, 6 ), new Program3.Point( 2, 0 ) );
            //act
            bool expected = true;
            bool actual = rec.IsARectangle();
            //assert
            Assert.AreEqual( expected, actual );
        }
        [TestMethod]
        [ExpectedException( typeof( ArgumentException ) )]
        public void DictanceInSquare () {
            //arrange
            Program3.Rectangle rec = new Program3.Rectangle( new Program3.Point( 0, 0 ), new Program3.Point( 0, 0 ), new Program3.Point( 2, 0 ), new Program3.Point( 2, 0 ) );
            //act
            double expected = 8;
            double actual = rec.Perimeter();
            //Assert          
            Assert.AreEqual( expected, actual );
        }
    }
}
