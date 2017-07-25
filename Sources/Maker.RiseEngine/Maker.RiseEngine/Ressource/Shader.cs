using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using System.IO;

namespace Maker.RiseEngine.Ressource
{
    public enum ShaderType
    {
        FragmentShader = 35632,
        VertexShader = 35633,
        GeometryShader = 36313,
        TessEvaluationShader = 36487,
        TessControlShader = 36488,
        ComputeShader = 37305
    }
    public class Shader
    {
        public int Handle { get; private set; }

        public Shader(string shaderPath, ShaderType shaderType)
        {
            Debug.WriteLog($"Compiling <{shaderType}>'{shaderPath}'", LogType.Info, nameof(Shader));
            Handle = GL.CreateShader((OpenTK.Graphics.OpenGL4.ShaderType)shaderType);
            GL.ShaderSource(Handle, File.ReadAllText(shaderPath));
            GL.CompileShader(Handle);
            var info = GL.GetShaderInfoLog(Handle);
            if (!string.IsNullOrWhiteSpace(info))
                Debug.WriteLog($"GL.CompileShader [{shaderType}] had info log: {info}", LogType.Warning, nameof(Shader));
        }

        public void Delete()
        {
            GL.DeleteShader(Handle);
        }
    }
}
