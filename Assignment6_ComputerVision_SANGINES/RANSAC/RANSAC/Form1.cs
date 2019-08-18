using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RANSAC
{
    public partial class Form1 : Form
    {
        List<Point> Shape1 = new List<Point>();
        List<Point> Shape2 = new List<Point>();
        List<Point> Shape2Transformed = new List<Point>();
        Ransac_Algo ransac = new Ransac_Algo();

        public Form1()
        {
            InitializeComponent();
        }

        private void initialize_btn_Click(object sender, EventArgs e)
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
            Graphics g = original_panel.CreateGraphics();
            DisplayShape(Shape1, pBlue, g);
            DisplayShape(Shape2, pRed, g);

        }

        private void transformation_btn_Click(object sender, EventArgs e)
        {
            Transformation T = ICPTransformation.ComputeTransformation(Shape1, Shape2);
            
            List<Point> Shape2T = ApplyTransformation(T, Shape2);
            Pen pBlue = new Pen(Brushes.Blue, 1);
            Pen pRed = new Pen(Brushes.Red, 1);
            Graphics g = transformed_panel.CreateGraphics();
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
                double yprime = T.B * pt.X * (-1) + T.A * pt.Y + T.T2;
                Point pTrans = new Point((int)xprime, (int)yprime);
                TList.Add(pTrans);
            }
            return TList;
        }

        private void ransac_btn_Click(object sender, EventArgs e)
        {

            ransac = ApplyRansac();
            //we need to sort the points, otherwise we will get a random figure
            List<Point> sorted1 = new List<Point>();
            List<Point> sorted2 = new List<Point>();
            for (int j = 0; j < Shape1.Count; j++)
            {
                if (ransac.best_consensus1.Contains(Shape1[j]))
                {
                    sorted1.Add(Shape1[j]);
                    sorted2.Add(Shape2[j]);
                }
            }

            List<Point> new_Shape2 = ApplyTransformation(ransac.best_model, sorted2);
            Pen pBlue = new Pen(Brushes.Blue, 1);
            Pen pRed = new Pen(Brushes.Red, 1);
            Graphics g = ransac_panel.CreateGraphics();
            DisplayShape(sorted1, pBlue, g);
            DisplayShape(new_Shape2, pRed, g);
            MessageBox.Show("Cost = " + ransac.best_error);

        }

        Ransac_Algo ApplyRansac()
        {
            Ransac_Algo rans = new Ransac_Algo();
            int k = 20; //iterations for the algorithm
            int t = 7; //treshold to determine if we accept the new point or not, if it adds less than 7 to the cost it is valid
            int n = 3; //number of initial random point
            int d = 4; //minimum data points to accept the model as valid

            int iterations = 0; //counter of iterations done
            /*
            Transformation best_model = new Transformation();
            List<Point> best_consensus_set1 = new List<Point>();
            List<Point> best_consensus_set2 = new List<Point>();
            Ransac_Algo rans = new Ransac_Algo();
            */
            
            double best_error = int.MaxValue;
            Random rand = new Random(); //used to select random indexes


            while (iterations < k)
            {
                List<int> random_index = new List<int>(); //list that will contain random indexes from shapes
                List<Point> maybe_inliners1 = new List<Point>();
                List<Point> maybe_inliners2 = new List<Point>();
                Transformation maybe_model = new Transformation();
                double maybe_cost = 0; //cost from the random points

                //selecting random points (using indexes) from data
                for (int i = 0; i < n; i++)
                {
                    int index = rand.Next(Shape1.Count);
                    while (random_index.Contains(index))
                    {
                        index = rand.Next(Shape1.Count);
                    }
                    random_index.Add(index);
                    maybe_inliners1.Add(Shape1[index]);
                    maybe_inliners2.Add(Shape2[index]);

                }

                maybe_model = ICPTransformation.ComputeTransformation(maybe_inliners1, maybe_inliners2); //computing model for random chosen points
                maybe_cost = ICPTransformation.ComputeCost(maybe_inliners1, maybe_inliners2, maybe_model); //computing cost for random chosen points
                List<Point> consensus_set1 = new List<Point>(maybe_inliners1);
                List<Point> consensus_set2 = new List<Point>(maybe_inliners2);

                for (int i = 0; i < Shape1.Count; i++)
                {
                    if (!random_index.Contains(i))
                    {
                        maybe_inliners1.Add(Shape1[i]);
                        maybe_inliners2.Add(Shape2[i]);
                        consensus_set1.Add(Shape1[i]);
                        consensus_set2.Add(Shape2[i]);
                        Transformation temp_model = ICPTransformation.ComputeTransformation(consensus_set1, consensus_set2);
                        double temp_cost = ICPTransformation.ComputeCost(consensus_set1, consensus_set2, temp_model);
                        double dif = Math.Abs(maybe_cost - temp_cost);
                        if (dif >= t)
                        {
                            consensus_set1.RemoveAt(consensus_set1.Count - 1);
                            consensus_set2.RemoveAt(consensus_set2.Count - 1);
                            
                        }

                    }
                }

                if (consensus_set1.Count > d) //checking if consensus has enough points to make the model valid
                {
                    Transformation better_model = ICPTransformation.ComputeTransformation(consensus_set1, consensus_set2);
                    double this_error = ICPTransformation.ComputeCost(consensus_set1, consensus_set2, better_model);
                    

                    if (this_error < best_error)
                    {
                        best_error = this_error;
                        rans.best_model = better_model;
                        rans.best_consensus1 = consensus_set1;
                        rans.best_consensus2 = consensus_set2;
                        rans.best_error = this_error;
                    }
                }

                iterations++;
            }
            return rans;
        }
    }
}
