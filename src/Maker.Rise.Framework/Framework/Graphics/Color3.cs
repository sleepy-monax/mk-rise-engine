using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maker.Rise.Framework.Graphics
{
    public class Color3
    {
        public byte Red { get; set; } = 0;
        public byte Green { get; set; } = 0;
        public byte Blue { get; set; } = 0;

        public Color3(byte brightness)
        {
            Red = brightness;
            Green = brightness;
            Blue = brightness;
        }

        public Color3(byte red, byte green, byte blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

    }
}
