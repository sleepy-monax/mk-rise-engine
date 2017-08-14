using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using OpenTK;
using Maker.Rise.Framework.Primitives;

namespace Maker.Rise.Framework.Graphics.Shaders
{
    public class ShaderProgram
    {

        public int Handle { get; set; } = -1;
        public int VertexShaderHandle { get; set; } = -1;
        public int FragmentShaderHandle { get; set; } = -1;

        private Dictionary<string, int> UniformVariableHandle = new Dictionary<string, int>();

        public ShaderProgram(string vertexShaderCode, string fragmentShaderCode, VaoAttribute[] attributes)
        {
            Handle = GL.CreateProgram();
            VertexShaderHandle = BuildShader(vertexShaderCode, ShaderType.VertexShader);
            FragmentShaderHandle = BuildShader(fragmentShaderCode, ShaderType.FragmentShader);

            GL.AttachShader(Handle, VertexShaderHandle);
            GL.AttachShader(Handle, FragmentShaderHandle);

            foreach (var a in attributes)
            {
                BindAttribute(a.Handle, a.Name);
            }

            GL.LinkProgram(Handle);
            GL.ValidateProgram(Handle);
        }

        private int BuildShader(string shaderCode, ShaderType type)
        {
            int shaderHandle = GL.CreateShader(type);
            GL.ShaderSource(shaderHandle, shaderCode);
            GL.CompileShader(shaderHandle);
            var buildLog = GL.GetShaderInfoLog(shaderHandle);

            if (!string.IsNullOrEmpty(buildLog))
            {
                Debugger.WriteLog(buildLog, LogType.Info, "Shader Compiller");
            }

            return shaderHandle;
        }

        internal void SetUniformVariable(string name, bool value)
        {
            int uniformHandle = GetUniformVariable(name);
            GL.Uniform1(uniformHandle, Convert.ToInt32(value));
        }

        private void BindAttribute(int vaoIndex, string name)
        {
            GL.BindAttribLocation(Handle, vaoIndex, name);
        }

        public void SetUniformVariable(string name, Matrix4 value)
        {
            int uniformHandle = GetUniformVariable(name);
            GL.UniformMatrix4(uniformHandle, false, ref value);
        }

        public void SetUniformVariable(string name, float value)
        {
            int uniformHandle = GetUniformVariable(name);
            GL.Uniform1(uniformHandle, value);
        }

        public void SetUniformVariable(string name, Vector3 value)
        {
            int uniformHandle = GetUniformVariable(name);
            GL.Uniform3(uniformHandle, ref value);
        }

        public void SetUniformVariable(string name, Point3D value)
        {
            int uniformHandle = GetUniformVariable(name);
            Vector3 vec = new Vector3(value.X, value.Y, value.Z);
            GL.Uniform3(uniformHandle, ref vec);
        }

        public void SetUniformVariable(string name, Color4 color)
        {
            int uniformHandle = GetUniformVariable(name);
            Vector4 vec = new Vector4(color.Red, color.Green, color.Blue, color.Alpha);
            GL.Uniform4(uniformHandle, ref vec);
        }

        internal void SetUniformVariable(string name, Color3 color)
        {
            int uniformHandle = GetUniformVariable(name);
            Vector3 vec = new Vector3(color.Red / 255f, color.Green / 255f, color.Blue / 255f);
            GL.Uniform3(uniformHandle, ref vec);
        }

        private int GetUniformVariable(string name)
        {
            if (!UniformVariableHandle.ContainsKey(name))
            {
                UniformVariableHandle[name] = GL.GetUniformLocation(Handle, name);
            }

            return UniformVariableHandle[name];
        }

        public void Use()
        {
            GL.UseProgram(Handle);
        }

        public void Stop()
        {
            GL.UseProgram(0);
        }

        public void Destroy()
        {
            Stop();
            GL.DetachShader(Handle, VertexShaderHandle);
            GL.DetachShader(Handle, FragmentShaderHandle);
            GL.DeleteShader(VertexShaderHandle);
            GL.DeleteShader(FragmentShaderHandle);
            GL.DeleteProgram(Handle);
        }
    }
}
