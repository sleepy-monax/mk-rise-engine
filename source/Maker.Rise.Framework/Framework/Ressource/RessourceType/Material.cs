using Maker.Rise.Framework.Primitives;
using Maker.Rise.Properties;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maker.Rise.Framework.Ressource.RessourceType
{
    public class Material : IRessource
    {
        public string Name { get; set; }

        private Texture2D DifuseMap;
        public ShaderProgram Shader;

        public float ShineDamper { get; set; } = 0f;
        public float Reflectivity { get; set; } = 0f;
        public bool FaceCulling { get; set; } = true;
        public bool Transparency { get; set; } = false;
        public bool OverideNormals { get; set; } = false;
        public Vector3D MaterialNormal { get; set; } = new Vector3D(0f, 1f, 0f);

        public Material(Texture2D difuseMap, ShaderProgram shaderProgram)
        {
            DifuseMap = difuseMap;
            Shader = shaderProgram;
        }

        /// <summary>
        /// Create a new material using the embeded shader.
        /// </summary>
        /// <param name="diffuseMap"></param>
        public Material(Texture2D diffuseMap)
        {
            DifuseMap = diffuseMap;
            Shader = new ShaderProgram(Resources.BaseMaterialVertShader, Resources.BaseMaterialFragShader, new VertexArrayAttributeBinding[] { new VertexArrayAttributeBinding("position", 0), new VertexArrayAttributeBinding("texture_coordinates", 1), new VertexArrayAttributeBinding("normals", 2) });
        }

        public void Bind()
        {
            GL.ActiveTexture(TextureUnit.Texture0);
            DifuseMap.Bind();
            Shader.Use();
            Shader.SetUniformVariable("material_reflectivity", Reflectivity);
            Shader.SetUniformVariable("material_shine_damper", ShineDamper);
            Shader.SetUniformVariable("material_transparency", Transparency);
            Shader.SetUniformVariable("material_overide_normals", OverideNormals);
            Shader.SetUniformVariable("material_normal", MaterialNormal);
        }

        public void Unbind()
        {
            Shader.Stop();
        }

        public void Destroy()
        {
            throw new NotImplementedException();
        }
    }
}
