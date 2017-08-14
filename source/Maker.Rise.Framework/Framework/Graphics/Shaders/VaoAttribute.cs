using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maker.Rise.Framework.Graphics.Shaders
{
    public class VaoAttribute
    {
        public string Name { get; private set; }
        public int Handle { get; private set; }
        public VaoAttribute(string name, int index)
        {
            Name = name;
            Handle = index;
        }

    }
}
