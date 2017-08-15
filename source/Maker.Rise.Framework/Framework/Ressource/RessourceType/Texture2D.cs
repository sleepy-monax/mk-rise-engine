using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maker.Rise.Framework.Ressource.RessourceType
{
    public class Texture2D : IRessource
    {

        public string Name { get; set; }
        public int Handle { get; private set; } = -1;
        public int Width { get; private set; } = 0;
        public int Height { get; private set; } = 0;

        public Texture2D(string name, int handle, int width, int height)
        {
            Name = name;
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
