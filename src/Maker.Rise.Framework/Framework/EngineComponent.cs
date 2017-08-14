namespace Maker.Rise.Framework
{
    public abstract class EngineComponent
    {
        public Engine Engine { get; set; }
        public abstract void Load();
        public abstract void Destroy();
    }
}
