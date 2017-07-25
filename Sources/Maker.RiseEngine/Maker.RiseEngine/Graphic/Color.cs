using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Maker.RiseEngine.Graphic
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Color
    {
        public float Alpha { get; set; }
        public float Red { get; set; }
        public float Green { get; set; }
        public float Blue { get; set; }

        public Color(float alpha, float red, float green, float blue)
        {
            Alpha = alpha;
            Red = red;
            Green = green;
            Blue = blue;
        }
    }
}
