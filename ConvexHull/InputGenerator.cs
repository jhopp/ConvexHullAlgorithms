using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvexHull
{
    public enum InputMode
    {
        RandomSquare,
        RandomCircle,
        Square,
        TwinPoints,
        Circle,
        Line,
    }

    public static class InputGenerator
    {
        public static List<Point> Generate(int nrPoints, InputMode im)
        {
            List<Point> result = new List<Point>();

            switch(im)
            {
                case InputMode.RandomSquare:
                    result = randomPoints(nrPoints);
                    break;
                case InputMode.RandomCircle:
                    result = randomCirclePoints(nrPoints);
                    break;
                case InputMode.Square:
                    result = squarePoints(nrPoints);
                    break;
                case InputMode.TwinPoints:
                    result = twinPoints(nrPoints);
                    break;
                case InputMode.Circle:
                    result = circlePoints(nrPoints);
                    break;
                case InputMode.Line:
                    throw new NotImplementedException("TODO");
            }

            // Shuffle points randomly
            Random random = new Random();
            return result.OrderBy(_ => random.Next()).ToList();
        }

        private static List<Point> randomPoints(int nrPoints)
        {
            Random random = new Random();
            List<Point> points = new List<Point>();

            for (int i = 0; i < nrPoints; i++)
            {
                // Generate x and y between 0 and 50
                double x = random.NextDouble() * 50;
                double y = random.NextDouble() * 50;

                // decimal x = random.Next(50);
                // decimal y = random.Next(50);
                points.Add(new Point(x, y));
            }

            return points;
        }

        private static List<Point> squarePoints(int nrPoints)
        {
            if (nrPoints < 4)
            {
                throw new ArgumentException("Cannot generate square with less than 4 points");
            }

            // Create structures and size of the square
            Random random = new Random();
            int squareSize = random.Next(1, 25);

            // Initialize with cornerpoints
            List<Point> points = new List<Point>() {
                new Point(25 + squareSize, 25 + squareSize),
                new Point(25 + squareSize, 25 - squareSize),
                new Point(25 - squareSize, 25 + squareSize),
                new Point(25 - squareSize, 25 - squareSize),
            };

            for (int i = 0; i < nrPoints - 4; i++)
            {
                // Determine on what side of the square to put the point
                int side = random.Next(4);

                // Offset on the line segment
                double offset = random.NextDouble() * squareSize;
                if (random.Next(2) == 0)
                {
                    offset = -offset;
                }

                // Add point to the list
                switch (side)
                {
                    case 0:
                        points.Add(new Point(25 - squareSize, 25 + offset));
                        break;
                    case 1:
                        points.Add(new Point(25 + squareSize, 25 + offset));
                        break;
                    case 2:
                        points.Add(new Point(25 + offset, 25 + squareSize));
                        break;
                    case 3:
                        points.Add(new Point(25 + offset, 25 - squareSize));
                        break;
                }
            }

            return points;
        }

        private static List<Point> twinPoints(int nrPoints)
        {
            Random random = new Random();
            List<Point> points = new List<Point>();

            for (int i = 0; i < nrPoints / 2; i++)
            {
                // Generate x and y between 0 and 50
                double x = random.NextDouble() * 50;
                double y = random.NextDouble() * 50;

                // double x = random.Next(50);
                // double y = random.Next(50);
                points.Add(new Point(x, y));
                points.Add(new Point(x, y));
            }

            return points;
        }

        private static List<Point> circlePoints(int nrPoints)
        {
            // Create structures and size of the square
            Random random = new Random();
            int circleRadius = random.Next(1, 25);
            double deltaAngle = 360d / nrPoints;
            List<Point> points = new List<Point>();

            for (int i = 0; i < nrPoints; i++)
            {
                double x = 25 + Math.Cos(i * deltaAngle) * circleRadius;
                double y = 25 + Math.Sin(i * deltaAngle) * circleRadius;

                points.Add(new Point(x, y));
            }

            return points;
        }

        // https://programming.guide/random-point-within-circle.html
        private static List<Point> randomCirclePoints(int nrPoints)
        {
            Random random = new Random();
            List<Point> points = new List<Point>();

            for (int i = 0; i < nrPoints; i++)
            {
                double a = random.NextDouble() * 2 * Math.PI;
                double r = 25 * Math.Sqrt(random.NextDouble());

                double x = 25 + r * Math.Cos(a);
                double y = 25 + r * Math.Sin(a);

                points.Add(new Point(x, y));
            }

            return points;
        }

        private static List<Point> linePoints(int nrPoints)
        {
            throw new NotImplementedException();

        }
    }
}
