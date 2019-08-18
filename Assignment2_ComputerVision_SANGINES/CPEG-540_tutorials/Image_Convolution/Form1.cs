// By Munif Alotaibi
// For Image Processing ( CPEG-540 ) 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Drawing.Imaging;
namespace Image_Convolution
{
    public partial class Form1 : Form
    {
         // declare classes and variables 
        convolution convolution = new convolution();
        public Bitmap origina_Image = null;
        public Bitmap resultImg = null;

        public Form1()
        {
            InitializeComponent();

        }
        private void LoadImgBtn_Click(object sender, EventArgs e)
        {
            // load img 
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select an image file.";
            ofd.Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg";
            ofd.Filter += "|Bitmap Images(*.bmp)|*.bmp";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(ofd.FileName);
                origina_Image = (Bitmap)Bitmap.FromStream(streamReader.BaseStream);
                streamReader.Close();
                pictureBox1.Image = origina_Image;

               
                ApplyMaskBtn.Enabled = true;
               
                textBox1.Text = String.Empty;
                textBox2.Text = String.Empty;
                textBox3.Text = String.Empty;
                textBox4.Text = String.Empty;
                textBox5.Text = String.Empty;
                textBox6.Text = String.Empty;
                textBox7.Text = String.Empty;
                textBox8.Text = String.Empty;
                textBox9.Text = String.Empty;
            
            }



        }

        private void ApplyMaskBtn_Click(object sender, EventArgs e)
        {
            double[,] MyMask = new double[3, 3];
            MyMask[0, 0] = Convert.ToDouble( textBox1.Text);
            MyMask[0, 1] = Convert.ToDouble(textBox2.Text); 
            MyMask[0, 2] = Convert.ToDouble(textBox3.Text); 
            MyMask[1, 0] = Convert.ToDouble(textBox4.Text);
            MyMask[1, 1] = Convert.ToDouble(textBox5.Text);
            MyMask[1, 2] = Convert.ToDouble(textBox6.Text);
            MyMask[2, 0] = Convert.ToDouble(textBox7.Text);
            MyMask[2, 1] = Convert.ToDouble(textBox8.Text);
            MyMask[2, 2] = Convert.ToDouble(textBox9.Text);

            resultImg = convolution.Convolution(origina_Image, MyMask);
            pictureBox1.Image = resultImg;
        }

        

        private void Savebtn_Click(object sender, EventArgs e)
        {

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "jpeg files (*.jpg)|*.jpg";
            if (DialogResult.OK == dlg.ShowDialog())
                this.pictureBox1.Image.Save(dlg.FileName, ImageFormat.Jpeg);


        }

        
    }
}
