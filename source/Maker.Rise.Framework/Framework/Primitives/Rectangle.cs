using System;

namespace Maker.Rise.Framework.Primitives
{
    [Serializable] public sealed class Rectangle
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        public Rectangle(float x, float y, float width, float height)
        {
            X = x; Y = y;
            Width = width; Height = height;
        }
    }
}
