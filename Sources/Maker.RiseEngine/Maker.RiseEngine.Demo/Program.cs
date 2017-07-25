using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maker.RiseEngine;
using Maker.RiseEngine.Graphic;
using Maker.RiseEngine.Ressource;
using Maker.RiseEngine.Primitive;
using Maker.RiseEngine.Ressource.Prefab;

namespace Maker.RiseEngine.Demo
{
    public class Program
    {
        public static ShaderProgram prog;
        public static Model Triangle;
        static void Main(string[] args)
        {
            GameWindow g = new GameWindow(800, 600, "Rise Engine Demo", false);
            g.Update += G_Update;
            g.Draw += G_Draw;
            g.Load += G_Load;
            g.Show(60);
        }

        private static void G_Load(object sender, EventArgs e)
        {
            prog = new ShaderProgram(true, new Shader("Assets\\Shaders\\FragmentShader.frag.glsl", ShaderType.FragmentShader), new Shader("Assets\\Shaders\\VertexShader.vert.glsl", ShaderType.VertexShader));
            Triangle = new Cube(new Color(0,1,0,1));
        }

        private static void G_Draw(object sender, GameWindowDrawEventArgs e)
        {
            ((GameWindow)sender).Clear(new Color(0, 0, 0, 0));
            prog.Use();
            //Graphic.Primitive.DrawPoint(new Primitive.Point2D(10, 10), 10, new Color(0, 255, 0, 0));
            //Graphic.Primitive.DrawPoint(new Primitive.Point2D(-10, -10), 1, new Color(0, 255, 0, 0));
            Triangle.Draw(e.DeltaTime);
            ((GameWindow)sender).SwapBuffer();
        }

        private static void G_Update(object sender, GameWindowUpdateEventArgs e)
        {
           
        }
    }
}
