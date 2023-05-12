using System;
using System.Collections.Generic;
using ConvexHull.Algorithm;

namespace ConvexHull
{
    public class Program
    {
        public Program()
        {
            List<Point> input = InputGenerator.Generate(10, InputMode.RandomSquare);
            ConvexHullAlgorithm gs = new GrahamScan(input);
            List<Point> convexHull = gs.ComputeConvexHull();
            printList(convexHull);

            Console.WriteLine();

            Quickhull qh = new Quickhull(input);
            List<Point> convexHull2 = qh.ComputeConvexHull();
            printList(convexHull2);
        }

        static void Main(string[] args)
        {
            new Program();
        }

        private void printList(List<Point> result)
        {
            for (int i = 0; i < result.Count; i++)
            {
                Console.Write(result[i] + " ");
            }
        }
    }
}
