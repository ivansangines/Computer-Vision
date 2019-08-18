using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HistogramEqualization
{
    public partial class Form1 : Form
    {
        int[,] Histogram;
        bool isGray = false;
        bool isImage = false;
        Bitmap bm;

        public Form1()
        {
            InitializeComponent();
        }

        
        

        

        //Loading Image
        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "jpeg files (*.jpg)|*.jpg|(*.gif)|gif||";
            if (DialogResult.OK == dialog.ShowDialog())
            {
                bm = new Bitmap(dialog.FileName);
                while (bm.Height > picOriginal.Height || bm.Width > picOriginal.Width)
                {
                    bm = new Bitmap(bm, new Size(bm.Width / 2, bm.Height / 2)); //if the image is greater than the picturebo make the picture smaller 
                }
                picOriginal.Image = bm;
                isImage = true;
                isGray = false; //in case we are loading a new image
            }
        }

        //Converting image to Gray
        private void btnGrey_Click(object sender, EventArgs e)
        {
            if (isImage)
            {

                try
                {
                    bm = new Bitmap(picOriginal.Image);
                    isGray = MyImageProc.ConvertToGray(bm);
                    picOriginal.Image = bm;
                    //isGray = true;
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
            else
            {
                MessageBox.Show("You must Upload an Image");
            }
        }

        private void btnHisto_Click(object sender, EventArgs e)
        {
            if (isGray)
            {
                Bitmap modified = (Bitmap)bm.Clone();
                MyImageProc.CreateHistogram(modified);
                picModified.Image = modified;
            }
            else
            {
                MessageBox.Show("You must Convert the Image to Gray");
            }
            
        }
    }
}
