using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvexHull
{
    public struct Point
    {
        public decimal X, Y;

        public Point(decimal x, decimal y)
        {
            X = x;
            Y = y;
        }

        public Point(double x, double y)
        {
            X = (decimal)x;
            Y = (decimal)y;
        }

        public Point(float x, float y)
        {
            X = (decimal)x;
            Y = (decimal)y;
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        // Sees if AB is left of AC or right
        public decimal GetCrossProduct(Point B, Point C)
        {
            return (B.X - X) * (C.Y - Y) -
                (C.X - X) * (B.Y - Y);
        }

        // C is below B
        public bool Above(Point B, Point C)
        {
            return GetCrossProduct(B, C) > 0;
        }

        // B is below C
        public bool Below(Point B, Point C)
        {
            return GetCrossProduct(B, C) < 0;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
