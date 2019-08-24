using Microsoft.VisualStudio.TestTools.UnitTesting;
using MindboxTest.Shapes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Tests.Tests
{
    [TestClass]
    public class CircleTest
    {
        [TestMethod]
        public void Create_CircleWithInvalidRadius_ThrowsException()
        {
            var radius = -1;            

            Assert.ThrowsException<ArgumentException>(() => new Circle(radius));
        }

        [TestMethod]
        public void GetArea_Success()
        {
            var radius = 2;
            var expected = 12.5664;
            var circle = new Circle(radius);

            var result = circle.Area();

            Assert.AreEqual(expected, Math.Round(result,4));
        }
    }
}
