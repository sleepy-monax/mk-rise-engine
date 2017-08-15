using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maker.Rise.Framework.Ressource
{
    public interface IRessourceImporter
    {
        string RessourceTypeName { get; }
        IRessource Import(RessourceManager ressourceManager, string fileName);
        void Destroy();

    }
}
