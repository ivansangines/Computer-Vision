	using System;
	using System.Drawing;
	using System.Drawing.Drawing2D;
	using System.Drawing.Imaging;
	using System.Windows.Forms;


	namespace ImageProcesing2010
	{
		
		public class MyImageProc
		{
			public MyImageProc()
			{
				
			}
	
			public static bool CovertToGray(Bitmap b)
			{
				
				for (int i = 0; i < b.Width; i++)
					for (int j = 0; j < b.Height; j++)
					{
						Color c1 = b.GetPixel(i,j);
						int r1 = c1.R;
						int g1 = c1.G;
						int b1 = c1.B;
						int gray = (byte)(.299 * r1 
							+ .587 * g1 
							+ .114 * b1);
						r1 = gray;
						g1 = gray;
						b1 = gray;
										
						b.SetPixel(i,j,Color.FromArgb(r1,g1,b1));
					}
				return true;
			}


			public static Bitmap Brighten(Bitmap use, int nBrightness)
			{
				
				int Red,Green,Blue;
				if (nBrightness < -255 || nBrightness > 255) //pixels go from 0 to 255
					return use;
			
				Bitmap Bright= new Bitmap(use.Width,use.Height);

				for(int r=0;r<use.Height;r++)
				{
					for(int c=0;c<use.Width;c++)
					{
						Color cr = use.GetPixel(c,r);
						Red=nBrightness+Convert.ToInt32(cr.R);
						Green=nBrightness+Convert.ToInt32(cr.G);
						Blue=nBrightness+Convert.ToInt32(cr.B);
                        
                    //checking pixels are between 0 and 255
                        if (Red>255) 
                            Red =255;
						if(Red<0)
                            Red =0;
						if(Green>255)
                            Green =255;
						if(Green<0)
                            Green =0;
						if(Blue>255)
                            Blue =255;
						if(Blue<0)
                            Blue =0;

						Bright.SetPixel(c,r,Color.FromArgb(Red,Green,Blue));
				
					}
				}

				return Bright;
		
			}

			public static Bitmap Contrast(Bitmap b, sbyte nContrast)
			{
				Bitmap Contrast= new Bitmap(b.Width,b.Height);

				if (nContrast < -100)
                    nContrast =-100;
				if (nContrast >  100)
                    nContrast =100;

				double pixel = 0, contrast = (100.0+nContrast)/100.0;

				contrast *= contrast;

				int red, green, blue;
			
				for(int y=0;y<b.Height;++y)
				{
					for(int x=0; x < b.Width; ++x )
					{
						Color cr = b.GetPixel(x,y);
							
						red=Convert.ToInt32(cr.R);
						green=Convert.ToInt32(cr.G);
						blue=Convert.ToInt32(cr.B);
							
						pixel = red/255.0;
						pixel -= 0.5;
						pixel *= contrast;
						pixel += 0.5;
						pixel *= 255;
						if (pixel < 0) pixel = 0;
						if (pixel > 255) pixel = 255;
						red=(int)pixel;
						

						pixel = green/255.0;
						pixel -= 0.5;
						pixel *= contrast;
						pixel += 0.5;
						pixel *= 255;
						if (pixel < 0) pixel = 0;
						if (pixel > 255) pixel = 255;
						green=(int)pixel;

						pixel = blue/255.0;
						pixel -= 0.5;
						pixel *= contrast;
						pixel += 0.5;
						pixel *= 255;
						if (pixel < 0) pixel = 0;
						if (pixel > 255) pixel = 255;
						blue=(int)pixel;					

						Contrast.SetPixel(x,y,Color.FromArgb(red,green,blue));
					}
					
				}
		
				return Contrast;
			}
			public static Bitmap RecoverBitmapFromArray(double [] BitmapArr, int w1, int h1)
			{

				Bitmap brecov = new Bitmap(w1,h1);
				int p=0;
				int q = 0;
				for (int i = 0; i < BitmapArr.Length;i++)
				{
					int val = (int) (BitmapArr[i]/(1375669f*900f));
					if (val < 0)
						val = 0;
					//if (val > 255)
					//	val = 255;
					Color c1 = Color.FromArgb(val,val,val);
					brecov.SetPixel(p,q,c1);
					p++;
					if (p == w1)
					{
						p = 0;
						q++;
					}
				}
				return brecov;
			}


			public static bool RotateClear(Image img, ref Bitmap bm, double Rot)
			{
				if (Rot < -360 || Rot > 360)
					return false;
				bm = new Bitmap(img.Width,img.Height,PixelFormat.Format24bppRgb);
				Graphics dc = Graphics.FromImage(bm);
				dc.Clear(Color.White);
				dc.RotateTransform((float) Rot);
			//	dc.DrawImage(img,new Rectangle((int)Rot,(int)-Rot,img.Width,img.Height));
				dc.DrawImage(img,new Rectangle(0,0,img.Width,img.Height));

				return true;
			}

			public static bool RotateByPoints(Image img, ref Bitmap bm, Point p1, Point p2)
			{
				if ((p1.X == p2.X)) // no need to rotate
					return true;
				Point midPt = new Point();
				midPt.X = (int)((p1.X+p2.X)/2.0);
				midPt.Y = (int)((p1.Y+p2.Y)/2.0);
				double RotRadians = Math.Atan2(-(p2.Y - p1.Y),(p2.X - p1.X));
				Point newmidPt = new Point();
				newmidPt.X = (int) (midPt.X * Math.Cos(RotRadians) -
					midPt.Y * Math.Sin(RotRadians));
				newmidPt.Y = (int) (midPt.Y * Math.Cos(RotRadians) +
					midPt.X * Math.Sin(RotRadians));
				//MessageBox.Show(newmidPt.ToString());


				double Rot = RotRadians * 180/3.141516;
				return MyImageProc.RotateFill2(img, ref bm,Rot,midPt,newmidPt);
			}

			public static bool RotateFill(Image img, ref Bitmap bm, double Rot)
			{
				if (Rot < -360 || Rot > 360)
					return false;
				bm = new Bitmap(img.Width,img.Height,PixelFormat.Format24bppRgb);
				Graphics dc = Graphics.FromImage(bm);
				dc.DrawImage(img,new Rectangle(0,0,img.Width,img.Height));
				dc.RotateTransform((float)Rot);
				double rdegrees = Rot * 3.141516/180;
				int shift = (int)(bm.Height/2 * Math.Tan(rdegrees));
				if (rdegrees > 0)
					//dc.DrawImage(img,new Rectangle((int)shift-(int)(1.2*Rot),(int)-shift,img.Width,img.Height));
					dc.DrawImage(img,new Rectangle((int)shift,(int)-shift,img.Width,img.Height));
					else
					dc.DrawImage(img,new Rectangle((int)shift,(int)-shift/2,img.Width,img.Height));
				return true;
			}

			public static bool RotateFill2(Image img, ref Bitmap bm, double Rot, Point mpt, Point newmpt)
			{
				if (Rot < -360 || Rot > 360)
					return false;
				bm = new Bitmap(img.Width,img.Height,PixelFormat.Format24bppRgb);
				Graphics dc = Graphics.FromImage(bm);
				dc.DrawImage(img,new Rectangle(0,0,img.Width,img.Height));
				dc.RotateTransform((float)Rot);
				double rdegrees = Rot * 3.141516/180;
				int shift = (int)(bm.Height/2 * Math.Tan(rdegrees));
				if (rdegrees > 0)
					//dc.DrawImage(img,new Rectangle((int)shift-(int)(1.2*Rot),(int)-shift,img.Width,img.Height));
					dc.DrawImage(img,new Rectangle(0,0,img.Width,img.Height));
				else
					dc.DrawImage(img,new Rectangle(new Point(0,0),new Size(img.Width,img.Height)));
				return true;
			}

			public static bool DrawRectangle(Image img, ref Bitmap bm, Rectangle rect)
			{
				bm = new Bitmap(img.Width,img.Height,PixelFormat.Format24bppRgb);
				Graphics dc = Graphics.FromImage(bm);
				dc.DrawImage(img,new Rectangle(0,0,img.Width,img.Height));
				dc.DrawRectangle(new Pen(Color.Red),rect);
				return true;
			}

			public static bool DrawX(Image img, ref Bitmap bm, Point pt)
			{
				bm = new Bitmap(img.Width,img.Height,PixelFormat.Format24bppRgb);
				Graphics dc = Graphics.FromImage(bm);
				dc.DrawImage(img,new Rectangle(0,0,img.Width,img.Height));
				Brush br = new SolidBrush(Color.Red);
				Point p1 = new Point(pt.X-3,pt.Y-3);
				Point p2 = new Point(pt.X+3,pt.Y+3);
				dc.DrawLine(new Pen(Color.Blue),p1,p2);
				Point p3 = new Point(pt.X+3,pt.Y-3);
				Point p4 = new Point(pt.X-3,pt.Y+3);
				dc.DrawLine(new Pen(Color.Blue),p3,p4);

			//	dc.DrawString("x",new Font(FontFamily.GenericSansSerif,10),
			//		br,pt);
				return true;
			}

			public static bool Draw2X(Image img, ref Bitmap bm, Point pt1, Point pt2)
			{
				bm = new Bitmap(img.Width,img.Height,PixelFormat.Format24bppRgb);
				Graphics dc = Graphics.FromImage(bm);
				dc.DrawImage(img,new Rectangle(0,0,img.Width,img.Height));
				Brush br = new SolidBrush(Color.Red);
				Point p1a = new Point(pt1.X-3,pt1.Y-3);
				Point p2a = new Point(pt1.X+3,pt1.Y+3);
				dc.DrawLine(new Pen(Color.Red),p1a,p2a);
				Point p3a = new Point(pt1.X+3,pt1.Y-3);
				Point p4a = new Point(pt1.X-3,pt1.Y+3);
				dc.DrawLine(new Pen(Color.Red),p3a,p4a);

				Point p1b = new Point(pt2.X-3,pt2.Y-3);
				Point p2b = new Point(pt2.X+3,pt2.Y+3);
				dc.DrawLine(new Pen(Color.Red),p1b,p2b);
				Point p3b = new Point(pt2.X+3,pt2.Y-3);
				Point p4b = new Point(pt2.X-3,pt2.Y+3);
				dc.DrawLine(new Pen(Color.Red),p3b,p4b);

				//	dc.DrawString("x",new Font(FontFamily.GenericSansSerif,10),
				//		br,pt);
				return true;
			}

			public static bool Draw2Xbold(Image img, ref Bitmap bm, Point pt1, Point pt2)
			{
				bm = new Bitmap(img.Width,img.Height,PixelFormat.Format24bppRgb);
				Graphics dc = Graphics.FromImage(bm);
				dc.DrawImage(img,new Rectangle(0,0,img.Width,img.Height));
				Brush br = new SolidBrush(Color.Red);
				Point p1a = new Point(pt1.X-6,pt1.Y-6);
				Point p2a = new Point(pt1.X+6,pt1.Y+6);
				dc.DrawLine(new Pen(Color.Red,2),p1a,p2a);
				Point p3a = new Point(pt1.X+6,pt1.Y-6);
				Point p4a = new Point(pt1.X-6,pt1.Y+6);
				dc.DrawLine(new Pen(Color.Red,2),p3a,p4a);

				Point p1b = new Point(pt2.X-6,pt2.Y-6);
				Point p2b = new Point(pt2.X+6,pt2.Y+6);
				dc.DrawLine(new Pen(Color.Red,2),p1b,p2b);
				Point p3b = new Point(pt2.X+6,pt2.Y-6);
				Point p4b = new Point(pt2.X-6,pt2.Y+6);
				dc.DrawLine(new Pen(Color.Red,2),p3b,p4b);

				//	dc.DrawString("x",new Font(FontFamily.GenericSansSerif,10),
				//		br,pt);
				return true;
			}

			public static bool ResizeImage(Image img, ref Bitmap bm, Rectangle rect)
			{
				bm = new Bitmap(rect.Width,rect.Height,PixelFormat.Format24bppRgb);
				Graphics dc = Graphics.FromImage(bm);
				dc.DrawImage(img,rect);
				return true;
			}

			public static bool ResizeImageProportional(Image img, ref Bitmap bm, Rectangle rect)
			{
				Rectangle newR = new Rectangle(rect.X, rect.Y, rect.Width, img.Height*rect.Width/img.Width);
				bm = new Bitmap(newR.Width,newR.Height,PixelFormat.Format24bppRgb);
				Graphics dc = Graphics.FromImage(bm);
				//dc.InterpolationMode = InterpolationMode.High;
				dc.DrawImage(img,newR);
				return true;
			}

			public static bool CropImage(Image img, ref Bitmap bm, Rectangle rect)
			{
				Bitmap bmpCrop = new Bitmap (rect.Width, rect.Height,img.PixelFormat);

				Graphics dc = Graphics.FromImage(bmpCrop);
				Rectangle recDest = new Rectangle(0, 0, rect.Width,rect.Height);

				dc.DrawImage(bm, recDest, rect.X, rect.Y, rect.Width, rect.Height, GraphicsUnit.Pixel);
			
				bm = bmpCrop;
				return true;
			}

            public static bool ShiftImageHorizontal(Image img, ref Bitmap bmp, int shiftAmt)
            {
                if (shiftAmt > img.Width)
                    return false;
                //bmp = new Bitmap(img.Width + Math.Abs(shiftAmt), img.Height, PixelFormat.Format24bppRgb);
                bmp = new Bitmap(img.Width, img.Height, PixelFormat.Format24bppRgb);
                Graphics dc = Graphics.FromImage(bmp);
                dc.Clear(Color.Black);
                dc.TranslateTransform(shiftAmt,0);
                dc.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
                return true;
            }

            public static bool ShiftImageVertical(Image img, ref Bitmap bmp, int shiftAmt)
            {
                if (shiftAmt >  img.Width)
                    return false;
                bmp = new Bitmap(img.Width, img.Height + Math.Abs(shiftAmt), PixelFormat.Format24bppRgb);
                bmp = new Bitmap(img.Width, img.Height, PixelFormat.Format24bppRgb);
                Graphics dc = Graphics.FromImage(bmp);
                dc.Clear(Color.Black);
                dc.TranslateTransform(0,shiftAmt);
                dc.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
                return true;
            }
		}
	}

