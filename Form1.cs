using pac_man.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        static int forward;
        int step;
        Scene scene;
        Player p;
        bool hold, right, left, up, down = false;
        float distance;
        PointF valid;
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
            //if (left == true && hold == false)
            //{
            //    //pacman.Left -= 1;


            //}
            //else if (right == true && hold == false)
            //{
            //    //pacman.Left += 1;

            //}
            //else if (up == true && hold == false)
            //{
            //    //pacman.Top -= 1;
            //}
            //else if (down == true && hold == false)
            //{
            //    //pacman.Top += 1;
            //}
            PointF newpos = p.getPos();


            pacman.Left = (int)newpos.X;
            pacman.Top= (int)newpos.Y;
        }

        public void level1()
        {
            DrawMap1();
            pacman.Image = MyResource.fijo;
        }


        public void DrawMap1()
        {
            Bitmap bmp = new Bitmap(600, 600);
            g = Graphics.FromImage(bmp);
            map.Image = bmp;
            g.Clear(Color.Black);
            scene = new Scene();
            step = 3;
            


            for (int x = 0; x < mapaBase.map0.GetLength(0); x++)
            {
                for (int y = 0; y < mapaBase.map0.GetLength(1); y++)
                {


                    if (mapaBase.map0[y, x] == 1)
                    {
                        Figure fig = new Figure();
                        fig.Lines.Add(new Line(new PointF(x * 15, y * 15), new PointF(x * 15 + 15, y * 15)));
                        fig.Lines.Add(new Line(new PointF(x * 15 + 15, y * 15), new PointF(x * 15 + 15, y * 15 + 15)));
                        fig.Lines.Add(new Line(new PointF(x * 15 + 15, y * 15 + 15), new PointF(x * 15, y * 15 + 15)));
                        fig.Lines.Add(new Line(new PointF(x * 15, y * 15 + 15), new PointF(x * 15, y * 15)));
                        scene.Figures.Add(fig);
                    }
                    else if(mapaBase.map0[y, x] == 2)
                    {
                        p = new Player(new PointF(x * 15, y * 15), new PointF(x * 15 + 7.5f, y * 15-15));
                        
                    }

                    //guía panel cuadrado para código 
                    //g.DrawRectangle(Pens.Gray, x * 15, y * 15, 15, 15);
                }
            }

            Render();
        }

        public void Render()
        {
            g.Clear(Color.Black);
            for(int f=0; f<scene.Figures.Count; f++)
            {
                for (int l = 0; l<scene.Figures[f].Lines.Count; l++)
                {
                    g.DrawLine(Pens.Blue, scene.Figures[f].Lines[l].a, scene.Figures[f].Lines[l].b);
                }
            }
            Verify();
            DrawPlayer();
            map.Invalidate();
        }

        public void DrawPlayer()
        {
            g.FillEllipse(Brushes.Yellow, p.pos.X, p.pos.Y, 15, 15);
            g.DrawLine(Pens.Red, p.middle, valid);
        }

        public void UpdatePosition()
        {
            float f = (float)forward / 50;
            p.middle = Util.Instance.NextStep(p.middle, p.lookAt, f);
            p.pos = new PointF(p.middle.X - 7.5f, p.middle.Y - 7.5f);
            p.looks = new Line(p.middle, p.lookAt);
            Render();
            forward = 0;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Left:
                    p.Turn(4);
                    forward += step;
                    UpdatePosition();
                    break;
                case Keys.Right:
                    p.Turn(2);
                    forward += step;
                    UpdatePosition();
                    break;
                case Keys.Up:
                    p.Turn(1);
                    forward += step;
                    UpdatePosition();
                    break;
                case Keys.Down:
                    p.Turn(3);
                    forward += step;
                    UpdatePosition();
                    break;
                case Keys.Space:
                    break;
            }
            Render();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void Verify()
        {
            PointF collision;
            Figure figure;
            Line line, user;

            PointF tmp;
            float dTemp, d;

            dTemp = float.MaxValue;

            valid = new PointF();
            user = new Line(p.middle, p.lookAt);

            for(int i=0; i<scene.Figures.Count; i++)
            {
                figure = scene.Figures[i];
                for (int j=0; j<figure.Lines.Count; j++)
                {
                    line = figure.Lines[j];
                    if(Util.Instance.Intersect(user, line))
                    {
                        collision = Util.Instance.FindPoint(user, line);
                        d = Util.Instance.Distance(collision, p.middle);

                        if (d < dTemp)
                        {
                            dTemp = d;
                            valid = collision;
                        }
                    }
                }
            }
            g.FillEllipse(Brushes.Red, valid.X - 1, valid.Y - 1, 3, 3);
            distance = dTemp;

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
