using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Maker.Rise.Editor.Documents
{
    public partial class TextEditor : DockContent
    {
        string CurrentPath;
        bool saved = true;
        public TextEditor(string path, FastColoredTextBoxNS.Language language)
        {
            CurrentPath = path;
            InitializeComponent();
            fastColoredTextBox1.Language = language;
            fastColoredTextBox1.Text = File.ReadAllText(path);
            this.Text = $"{path.Split('\\').Last()}";
            saveToolStripMenuItem.Enabled = false;
        }

        private void fastColoredTextBox1_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            saved = false;
            saveToolStripMenuItem.Enabled = false;
            this.Text = $"{CurrentPath.Split('\\').Last()}*";
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saved = true;
            saveToolStripMenuItem.Enabled = false;
            this.Text = $"{CurrentPath.Split('\\').Last()}";
            File.WriteAllText(CurrentPath, fastColoredTextBox1.Text);
        }
    }
}
