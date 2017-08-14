using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace Maker.Rise.Framework.Texture
{


    public class TextureImporter : EngineComponent
    {
        private Dictionary<string, Texture2D> ManagedTexture2D;

        public override void Load()
        {
            ManagedTexture2D = new Dictionary<string, Texture2D>();
        }

        public override void Destroy()
        {
            foreach (Texture2D texture in ManagedTexture2D.Values)
            {
                texture.Destroy();
            }
        }


        public Texture2D GetTexture2D(string path, bool useLinearFiletering = false, bool useMipMap = true)
        {
            if (!ManagedTexture2D.ContainsKey(path))
            {
                Bitmap bitmap = new Bitmap(path);

                int handle = GL.GenTexture();
                GL.BindTexture(TextureTarget.Texture2D, handle);


                BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmapData.Width, bitmapData.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData.Scan0);
                bitmap.UnlockBits(bitmapData);

                if (!useLinearFiletering)
                {
                    if (useMipMap)
                    {
                        GL.GenerateTextureMipmap(handle);
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMinFilter.NearestMipmapNearest);
                    }
                    else
                    {
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
                    }
                }
                else
                {
                    if (useMipMap)
                    {
                        GL.GenerateTextureMipmap(handle);
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMinFilter.LinearMipmapLinear);
                    }
                    else
                    {
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
                    }
                }

                ManagedTexture2D[path] = new Texture2D(handle, bitmap.Height, bitmap.Width);
            }

            return ManagedTexture2D[path];
        }
    }
}
