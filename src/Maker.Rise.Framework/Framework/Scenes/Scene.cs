using Maker.Rise.Framework.Graphics;
using Maker.Rise.Framework.Graphics.Shaders;
using Maker.Rise.Framework.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maker.Rise.Framework.Scenes
{
    public class Scene
    {
        public StaticCamera Camera { get; set; }
        public Sun Sun { get; set; }
        public Fog Fog { get; set; }

        // Properties ---------------------------------------------------------
        public float brightness = 0.5f;

        public Scene()
        {
            Camera = new StaticCamera(1);
            Sun = new Sun(new Point3D(0f, 150f, 0f), new Color3(255));
            Fog = new Fog();
        }

        public Scene(StaticCamera camera, Sun sun)
        {
            Camera = camera;
            Sun = sun;
            Fog = new Fog();
        }

        public void Bind(ShaderProgram shader)
        {
            // Camera ---------------------------------------------------------
            shader.SetUniformVariable("projection_matrix", Camera.GetProjectionMatrix());
            shader.SetUniformVariable("view_matrix", Camera.GetViewMatrix());

            // Sun ------------------------------------------------------------
            shader.SetUniformVariable("sun_position", Sun.Position);
            shader.SetUniformVariable("sun_color", Sun.Color);

            // Fog ------------------------------------------------------------
            shader.SetUniformVariable("fog_density", Fog.Density);
            shader.SetUniformVariable("fog_gradiant", Fog.Gradiant);
            shader.SetUniformVariable("fog_distance", Fog.Distance);
            shader.SetUniformVariable("fog_color", Fog.Color);

            // Scene ----------------------------------------------------------
            shader.SetUniformVariable("scene_brightness", brightness);
        }
    }
}
