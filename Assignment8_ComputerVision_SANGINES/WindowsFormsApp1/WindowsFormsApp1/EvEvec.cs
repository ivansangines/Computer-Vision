using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class EvEvec:ICloneable, IComparable
    {
        public double EigenValue; // Eigen value
        public double[] EigenVec; // Eigen Vector Array
        public int size; // Size of Eigen Vector array

        public EvEvec()
        {
        }

        public EvEvec(double Ev, double[] Evc, int sz)
        {
            EigenVec = new double[sz];
            EigenValue = Ev;
            size = sz;
            for (int i = 0; i < sz; i++)
                EigenVec[i] = Evc[i];
            // EVecs are already normalized i.e., magnitude of 1
        }
        public int CompareTo(Object obj) // for sorting
        {
            EvEvec evv = (EvEvec)obj; 
            return evv.EigenValue.CompareTo(this.EigenValue); // highest to lowest sorting by Eigen value
        }
        public object Clone() // for making a copy of the EvEvec object
        {
            EvEvec clone = new EvEvec();
            clone.EigenValue = this.EigenValue;
            if (this.EigenVec != null)
                clone.EigenVec = (double[])this.EigenVec.Clone();
            clone.size = this.size;
            return clone;
        }
    }
}
