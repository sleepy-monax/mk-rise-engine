using Maker.Rise.Framework.Ressource.Json;
using Maker.Rise.Framework.Ressource.RessourceType;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maker.Rise.Framework.Ressource.RessourceImporter
{
    public class ShaderProgramFile
    {
        public VertexArrayAttributeBinding[] VertexArrayAttributBinding { get; set; }
        public string VertexShaderName { get; set; }
        public string FragmentShaderName { get; set; }
    }

    public class ShaderProgramImporter : IRessourceImporter
    {
        public string RessourceTypeName => "shader";

        public void Destroy()
        {

        }

        public IRessource Import(RessourceManager ressourceManager, string fileName)
        {
            ShaderProgramFile shaderProgrameFile = File.ReadAllText(fileName).FromJson<ShaderProgramFile>();
            string vertexShaderCode = File.ReadAllText($"{Path.GetDirectoryName(fileName)}/{shaderProgrameFile.VertexShaderName}");
            string fradmentShaderCode = File.ReadAllText($"{Path.GetDirectoryName(fileName)}/{shaderProgrameFile.FragmentShaderName}");


            return new ShaderProgram(vertexShaderCode, fradmentShaderCode, shaderProgrameFile.VertexArrayAttributBinding);
        }
    }
}
