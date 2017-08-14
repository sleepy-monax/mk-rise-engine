using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maker.Rise.Framework.Ressources
{
    public interface IRessource
    {
        string Name { get; }
        void Load(string fileName);
        void Destroy();
    }
}
