using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pac_man
{
    public class Player
    {
        public Line looks;
        public PointF pos, lookAt, middle;

        public Player(PointF pos, PointF looksAt)
        {
            this.pos = pos;
            this.lookAt = looksAt;

            middle=new PointF(pos.X+7.5f, pos.Y+7.5f);
            looks = new Line(middle, looksAt);

        }

        public void Turn(int i)
        {
            switch (i)
            {
                case 1:
                    {
                        lookAt.X = middle.X;
                        lookAt.Y = middle.Y - 22.5f;
                        break;
                    }

                case 2:
                    {
                        
                        lookAt.X = middle.X+22.5f;
                        lookAt.Y = middle.Y;
                        break;
                    }

                case 3:
                    {
                        lookAt.X = middle.X;
                        lookAt.Y = middle.Y + 22.5f;
                        break;
                    }
                case 4:
                    {
                        lookAt.X = middle.X - 22.5f;
                        lookAt.Y = middle.Y;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

    }
}
