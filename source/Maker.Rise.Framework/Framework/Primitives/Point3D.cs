using System;

namespace Maker.Rise.Framework.Primitives
{
    [Serializable]
    public sealed class Point3D
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Point3D()
        {
            X = 0; Y = 0; Z = 0;
        }

        public Point3D(float x, float y, float z)
        {
            X = x; Y = y; Z = z;
        }
    }
}
