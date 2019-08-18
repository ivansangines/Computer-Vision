using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsApp1.MyEnums;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int NumberOfEigenFaces = 100; // 100 most significant EigenVctors
        int width = 92;
        int height = 112;
        FaceRecogByEF ef = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_EF_Click(object sender, EventArgs e)
        {
            ef = new FaceRecogByEF(width, height, width * height, NumberOfEigenFaces);
            ef.ComputeEFs(ImgComparison.CORRELATION, @"C:\Users\ivans_000\Desktop\MASTER\Spring2019\Computer Vision\Assignment8_ComputerVision_SANGINES\ATTFaceDataSet\Training");
            // show average image
            double[] avgData = new double[ef.AvgImage.ImgVector.Length];
            for (int i = 0; i < avgData.Length; i++)
                avgData[i] = ef.AvgImage.ImgVector[i];
            NormalizeDataAndShowFace(avgData, width, height, picAvg);

            // show top five Eigen Faces
            double[] eData0 = new double[((EigenFace)ef.EigenFaceList[0]).EF.Length];
            for (int i = 0; i < eData0.Length; i++)
                eData0[i] = ((EigenFace)ef.EigenFaceList[0]).EF[i];
            NormalizeDataAndShowFace(eData0, width, height, picEF1);
            double[] eData1 = new double[((EigenFace)ef.EigenFaceList[1]).EF.Length];
            for (int i = 0; i < eData1.Length; i++)
                eData1[i] = ((EigenFace)ef.EigenFaceList[1]).EF[i];//+ef.AvgImg.ImgVector[i]);
            NormalizeDataAndShowFace(eData1, width, height, picEF2);
            double[] eData2 = new double[((EigenFace)ef.EigenFaceList[2]).EF.Length];
            for (int i = 0; i < eData2.Length; i++)
                eData2[i] = ((EigenFace)ef.EigenFaceList[2]).EF[i];//+ef.AvgImg.ImgVector[i]);
            NormalizeDataAndShowFace(eData2, width, height, picEF3);
            double[] eData3 = new double[((EigenFace)ef.EigenFaceList[3]).EF.Length];
            for (int i = 0; i < eData3.Length; i++)
                eData3[i] = ((EigenFace)ef.EigenFaceList[3]).EF[i];//+ef.AvgImg.ImgVector[i]);
            NormalizeDataAndShowFace(eData3, width, height, picEF4);
            double[] eData4 = new double[((EigenFace)ef.EigenFaceList[4]).EF.Length];
            for (int i = 0; i < eData3.Length; i++)
                eData4[i] = ((EigenFace)ef.EigenFaceList[4]).EF[i];//+ef.AvgImg.ImgVector[i]);
            NormalizeDataAndShowFace(eData4, width, height, picEF5);
        }

        private void btn_Test_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileInfo fi = new FileInfo(ofd.FileName);
                Bitmap bmp = new Bitmap(ofd.FileName);
                bmp = new Bitmap(bmp, new Size(width, height));
                MyImage mimg = null;
                if (fi.Extension.ToUpper() == ".GIF")
                    mimg = new MyImage(ofd.FileName, fi.Name, width, height, ImgFormat.EightBit, ImgComparison.CORRELATION);
                if (fi.Extension.ToUpper() == ".JPG")
                    mimg = new MyImage(ofd.FileName, fi.Name, width, height, ImgFormat.TwentyFourBit, ImgComparison.CORRELATION);
                NormalizeDataAndShowFace(mimg.ImgVector, width, height, pic0);
                lblCheck.Text = mimg.FileNameShort;
                ef.SubtractAvgImage(mimg); // mean adjusted image
                NormalizeDataAndShowFace(mimg.ImgVectorAdjM, width, height, picAdjust);
                double selfReconsError = 0;
                MatchResult[] bestMatches = new MatchResult[ef.ImageList.Count]; 
                MyImage reconImg = ef.GetMatchedAndReconstructedImages(mimg, ref selfReconsError,ref bestMatches);
                NormalizeDataAndShowFace(reconImg.ImgVectorAdjM, width, height, picRecons);
                //lblReconstructedError.Text = selfReconsError.ToString() + ":" + bestMatches[0].ImageName.ToString();

                if (bestMatches[0].EucledianDist < 50)
                    lblBest.BackColor = System.Drawing.Color.Green;
                else
                    lblBest.BackColor = System.Drawing.Color.Red;

                NormalizeDataAndShowFace(((MyImage)ef.ImageList[bestMatches[0].ImageNum]).ImgVector, width, height, picBest1);
                lblBest.Text = "D=" + bestMatches[0].EucledianDist.ToString() + "\n" + bestMatches[0].Correlation.ToString();//.Substring(0, 5);

                NormalizeDataAndShowFace(((MyImage)ef.ImageList[bestMatches[1].ImageNum]).ImgVector,width, height, picBest2);
                lblBest2.Text = "D=" + bestMatches[1].EucledianDist.ToString() + "\n" + bestMatches[1].Correlation.ToString().Substring(0, 5);

                NormalizeDataAndShowFace(((MyImage)ef.ImageList[bestMatches[2].ImageNum]).ImgVector,width, height, picBest3);
                lblBest3.Text = "D=" + bestMatches[2].EucledianDist.ToString() + "\n" + bestMatches[2].Correlation.ToString().Substring(0, 5);

                NormalizeDataAndShowFace(((MyImage)ef.ImageList[bestMatches[3].ImageNum]).ImgVector,width, height, picBest4);
                lblBest4.Text = "D=" + bestMatches[3].EucledianDist.ToString() + "\n" + bestMatches[3].Correlation.ToString().Substring(0, 5);

                NormalizeDataAndShowFace(((MyImage)ef.ImageList[bestMatches[4].ImageNum]).ImgVector,width, height, picBest5);
                lblBest5.Text = "D=" + bestMatches[4].EucledianDist.ToString() +"\n" + bestMatches[4].Correlation.ToString().Substring(0, 5);

                NormalizeDataAndShowFace(((MyImage)ef.ImageList[bestMatches[5].ImageNum]).ImgVector,width, height, picBest6);
                lblBest6.Text = "D=" + bestMatches[5].EucledianDist.ToString() +"\n" + bestMatches[5].Correlation.ToString().Substring(0, 5);

                NormalizeDataAndShowFace(((MyImage)ef.ImageList[bestMatches[6].ImageNum]).ImgVector,width, height, picBest7);
                lblBest7.Text = "D=" + bestMatches[6].EucledianDist.ToString() + "\n" + bestMatches[6].Correlation.ToString().Substring(0, 5);

                NormalizeDataAndShowFace(((MyImage)ef.ImageList[bestMatches[7].ImageNum]).ImgVector,width, height, picBest8);
                lblBest8.Text = "D=" + bestMatches[7].EucledianDist.ToString() + "\n" + bestMatches[7].Correlation.ToString().Substring(0, 5);
            }
        }

        private void btn_Accuracy_Click(object sender, EventArgs e)
        {
            try
            { // loop through test images folder to see if the
              // test image matches correctly to known images
                string testImagesFolder = @"C:\Users\ivans_000\Desktop\MASTER\Spring2019\Computer Vision\Assignment8_ComputerVision_SANGINES\ATTFaceDataSet\Testing";
                DirectoryInfo dirInfo = new DirectoryInfo(testImagesFolder);
                if (!dirInfo.Exists)
                    throw new DirectoryNotFoundException(testImagesFolder +" folder does not exist,");
                int accuracyCount = 0;
                int count = 0;
                foreach (FileInfo nextFile in dirInfo.GetFiles())
                {
                    if (nextFile.Extension.ToUpper() == ".JPG")
                    {
                        MyImage mimg = new MyImage(nextFile.FullName, nextFile.Name,width,height, ImgFormat.TwentyFourBit, ImgComparison.CORRELATION);
                        //ef.SubtractAvgImage(mimg);
                        MatchResult[] bestMatches = new MatchResult[ef.ImageList.Count];
                        double reconstError = 0;
                        MyImage reconImg = ef.GetMatchedAndReconstructedImages(mimg, ref reconstError, ref bestMatches);
                        if (bestMatches[0].ImageName.ToString().Substring(0, 3) == mimg.FileNameShort.Substring(0, 3))
                            accuracyCount++;
                        else
                            Console.WriteLine(mimg.FileNameShort + ":" + bestMatches[0].ImageName);
                        count++;
                    }
                }
                MessageBox.Show("Accuracy = " + ((double)accuracyCount / count * 100).ToString() + "%");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "Error creating the ImageList..");
            }
        }

        Bitmap GetBitmapFromByteArray(byte[] bdata)
        {
            Bitmap bmp = new Bitmap(width, height);
            int k = 0;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    bmp.SetPixel(j, i, Color.FromArgb(bdata[k], bdata[k], bdata[k]));
                    k++;
                }
            }
            return bmp;
        }

        void NormalizeDataAndShowFace(double[] imData, int width, int height,PictureBox pb)
        {
            // normalize the reconstructed image to 0-255 range
            double max1 = (from n in imData select n).Max();
            double min = (from n in imData select n).Min();
            double diff = max1 - min;
            for (int i = 0; i < width * height; i++)
            {
                imData[i] = imData[i] - min;
                imData[i] = imData[i] / diff * 255;
                if (imData[i] < 0)
                    imData[i] = 0;
                if (imData[i] > 255)
                    imData[i] = 255;
            }
            Bitmap bmp = new Bitmap(width, height);
            int k = 0;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    bmp.SetPixel(j, i, Color.FromArgb((int)imData[k], (int)imData[k],
                   (int)imData[k]));
                    k++;
                }
            }
            pb.Image = bmp;
        }
    }
}
