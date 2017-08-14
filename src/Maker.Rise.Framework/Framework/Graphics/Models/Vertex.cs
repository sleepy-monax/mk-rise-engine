using Maker.Rise.Framework.Primitives;
using OpenTK;
using System;

namespace Maker.Rise.Framework.Graphics.Models
{
    [Serializable]
    public class Vertex
    {
        public Point2D TextureCoordinate { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 Normal { get; set; }

        public Vertex(Vector3 position)
        {
            Position = position;
        }

        public Vertex(Vector3 position, Vector3 normal, Point2D textureCoordinate)
        {
            Position = position;
            Normal = normal;
            TextureCoordinate = textureCoordinate;
        }
    }
}
