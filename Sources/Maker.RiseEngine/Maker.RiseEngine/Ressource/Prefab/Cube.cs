using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maker.RiseEngine.Primitive;
using Maker.RiseEngine.Graphic;

namespace Maker.RiseEngine.Ressource.Prefab
{
    public class Cube : Model
    {
        public Cube(Color color) : base()
        {
            float side = 0.5f;
            Vertex[] vertices =
            {
                new Vertex(-side, -side, -side, color),
                new Vertex(-side, -side,  side, color),
                new Vertex(-side,  side, -side, color),
                new Vertex(-side,  side, -side, color),
                new Vertex(-side, -side,  side, color),
                new Vertex(-side,  side,  side, color),
                new Vertex( side, -side, -side, color),
                new Vertex( side,  side, -side, color),
                new Vertex( side, -side,  side, color),
                new Vertex( side, -side,  side, color),
                new Vertex( side,  side, -side, color),
                new Vertex( side,  side,  side, color),
                new Vertex(-side, -side, -side, color),
                new Vertex( side, -side, -side, color),
                new Vertex(-side, -side,  side, color),
                new Vertex(-side, -side,  side, color),
                new Vertex( side, -side, -side, color),
                new Vertex( side, -side,  side, color),
                new Vertex(-side,  side, -side, color),
                new Vertex(-side,  side,  side, color),
                new Vertex( side,  side, -side, color),
                new Vertex( side,  side, -side, color),
                new Vertex(-side,  side,  side, color),
                new Vertex( side,  side,  side, color),
                new Vertex(-side, -side, -side, color),
                new Vertex(-side,  side, -side, color),
                new Vertex( side, -side, -side, color),
                new Vertex( side, -side, -side, color),
                new Vertex(-side,  side, -side, color),
                new Vertex( side,  side, -side, color),
                new Vertex(-side, -side,  side, color),
                new Vertex( side, -side,  side, color),
                new Vertex(-side,  side,  side, color),
                new Vertex(-side,  side,  side, color),
                new Vertex( side, -side,  side, color),
                new Vertex( side,  side,  side, color),
            };

            LoadVertices(vertices);
        }
    }
}
