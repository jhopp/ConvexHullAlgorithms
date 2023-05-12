using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvexHull.Algorithm
{
    public class JarvisMarch : ConvexHullAlgorithm
    {
        public JarvisMarch(List<Point> input)
        {
            points = input;
        }

        public override List<Point> ComputeConvexHull()
        {
            int start = GetLeftMostIndex();
            List<Point> convexHull = new List<Point>();
            convexHull.Add(points[start]);

            Point nextPoint = CalculateNextPoint(convexHull);
            convexHull.Add(nextPoint);
            nextPoint = CalculateNextPoint(convexHull);
            while (!(convexHull[0].X == nextPoint.X && convexHull[0].Y == nextPoint.Y))
            {
                convexHull.Add(nextPoint);
                nextPoint = CalculateNextPoint(convexHull);
            }
            return convexHull;
        }

        public int GetLeftMostIndex()
        {
            Point leftmostpoint = points[0];
            int index = 0;
            for(int i = 1; i<points.Count; i++)
            {
                if(points[i].X< leftmostpoint.X || (points[i].X == leftmostpoint.X && points[i].Y > leftmostpoint.Y))
                {
                    leftmostpoint = points[i];
                    index = i;
                }
            }
            return index;
        }
        public Point CalculateNextPoint(List<Point> currentHull)
        {

            Point lastPoint = currentHull[currentHull.Count - 1];
            Point nextpoint = points[1];
            //double currentMaxCross = -2;
            //  Point secondToLastPoint = new Point(lastPoint.X, lastPoint.Y-1);

            //Vector lastLineSegment = new Vector(lastPoint, secondToLastPoint);
            Vector lastLineSegment = new Vector(lastPoint, points[1]);
            for (int i =0; i < points.Count; i++)
            {
                Vector currentLineSegment = new Vector(lastPoint, points[i]);
                decimal cross = lastLineSegment.GetCrossProduct(currentLineSegment);
                if(cross > 0)
                {
                    nextpoint = points[i];
                    // currentMaxCross = cross;
                    lastLineSegment = currentLineSegment;
                }
                else if(cross == 0)
                {
                    decimal previousDistance = GetVectorSize(lastLineSegment);
                    decimal thisDistance = GetVectorSize(currentLineSegment);
                    if(thisDistance> previousDistance)
                    {
                        nextpoint = points[i];
                        lastLineSegment = currentLineSegment;
                    }
                }
            }
            return nextpoint;
        }
        public decimal GetVectorSize(Vector v)
        {
            return v.X * v.X + v.Y * v.Y;
            //return (p2.X - p1.X) * (p2.X - p1.X) + (p2.Y - p1.Y) * (p2.Y - p1.Y);
        }
    }
}
