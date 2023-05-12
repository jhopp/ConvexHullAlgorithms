using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvexHull.Algorithm
{
    public class ChanAlgorithm : ConvexHullAlgorithm
    {
        public ChanAlgorithm(List<Point> input)
        {
            points = input;
        }

        public override List<Point> ComputeConvexHull()
        {
            Point p1 = leftMostPoint();
            Point prev = new Point(0, -1);
            for (int t = 1; t < Math.Ceiling(Math.Log(Math.Log(points.Count))); t++)
            {
                int m = 2 * (int)Math.Pow(2, Math.Pow(2, t));
                List<Point> result = new List<Point> { p1 };
                int K = (int)Math.Ceiling(points.Count / (float)m);
                List<Point>[] subHulls = computeConvexHulls(K, m);

                for (int i = 0; i < m; i++)
                {
                    List<Point> q = new List<Point>();
                    for (int k = 0; k < K; k++)
                    {
                        q.Add(leftTangent_PointPolyC(result[i], subHulls[k]));
                    }

                    Point next = getBiggestAngle(result[i], prev, q);

                    if (next.Equals(p1))
                    {
                        return result;
                    }

                    prev = next;
                    result.Add(next);
                }
            }
            return null;
        }

        private Point getBiggestAngle(Point a, Point b, List<Point> Q)
        {
            Point q = Q[0];
            for (int i = 1; i < Q.Count; i++)
            {
                decimal notOver180 = a.GetCrossProduct(b, Q[i]);
                // Not more than 180 degree
                if (notOver180 < 0)
                {
                    continue;
                }

                // See if the relative angle is positive
                decimal relativeDot = a.GetCrossProduct(q, Q[i]);
                if (relativeDot > 0)
                {
                    q = Q[i];
                }
            }

            return q;
        }

        private List<Point>[] computeConvexHulls(int K, int m)
        {
            int remainder;
            int div = Math.DivRem(points.Count, K, out remainder);

            List<Point>[] subHulls = new List<Point>[K];

            int startIndex = 0;
            // List is already shuffled, arbitrarily choosing equals just picking portions of the points
            for (int k = 0; k < K; k++)
            {
                int numberItems = k < div ? div : div + 1;
                GrahamScan gs = new GrahamScan(points.GetRange(startIndex, numberItems));
                subHulls[k] = gs.ComputeConvexHull();
                startIndex += numberItems;
            }

            return subHulls;
        }

        // https://geomalgorithms.com/a15-_tangents.html
        // Ltangent_PointPolyC(): binary search for left tangent to polygon
        //    Input:  P = a 2D point (exterior to the polygon)
        //            n = number of polygon vertices
        //            V = array of vertices for polygon with V[n]=V[0]
        //    Return: index "i" of leftmost tangent point V[i]
        private Point leftTangent_PointPolyC(Point P, List<Point> convexHull)
        {
            // use binary search for large convex polygons
            int a, b, c;        // indices for edge chain endpoints
            bool dnA, dnC;       // test down direction of edges a and c
            int n = convexHull.Count;
            // leftmost tangent = minimum for the isLeft() ordering
            // test if V[0] is a local minimum
            if (P.Above(convexHull[n - 1], convexHull[0]) && !P.Below(convexHull[1], convexHull[0]))
                return convexHull[0];           // V[0] is the minimum tangent point

            for (a = 0, b = n; ;)
            {
                // start chain = [0,n] with V[n] = V[0]
                c = (a + b) / 2;    // midpoint of [a,b], and 0<c<n
                if (c+1 == n)
                {
                    dnC = P.Below(convexHull[0], convexHull[c]);
                }
                else
                {
                    dnC = P.Below(convexHull[c + 1], convexHull[c]);
                }
                if (P.Above(convexHull[c - 1], convexHull[c]) && !dnC)
                    return convexHull[c];       // V[c] is the minimum tangent point

                // no min yet, so continue with the binary search
                // pick one of the two subchains [a,c] or [c,b]
                if (a+1==n)
                {
                    dnA = P.Below(convexHull[0], convexHull[a]);
                }
                else
                {
                    dnA = P.Below(convexHull[a + 1], convexHull[a]);
                }

                if (dnA)
                {                       // edge a points down
                    if (!dnC)                        // edge c points up
                        b = c;                           // select [a,c]
                    // edge c points down
                    else if (P.Below(convexHull[a], convexHull[c]))     // V[a] below V[c]
                        b = c;                       // select [a,c]
                    else                          // V[a] above V[c]
                        a = c;                       // select [c,b]
                }
                else
                {
                    // edge a points up
                    if (dnC)                         // edge c points down
                        a = c;                           // select [c,b]
                    // edge c points up
                    else if (P.Above(convexHull[a], convexHull[c]))     // V[a] above V[c]
                        b = c;                       // select [a,c]
                    else                          // V[a] below V[c]
                        a = c;                       // select [c,b]
                }
            }
        }

        // private List<Point>

        private Point leftMostPoint()
        {
            Point p = points[0];

            for (int i = 1; i < points.Count; i++)
            {
                if (points[i].X > p.X)
                {
                    continue;
                }
                else if (points[i].X < p.X)
                {
                    p = points[i];
                }
                else if (points[i].Y < p.Y)
                {
                    p = points[i];
                }
            }

            return p;
        }

        /*private int[] subDivision(int m, int k, int n)
        {
            // k=7 m=8 n=50
        }*/
    }
}
