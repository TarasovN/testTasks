using System;
using System.Collections.Generic;
using System.Text;

namespace MindboxTest.Shapes
{
    public class Triangle : IShape
    {
        public double ASide { get; private set; }
        public double BSide { get; private set; }
        public double CSide { get; private set; }

        public Triangle(double aSide, double bSide, double cSide)
        {
            if (!IsSidesValid(aSide, bSide, cSide))
            {
                throw new ArgumentException("Sides of triangle must be greater than zero and any sum of two should be greater than third");
            }

            ASide = aSide;
            BSide = bSide;
            CSide = cSide;
        }

        private bool IsSidesValid(double aSide, double bSide, double cSide)
        {
            return SidesGreaterThanZero(aSide, bSide, cSide) && TwoSidesGreaterThanThird(aSide, bSide, cSide);
        }    
        
        private bool SidesGreaterThanZero(double aSide, double bSide, double cSide)
        {
            return aSide > 0 && bSide > 0 && cSide > 0;
        }

        private bool TwoSidesGreaterThanThird(double aSide, double bSide, double cSide)
        {
            return aSide + bSide > cSide && aSide + cSide > bSide && bSide + cSide > aSide;
        }

        public double Area()
        {
            var p = (ASide + BSide + CSide) / 2;
            return Math.Sqrt(p * (p - ASide) * (p - BSide) * (p - CSide));
        }

        public bool IsRightAngled()
        {
            double a, b, c;

            var sideArray = new double[3]{ ASide, BSide, CSide};
            Array.Sort(sideArray);

            a = sideArray[0];
            b = sideArray[1];
            c = sideArray[2];

            return Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2);

        }
    }
}
