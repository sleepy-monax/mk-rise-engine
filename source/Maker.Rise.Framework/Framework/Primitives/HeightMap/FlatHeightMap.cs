using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maker.Rise.Framework.Primitives.HeightMap
{
    public class FlatHeightMap : IHeightMap
    {
        public float GetHeight(float x, float y)
        {
            return 0;
        }

        public Vector3 GetNormal(float x, float y)
        {
            return new Vector3(0f, 1f, 0f);
        }
    }
}
