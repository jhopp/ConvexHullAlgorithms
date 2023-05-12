using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConvexHull;

namespace DisplayConvexHull
{
    internal static class InputSaver
    {
        public static List<Point> ImportFile()
        {
            List<Point> input = new List<Point>();
            OpenFileDialog s = new OpenFileDialog();

            // Filter files by extension
            s.Filter = "Text (.txt)|*.txt";
            s.RestoreDirectory = true;

            //
            if (s.ShowDialog() == DialogResult.OK)
            {
                string filename = s.FileName;

                using (StreamReader file = new StreamReader(filename))
                {
                    string line = file.ReadLine();
                    while (line != "" && line != null)
                    {
                        string[] coordinate = line.Split(';');
                        double x = double.Parse(coordinate[0]);
                        double y = double.Parse(coordinate[1]);

                        input.Add(new Point(x,y));
                        line = file.ReadLine();
                    }

                    file.Close();
                }
            }

            return input;
        }

        public static void ExportToFile(List<Point> input, List<Point> convexHull)
        {
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "Text (.txt)|*.txt"; // Filter files by extension
            s.RestoreDirectory = true;

            if (s.ShowDialog() == DialogResult.OK)
            {
                // Save Image
                string filename = s.FileName;

                using (StreamWriter file = new StreamWriter(filename))
                {
                    foreach (Point p in input)
                    {
                        file.WriteLine(p.X + "; " + p.Y);
                    }
                    file.WriteLine();
                    for (int i = 0; i < convexHull.Count; i++)
                    {
                        file.WriteLine(i + ": " + convexHull[i].X + ", " + convexHull[i].Y);
                    }
                    file.Close();
                }
            }
        }
    }
}
