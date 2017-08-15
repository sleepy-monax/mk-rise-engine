using Maker.Rise.Framework.Graphics;
using Maker.Rise.Framework.Primitives;
using System;
using System.Collections.Generic;

namespace Maker.Rise.Framework.Ressource.RessourceType
{
    public class Model : IRessource
    {
        public string Name { get; set; }

        public int VertexCount { get; private set; } = -1;
        public Vao VAO { get; private set; }

        public Model(Vertex[] vertecies, int[] vertexIndices)
        {
            VAO = new Vao();
            List<float> vertexPositionData = new List<float>();
            List<float> vertexTextureCoordinate = new List<float>();
            List<float> vertexNormals = new List<float>();

            foreach (var v in vertecies)
            {
                vertexPositionData.Add(v.Position.X);
                vertexPositionData.Add(v.Position.Y);
                vertexPositionData.Add(v.Position.Z);

                vertexTextureCoordinate.Add(v.TextureCoordinate.X);
                vertexTextureCoordinate.Add(v.TextureCoordinate.Y);

                vertexNormals.Add(v.Normal.X);
                vertexNormals.Add(v.Normal.Y);
                vertexNormals.Add(v.Normal.Z);
            }

            VAO.SetIndecesBuffer(vertexIndices);
            VAO.StoreAttribute(0, vertexPositionData.ToArray(), 3);
            VAO.StoreAttribute(1, vertexTextureCoordinate.ToArray(), 2);
            VAO.StoreAttribute(2, vertexNormals.ToArray(), 3);
            VertexCount = vertexIndices.Length;
        }

        public virtual void Destroy()
        {
            VAO.Destroy();
        }
    }
}
