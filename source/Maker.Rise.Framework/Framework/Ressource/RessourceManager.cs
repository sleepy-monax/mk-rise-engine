using Maker.Rise.Framework.Ressource.RessourceImporter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maker.Rise.Framework.Ressource
{
    public class RessourceManager : EngineComponent
    {
        public Dictionary<string, IRessource> ManagedRessources;
        private Dictionary<string, IRessourceImporter> Importers;
        private string RessourceFolderName = "assets";

        public RessourceManager()
        {
            ManagedRessources = new Dictionary<string, IRessource>();
            Importers = new Dictionary<string, IRessourceImporter>();
        }


        public override void Load()
        {
            AddImporter(new ModelImporter());
            AddImporter(new Texture2DImporter());
            AddImporter(new SoundImporter());
            AddImporter(new ShaderProgramImporter());
        }

        public override void Destroy()
        {
            foreach (var item in Importers)
            {
                Debugger.WriteLog($"Destroying '{item.Key}' importer.", LogType.Info, nameof(RessourceManager));
                item.Value.Destroy();
            }

            foreach (var item in ManagedRessources)
            {
                Debugger.WriteLog($"Destroying ressource: '{item.Key}'.", LogType.Info, nameof(RessourceManager));
                item.Value.Destroy();
            }
        }

        public T ImportRessource<T>(string ressourceID) where T : IRessource
        {
            if (!ManagedRessources.ContainsKey(ressourceID))
            {
                Debugger.WriteLog($"Importing : '{ressourceID}'...", LogType.Info, nameof(RessourceManager));
                string ressourceTypeName = ressourceID.Split(':')[0];
                IRessourceImporter importer = Importers[ressourceTypeName];
                IRessource ressource = importer.Import(this, $"{RessourceFolderName}/{ressourceTypeName}/{ressourceID.Split(':')[1]}");
                if (ressource != null)
                {
                    ManagedRessources[ressourceID] = ressource;
                }
                else
                {
                    throw new Exception($"Cannot import '{ressourceID}' with '{Importers}'. The importer return a 'null'!");
                }
            }

            return (T)ManagedRessources[ressourceID];
        }

        public void AddImporter(IRessourceImporter importer)
        {
            Importers.Add(importer.RessourceTypeName, importer);
            Directory.CreateDirectory($"{RessourceFolderName}/{importer.RessourceTypeName}");
        }
    }
}
