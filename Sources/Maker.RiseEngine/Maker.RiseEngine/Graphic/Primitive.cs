using Maker.RiseEngine.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using OpenTK;

namespace Maker.RiseEngine.Graphic
{
    public static class Primitive
    {

        public static void DrawPoint(Point2D point, int size, Color color)
        {
            GL.DrawArrays(PrimitiveType.Points, 0, 1);
            GL.PointSize(size);

        }

    }
}
