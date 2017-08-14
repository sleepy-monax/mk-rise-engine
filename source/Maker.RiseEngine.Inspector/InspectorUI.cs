using Maker.Rise.Framework.Scenes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maker.Rise.Inspector
{
    public partial class InspectorUI : Form
    {
        public Scene Scene;

        public InspectorUI(Scene scene)
        {
            InitializeComponent();
            Scene = scene;
        }

        float divisor = 1000f;

        private void OnLoad(object sender, EventArgs e)
        {
            // Fog ------------------------------------------------------------
            FogDensity.Value = (int)(Scene.Fog.Density * divisor);
            FogDistance.Value = (int)(Scene.Fog.Distance * divisor);
            FogGradiant.Value = (int)(Scene.Fog.Gradiant * divisor);

            // Scene ----------------------------------------------------------
            SceneBrightness.Value = (int)(Scene.brightness * 100);
        }

        public void ShowInspector()
        {
            Show();
        }

        private void FogDistance_Scroll(object sender, EventArgs e)
        {
            Scene.Fog.Distance = FogDistance.Value / divisor;
        }

        private void FogDensity_Scroll(object sender, EventArgs e)
        {
            Scene.Fog.Density = FogDensity.Value / divisor;
        }

        private void FogGradiant_Scroll(object sender, EventArgs e)
        {
            Scene.Fog.Gradiant = FogGradiant.Value / divisor;
        }

        private void SceneBrightness_Scroll(object sender, EventArgs e)
        {
            Scene.brightness = SceneBrightness.Value / 100f;
        }
    }
}
