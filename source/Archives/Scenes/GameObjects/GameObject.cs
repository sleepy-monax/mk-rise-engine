using Maker.Rise.Framework.Graphics.Models;
using Maker.Rise.Framework.Primitives;
using System;
using System.Collections.Generic;

namespace Maker.Rise.Framework.Scenes.GameObjects
{
    [Serializable]
    public sealed class GameObject : IDrawable, IUpdateable
    {
        [NonSerialized] public Scene ParentScene;
        [NonSerialized] private List<GameObjectComponent> Components;

        public bool Visible { get; set; }
        public bool Enable { get; set; }

        Transform Transform;
        Model Model;

        public GameObject(Transform transform, Model model)
        {
            Transform = transform; Model = model;

            Visible = true;
            Enable = true;
            Components = new List<GameObjectComponent>();
        }

        public void AddComponent(GameObjectComponent component)
        {
            component.Parent = this;
            component.Engine = ParentScene.Engine;
            Components.Add(component);
        }

        public T GetComponent<T>() where T : GameObjectComponent
        {
            foreach (GameObjectComponent c in Components)
                if (c.GetType().Equals(typeof(T)))
                    return (T)c;
            return null;
        }

        public List<GameObjectComponent> GetAllComponents()
        {
            return Components;
        }

        public void Update(float deltaTime)
        {
            foreach (GameObjectComponent i in Components)
            {
                if (i is IUpdateable u && u.Enable) u?.Update(deltaTime);
            }
        }

        public void Draw()
        {
            foreach (GameObjectComponent i in Components)
            {
                if (i is IDrawable u && u.Visible) u?.Draw();
            }
        }

        public void Destroy()
        {
            foreach (GameObjectComponent i in Components)
            {
                i.Unload();
            }
        }
    }
}
