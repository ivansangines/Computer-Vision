using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSAC
{
    class Ransac_Algo
    {
        public Transformation best_model { get; set; }
        public List<Point> best_consensus1 { get; set; }
        public List<Point> best_consensus2 { get; set; }
        public double best_error { get; set; }
    }
}
