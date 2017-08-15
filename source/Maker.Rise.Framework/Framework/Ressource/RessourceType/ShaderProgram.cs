using Maker.Rise.Framework.Graphics;
using Maker.Rise.Framework.Primitives;
using OpenTK;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;

namespace Maker.Rise.Framework.Ressource.RessourceType
{
    public class VertexArrayAttributeBinding
    {
        public string UniformName { get; set; }
        public int Index { get; set; }

        public VertexArrayAttributeBinding()
        {
        }

        public VertexArrayAttributeBinding(string name, int index)
        {
            UniformName = name;
            Index = index;
        }

    }

    public class ShaderProgram : IRessource
    {

        private int Handle { get; set; } = -1;
        private int VertexShaderHandle { get; set; } = -1;
        private int FragmentShaderHandle { get; set; } = -1;
        string IRessource.Name { get; set; }

        private Dictionary<string, int> UniformVariableHandleCache = new Dictionary<string, int>();

        public ShaderProgram(string vertexShaderCode, string fragmentShaderCode, VertexArrayAttributeBinding[] attributes)
        {
            Handle = GL.CreateProgram();
            VertexShaderHandle = BuildShader(vertexShaderCode, ShaderType.VertexShader);
            FragmentShaderHandle = BuildShader(fragmentShaderCode, ShaderType.FragmentShader);

            GL.AttachShader(Handle, VertexShaderHandle);
            GL.AttachShader(Handle, FragmentShaderHandle);

            foreach (var a in attributes)
            {
                BindAttribute(a.Index, a.UniformName);
            }

            GL.LinkProgram(Handle);
            GL.ValidateProgram(Handle);
        }

        private int BuildShader(string shaderCode, ShaderType type)
        {
            if (string.IsNullOrWhiteSpace(shaderCode))
            {
                Debugger.WriteLog($"No shader to compile {type}", LogType.Error, nameof(ShaderProgram));
                return -1;
            }

            try
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
            catch (Exception ex)
            {
                Debugger.WriteLog("compiling shader failed ! :" + ex.ToString(), LogType.Error, nameof(ShaderProgram));
            }

            return -1;
        }

        private void BindAttribute(int vaoIndex, string name)
        {
            GL.BindAttribLocation(Handle, vaoIndex, name);
        }

        private int GetUniformVariable(string name)
        {
            if (!UniformVariableHandleCache.ContainsKey(name))
            {
                UniformVariableHandleCache[name] = GL.GetUniformLocation(Handle, name);
            }

            return UniformVariableHandleCache[name];
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

        #region Set Uniform Variable
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

        public void SetUniformVariable(string name, Vector3D value)
        {
            int uniformHandle = GetUniformVariable(name);
            Vector3 vec = new Vector3(value.X, value.Y, value.Z);
            GL.Uniform3(uniformHandle, ref vec);
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

        internal void SetUniformVariable(string name, bool value)
        {
            int uniformHandle = GetUniformVariable(name);
            GL.Uniform1(uniformHandle, Convert.ToInt32(value));
        }

        #endregion
    }
}
