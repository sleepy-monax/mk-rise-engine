using Maker.Rise.Framework.Graphics.Models;
using Maker.Rise.Framework.Graphics.Shaders;
using Maker.Rise.Framework.Scenes;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maker.Rise.Framework.Graphics.Batching
{
    public enum RenderMode { Line, Point, Triangle }
    public class RenderBatch
    {
        private Scene Scene;
        private Dictionary<Material, Dictionary<Model, List<Entity>>> BatchItems;
        private bool IsBegin = false;

        public RenderBatch()
        {
            BatchItems = new Dictionary<Material, Dictionary<Model, List<Entity>>>();
        }

        public void Begin(Scene scene, RenderMode mode = RenderMode.Triangle)
        {
            if (IsBegin)
            {
                throw new Exception("Rendering batch is already begun !");
            }
            else
            {
                Scene = scene;
                BatchItems.Clear();

                GL.Enable(EnableCap.CullFace);
                GL.CullFace(CullFaceMode.Back);

                IsBegin = true;
            }
        }

        public void Draw(Entity entity)
        {
            if (IsBegin)
            {
                // The batch is begin, evething fine.
                if (!BatchItems.ContainsKey(entity.Material))
                {
                    BatchItems.Add(entity.Material, new Dictionary<Model, List<Entity>>());
                }

                if (!BatchItems[entity.Material].ContainsKey(entity.Model))
                {
                    BatchItems[entity.Material].Add(entity.Model, new List<Entity>());
                }

                BatchItems[entity.Material][entity.Model].Add(entity);
            }
            else
            {
                // Ho ho.. The batch is't begin :/
                throw new Exception("Rendering batch is't begun !");
            }
        }

        public void End()
        {
            if (IsBegin)
            {
                GL.Enable(EnableCap.DepthTest);

                foreach (var materialAndModel in BatchItems)
                {
                    var material = materialAndModel.Key;
                    material.Bind();
                    Scene.Bind(material.Shader);

                    if (material.FaceCulling)
                    {
                        GL.Enable(EnableCap.CullFace);
                        GL.CullFace(CullFaceMode.Back);
                    }
                    else
                    {
                        GL.Disable(EnableCap.CullFace);
                    }

                    foreach (var modelAndEntity in materialAndModel.Value)
                    {
                        var model = modelAndEntity.Key;
                        model.VAO.Bind();

                        foreach (var entity in modelAndEntity.Value)
                        {

                            material.Shader.SetUniformVariable("entity_transform", entity.Transform.GetTransformationMatrix());
                            GL.PointSize(5f);
                            GL.DrawElements(BeginMode.Triangles, model.VertexCount, DrawElementsType.UnsignedInt, 0);
                        }

                        model.VAO.Unbind();
                    }
                }

                IsBegin = false;
            }
            else
            {
                throw new Exception("Rendering batch is't begun !");
            }
        }

    }
}
