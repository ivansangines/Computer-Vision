using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WindowsFormsApp1.MyEnums;

namespace WindowsFormsApp1
{
    class MatchResult:ICloneable, IComparable
    {
        public double Correlation;
        public double EucledianDist;
        public MyImage mImage;
        public int ImageNum;
        public string ImageName;
        public MatchResult(int Imnum, double err, MyImage img)
        {
            ImageNum = Imnum;
            if (img.FileNameShort.Length > 10)
                ImageName = img.FileNameShort.Substring(img.FileNameShort.Length - 10,
                9);
            else
                ImageName = img.FileNameShort;
            mImage = img;
            if (img.ImgCompareMode == ImgComparison.CORRELATION)
                Correlation = err;
            else
                EucledianDist = err;
        }

        public int CompareTo(Object rhs) // for sorting
        {
            MatchResult mr = (MatchResult)rhs;
            if (mImage.ImgCompareMode == ImgComparison.CORRELATION)
                return mr.Correlation.CompareTo(this.Correlation); // high corr is best
            else
                return this.EucledianDist.CompareTo(mr.EucledianDist); // low dist isbest
        }
        
        public object Clone()
        {
            MatchResult clone = new MatchResult(0, 0, null);
            clone.Correlation = this.Correlation;
            clone.mImage = (MyImage)this.mImage.Clone();
            return clone;
        }

       

    }
}
