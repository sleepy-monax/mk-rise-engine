namespace Maker.Rise.Framework
{
    interface IDrawable
    {
        bool Visible { get; set; }
        void Draw();
    }
}
