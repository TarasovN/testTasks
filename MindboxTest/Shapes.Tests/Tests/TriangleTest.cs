using Microsoft.VisualStudio.TestTools.UnitTesting;
using MindboxTest.Shapes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Tests.Tests
{
    [TestClass]
    public class TriangleTest
    {
        [TestMethod]
        public void Create_TriangleWithInvalidASide_ThrowsException()
        {
            var aSide = -1;
            var bSide = 1;
            var cSide = 1;

            Assert.ThrowsException<ArgumentException>(() => new Triangle(aSide, bSide, cSide));
        }

        [TestMethod]
        public void Create_TriangleWithInvalidBSide_ThrowsException()
        {
            var aSide = 1;
            var bSide = -1;
            var cSide = 1;

            Assert.ThrowsException<ArgumentException>(() => new Triangle(aSide, bSide, cSide));
        }

        [TestMethod]
        public void Create_TriangleWithInvalidCSide_ThrowsException()
        {
            var aSide = 1;
            var bSide = 1;
            var cSide = -1;

            Assert.ThrowsException<ArgumentException>(() => new Triangle(aSide, bSide, cSide));
        }

        [TestMethod]
        public void Create_TriangleWithInvalidSideSum_ThrowsException()
        {
            var aSide = 1;
            var bSide = 1;
            var cSide = 3;

            Assert.ThrowsException<ArgumentException>(() => new Triangle(aSide, bSide, cSide));
        }

        [TestMethod]
        public void GetArea_Success()
        {
            var aSide = 3;
            var bSide = 4;
            var cSide = 5;
            var expected = 6;
            var triangle = new Triangle(aSide, bSide, cSide);

            var result = triangle.Area();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IsRightAngled_ReturnTrue_Success()
        {
            var aSide = 3;
            var bSide = 4;
            var cSide = 5;            
            var triangle = new Triangle(aSide, bSide, cSide);

            var result = triangle.IsRightAngled();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsRightAngled_ReturnFalse_Success()
        {
            var aSide = 3;
            var bSide = 4;
            var cSide = 6;
            var triangle = new Triangle(aSide, bSide, cSide);

            var result = triangle.IsRightAngled();

            Assert.IsFalse(result);
        }
    }
}
