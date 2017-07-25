using Maker.RiseEngine.Graphic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Maker.RiseEngine.Primitive
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Vertex
    {
        public readonly float X, Y, Z;
        public readonly Color Color;
        //public readonly float TextureCoordinateX, TextureCoordinateY;

        public Vertex(float x, float y, float z, Color color)
        {
            X = x;
            Y = y;
            Z = z;

            Color = color;
        }


    }
}
