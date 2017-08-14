using System.Collections.Generic;

namespace Maker.Rise.Framework.Scenes
{
    public class SceneManager : EngineComponent, IUpdateable, IDrawable
    {
        public bool Enable { get; set; }
        public bool Visible { get; set; }

        private List<Scene> loadedScene;
        private List<Scene> deletedScene;
        public List<Scene> activeScene;

        public void ShowScene(Scene scene)
        {
            loadedScene.Add(scene);
            Debugger.WriteLog($"'{scene.GetType().Name}' added.", LogType.Info, nameof(SceneManager));
        }

        public void RemoveScene(Scene scene)
        {
            deletedScene.Add(scene);
        }

        public void Draw()
        {
            foreach (Scene s in activeScene)
            {
                s.Draw();
            }
        }

        public override void Load()
        {
            loadedScene = new List<Scene>();
            deletedScene = new List<Scene>();
            activeScene = new List<Scene>();

            this.Visible = true;
            this.Enable = true;
        }

        public override void Destroy()
        {
            
        }

        public void Update(float deltaTime)
        {
            foreach (Scene s in deletedScene)
            {
                s.Destroy();
                activeScene.Remove(s);
            }

            deletedScene.Clear();

            foreach (Scene s in loadedScene)
            {
                s.Engine = Engine;
                s.Load();
                activeScene.Add(s);
            }

            loadedScene.Clear();

            foreach (Scene s in activeScene)
            {
                s.Update(deltaTime);
            }
        }
    }
}
