using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pac_man
{
    public class Dots
    {
        public List<Dot> dots;

        public Dots()
        {
            this.dots=new List<Dot>();
        }

        public Dots(List<Dot> dots)
        {
            this.dots = dots;
        }
    }
}
