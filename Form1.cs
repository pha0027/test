using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace draw
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Graphics g;
        Pen p;
        float centerpointx;
        float centerpointy;
        public double DEGTORAD(float deg)
        {
            return Math.PI * deg / 180;
        }
        public void GenerateCircle(int degree, int radius)
        {
            int count = 0;
            for(float i = 225.0f; i <= degree; i+=7.5f)
            {
                    
                    SolidBrush s = new SolidBrush(Color.Blue);
                    PointF p1 = new PointF();
                    PointF p2 = new PointF();
                    p1.X = centerpointx + ((float)Math.Cos(DEGTORAD(i-7.5f)) * radius);
                    p1.Y = centerpointy + ((float)Math.Sin(DEGTORAD(i-7.5f)) * radius);
                    p2.X = centerpointy + ((float)Math.Cos(DEGTORAD(i)) * radius);
                    p2.Y = centerpointy + ((float)Math.Sin(DEGTORAD(i)) * radius);
                    g.DrawString(count.ToString(), new Font(new FontFamily("Arial"), 10), s, p2.X - 10, p2.Y - 10);
                    g.DrawLine(p, new PointF(centerpointx,centerpointy), p2);
                    
                    
                    count++;
                    Thread.Sleep(500);
                    

            }
        }
        private void ClearColor(PaintEventArgs e)
        {
            // Clear screen with teal background.
            e.Graphics.Clear(Color.Teal);
        }
        public void GenerateMinutes(int degree, int radius)
        {
            int count = 0;
            
            for (float i = 225.0f; i <= degree; i += 1.5f)
            {
                
                SolidBrush s = new SolidBrush(Color.Blue);
                PointF p1 = new PointF();
                PointF p2 = new PointF();
                p1.X = centerpointx + ((float)Math.Cos(DEGTORAD(i - 1.5f)) * radius);
                p1.Y = centerpointy + ((float)Math.Sin(DEGTORAD(i - 1.5f)) * radius);
                p2.X = centerpointy + ((float)Math.Cos(DEGTORAD(i)) * radius);
                p2.Y = centerpointy + ((float)Math.Sin(DEGTORAD(i)) * radius);
                if(count == 0 && i == 225.0f)
                {
                    g.DrawString(count.ToString(), new Font(new FontFamily("Arial"), 10), s, p2.X - 10, p2.Y - 10);
                    count += 10;

                }
                else if(count <= 60)
                {
                    float a = i - 225.0f;
                    if(a % 15 == 0)
                    {
                        g.DrawString(count.ToString(), new Font(new FontFamily("Arial"), 10), s, p2.X - 10, p2.Y - 10);
                        count += 10;
                    }
                }
                else if(count > 60)
                {
                    //g.DrawString(count.ToString(), new Font(new FontFamily("Arial"), 10), s, p2.X - 10, p2.Y - 10);
                    count = 0;
                }
                g.DrawLine(p, new PointF(centerpointx, centerpointy), p2);
                


                Thread.Sleep(500);
                

            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            p = new Pen(Brushes.Black, 0.1f);
            centerpointx = 150;
            centerpointy = 150;
            GenerateCircle(315, 100);
            centerpointx = 300;
            centerpointy = 300;
            GenerateMinutes(315, 100);
        }
    }
}
