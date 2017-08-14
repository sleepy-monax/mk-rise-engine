using Maker.Rise.Framework.Graphics;
using Maker.Rise.Framework.Graphics.Batching;
using Maker.Rise.Framework.Graphics.Models;
using Maker.Rise.Framework.Graphics.Shaders;
using Maker.Rise.Framework.Input;
using Maker.Rise.Framework.Primitives;
using Maker.Rise.Framework.Texture;
using Maker.Rise.Framework.Scenes;
using OpenTK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
namespace Maker.Rise.Framework.Exemple
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            new Engine(new TestGame()).Start();
        }
    }

    public class TestGame : Game
    {
        RenderBatch render;
        OrbitalCamera camera;
        Scene testScene;
        Sun testSun;
        Entity terrain;
        List<Entity> Entities;

        public override void Load()
        {
            // Engine components.
            ModelImporter modelImporter = Engine.GetComponent<ModelImporter>();
            TextureImporter textureImporter = Engine.GetComponent<TextureImporter>();


            // Setup the scene
            Entities = new List<Entity>();
            camera = new OrbitalCamera(Engine.GraphicDevice.GetBufferSize().X / Engine.GraphicDevice.GetBufferSize().Y, 90);
            render = new RenderBatch();
            testSun = new Sun(new Point3D(-150f, 150f, -150f), new Color3(255, 255, 255));
            testScene = new Scene(camera, testSun);
            testScene.Fog.Density = 0f;

            // Show the inspector.
            new Inspector.InspectorUI(testScene).ShowInspector();

            Model grassModel = modelImporter.GetModel("Assets/grassModel.obj");
            Material grassMaterial = new Material(textureImporter.GetTexture2D("Assets/grassTexture.png"))
            {
                Reflectivity = 0.1f,
                ShineDamper = 10f,
                OverideNormals = true,
                Transparency = true,
                FaceCulling = false
            };

            Model fernModel = modelImporter.GetModel("Assets/fern.obj");

            Material fernMaterial = new Material(textureImporter.GetTexture2D("Assets/fern.png"))
            {
                Reflectivity = 0.1f,
                ShineDamper = 10f,
                Transparency = true,
                FaceCulling = false
            };

            // Dragon
            Model dragonModel = modelImporter.GetModel("Assets/dragon.obj");
            Material dragonMaterial = new Material(textureImporter.GetTexture2D("Assets/texture.png"));
            dragonMaterial.Reflectivity = 1f;
            dragonMaterial.ShineDamper = 10f;
            Entities.Add(new Entity(new Transform(new Vector3(0, 0, 0), new Vector3(), 0.1f), dragonModel, dragonMaterial));

            // Terrain
            Material GrassMaterial = new Material(textureImporter.GetTexture2D("Assets/grass.png"))
            {
                Reflectivity = 0f,
                ShineDamper = 10f
            };
            terrain = new Entity(new Transform(-32f, 0, -32f), ModelFactorie.GeneratePlane(64f, 256, 64), GrassMaterial);

            Random rnd = new Random();
            for (int i = 0; i < 200; i++)
            {
                Entity e = null;
                Transform t = new Transform((float)rnd.NextDouble() * 64f - 32f, 0f, (float)rnd.NextDouble() * 64f - 32f);

                switch (rnd.Next(0, 2))
                {
                    case 0:
                        t.Scale = 0.25f;
                        e = new Entity(t, grassModel, grassMaterial);
                        break;
                    case 1:
                        t.Scale = 0.1f;
                        e = new Entity(t, fernModel, fernMaterial);
                        break;
                }

                Entities.Add(e);
            }


        }


        public override void Unload()
        {

        }

        public override void Update(float deltaTime)
        {
            camera.AspectRacio = Engine.GraphicDevice.GetBufferSize().X / Engine.GraphicDevice.GetBufferSize().Y;
            InputManager input = Engine.GetComponent<InputManager>();
            camera.Move(input);
            if (input.IsKeyBoardKeyDown(KeyboardKey.W)) { camera.Focus.Z += 0.1f; }
            if (input.IsKeyBoardKeyDown(KeyboardKey.S)) { camera.Focus.Z -= 0.1f; }
            if (input.IsKeyBoardKeyDown(KeyboardKey.A)) { camera.Focus.X += 0.1f; }
            if (input.IsKeyBoardKeyDown(KeyboardKey.D)) { camera.Focus.X -= 0.1f; }
        }

        float value = 0f;

        public override void Draw()
        {
            Engine.GraphicDevice.Clear(new Color3(100, 149, 237));


            render.Begin(testScene);
            render.Draw(terrain);
            foreach (var item in Entities)
            {
                render.Draw(item);
            }

            render.End();

            Engine.GraphicDevice.SwapBuffers();
            value += 0.01f;
        }
    }


}
