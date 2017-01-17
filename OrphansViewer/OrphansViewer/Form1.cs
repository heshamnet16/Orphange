using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Collections;

namespace OrphansViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            unsafe
            {
                try
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.ShowDialog();
                    FileCreation.XmlBuilder xr = new FileCreation.XmlBuilder();
                    System.IO.FileStream fS = new System.IO.FileStream(ofd.FileName, System.IO.FileMode.Open);
                    System.Drawing.Image[] ic = xr.OrphanImagesFromXMLBytes(FileCreation.BinaryFile.ReadAllBytes(fS,true));
                    if (ic != null)
                        //this.BackgroundImage = MakeAll(ic,Properties.Resources.png_Delete , 256);
                        this.BackgroundImage = Draw(ic, Properties.Resources.png_Delete, 256);
                }
                catch
                {
                }
            }
        }
        public Bitmap MakeAll(Image[] imgs, Image backGround, uint width)
        {
            unsafe
            {
                int SmallWidth, rowWidth = 2;
                int margin = 2;
                if (imgs.Length > 6)
                {
                    SmallWidth = (int)Math.Floor((float)width / (float)((float)imgs.Length / 3f)) - margin;
                    rowWidth = 3;
                    //margin = (int)Math.Floor((float)width / 22F);
                }
                else if (imgs.Length > 3 && imgs.Length <= 6)
                {
                    SmallWidth = (int)Math.Floor((float)width / (float)((float)imgs.Length / 2f)) - margin;
                    rowWidth = 2;
                    //margin = (int)Math.Floor((float)width / 25F);
                }
                else if (imgs.Length == 3)
                {
                    SmallWidth = (int)Math.Floor((float)width / (float)((float)4 / 2f)) - margin;
                    rowWidth = 2;
                    //margin = (int)Math.Floor((float)width / 25F);
                }
                else if (imgs.Length == 2)
                {
                    rowWidth = 1;
                    SmallWidth = (int)((float)width / 2f) - margin;
                    //margin = (int)Math.Floor((float)width / 25F);
                }
                else
                {
                    //margin = 8;
                    SmallWidth = (int)((float)width - 10f);
                    //return new Bitmap(imgs[0], new Size((int)width, (int)width));
                    rowWidth = 1;
                }
                int indexX = margin;
                int indexY = (int)(((float)width/2f)-(float)(((float)(SmallWidth*rowWidth)/2f) -margin )) ;
                backGround = new Bitmap(backGround, new Size((int)width, (int)width));
                Graphics g = Graphics.FromImage(backGround);
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;                
                foreach (Image img in imgs)
                {
                    ColorMatrix matrix = new ColorMatrix();
                    matrix.Matrix33 = 0.95f;
                    ImageAttributes attributes = new ImageAttributes();
                    Bitmap bim = new Bitmap(img, new Size(SmallWidth, SmallWidth));
                    attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                    g.DrawImage(bim, new Rectangle(indexX, indexY, SmallWidth, SmallWidth), 0, 0, bim.Width, bim.Height, GraphicsUnit.Pixel, attributes);
                    g.DrawRectangle(new Pen(Brushes.Black), indexX, indexY, SmallWidth, SmallWidth);
                    indexX += SmallWidth + margin;
                    if (indexX + SmallWidth + margin > width )
                    {
                        indexY += (SmallWidth) + margin;
                        indexX = margin;
                        if (indexY + SmallWidth + margin > width)
                        {
                            break;
                        }
                    }
                }
                g.DrawPolygon(Pens.Red,GetCirclePoints(new Size((int)width,(int)width),SmallWidth));
                g.DrawPolygon(Pens.AliceBlue,GetCirclePoints(new Size((int)width,(int)width),20));
                g.DrawPolygon(Pens.AliceBlue,GetCirclePoints(new Size((int)width,(int)width),50));
                g.DrawPolygon(Pens.AliceBlue,GetCirclePoints(new Size((int)width,(int)width),100));
                g.Dispose();
            }
            return new Bitmap(backGround);
        }
        bool UseNegativeNumber = false;
        ArrayList UsedPoints;
        public void DrawImageInCenter(ref Graphics g,Image img,Size BackSize,Size _size)
        {
            int x = 0;
            int y = 0;
            Point Center = GetCenter(BackSize);
            x = Center.X - (_size.Width/2);
            y = Center.Y - (_size.Height/2);
            ColorMatrix matrix = new ColorMatrix();
            matrix.Matrix33 = 0.70f;
            ImageAttributes attributes = new ImageAttributes();
            Bitmap bim = new Bitmap(img, _size);
            attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            g.TranslateTransform(Center.X, Center.Y);
            Random rnd = new Random(DateTime.Now.Second);
            int Angl = rnd.Next(0, 60);
            if (!UseNegativeNumber)
            { g.RotateTransform(Angl); UseNegativeNumber = true; }
            else
            { 
                g.RotateTransform(-Angl); UseNegativeNumber = false; }
            g.TranslateTransform(-Center.X, -Center.Y);
            g.DrawImage(bim, new Rectangle(x, y, bim.Width, bim.Height), 0, 0, bim.Width, bim.Height, GraphicsUnit.Pixel, attributes);
            //g.DrawRectangle(new Pen(Brushes.Brown, 2), x, y, bim.Width, bim.Height);
        }
        public void DrawImageByPoint(ref Graphics g, Image img, Point pnt, Size BackSize, Size _size)
        {
            int x = pnt.X - (_size.Width/2 ) ;
            int y = pnt.Y - (_size.Height/2)  ;
            Point Center = GetCenter(BackSize);
            ColorMatrix matrix = new ColorMatrix();
            matrix.Matrix33 = 0.80f;
            ImageAttributes attributes = new ImageAttributes();
            Bitmap bim = new Bitmap(img, _size);
            attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            g.TranslateTransform(Center.X, Center.Y);
            Random rnd = new Random(DateTime.Now.Second );
            int Angl = rnd.Next(0, 60);
            if (!UseNegativeNumber)
            { g.RotateTransform(Angl); UseNegativeNumber = !UseNegativeNumber; }
            else
            {
                g.RotateTransform(-Angl); UseNegativeNumber = !UseNegativeNumber;
            }
            g.TranslateTransform(-Center.X, -Center.Y);
            g.DrawImage(bim, new Rectangle(x, y, bim.Width, bim.Height), 0, 0, bim.Width, bim.Height, GraphicsUnit.Pixel, attributes);
            //g.DrawRectangle(new Pen(Brushes.Aqua, 1), x, y, bim.Width, bim.Height);
        }
        public Point GetCenter(Size _Sz)
        {
            return new Point(_Sz.Width / 2, _Sz.Height / 2);
        }
        public Point[] GetCirclePoints(Size BackgSize, int radius)
        {
            Point[] ret;
            Point Center = GetCenter(BackgSize);
            int x , y;
            ArrayList Points = new ArrayList();
            bool Reverse = false;
                for (int i = 0; i < 360; i += 45)
                {
                    int j = i;
                    if (Reverse)
                    {
                        if (j < 180)
                        j = 180 + j;
                    else if (j == 180)
                        j = 180;
                    else
                        j -= 180;
                        Reverse = !Reverse;
                    }
                    else
                        Reverse = !Reverse;

                    double angle = j * System.Math.PI / 180;
                    radius = (int)Math.Floor((float)radius / 2f); 
                     x = (int)(Center.X  + (radius) * System.Math.Cos(angle));
                     y = (int)(Center.Y  + (radius) * System.Math.Sin(angle));

                    Points.Add(new Point(x, y));
                    //System.Threading.Thread.Sleep(1); // If you want to draw circle very slowly.
                }
            ret = (Point[])Points.ToArray(typeof(Point));
            return ret;
        }
        public Point GetNextPoint(Point[] points)
        {
            if (UsedPoints == null) UsedPoints = new ArrayList();
            Random rnd = new Random();
            bool Ok = false;
            int num=0;
            do
            {
                if(!UsedPoints.Contains(points[num]))
                {
                    UsedPoints.Add(points[num]);
                    Ok = true;
                }
                num++;
                if (num == points.Length)
                { return new Point(-1,-1); }
            } while (Ok == false);
            return points[num];
        }
        public int CalculateThumbnailSise(int width, int numberOfImages)
        {
            int ret;
            if (numberOfImages == 1)
            {
                ret = (int)Math.Floor( (float)width / 1.333f);
            }
            else if (numberOfImages == 2)
            {
                ret = (int)Math.Floor((float)width / 1.8f);
            }
            else
            {
                ret = (int)Math.Floor((float)width / 2f);
            }
            return ret;
        }
        public Image Draw(Image[] imgs, Image background, int width)
        {           
            int ThumbWidth = CalculateThumbnailSise(width, imgs.Length);
            Bitmap bckG = new Bitmap(background,new Size(width,width));
            Graphics g = Graphics.FromImage(bckG);
            if (imgs.Length == 1)
            {
                DrawImageInCenter(ref g, imgs[0], new Size(width, width), new Size(ThumbWidth, ThumbWidth));
            }
            else
            {

                Point[] ponts = GetCirclePoints(new Size(width, width), ThumbWidth);
                if (UsedPoints != null) UsedPoints.Clear();
                foreach (Image img in imgs)
                {
                    if (img == imgs[imgs.Length-1])
                    {
                        DrawImageInCenter(ref g, img, new Size(width, width), new Size(ThumbWidth, ThumbWidth));
                    }
                    else
                    {
                        int i = 0;
                        Point Next = GetNextPoint(ponts);
                        while (Next.X + (ThumbWidth / 2) >= width || Next.X - (ThumbWidth / 2) <= 0 ||
                            Next.Y + (ThumbWidth / 2) >= width || Next.Y - (ThumbWidth / 2) <= 0)
                        {
                            Next = GetNextPoint(ponts);
                            if (Next.X == -1 && Next.Y == -1)
                            {
                                i += 5;
                                ponts = GetCirclePoints(new Size(width, width), ThumbWidth - i);
                                UsedPoints.Clear();
                            }
                        }
                        DrawImageByPoint(ref g, img, Next, new Size(width, width), new Size(ThumbWidth, ThumbWidth));
                    }
                }
            }
            g.Dispose();
            return bckG;
        }
    }
}
