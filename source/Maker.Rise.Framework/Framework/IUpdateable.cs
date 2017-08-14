namespace Maker.Rise.Framework
{
    public interface IUpdateable
    {
        bool Enable { get; set; }
        void Update(float deltaTime);
    }
}
