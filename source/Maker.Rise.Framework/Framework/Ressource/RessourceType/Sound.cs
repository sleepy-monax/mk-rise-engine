using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maker.Rise.Framework.Ressource.RessourceType
{
    public class Sound : IRessource
    {
        public string Name { get ; set ; }

        public void Destroy()
        {
            throw new NotImplementedException();
        }
    }
}
