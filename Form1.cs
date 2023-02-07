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
        bool hold, right, left, down = false;
        bool up = false;
        float distance;
        PointF valid, valid2, valid3;
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
            {
                up = false;
                down = false;
                left = true;
                right = false;
                p.LeftRight();
                p.Turn(4);
                if (valid.X == 0 && valid.Y == 0 && valid2.X == 0 && valid2.Y == 0 && valid3.X == 0 && valid3.Y == 0)
                {
                    p.Turn(4);
                    forward += step;
                    UpdatePosition();
                    
                }
                if ((p.middle.X - 7.5f <= valid.X + 1 && valid.X != 0 && valid.Y != 0) || (p.middle2.X - 7.5f <= valid2.X + 1 && valid2.X != 0 && valid2.Y != 0) || (p.middle3.X - 7.5f <= valid3.X + 1 && valid3.X != 0 && valid3.Y != 0))
                {
                    left = false;
                    
                }
                else
                {
                    p.Turn(4);
                    forward += step;
                    UpdatePosition();
                }

            }
            else if (right == true && hold == false)
            {
                up = false;
                down = false;
                left = false;
                right = true;
                p.LeftRight();
                p.Turn(2);
                if (valid.X == 0 && valid.Y == 0 && valid2.X == 0 && valid2.Y == 0 && valid3.X == 0 && valid3.Y == 0)
                {
                    p.Turn(2);
                    forward += step;
                    UpdatePosition();
                }
                if ((p.middle.X + 7.5f >= valid.X - 1 && valid.X != 0 && valid.Y != 0) || (p.middle2.X + 7.5f >= valid2.X - 1 && valid2.X != 0 && valid2.Y != 0) || (p.middle3.X + 7.5f >= valid3.X - 1 && valid3.X != 0 && valid3.Y != 0))
                {
                    right=false;
                }
                else
                {
                    p.Turn(2);
                    forward += step;
                    UpdatePosition();
                }

            }
            else if (up == true && hold == false)
            {
                up = true;
                down = false;
                left = false;
                right = false;
                p.UpDown();
                p.Turn(1);
                if (valid.X == 0 && valid.Y == 0 && valid2.X == 0 && valid2.Y == 0 && valid3.X == 0 && valid3.Y == 0)
                {
                    p.Turn(1);
                    forward += step;
                    UpdatePosition();
                }
                if ((p.middle.Y - 7.5f <= valid.Y + 1 && valid.X != 0 && valid.Y != 0) || (p.middle2.Y - 7.5f <= valid2.Y + 1 && valid2.X != 0 && valid2.Y != 0) || (p.middle3.Y - 7.5f <= valid3.Y + 1 && valid3.X != 0 && valid3.Y != 0))
                {
                    up = false;
                }
                else
                {
                    p.Turn(1);
                    forward += step;
                    UpdatePosition();
                }
            }
            else if (down == true && hold == false)
            {
                
                up = false;
                down = true;
                left = false;
                right = false;
                p.UpDown();
                p.Turn(3);
                if (valid.X == 0 && valid.Y == 0 && valid2.X == 0 && valid2.Y == 0 && valid3.X == 0 && valid3.Y == 0)
                {
                    p.Turn(3);
                    forward += step;
                    UpdatePosition();
                    
                }
                if ((p.middle.Y + 7.5f >= valid.Y - 1 && valid.X != 0 && valid.Y != 0) || (p.middle2.Y + 7.5f >= valid2.Y - 1 && valid2.X != 0 && valid2.Y != 0) || (p.middle3.Y + 7.5f >= valid3.Y - 1 && valid3.X != 0 && valid3.Y != 0))
                {
                    down=false;
                }
                else
                {
                    p.Turn(3);
                    forward += step;
                    UpdatePosition();
                   
                }
            }
            Render();
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

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Right & !hold)
            { 
                pacman.Image = MyResource.fijo;
            }
            else if (e.KeyData == Keys.Left & !hold)
            {
                pacman.Image = MyResource.fijo;
            }
            else if (e.KeyData == Keys.Up & !hold)
            {
                pacman.Image = MyResource.fijo;
            }
            else if (e.KeyData == Keys.Down & !hold)
            {
                pacman.Image = MyResource.fijo;
            }
        }

        public void DrawPlayer()
        {
            g.FillEllipse(Brushes.Yellow, p.pos.X, p.pos.Y, 15, 15);
            //g.DrawLine(Pens.Red, p.middle, valid);
            //g.DrawLine(Pens.Red, p.middle2, valid2);
            //g.DrawLine(Pens.Red, p.middle3, valid3);

        }

        public void UpdatePosition()
        {
            float f = (float)forward / 50;
            if (p.pos.X > 605)
            {
                p.middle.X = -50f;
            }
            if (p.pos.X < -20)
            {
                p.middle.X = 650f;
            }
            if (p.pos.Y > 605)
            {
                p.middle.Y = -50f;
            }
            if (p.pos.Y < -20)
            {
                p.middle.Y = 650f;
            }
            p.middle = Util.Instance.NextStep(p.middle, p.lookAt, f);
            p.middle2 = Util.Instance.NextStep(p.middle2, p.lookAt2, f);
            p.middle3 = Util.Instance.NextStep(p.middle3, p.lookAt3, f);
            p.pos = new PointF(p.middle.X - 7.5f, p.middle.Y - 7.5f);
            p.looks = new Line(p.middle, p.lookAt);
            Render();
            forward = 0;
        }


        public void Verify()
        {
            PointF collision, collision2, collision3;
            Figure figure;
            Line line, user, user2, user3;

            PointF tmp;
            float dTemp,dTemp2, dTemp3, d, d2, d3;

            dTemp = float.MaxValue;
            dTemp2 = float.MaxValue;
            dTemp3 = float.MaxValue;

            valid = new PointF();
            valid2 = new PointF();
            valid3 = new PointF();
            user = new Line(p.middle, p.lookAt);
            user2 = new Line(p.middle2, p.lookAt2);
            user3 = new Line(p.middle3, p.lookAt3);

            for (int i=0; i<scene.Figures.Count; i++)
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
                    if (Util.Instance.Intersect(user2, line))
                    {
                        collision2 = Util.Instance.FindPoint(user2, line);
                        d2 = Util.Instance.Distance(collision2, p.middle2);

                        if (d2 < dTemp2)
                        {
                            dTemp2 = d2;
                            valid2 = collision2;

                        }
                    }
                    if (Util.Instance.Intersect(user3, line))
                    {
                        collision3 = Util.Instance.FindPoint(user3, line);
                        d3 = Util.Instance.Distance(collision3, p.middle3);

                        if (d3 < dTemp3)
                        {
                            dTemp3 = d3;
                            valid3 = collision3;

                        }
                    }
                }
            }
            g.FillEllipse(Brushes.Red, valid.X - 1, valid.Y - 1, 3, 3);
            g.FillEllipse(Brushes.Red, valid2.X - 1, valid2.Y - 1, 3, 3);
            g.FillEllipse(Brushes.Red, valid3.X - 1, valid3.Y - 1, 3, 3);
            distance = dTemp;

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Right )
            {
                right = true;
                left = false;
                up = false;
                down = false;
                hold = false;
                
                pacman.Image = MyResource.pac_man_d;
            }
            else if (e.KeyData == Keys.Left )
            {
                left = true;
                right = false;
                up = false;
                down = false;
                hold = false;
                pacman.Image = MyResource.pac_man_i;
            }
            else if (e.KeyData == Keys.Up )
            {
                up = true;
                right = false;
                left = false;
                down = false;
                hold = false;
                pacman.Image = MyResource.pac_man_ar;
            }
            else if (e.KeyData == Keys.Down)
            {
                down = true;
                right = false;
                left = false;
                up = false;
                hold = false;
                pacman.Image = MyResource.pac_man_ab;
            }
        }

    }
}
