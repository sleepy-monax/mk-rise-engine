using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maker.Rise.Framework.Ressources
{
    public class RessourcePool
    {

        private Dictionary<string, IRessource> RessourceCache;

        public RessourcePool()
        {
            RessourceCache = new Dictionary<string, IRessource>();
        }

        public void GetRessource<T>(string fileName) where T : IRessource
        {

        }

        private void LoadModel()
        {

        }

        private void LoadTexture()
        {

        }

        private void LoadMaterial()
        {

        }

        private void LoadShaderProgramme()
        {

        }
    }
}
