using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistogramEqualization
{
    class MyImageProc
    {
        public static int[,] Histogram = new int[256,3];
        //Converting image to gray scale
        public static bool ConvertToGray(Bitmap b)
        {
            for(int col = 0; col<b.Width; col++)
            {
                for(int row=0; row<b.Height; row++)
                {
                    Color c = b.GetPixel(col, row);
                    int red = c.R;
                    int green = c.G;
                    int blue = c.B;
                    int gray = (byte)(.299 * red + .557 * green + .114 * blue);

                    red = gray;
                    green = gray;
                    blue = gray;
                    b.SetPixel(col, row, Color.FromArgb(red, green, blue));
                }
            }

            return true;
        }

        //
        public static void CreateHistogram(Bitmap b)
        {
            //int[] allPixels = new int[b.Width * b.Height];
            
            //Setting array deffault values to 0
            for (int row=0; row<256; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Histogram[row, col] = 0;
                }
            }

            //Pixel Count
            for (int i = 0; i < b.Height; i++)
            {
                for (int j = 0; j < b.Width; j++)
                {
                    Color c = b.GetPixel(j, i);
                    int pValue = Convert.ToInt32(c.R); //Since it is in grey scale, we can get any pixel R,G or B
                    Histogram[pValue, 0] += 1; //counting how many pixels of each value
                }
            }
            
            int ind = 0; 

            //computing the cdf (adding previous + current)
            Histogram[0, 1] = Histogram[0, 0];
            for (int i = 1; i<256; i++)
            {
                if (Histogram[i, 0] != 0) //checking if the pixel exists in the bitmap
                {
                    Histogram[i, 1] = Histogram[ind, 1] + Histogram[i, 0]; //using histogram at [i,0] because all the [i,1] at 0 at the begining
                    ind = i; //keeping track of the last non 0 index
                }
            }

            //Computing h (using given formula)
            int cdfMin = 0;
            int pixel = 0; //will be used to loop through the array to find first non-zero value
            while (cdfMin == 0)
            {
                cdfMin = Histogram[pixel, 1];
                pixel++;
            }

            int totalPixels = b.Width * b.Height;
            for (int i=0; i<256; i++)
            {
                if(Histogram[i,1] !=0)
                    Histogram[i,2]= (int)(((Histogram[i, 1] - cdfMin) * 255.0 / (totalPixels - cdfMin)));
            }

            ApplyHistogram(b);

        }

        public static void ApplyHistogram(Bitmap b)
        {
            for (int col = 0; col < b.Width; col++)
            {
                for(int row=0; row<b.Height; row++)
                {
                    Color c = b.GetPixel(col, row);
                    int pix = Convert.ToInt32(c.R);
                    b.SetPixel(col, row, Color.FromArgb(Histogram[pix, 2], Histogram[pix, 2], Histogram[pix, 2]));
                }
            }
        }
    }
}
