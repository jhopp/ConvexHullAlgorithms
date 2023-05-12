using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ConvexHull.Algorithm
{
    public class GrahamScan : ConvexHullAlgorithm
    {
        public GrahamScan(List<Point> input)
        {
            points = input;
        }

        public override List<Point> ComputeConvexHull()
        {
            if (points.Count < 3)
            {
                return points;
            }

            // Sort the points from left to right
            points = points.OrderBy(p => p.X).ThenBy(p => p.Y).ToList();
            List<Point> topHull = computeTopHull();
            List<Point> bottomHull = computeBottomHull();

            // Reverse so we can combine both results
            bottomHull.Reverse();
            List<Point> convexHull = topHull.Concat(bottomHull.GetRange(1, bottomHull.Count - 2)).ToList();
            return convexHull;
        }

        private List<Point> computeTopHull()
        {
            // Add the first two points to the convex hull
            List<Point> result = new List<Point>() { points[0], points[1] };

            Vector lastLineSegment = new Vector(points[0], points[1]);

            for (int i = 2; i < points.Count; i++)
            {
                Point C = points[i];

                while (true)
                {
                    // Cross product
                    decimal cross = lastLineSegment.GetCrossProduct(new Vector(result[result.Count - 2], C));

                    // New point needs to get added because of right turn
                    if (cross < 0)
                    {
                        lastLineSegment = new Vector(result[result.Count - 1], C);
                        result.Add(C);
                        break;
                    }
                    // Left turn made, remove points until the end
                    else if (cross > 0)
                    {
                        result.RemoveAt(result.Count - 1);
                        if (result.Count == 1)
                        {
                            lastLineSegment = new Vector(result[result.Count - 1], C);
                            result.Add(C);
                            break;
                        }
                        lastLineSegment = new Vector(result[result.Count - 2], result[result.Count - 1]);
                    }
                    // The two points are on the same line
                    else
                    {
                        result.RemoveAt(result.Count - 1);
                        lastLineSegment = new Vector(result[result.Count - 1], C);
                        result.Add(C);
                        break;
                    }
                }
            }

            return result;
        }

        private List<Point> computeBottomHull()
        {
            // Add the first two points to the convex hull
            List<Point> result = new List<Point>() { points[0], points[1] };

            Vector lastLineSegment = new Vector(points[0], points[1]);

            for (int i = 2; i < points.Count; i++)
            {
                Point C = points[i];

                while (true)
                {
                    // Cross product
                    decimal cross = lastLineSegment.GetCrossProduct(new Vector(result[result.Count - 2], C));

                    // New point needs to get added because of right turn
                    if (cross > 0)
                    {
                        lastLineSegment = new Vector(result[result.Count - 1], C);
                        result.Add(C);
                        break;
                    }
                    // Left turn made, remove points until the end
                    else if (cross < 0)
                    {
                        result.RemoveAt(result.Count - 1);
                        if (result.Count == 1)
                        {
                            lastLineSegment = new Vector(result[result.Count - 1], C);
                            result.Add(C);
                            break;
                        }
                        lastLineSegment = new Vector(result[result.Count - 2], result[result.Count - 1]);
                    }
                    // The two points are on the same line
                    else
                    {
                        result.RemoveAt(result.Count - 1);
                        lastLineSegment = new Vector(result[result.Count - 1], C);
                        result.Add(C);
                        break;
                    }
                }
            }

            return result;
        }
    }
}
