using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{   
    //An EigenFace is one of the vectors after we reduce the dimensionality  
    class EigenFace:ICloneable
    {
        public double[] EF;
        public int size;
        public double[] Xvar2;
        public double EigenValue;

        public EigenFace()
        {
        }
        public EigenFace(int sz)
        {
            EF = new double[sz];
            Xvar2 = new Double[sz];
            size = sz;
        }
        public object Clone() // for in memory copy
        {
            EigenFace copy = new EigenFace();
            if (this.EF != null)
                copy.EF = (double[])this.EF.Clone();
            copy.EigenValue = this.EigenValue;
            copy.size = this.size;
            if (this.Xvar2 != null)
                copy.Xvar2 = (double[])this.Xvar2.Clone();
            return copy;
        }

    }
}
