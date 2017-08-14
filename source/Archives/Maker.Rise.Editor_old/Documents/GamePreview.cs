using Maker.Rise.Framework;
using Maker.Rise.Framework.Graphics;
using OpenTK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Maker.Rise.Editor.Documents
{
    public partial class GamePreview : DockContent
    {
        public Engine GameEngine;
        public System.Windows.Forms.Timer ReshTimer;
        private MainEditor mainEditor;

        public GamePreview(MainEditor mainEditor)
        {
            InitializeComponent();
            this.mainEditor = mainEditor;
            ReshTimer = new System.Windows.Forms.Timer();
            ReshTimer.Interval = 1000 / 60;
            ReshTimer.Tick += ReshTimer_Tick;
        }

        private void ReshTimer_Tick(object sender, EventArgs e)
        {
            glHost.Refresh();
        }

        private void GamePreview_Load(object sender, EventArgs e)
        {

        }


        public void StartGame(bool windowed = false)
        {

            runToolStripMenuItem.Enabled = false;
            runWindowedToolStripMenuItem.Enabled = false;
            stopToolStripMenuItem.Enabled = true;
            mainEditor.gameInspector.Enabled = true;

            if (windowed)
            {
                Text = "Game (Running windowed)";
                new Thread(new ThreadStart(delegate ()
                {
                    GameEngine = new Engine(new GraphicDevice(new GameWindow()));
                    GameEngine.Start();
                    this.Invoke(new Action( () => StopGame()));
                    GC.Collect();
                })).Start();
            }
            else
            {
                Text = "Game (Running)";
                GameEngine = new Engine(new GraphicDevice(glHost));
                GameEngine.Start();
                ReshTimer.Start();
            }
        }

        public void StopGame()
        {
            this.Text = "Game";
            runToolStripMenuItem.Enabled = true;
            runWindowedToolStripMenuItem.Enabled = true;
            stopToolStripMenuItem.Enabled = false;

            mainEditor.gameInspector.Enabled = false;
            ReshTimer.Stop();
            GameEngine.Stop();
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartGame(false);
        }

        private void runWindowedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartGame(true);
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopGame();
        }
    }
}
