using OpenTK.Graphics.OpenGL;
using System;

namespace Maker.Rise.Framework.Texture
{
    public class Texture2D
    {
        public int Handle { get; private set; } = -1;
        public int Width { get; private set; } = 0;
        public int Height { get; private set; } = 0;

        public Texture2D(int handle, int width, int height)
        {
            Handle = handle;
            Width = width;
            Height = height;
        }

        public void Bind()
        {
            GL.BindTexture(TextureTarget.Texture2D, Handle);
        }

        public void Destroy()
        {
            GL.DeleteTexture(Handle);
            Handle = -1;
        }
    }
}
