using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pac_man
{
    public class Dot
    {
        public List<Line> hb;
        public PointF location;
        public Dot(PointF location)
        {
            this.location = location;
            this.hb=new List<Line>();
        }
    }
}
