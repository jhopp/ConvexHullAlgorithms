using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvexHull.Algorithm
{
    public abstract class ConvexHullAlgorithm
    {
        public List<Point> points = new List<Point>();

        public abstract List<Point> ComputeConvexHull();
    }
}
