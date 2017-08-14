using Maker.Rise.Editor.Documents;
using System;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Maker.Rise.Editor
{
    public partial class MainEditor : Form
    {

        public GamePreview gamePreview;
        public Inspector gameInspector;
        public ProjectExplorer explorer;
        public string ProjectPath;

        public MainEditor()
        {
            InitializeComponent();
            gamePreview = new GamePreview(this);
            gameInspector = new Inspector(this);
            explorer = new ProjectExplorer(this);
        }

        public void LoadProject(string projectPath)
        {
            ProjectPath = projectPath;

            gamePreview.Show(DockHost, DockState.DockLeft);
            gameInspector.Show(DockHost, DockState.DockRight);
            gameInspector.propertyGrid1.SelectedObject = gamePreview.GameEngine;
            explorer.Show(DockHost, DockState.DockRight);
            explorer.LoadFolder("test", projectPath);
        }

        private void projectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MainForm(this).ShowDialog();
        }
    }
}
