using Maker.Rise.Framework.Graphics.Shaders;
using OpenTK.Graphics.OpenGL4;
using System.Collections.Generic;

namespace Maker.Rise.Framework.Graphics.Models
{
    public class Vao
    {
        public int Handle { get; private set; } = -1;
        private List<int> VBOHandles;
        private List<int> Attributes;

        public Vao()
        {
            Handle = GL.GenVertexArray();
            VBOHandles = new List<int>();
            Attributes = new List<int>();
        }

        public void SetIndecesBuffer(int[] indeces)
        {
            GL.BindVertexArray(Handle);

            int IndecesBufferHandle = GL.GenBuffer();
            VBOHandles.Add(IndecesBufferHandle);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, IndecesBufferHandle);

            GL.BufferData(BufferTarget.ElementArrayBuffer, indeces.Length * sizeof(int), indeces, BufferUsageHint.StaticCopy);

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            GL.BindVertexArray(0);
        }

        public void StoreAttribute(int AttributeIndex, float[] data, int size = 3)
        {
            Attributes.Add(AttributeIndex);
            GL.BindVertexArray(Handle);
            int VBO = GL.GenBuffer();
            VBOHandles.Add(VBO);
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.BufferData(BufferTarget.ArrayBuffer, data.Length * sizeof(float), data, BufferUsageHint.DynamicDraw);
            GL.VertexAttribPointer(AttributeIndex, size, VertexAttribPointerType.Float, false, 0, 0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
        }

        public void Bind()
        {
            GL.BindVertexArray(Handle);
            foreach (var a in Attributes)
            {
                GL.EnableVertexAttribArray(a);
            }
        }

        public void Unbind()
        {
            GL.BindVertexArray(0);
            foreach (var a in Attributes)
            {
                GL.DisableVertexAttribArray(a);
            }
        }

        public void Destroy()
        {
            foreach (var vbo in VBOHandles)
            {
                GL.DeleteBuffer(vbo);
            }

            GL.DeleteVertexArray(Handle);
        }
    }
}
