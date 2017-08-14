namespace Maker.Rise.Framework.Graphics
{
    public sealed class Color4
    {
        public byte Red { get; set; } = 0;
        public byte Green { get; set; } = 0;
        public byte Blue { get; set; } = 0;
        public byte Alpha { get; set; } = 0;

        public Color4(byte brightness)
        {
            Red = brightness;
            Green = brightness;
            Blue = brightness;
            Alpha = 255;
        }

        public Color4(byte red, byte green, byte blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
            Alpha = 255;
        }

        public Color4(byte red, byte green, byte blue, byte alpha)
        {
            Red = red;
            Green = green;
            Blue = blue;
            Alpha = alpha;
        }
    }
}
