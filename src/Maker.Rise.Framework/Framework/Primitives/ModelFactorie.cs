using Maker.Rise.Framework.Graphics.Models;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maker.Rise.Framework.Primitives
{
    public static class ModelFactorie
    {
        /// <summary>
        /// Generate a flat plane.
        /// </summary>
        /// <param name="size">Size of the plane.</param>
        /// <param name="vertexCount">Number of vertex per side.</param>
        /// <param name="textureRepeate">Number of texture repeate.</param>
        /// <returns>A flat plane.</returns>
        public static Model GeneratePlane(float size, int vertexCount, int textureRepeate)
        {

            int count = vertexCount * vertexCount;

            Vertex[] vertecies = new Vertex[count];
            int[] indices = new int[6 * (vertexCount - 1) * (vertexCount - 1)];

            int vertexPointer = 0;
            for (int y = 0; y < vertexCount; y++)
            {
                for (int x = 0; x < vertexCount; x++)
                {
                    vertecies[vertexPointer] = new Vertex(new Vector3(x / ((float)vertexCount - 1) * size, 0, y / ((float)vertexCount - 1) * size),
                                                          new Vector3(0, 1, 0),
                                                          new Point2D(x / ((float)vertexCount - 1) * textureRepeate, (float)y / ((float)vertexCount - 1) * textureRepeate));
                    vertexPointer++;
                }
            }
            int pointer = 0;
            for (int y = 0; y < vertexCount - 1; y++)
            {
                for (int x = 0; x < vertexCount - 1; x++)
                {
                    int topLeft = (y * vertexCount) + x;
                    int topRight = topLeft + 1;
                    int bottomLeft = ((y + 1) * vertexCount) + x;
                    int bottomRight = bottomLeft + 1;
                    indices[pointer++] = topLeft;
                    indices[pointer++] = bottomLeft;
                    indices[pointer++] = topRight;
                    indices[pointer++] = topRight;
                    indices[pointer++] = bottomLeft;
                    indices[pointer++] = bottomRight;
                }
            }

            return new Model(vertecies, indices);
        }

        public static Model GenerateCube(float size)
        {
            return null;
        }
    }
}
