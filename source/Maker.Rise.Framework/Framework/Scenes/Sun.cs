using Maker.Rise.Framework.Graphics;
using Maker.Rise.Framework.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maker.Rise.Framework.Scenes
{
    public class Sun
    {
        public Point3D Position { get; set; }
        public Color3 Color { get; set; }

        public Sun(Point3D position, Color3 color)
        {
            Position = position;
            Color = color;
        }
    }
}
