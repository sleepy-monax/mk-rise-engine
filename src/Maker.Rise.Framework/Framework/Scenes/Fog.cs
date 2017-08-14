using Maker.Rise.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maker.Rise.Framework.Scenes
{
    public class Fog
    {
        public float Density { get; set; } = 1f;
        public float Gradiant { get; set; } = 1f;
        public float Distance { get; set; } = 1f;
        public Color3 Color { get; set; } = new Color3(100, 149, 237);
    }
}
