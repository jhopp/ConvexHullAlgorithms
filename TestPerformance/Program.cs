using System;
using System.Collections.Generic;
using System.Diagnostics;
using ConvexHull;
using ConvexHull.Algorithm;

namespace TestPerformance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("(JarvisMarch/Quickhull/GrahamScan) nrTests nrPoints (RandomSquare/Square/TwinPoints/RandomCircle/Circle/Line)");
            Console.WriteLine("Example: JarvisMarch 10 10 RandomSquare");
            Console.WriteLine("Leave empty to exit");

            string[] userInput = Console.ReadLine().Split();

            while (userInput.Length != 0)
            {
                (int nrTests, int nrPoints, InputMode inputMode, ConvexHullAlgorithm cha) = parseArguments(userInput);
                List<Point>[] inputs = generateInputs(nrTests, nrPoints, inputMode);
                runTests(cha, inputs);
                userInput = Console.ReadLine().Split();
            }
        }

        static (int, int, InputMode, ConvexHullAlgorithm) parseArguments(string[] userInput)
        {
            int nrTests = int.Parse(userInput[1]);
            int nrPoints = int.Parse(userInput[2]);
            InputMode inputMode = default;
            switch (userInput[3].ToLower())
            {
                case "randomsquare":
                    inputMode = InputMode.RandomSquare;
                    break;
                case "randomcircle":
                    inputMode = InputMode.RandomCircle;
                    break;
                case "square":
                    inputMode = InputMode.Square;
                    break;
                case "twinpoints":
                    inputMode = InputMode.TwinPoints;
                    break;
                case "circle":
                    inputMode = InputMode.Circle;
                    break;
                case "line":
                    inputMode = InputMode.Line;
                    break;
                default:
                    throw new ArgumentException($"InputMode '{userInput[2].ToLower()}' does not exist");
            }
            ConvexHullAlgorithm cha;
            switch (userInput[0].ToLower())
            {
                case "grahamscan":
                    cha = new GrahamScan(default);
                    break;
                case "jarvismarch":
                    cha = new JarvisMarch(default);
                    break;
                case "quickhull":
                    cha = new Quickhull(default);
                    break;
                default:
                    throw new ArgumentException($"Algorithm '{userInput[3]}' does not exist");
            }
            return (nrTests, nrPoints, inputMode, cha);
        }

        static void runTests(ConvexHullAlgorithm cha, List<Point>[] inputs)
        {
            double totalPoints = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < inputs.Length; i++)
            {
                cha.points = inputs[i];
                totalPoints += cha.ComputeConvexHull().Count;
            }

            sw.Stop();
            Console.WriteLine($"Runtime (ms): {sw.ElapsedMilliseconds}, Average points in Hull: {totalPoints / inputs.Length}");
        }

        static List<Point>[] generateInputs(int nrTests, int nrPoints, InputMode inputMode)
        {
            List<Point>[] inputs = new List<Point>[nrTests];
            for (int i = 0; i < nrTests; i++)
            {
                inputs[i] = InputGenerator.Generate(nrPoints, inputMode);
            }

            return inputs;
        }
    }
}
