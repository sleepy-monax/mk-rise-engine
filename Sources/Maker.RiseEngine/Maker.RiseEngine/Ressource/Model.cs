using Maker.RiseEngine.Graphic;
using Maker.RiseEngine.Primitive;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maker.RiseEngine.Ressource
{
    public class Model : IDrawable
    {
        public int VertexArrayHandle { get; private set; }
        public int VertexBufferHandle { get; private set; }
        public int VertexCount { get; private set; }

        public Model()
        {
            // Do noathing
        }

        public Model(Vertex[] vertices)
        {
            LoadVertices(vertices);
        }

        public void LoadVertices(Vertex[] vertices)
        {
            VertexCount = vertices.Length;
            VertexArrayHandle = GL.GenVertexArray();
            VertexBufferHandle = GL.GenBuffer();

            GL.BindVertexArray(VertexArrayHandle);
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexArrayHandle);
            GL.NamedBufferStorage(VertexBufferHandle, typeof(Vertex).GetSize() * VertexCount, vertices, BufferStorageFlags.MapWriteBit);

            GL.VertexArrayAttribBinding(VertexArrayHandle, 0, 0);
            GL.EnableVertexArrayAttrib(VertexArrayHandle, 0);
            GL.VertexArrayAttribFormat(VertexBufferHandle, 0, 3, VertexAttribType.Float, false, 0);
            AddVertexAtribut(0, 3, 0);
            AddVertexAtribut(1, 4, 16);

            GL.VertexArrayVertexBuffer(VertexArrayHandle, 0, VertexBufferHandle, IntPtr.Zero, typeof(Vertex).GetSize());
        }

        private void AddVertexAtribut(int atributIndex, int atributSize, int atributeOffset)
        {
            GL.VertexArrayAttribBinding(VertexArrayHandle, atributIndex, 0);
            GL.EnableVertexArrayAttrib(VertexArrayHandle, atributIndex);
            GL.VertexArrayAttribFormat(VertexBufferHandle, atributIndex, atributSize, VertexAttribType.Float, false, atributeOffset);
        }

        public void Draw(double GameTime)
        {
            GL.BindVertexArray(VertexArrayHandle);
            GL.DrawArrays(PrimitiveType.Triangles, 0, VertexCount);
        }

        public void Delete()
        {

        }

    }
}
