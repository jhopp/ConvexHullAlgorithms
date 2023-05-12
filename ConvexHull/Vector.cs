using System;

namespace ConvexHull
{
    public struct Vector
    {
        public decimal X, Y;

        public Vector(Point a, Point b)
        {
            X = b.X - a.X;
            Y = b.Y - a.Y;
        }

        // https://stackoverflow.com/questions/2533011/how-to-compute-the-cross-product
        public decimal GetCrossProduct(Vector b)
        {
            return X * b.Y - Y * b.X;
        }

        public override string ToString()
        {
            return $"Vec({X}, {Y})";
        }
    }
}
