using NLua;

namespace Maker.Rise.Framework.Scenes.GameObjects
{
    public class LuaGameObjectComponent : GameObjectComponent, IDrawable, IUpdateable
    {
        public bool Visible { get; set; }
        public bool Enable { get; set; }

        public string ScriptePath { get; private set; }
        Lua Stats;

        public LuaGameObjectComponent(string scriptPath)
        {
            Stats = new Lua();
            Stats.DoFile(scriptPath);
        }

        public void Draw()
        {
            Stats.GetFunction("on_draw").Call();
        }

        public override void Load()
        {
            Stats["engine"] = this.Engine;
            Stats["parent"] = this.Parent;

            Stats.GetFunction("on_load").Call();
        }

        public override void Unload()
        {
            Stats.GetFunction("on_unload").Call();
        }

        public void Update(float deltaTime)
        {
            Stats.GetFunction("on_update").Call(deltaTime);
        }
    }
}
