using Maker.Rise.Framework.Scenes.GameObjects;
using System;
using System.Collections.Generic;

namespace Maker.Rise.Framework.Scenes
{
    public class Scene : IUpdateable, IDrawable
    {
        public Engine Engine;
        public bool Enable { get; set; }
        public bool Visible { get; set; }

        private List<GameObject> LoadedGameObjects;
        private List<GameObject> DeletedGameObjects;
        private List<GameObject> ActiveGameObjects;

        public void AddGameObject(GameObject gameObject)
        {
            LoadedGameObjects.Add(gameObject);
            gameObject.ParentScene = this;
        }

        public void RemoveGameObject(GameObject gameObject)
        {
            DeletedGameObjects.Add(gameObject);
            gameObject.Destroy();
        }

        public List<GameObject> GetAllActiveGameObjects()
        {
            return ActiveGameObjects;
        }

        public void Load()
        {
            LoadedGameObjects = new List<GameObject>();
            DeletedGameObjects = new List<GameObject>();
            ActiveGameObjects = new List<GameObject>();
            OnLoad();
        }

        public virtual void OnLoad()
        {

        }

        public void Draw()
        {
            OnDrawBegin();
            foreach (GameObject gobj in ActiveGameObjects)
            {
                if (gobj.Visible)
                {
                    gobj.Draw();
                }
            }
            OnDrawEnd();
        }

        public virtual void OnDrawBegin() { }
        public virtual void OnDrawEnd() { }

        public void Update(float deltaTime)
        {
            foreach (GameObject gobj in DeletedGameObjects)
            {
                ActiveGameObjects.Remove(gobj);
            }

            DeletedGameObjects.Clear();

            foreach (GameObject gobj in LoadedGameObjects)
            {
                ActiveGameObjects.Add(gobj);
            }

            LoadedGameObjects.Clear();

            foreach (GameObject gobj in ActiveGameObjects)
            {
                if (gobj.Enable)
                    gobj.Update(deltaTime);
            }

            OnUpdate(deltaTime);
        }

        public virtual void OnUpdate(float deltaTime)
        {

        }

        public void Destroy()
        {
            OnDestroy();

            Enable = false;
            Visible = false;

            foreach (GameObject gobj in ActiveGameObjects)
            {
                gobj.Destroy();
            }

            foreach (GameObject gobj in LoadedGameObjects)
            {
                gobj.Destroy();
            }

            ActiveGameObjects.Clear();
            LoadedGameObjects.Clear();
            DeletedGameObjects.Clear();

            ActiveGameObjects = null;
            LoadedGameObjects = null;
            DeletedGameObjects = null;

            GC.Collect();
        }

        public virtual void OnDestroy()
        {

        }
    }
}
