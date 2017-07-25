using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;

namespace Maker.RiseEngine.Ressource
{
    public class ShaderProgram
    {
        public int Handle;

        public ShaderProgram(bool deleteShaders = true, params Shader[] shaders)
        {
            Handle = GL.CreateProgram();

            // Attach shader to the programe and link then.
            foreach (var i in shaders) GL.AttachShader(this.Handle, i.Handle);
            GL.LinkProgram(Handle);

            // Output shader program log.
            var info = GL.GetProgramInfoLog(Handle);
            if (!string.IsNullOrWhiteSpace(info))
                Debug.WriteLog($"GL.LinkProgram had info log: {info}", LogType.Warning, nameof(ShaderProgram));

            // Delete the shaders if wanted.
            if (deleteShaders)
                foreach (var i in shaders)
                {
                    GL.DetachShader(this.Handle, i.Handle);
                    i.Delete();
                }
        }

        public void Use()
        {
            GL.UseProgram(Handle);
        }

        public void Delete()
        {
            GL.DeleteProgram(Handle);
        }
    }
}
