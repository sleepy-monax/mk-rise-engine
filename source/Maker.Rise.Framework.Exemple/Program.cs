using Maker.Rise.Framework.Graphics;
using Maker.Rise.Framework.Input;
using Maker.Rise.Framework.Primitives;
using Maker.Rise.Framework.Primitives.HeightMap;
using Maker.Rise.Framework.Ressource;
using Maker.Rise.Framework.Ressource.Json;
using Maker.Rise.Framework.Ressource.RessourceImporter;
using Maker.Rise.Framework.Ressource.RessourceType;
using Maker.Rise.Framework.Scenes;
using Maker.Rise.Framework.Scenes.Camera;
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
            Console.ReadKey();
        }
    }

    public class TestGame : Game
    {
        RenderBatch render;
        OrbitalCamera camera;
        Scene testScene;
        Sun testSun;
        Entity terrain;
        Entity water;
        List<Entity> Entities;

        public override void Load()
        {
            // Engine components.
            RessourceManager ressourceManager = Engine.GetComponent<RessourceManager>();


            // Setup the scene
            Entities = new List<Entity>();
            camera = new OrbitalCamera(Engine.GraphicDevice.GetBufferSize().X / Engine.GraphicDevice.GetBufferSize().Y, 90);
            render = new RenderBatch();
            testSun = new Sun(new Point3D(-150f, 150f, -150f), new Color3(255, 255, 255));
            testScene = new Scene(camera, testSun);
            testScene.Fog.Density = 0f;

            // Dragon
            Model dragonModel = ressourceManager.ImportRessource<Model>("model:dragon.obj");
            Material dragonMaterial = new Material(ressourceManager.ImportRessource<Texture2D>("texture2D:blue.png"));
            dragonMaterial.Reflectivity = 1f;
            dragonMaterial.ShineDamper = 10f;
            ressourceManager.ImportRessource<ShaderProgram>("shader:material.json");
            Entities.Add(new Entity(new Transform(new Vector3(0, 0, 0), new Vector3(), 0.1f), dragonModel, dragonMaterial));

            // Terrain
            Material GrassMaterial = new Material(ressourceManager.ImportRessource<Texture2D>("texture2D:grass.png"))
            {
                Reflectivity = 0f,
                ShineDamper = 10f
            };
            terrain = new Entity(new Transform(0, -10f, 0), ModelFactorie.GeneratePlane(640f, 256, 64, new PerlinHeightMap()), GrassMaterial);
            water = new Entity(new Transform(0, 0, 0), ModelFactorie.GeneratePlane(640f, 16, 64, new FlatHeightMap()), dragonMaterial);


            // Show the inspector.
            new Inspector.InspectorUI(Engine, testScene).ShowInspector();
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
            if (input.IsKeyBoardKeyDown(KeyboardKey.W)) { camera.Focus.Z += 0.1f; }
            if (input.IsKeyBoardKeyDown(KeyboardKey.Space)) { camera.Focus.Y += 0.1f; }
            if (input.IsKeyBoardKeyDown(KeyboardKey.LShift)) { camera.Focus.Y -= 0.1f; }
        }

        float value = 0f;

        public override void Draw()
        {
            Engine.GraphicDevice.Clear(new Color3(100, 149, 237));


            render.Begin(testScene);
            render.Draw(terrain);
            render.Draw(water);
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
