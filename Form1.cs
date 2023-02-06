using pac_man.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pac_man
{
    public partial class Form1 : Form
    {
        static Graphics g;
        Scene scene;
        bool hold, right, left, up, down = false;
        //bool up, down = false;
        public Form1()
        {
            InitializeComponent();
            //DrawMap1();
            Init();
        }
        public void Init()
        {
            level1();

        }

        private void TIMER_Tick(object sender, EventArgs e)
        {
            if (left == true && hold == false)
                pacman.Left -= 1; 
            else if (right == true && hold == false)
                pacman.Left += 1;
            else if (up == true && hold == false)
                pacman.Top -= 1;
            else if (down == true && hold == false)
                pacman.Top += 1;
        }

        private void map_Click(object sender, EventArgs e)
        {

        }

        public void level1()
        {
            DrawMap1();
            pacman.Image = MyResource.fijo;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void DrawMap1()
        {
            Bitmap bmp = new Bitmap(600, 600);
            g = Graphics.FromImage(bmp);
            map.Image = bmp;
            g.Clear(Color.Black);
            scene = new Scene();


            for (int x = 0; x < mapaBase.map0.GetLength(0); x++)
            {
                for (int y = 0; y < mapaBase.map0.GetLength(1); y++)
                {


                    if (mapaBase.map0[y, x] != 0)
                    {
                        Figure fig = new Figure();
                        fig.Lines.Add(new Line(new PointF(x * 15, y * 15), new PointF(x * 15 + 15, y * 15)));
                        fig.Lines.Add(new Line(new PointF(x * 15 + 15, y * 15), new PointF(x * 15 + 15, y * 15 + 15)));
                        fig.Lines.Add(new Line(new PointF(x * 15 + 15, y * 15 + 15), new PointF(x * 15, y * 15 + 15)));
                        fig.Lines.Add(new Line(new PointF(x * 15, y * 15 + 15), new PointF(x * 15, y * 15)));
                        scene.Figures.Add(fig);

                        //g.FillRectangle(new SolidBrush(Color.FromArgb(35, 35, 35)), x * 15, y * 15, 15, 15);
                        //g.FillRectangle(new SolidBrush(Color.Blue), x * 15, y * 15, 15, 15);
                    }
                    else
                        g.FillRectangle(new SolidBrush(Color.Black), x * 15, y * 15, 15, 15);

                    //guía panel cuadrado para código 
                    //g.DrawRectangle(Pens.Gray, x * 15, y * 15, 15, 15);
                }
            }

            Render();
        }

        public void Render()
        {
            for(int f=0; f<scene.Figures.Count; f++)
            {
                for (int l = 0; l<scene.Figures[f].Lines.Count; l++)
                {
                    g.DrawLine(Pens.Blue, scene.Figures[f].Lines[l].a, scene.Figures[f].Lines[l].b);
                }
            }
            map.Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Right & hold)
            {
                right = true;
                hold = false;
                pacman.Image = MyResource.pac_man_d;
            }
            else if (e.KeyData == Keys.Left & hold)
            {
                left = true;
                hold = false;
                pacman.Image = MyResource.pac_man_i;
            }
            else if (e.KeyData == Keys.Up & hold)
            {
                up = true;
                hold = false;
                pacman.Image = MyResource.pac_man_ar;
            }
            else if (e.KeyData == Keys.Down & hold)
            {
                down = true;
                hold = false;
                pacman.Image = MyResource.pac_man_ab;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Right & !hold)
            {
                right = false;
                hold = true;
                pacman.Image = MyResource.fijo;
            }
            else if (e.KeyData == Keys.Left & !hold)
            {
                left = false;
                hold = true;
                pacman.Image = MyResource.fijo;
            }
            else if (e.KeyData == Keys.Up & !hold)
            {
                up = false;
                hold = true;
                pacman.Image = MyResource.fijo;
            }
            else if (e.KeyData == Keys.Down & !hold)
            {
                down = false;
                hold = true;
                pacman.Image = MyResource.fijo;
            }
        }
    }
}
