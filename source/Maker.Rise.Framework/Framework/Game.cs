namespace Maker.Rise.Framework
{
    public abstract class Game
    {
        public Engine Engine { get; set; }
        public string Name { get; set; } = "Game";

        public abstract void Load();
        public abstract void Unload();
        public abstract void Draw();
        public abstract void Update(float deltaTime);
    }
}
