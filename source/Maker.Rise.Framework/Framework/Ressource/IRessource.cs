using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maker.Rise.Framework.Ressource
{
    public interface IRessource
    {

        string Name { get; set; }
        void Destroy();

    }
}
