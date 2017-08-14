using Maker.Rise.Framework.Graphics;
using Maker.Rise.Framework.Graphics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maker.Rise.Framework.Scenes
{
    public class Entity
    {

        public Transform Transform { get; set; }
        public Model Model { get; set; }
        public Material Material { get; set; }

        public Entity(Transform transform, Model model, Material material)
        {
            Transform = transform;
            Model = model;
            Material = material;
        }

    }
}
