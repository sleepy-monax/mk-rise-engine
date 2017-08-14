namespace Maker.Rise.Framework.Scenes.GameObjects
{
    public abstract class GameObjectComponent
    {
        public GameObject Parent;
        public Engine Engine;

        public abstract void Load();
        public abstract void Unload();
    }
}
