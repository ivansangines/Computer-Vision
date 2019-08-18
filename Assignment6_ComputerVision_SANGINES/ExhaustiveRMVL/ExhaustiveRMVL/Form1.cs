using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExhaustiveRMVL
{
    public partial class Form1 : Form
    {
        List<Point> Shape1 = new List<Point>();
        List<Point> Shape2 = new List<Point>();
        List<Point> Shape2Transformed = new List<Point>();
        List<Point> Shape1Transformed = new List<Point>();
        Transformation T;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Shape1.Clear();
            Shape2.Clear();
            
            Point p1a = new Point(20, 30);
            Point p2a = new Point(120, 50);
            Point p3a = new Point(160, 80);
            Point p4a = new Point(180, 300);
            Point p5a = new Point(100, 220);
            Point p6a = new Point(50, 280);
            Point p7a = new Point(20, 140);
            Shape1.Add(p1a);
            Shape1.Add(p2a);
            Shape1.Add(p3a);
            Shape1.Add(p4a);
            Shape1.Add(p5a);
            Shape1.Add(p6a);
            Shape1.Add(p7a);
            Transformation T2 = new Transformation();
            T2.A = 1.05; T2.B = 0.05; T2.T1 = 15; T2.T2 = 22;
            Shape2 = ApplyTransformation(T2, Shape1);
            Shape2[2] = new Point(Shape2[2].X + 10, Shape2[2].Y + 3);// change one point
                                                                     // add outliers to both shapes
            Point ptOutlier1 = new Point(200, 230);
            Shape1.Add(ptOutlier1);
            Point ptOutLier2 = new Point(270, 160);
            Shape2.Add(ptOutLier2);
            Pen pBlue = new Pen(Brushes.Blue, 1);
            Pen pRed = new Pen(Brushes.Red, 1);
            Graphics g = panel1.CreateGraphics();
            DisplayShape(Shape1, pBlue, g);
            DisplayShape(Shape2, pRed, g);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            T = ICPTransformation.ComputeTransformation(Shape1, Shape2);
            List<Point> Shape2T = ApplyTransformation(T, Shape2);
            Pen pBlue = new Pen(Brushes.Blue, 1);
            Pen pRed = new Pen(Brushes.Red, 1);
            Graphics g = panel2.CreateGraphics();
            DisplayShape(Shape1, pBlue, g);
            DisplayShape(Shape2T, pRed, g);
            MessageBox.Show("Cost = " + ICPTransformation.ComputeCost(Shape1, Shape2, T).ToString());

        }

        void DisplayShape(List<Point> Shp, Pen pen, Graphics g)
        {
            Point? prevPoint = null; // nullable
            foreach (Point pt in Shp)
            {
                g.DrawEllipse(pen, new Rectangle(pt.X - 2, pt.Y - 2, 4, 4));
                if (prevPoint != null)
                    g.DrawLine(pen, (Point)prevPoint, pt);
                prevPoint = pt;
            }
            g.DrawLine(pen, Shp[0], Shp[Shp.Count - 1]);
        }
        List<Point> ApplyTransformation(Transformation T, List<Point> shpList)
        {
            List<Point> TList = new List<Point>();
            foreach (Point pt in shpList)
            {
                double xprime = T.A * pt.X + T.B * pt.Y + T.T1;
                double yprime = T.B * pt.X * -1 + T.A * pt.Y + T.T2;
                Point pTrans = new Point((int)xprime, (int)yprime);
                TList.Add(pTrans);
            }
            return TList;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double[] cost = new double[Shape1.Count];

            for (int i=0; i<Shape1.Count; i++)
            {
                double xprime = T.A * Shape2[i].X + T.B * Shape2[i].Y + T.T1;
                double yprime = -1 * T.B * Shape2[i].X + T.A * Shape2[i].Y + T.T2;
                cost[i] = (Shape1[i].X - xprime) * (Shape1[i].X - xprime) + (Shape1[i].Y - yprime) * (Shape1[i].Y - yprime);
            }

            
            int count = (int)(Shape1.Count * 0.8) + 1;
            int[] index = new int[count];

            for (int j = 0; j < count; j++)//remove 20% of the points with the largest errors
            {
                double min = cost.Min();
                index[j] = cost.ToList().IndexOf(min);
                cost[index[j]] = cost.Max();
            }

            //Sort the indexes in order to NOT show a random shape
            Array.Sort(index);
            for (int i = 0; i < index.Length; i++)
            {
                Shape1Transformed.Add(Shape1[index[i]]);
                Shape2Transformed.Add(Shape2[index[i]]);

            }
            Transformation T2 = ICPTransformation.ComputeTransformation(Shape1Transformed, Shape2Transformed);
            List<Point> Shape2T = this.ApplyTransformation(T2, Shape2Transformed);
            Pen pBlue = new Pen(Brushes.Blue, 1);
            Pen pRed = new Pen(Brushes.Red, 1);
            Graphics g = panel3.CreateGraphics();
            DisplayShape(Shape1Transformed, pBlue, g);
            DisplayShape(Shape2T, pRed, g);
            MessageBox.Show("Cost = " + ICPTransformation.ComputeCost(Shape1Transformed, Shape2Transformed, T2).ToString());
        }
    }
}
