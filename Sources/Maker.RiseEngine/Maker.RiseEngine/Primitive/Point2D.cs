using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maker.RiseEngine.Primitive
{
    public class Point2D
    {
        public int X {get; set;} = 0;
        public int Y {get; set;} = 0;

        public Point2D(int x, int y)
        {
            X = x;
            Y = y;
        }

    }
}
