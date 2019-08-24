using MindboxTest.Shapes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MindboxShapes
{
    public class ShapeCalculator
    {
        private IShape _shape { get; set; }

        public ShapeCalculator(IShape shape)
        {
            _shape = shape;
        }

        public double Area()
        {
            return _shape.Area();
        }
    }
}
