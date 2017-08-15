using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maker.Rise.Framework.Primitives.HeightMap
{
    public interface IHeightMap
    {

        float GetHeight(float x, float y);
        Vector3 GetNormal(float x, float y);

    }
}
