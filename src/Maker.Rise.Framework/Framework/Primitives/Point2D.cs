using System;

namespace Maker.Rise.Framework.Primitives
{
    [Serializable] public sealed class Point2D
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Point2D(float x, float y)
        {
            X = x; Y = y;
        }
    }
}
