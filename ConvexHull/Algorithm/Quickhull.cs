using System;
using System.Collections.Generic;

namespace ConvexHull.Algorithm
{
    public class Quickhull : ConvexHullAlgorithm
    {
        public Quickhull(List<Point> input)
        {
            points = input;
        }

        // Computes the convex hull of a set of points:
        //  find the line segment ab which divides the points into two
        //  find the point furthest away from ab for both sets
        //  the found points c are part of the convex hull
        //  points within triangle abc are not part of the convex hull
        //  repeat for ac and cb
        public override List<Point> ComputeConvexHull()
        {
            // find point with min x and max x
            Point a = points[0];
            Point b = points[0];
            foreach (Point p in points)
            {
                if (p.X < a.X || (p.X == a.X && p.Y < a.Y))
                    a = p; // if X is equal then lower Y takes priority
                else if (p.X > b.X || (p.X == b.X && p.Y > b.Y))
                    b = p; // if X is equal then higher Y takes priority
            }

            // split points set into left of line segment ab and right of it
            List<Point> left = new List<Point>();
            List<Point> right = new List<Point>();

            foreach (Point p in points)
            {
                decimal cross = a.GetCrossProduct(b, p);
                // above
                if (cross > 0)
                    left.Add(p);
                else if (cross < 0)
                    right.Add(p);
            }

            List<Point> convexHull = new List<Point>();
            // compute hull for left and right sets
            if (left.Count == 0) convexHull.Add(a);
            else convexHull.AddRange(FindHull(left, a, b));

            if (right.Count == 0) convexHull.Add(b);
            else convexHull.AddRange(FindHull(right, b, a));

            return convexHull;
        }

        // Recursively computes convex hull of set of points
        public List<Point> FindHull(List<Point> points, Point a, Point b)
        {
            // split set
            List<Point> left = new List<Point>();
            List<Point> right = new List<Point>();

            List<Point> result = new List<Point>();

            Point c = FurthestPoint(a, b, points);

            foreach (Point p in points)
                if (a.Above(c, p))
                    left.Add(p);
                else if (c.Above(b, p))
                    right.Add(p);

            // compute convex hull for both sets
            if (left.Count > 0) result.AddRange(FindHull(left, a, c));
            else if (left.Count == 0) result.Add(a); // if the set was empty, this part is done and we add the left endpoint a
            if (right.Count > 0) result.AddRange(FindHull(right, c, b));
            else if(right.Count == 0) result.Add(c); // if the set was empty, this part is done and we add the left endpoint c

            return result;
        }

        // Returns a point from points which is furthest from line segment ab
        static public Point FurthestPoint(Point a, Point b, List<Point> points)
        {
            if (points.Count == 0) throw new Exception();

            Point c = points[0], cPrime = new Point(c.X - (b.X - a.X), c.Y - (b.Y - a.Y));

            for (int i = 1; i < points.Count; i++)
            {
                decimal crossProduct = cPrime.GetCrossProduct(c, points[i]);
                if (crossProduct < 0)
                {
                    continue;
                }
                else if (crossProduct > 0) {
                    c = points[i];
                    cPrime = new Point(c.X - (b.X - a.X), c.Y - (b.Y - a.Y));
                }
                // Deal with trilinear points (same distance from segment $ab$ by only remembering the corner points)
                else if (points[i].X < c.X)
                {
                    c = points[i];
                    cPrime = new Point(c.X - (b.X - a.X), c.Y - (b.Y - a.Y));
                }
            }
            return c;
        }
    }
}
