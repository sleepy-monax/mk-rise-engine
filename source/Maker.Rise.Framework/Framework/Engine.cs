using Maker.Rise.Framework.Audio;
using Maker.Rise.Framework.Graphics;
using Maker.Rise.Framework.Graphics.Models;
using Maker.Rise.Framework.Input;
using Maker.Rise.Framework.Primitives;
using Maker.Rise.Framework.Texture;
using System.Collections.Generic;

namespace Maker.Rise.Framework
{
    public sealed class Engine
    {
        public GameHost GraphicDevice { get; set; }
        private List<EngineComponent> Components { get; set; } = new List<EngineComponent>();
        private Game Game;

        public Engine(Game game)
        {
            Game = game;

            GraphicDevice = new GameHost();
            GraphicDevice.Load += Load;
            GraphicDevice.Update += Update;
            GraphicDevice.Draw += Draw;
            GraphicDevice.Unload += Destroy;
        }

        public Engine(GameHost graphicDevice, Game game)
        {
            Game = game;
            GraphicDevice = graphicDevice;
            GraphicDevice.Load += Load;
            GraphicDevice.Update += Update;
            GraphicDevice.Draw += Draw;
            GraphicDevice.Unload += Destroy;
        }

        #region ComponentManager
        public void AddComponent(EngineComponent component)
        {
            Components.Add(component);
            component.Engine = this;
            component.Load();
        }

        public T GetComponent<T>() where T : EngineComponent
        {
            foreach (EngineComponent goc in Components)
                if (goc.GetType().Equals(typeof(T)))
                    return (T)goc;
            return null;
        }
        #endregion

        public void Start()
        {
            GraphicDevice.StartRenderLoop(120);
        }

        public void Stop()
        {
            GraphicDevice.StopGameLoop();
        }

        public void Load()
        {
            GraphicDevice.SetBufferSize(new Point2D(800, 600));
            AddComponent(new TextureImporter());
            AddComponent(new AudioManager());
            AddComponent(new ModelImporter());
            AddComponent(new InputManager(GraphicDevice));

            Game.Engine = this;
            Game.Load();
            GraphicDevice.SetTitle(Game.Name);
        }

        public void Update(float deltaTime)
        {
            foreach (EngineComponent i in Components)
            {
                if (i is IUpdateable u && u.Enable) u?.Update(deltaTime);
            }
            Game.Update(deltaTime);
        }

        public void Draw()
        {
            foreach (EngineComponent components in Components)
            {
                if (components is IDrawable u && u.Visible) u?.Draw();
            }
            Game.Draw();
        }

        public void Destroy()
        {
            foreach (EngineComponent i in Components) i.Destroy();

            Game.Unload();
        }
    }
}
