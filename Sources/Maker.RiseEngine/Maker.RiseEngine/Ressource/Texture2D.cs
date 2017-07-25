using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using System.Drawing;
using System.Drawing.Imaging;

namespace Maker.RiseEngine.Ressource
{
    public enum TextureQuality { Low, Hight }

    public class Texture2D
    {

        public int Handle { get; private set; }
        public int Height, Width;

        public Texture2D(string texturePath, TextureQuality textureQuality = TextureQuality.Hight, bool repeat = true)
        {
            if (!File.Exists(texturePath))
            {
                Bitmap textureBitmap = new Bitmap(texturePath);
                Handle = GL.GenTexture();
                GL.BindTexture(TextureTarget.Texture2D, Handle);

                switch (textureQuality)
                {
                    case TextureQuality.Low:
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)All.Linear);
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)All.Linear);
                        break;

                    case TextureQuality.Hight:
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)All.Nearest);
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)All.Nearest);
                        break;
                }

                if (repeat)
                {
                    //This will repeat the texture past its bounds set by TexImage2D
                    GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)All.Repeat);
                    GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)All.Repeat);
                }
                else
                {
                    //This will clamp the texture to the edge, so manipulation will result in skewing
                    //It can also be useful for getting rid of repeating texture bits at the borders
                    GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)All.ClampToEdge);
                    GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)All.ClampToEdge);
                }

                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, textureBitmap.Width, textureBitmap.Height, 0, OpenTK.Graphics.OpenGL4.PixelFormat.Bgra, PixelType.UnsignedByte, IntPtr.Zero);
                BitmapData textureBitmapData = textureBitmap.LockBits(new Rectangle(0, 0, textureBitmap.Width, textureBitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                GL.TexSubImage2D(TextureTarget.Texture2D, 0, 0, 0, textureBitmap.Width, textureBitmap.Height, OpenTK.Graphics.OpenGL4.PixelFormat.Bgra, PixelType.UnsignedByte, textureBitmapData.Scan0);
                textureBitmap.UnlockBits(textureBitmapData);
                textureBitmap.Dispose();
                GL.BindTexture(TextureTarget.Texture2D, 0);
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        public void Bind()
        {
            GL.BindTexture(TextureTarget.Texture2D, Handle);
        }
    }
}
