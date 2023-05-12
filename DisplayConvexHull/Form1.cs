using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConvexHull;
using ConvexHull.Algorithm;

namespace DisplayConvexHull
{
    public partial class ConvexHullForm : Form
    {
        List<ConvexHull.Point> points = new List<ConvexHull.Point>();
        List<ConvexHull.Point> convexHullPoints = new List<ConvexHull.Point>();

        public ConvexHullForm()
        {
            InitializeComponent();
            comboBox1.DataSource = Enum.GetValues(typeof(InputMode));
            algorithmComboBox.SelectedText = "Quickhull";
            algorithmComboBox.SelectedItem = "Quickhull";
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            int width = pictureBox.Width;
            int height = pictureBox.Height;

            decimal dx = width / (decimal)50;
            decimal dy = height / (decimal)50;

            // Draw all points in black
            for (int i = 0; i < points.Count; i++)
            {
                ConvexHull.Point p = points[i];
                e.Graphics.FillEllipse(
                    new SolidBrush(Color.Black),
                    (int)(p.X * dx), pictureBox.Height - (int)(p.Y * dy), 4, 4);
            }

            // Draw all points that are part of the convex hull red
            for (int i = 0; i < convexHullPoints.Count; i++)
            {
                ConvexHull.Point p = convexHullPoints[i];
                e.Graphics.FillEllipse(
                    new SolidBrush(Color.Red),
                    (int)(p.X * dx), pictureBox.Height - (int)(p.Y * dy), 4, 4);
                e.Graphics.DrawString(
                    i.ToString(), new Font("Tahoma", 8), new SolidBrush(Color.Black),
                    (int)(p.X * dx), pictureBox.Height - (int)(p.Y * dy));
            }

            // Draw lines between the points of the convex hull
            for (int i = 0; i < convexHullPoints.Count - 1; i++)
            {
                ConvexHull.Point p = convexHullPoints[i];
                ConvexHull.Point q = convexHullPoints[i+1];
                e.Graphics.DrawLine(
                    new Pen(Color.Red, 2f),
                    (int)(p.X * dx), pictureBox.Height - (int)(p.Y * dy),
                    (int)(q.X * dx), pictureBox.Height - (int)(q.Y * dy));
            }

            // Draw last line segment
            if (convexHullPoints.Count > 1)
            {
                ConvexHull.Point p = convexHullPoints[convexHullPoints.Count - 1];
                ConvexHull.Point q = convexHullPoints[0];

                e.Graphics.DrawLine(
                    new Pen(Color.Red, 2f),
                    (int)(p.X * dx), pictureBox.Height - (int)(p.Y * dy),
                    (int)(q.X * dx), pictureBox.Height - (int)(q.Y * dy));
            }
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            InputMode im = (InputMode)comboBox1.SelectedItem;
            int nrPoints = (int)numericUpDown1.Value;
            points.Clear();
            points = InputGenerator.Generate(nrPoints, im);

            // Calculate convex hull
            calculateConvexHull();

            // Redraw
            pictureBox.Invalidate();
        }

        private void calculateConvexHull()
        {
            ConvexHullAlgorithm cha;
            switch (algorithmComboBox.SelectedItem)
            {
                case "GrahamScan":
                    cha = new GrahamScan(points);
                    break;
                case "JarvisMarch":
                    cha = new JarvisMarch(points);
                    break;
                case "Quickhull":
                    cha = new Quickhull(points);
                    break;
                default:
                    throw new NotImplementedException();
            }

            // ConvexHull algorithm
            convexHullPoints = cha.ComputeConvexHull();

            NrPointsLabel.Text = "NrPoints: " + points.Count;
            HullPointsLabel.Text = "HullPoints: " + convexHullPoints.Count();
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            InputSaver.ExportToFile(points, convexHullPoints);
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            points = InputSaver.ImportFile();

            // There is nothing to calculate
            if (points.Count < 1)
            {
                return;
            }

            calculateConvexHull();
            pictureBox.Invalidate();
        }
    }
}
