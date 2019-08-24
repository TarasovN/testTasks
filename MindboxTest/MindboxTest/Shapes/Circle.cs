using System;
using System.Collections.Generic;
using System.Text;

namespace MindboxTest.Shapes
{
    public class Circle : IShape
    {
        public double Radius { get; private set; }

        public Circle(double radius)
        {
            if(radius <= 0)
            {
                throw new ArgumentException("Radius of square must be greater than zero");
            }

            Radius = radius;
        }

        public double Area()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
}
