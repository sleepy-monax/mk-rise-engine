using Maker.Rise.Framework.Texture;
using OpenTK.Graphics.OpenGL4;
using System.Collections.Generic;

namespace Maker.Rise.Framework.Graphics.Models
{
    public class Model
    {
        public int VertexCount { get; private set; } = -1;
        public Vao VAO { get; private set; }

        public Model(Vertex[] vertecies, int[] vertexIndices)
        {
            VAO = new Vao();
            List<float> vertexPositionData = new List<float>();
            List<float> vertexTextureCoordinate = new List<float>();
            List<float> normals = new List<float>();

            foreach (var v in vertecies)
            {
                vertexPositionData.Add(v.Position.X);
                vertexPositionData.Add(v.Position.Y);
                vertexPositionData.Add(v.Position.Z);

                vertexTextureCoordinate.Add(v.TextureCoordinate.X);
                vertexTextureCoordinate.Add(v.TextureCoordinate.Y);

                normals.Add(v.Normal.X);
                normals.Add(v.Normal.Y);
                normals.Add(v.Normal.Z);
            }

            VAO.SetIndecesBuffer(vertexIndices);
            VAO.StoreAttribute(0, vertexPositionData.ToArray(), 3);
            VAO.StoreAttribute(1, vertexTextureCoordinate.ToArray(), 2);
            VAO.StoreAttribute(2, normals.ToArray(), 3);
            VertexCount = vertexIndices.Length;
        }

        public virtual void Destroy()
        {
            VAO.Destroy();
        }
    }
}
