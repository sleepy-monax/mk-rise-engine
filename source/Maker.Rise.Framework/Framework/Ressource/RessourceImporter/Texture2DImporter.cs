using Maker.Rise.Framework.Ressource.RessourceType;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maker.Rise.Framework.Ressource.RessourceImporter
{


    public class Texture2DImporter : IRessourceImporter
    {
        public string RessourceTypeName => "texture2D";
        public bool UseLinearFiletering { get; set; } = true;
        public bool UseMipMap { get; set; } = true;

        public void Destroy()
        {

        }

        public IRessource Import(RessourceManager ressourceManager, string fileName)
        {
            Bitmap bitmap = new Bitmap(fileName);

            int handle = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, handle);


            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmapData.Width, bitmapData.Height, 0, OpenTK.Graphics.OpenGL4.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData.Scan0);
            bitmap.UnlockBits(bitmapData);

            if (!UseLinearFiletering)
            {
                if (UseMipMap)
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
                if (UseMipMap)
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

            return new Texture2D(fileName, handle, bitmap.Height, bitmap.Width);
        }
    }
}
