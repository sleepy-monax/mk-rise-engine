using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maker.Rise.Framework.Ressource.RessourceImporter
{
    class MaterialDescriptionFile
    {



    }

    class MaterialImporter : IRessourceImporter
    {
        public string RessourceTypeName => "material";

        public void Destroy()
        {

        }

        public IRessource Import(RessourceManager ressourceManager, string fileName)
        {
            return null;
        }
    }
}
